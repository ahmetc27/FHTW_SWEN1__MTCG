using System.Net.Sockets;
using System.Text;

namespace MTCG;

public class Request
{
    public string Method { get; set; }
    public string Path {get; set;}
    public string Version { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public string Body { get; set; }
    public Request(TcpClient tcpClient)
    {
        var reader = new StreamReader(tcpClient.GetStream());
        
        // ----- 1. Read the HTTP-Request -----
        string? line;
            
        // 1.1 first line in HTTP contains the method, path and HTTP version
        line = reader.ReadLine();
        if (line == null)
        {
            throw new Exception("String invalid request");
        }
        string[] x = line.Split(" ");
        Method = x[0];
        Path = x[1];
        Version = x[2];
        
        // 1.2 read the HTTP-headers (in HTTP after the first line, until the empty line)
        var contentLength = 0; // we need the content_length later, to be able to read the HTTP-content
        Headers = new Dictionary<string, string>();
        while ((line = reader.ReadLine()) != null)
        {
            if (line == "")
            {
                break;  // empty line indicates the end of the HTTP-headers
            }

            // Parse the header
            var parts = line.Split(':');
            if (parts.Length < 2)
            {
                throw new Exception("Header path part invalid request");
            }
            Headers.Add(parts[0], parts[1]);
            if (parts.Length == 2 && parts[0] == "Content-Length")
            {
                contentLength = int.Parse(parts[1].Trim());
            }
        }
            
        // 1.3 read the body if existing
        if (contentLength > 0)
        {
            var data = new StringBuilder(200);
            char[] chars = new char[1024*4];
            int bytesReadTotal = 0;
            while (bytesReadTotal < contentLength)
            {
                var bytesRead = reader.Read(chars, 0, chars.Length);
                bytesReadTotal += bytesRead;
                if (bytesRead == 0)
                    break;
                data.Append(chars, 0, bytesRead);
            }
            Body = data.ToString();
        }
    }
}
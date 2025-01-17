using System.Net.Sockets;

namespace MTCG;

public class Response
{
    private StreamWriter Writer { get; set;}
    public Response(TcpClient tcpClient)
    {
        Writer = new StreamWriter(tcpClient.GetStream());
        // Writer.AutoFlush = true; // buffer is cleared immediately after each write operation
    }

    public void Ok()
    {
        Writer.WriteLine("HTTP/1.1 200 OK");
        Writer.Close();
        Console.WriteLine("OK");
    }

    public void NoContent()
    {
        Writer.WriteLine("HTTP/1.1 204 No Content");
        Writer.Close();
        Console.WriteLine("No Content");
    }

    public void BadRequest()
    {
        Writer.WriteLine("HTTP/1.1 400 Bad Request");
        Writer.Close();
        Console.WriteLine("Bad Request");
    }

    public void Forbidden()
    {
        Writer.WriteLine("HTTP/1.1 403 Forbidden");
        Writer.Close();
        Console.WriteLine("Forbidden");
    }
}
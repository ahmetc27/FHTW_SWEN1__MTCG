using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MTCG;

public class Program
{
    static void Main()
    {
        Server server = new Server();
        server.Run();
    }
}
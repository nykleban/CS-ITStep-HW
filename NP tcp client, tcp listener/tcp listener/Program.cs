using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcp_listener
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            TcpServer server = new TcpServer("127.0.0.1", 5000);
            await server.Start();
        }
    }
}

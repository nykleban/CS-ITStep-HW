using System.Net;
using System.Text;
using System.Net.Sockets;
using static System.Net.Mime.MediaTypeNames;

namespace NP_tcp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            server.Bind(endPoint);
            server.Listen(10);

            Console.WriteLine("Waiting for clients...");
            Socket client = server.Accept();
            Console.WriteLine($"Client {client.RemoteEndPoint} connected");


            byte[] buffer = new byte[1024];
            int receivedBytes = client.Receive(buffer);
            string data = System.Text.Encoding.UTF8.GetString(buffer, 0, receivedBytes);


            string time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"О {time} від {client.RemoteEndPoint} отримано рядок: {data}");

            string message = "Привіт, клієнт!";
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(msg);
            Console.ReadLine();
        }
    }
}

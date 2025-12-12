using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NP_tcp_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            client.Connect(endPoint);
            Console.WriteLine("Connected to server...");

            string msg = "Привіт, сервер!";
            byte[] msgData = System.Text.Encoding.UTF8.GetBytes(msg);
            client.Send(msgData);

            byte[] data = new byte[1024];
            int receivedBytes = client.Receive(data);
            string message = System.Text.Encoding.UTF8.GetString(data, 0, receivedBytes);
            string time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"О {time} від {client.RemoteEndPoint} отримано рядок: {message}");

        }
    }
}

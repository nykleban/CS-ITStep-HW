using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcp_task_2_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);
            Console.WriteLine("Connected to server...");
            while (true)
            {
                Console.Write("Enter 'date' or 'time': ");
                string msg = Console.ReadLine();
                byte[] msgData = Encoding.UTF8.GetBytes(msg);
                client.Send(msgData);

                byte[] data = new byte[1024];
                int receivedBytes = client.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, receivedBytes);
                string time = DateTime.Now.ToShortTimeString();
                Console.WriteLine($"О {time} від {client.RemoteEndPoint} отримано рядок:    {message}");
            }

        }
    }
}

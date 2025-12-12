using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcp_task_2_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            server.Bind(endPoint);
            server.Listen(10);
            Console.WriteLine("Waiting for users..");

            Socket client = server.Accept();
            while (true)
            {
                byte[] data = new byte[1024];
                int receivedBytes = client.Receive(data);
                string request = Encoding.UTF8.GetString(data, 0, receivedBytes);

                Console.WriteLine($"О {DateTime.Now.ToShortTimeString()} від {client.RemoteEndPoint} отримано запит: {request}");

                string response = "";
                switch (request.ToLower().Trim())
                {
                    case "date":
                        response = DateTime.Now.ToShortDateString();
                        break;
                    case "time":
                        response = DateTime.Now.ToShortTimeString();
                        break;
                    default:
                        response = "Unknown command";
                        break;
                }

                byte[] msg = Encoding.UTF8.GetBytes(response);
                client.Send(msg);

            }
                Console.ReadLine();
        }
    }
}
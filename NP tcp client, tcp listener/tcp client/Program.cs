using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            try
            {
                TcpClient client = new TcpClient();
                Console.WriteLine("Підключення до сервера...");
                client.Connect("127.0.0.1", 5000);
                if (client.Connected) Console.WriteLine("Успішно!");
                
                var stream = client.GetStream();

                Console.Write("Введіть ваше ім'я: ");
                string name = Console.ReadLine();
                byte[] nameBytes = Encoding.UTF8.GetBytes(name);
                stream.Write(nameBytes, 0, nameBytes.Length);


                while (true)
                {
                    Console.WriteLine("\n--- МЕНЮ ---");
                    Console.WriteLine("1 - отримати цитату");
                    Console.WriteLine("0 - вихід");
                    Console.Write("Ваш вибір: ");
                    string choice = Console.ReadLine();

                    byte[] choiceBytes = Encoding.UTF8.GetBytes(choice);
                    stream.Write(choiceBytes, 0, choiceBytes.Length);

                    if (choice == "0")
                    {
                        Console.WriteLine("Відключення...");
                        break;
                    }
                    else if (choice == "1")
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);

                        string quote = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        Console.ForegroundColor = ConsoleColor.Yellow; // подумав так буде прикольніше
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\nЦИТАТА: {quote}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Невідома команда, спробуйте ще раз.");
                    }
                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("Натисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}
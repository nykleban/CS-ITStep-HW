using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcp_listener
{
    internal class TcpServer
    {
        private readonly List<string> _quotes = new List<string>
        {
            "Код — це поезія машин.",
            "Працює — не чіпай.",
            "Сім разів відміряй, один раз натисни Enter.",
            "Все є об'єкт (крім value types).",
            "Рекурсія: див. 'Рекурсія'.",
            "Відлагодження — це мистецтво знаходити помилки, яких ти не бачив раніше.",
            "Програмування — це як написання книги, але якщо ти зробиш помилку на сторінці 126, весь роман не працюватиме.",
            "Алгоритми — це рецепти для комп'ютерів."
        };
        private readonly int _port;
        private readonly TcpListener listener;
        public TcpServer(string ipAddres, int port)
        {
            _port = port;
            IPAddress address = IPAddress.Parse(ipAddres);
            listener = new TcpListener(address, _port);
        }
        public async Task Start() { 
            listener.Start();
            Console.WriteLine($"Сервер запущений на порту {_port}. Очікування клієнтів...");
            try
            {
                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Task.Run(() => HandleClientAsync(client));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Server Error]: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }

        }

        public void HandleClientAsync(TcpClient client)
        {
            var sendedQuotes = new List<string>();
            string clientEndPoint = client.Client.RemoteEndPoint.ToString();
            DateTime clientConectionTime = DateTime.Now;
            Console.WriteLine($"Клієнт підключився: {clientEndPoint} о {clientConectionTime}");

            try
            {
                var stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string clientName = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                Console.WriteLine($"Ім'я клієнта: {clientName}");

                while (true)
                {
                    try
                    {
                        buffer = new byte[1024];
                        int len = stream.Read(buffer, 0, buffer.Length);
                        if (len == 0) break;

                        string request = Encoding.UTF8.GetString(buffer, 0, len).Trim();
                        if (request == "0")
                        {
                            break;
                        }
                        else if (request == "1")
                        {
                            var quote = GetRandomQuote();
                            byte[] quoteBytes = Encoding.UTF8.GetBytes(quote);
                            stream.Write(quoteBytes, 0, quoteBytes.Length);

                            Console.WriteLine($"Відправлено клієнту {clientName}: {quote}");
                            sendedQuotes.Add(quote);
                        }
                        else
                        {
                            Console.WriteLine($"Невідомий запит від {clientName}: {request}");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Client Handling Error]: {ex.Message}");
                    }
                }
            
            }
            catch (System.IO.IOException)
            {
                // спитав в гпт за помилку і він сказав що так можна робити
                // цей блок ловить саме натискання "Хрестика"
                Console.WriteLine($"[INFO] Клієнт {clientEndPoint} розірвав з'єднання примусово.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client Error]: {ex.Message}");
            }
            finally
            {
                PrintInfoAboutClient(clientEndPoint, clientConectionTime, sendedQuotes);
                Console.WriteLine($"Клієнт {clientEndPoint} відключився.");
                client.Close();
            }
        }
        private string GetRandomQuote()
        {
            Random rand = new Random();
            int index = rand.Next(_quotes.Count);
            return _quotes[index];
        }
        private void PrintInfoAboutClient(string clientEndPoint, DateTime start, List<string> history)
        {
            Console.WriteLine("--- --- --- --- ---");
            Console.WriteLine($"IP: ({clientEndPoint})");
            Console.WriteLine($"Початок: {start}");
            Console.WriteLine($"Кінець:  {DateTime.Now}");
            Console.WriteLine("Надіслані цитати:");
            Console.ForegroundColor = ConsoleColor.DarkGreen; // подумав так буде прикольніше
            Console.BackgroundColor = ConsoleColor.White;
            foreach (var q in history)
                Console.WriteLine($" - {q}");
            Console.ResetColor();
            Console.WriteLine("--- --- --- --- ---");
        }
    }
}

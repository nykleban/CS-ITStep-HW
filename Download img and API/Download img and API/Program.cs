using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Download_img_and_API
{
    internal class Program
    {
        static async Task DownloadImg(string url, string name, string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                string fullPath = Path.Combine(dir, name);
                System.IO.File.WriteAllBytes(fullPath, bytes);
            }
        }

        static async Task Task1()
        {
            try
            {
                Console.WriteLine(@"Написати додаток який дає можливість скачати фото за посиланням.
Користувач передає посилання на фото, шлях та назву файлу.
Програма зберігає фото за вказаним шляхом;
");
                Console.Write("Встав сюди посилання на фото, яке ти хочеш скачати: ");
                string url = Console.ReadLine().Trim();

                Console.Write("Введи назву для фото (з розширенням, напр. image.jpg): ");
                string name = Console.ReadLine().Trim();

                Console.Write("Введи шлях куди скачати це фото: ");
                string dir = Console.ReadLine().Trim();
                await DownloadImg(url, name, dir);

                Console.WriteLine("Виконано!!!");
                Console.WriteLine("Збережено сюди -> " + dir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        static async Task Task2()
        {
            Console.WriteLine(@"Що би ти хотів глянути? який з цих списків:
1 - posts
2 - comments
3 - albums
4 - photos
5 - todos
6 - users");

            Console.Write("Твій вибір: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                string url = @"https://jsonplaceholder.typicode.com/";

                switch (choice)
                {
                    case 1: url += "posts"; break;
                    case 2: url += "comments"; break;
                    case 3: url += "albums"; break;
                    case 4: url += "photos"; break;
                    case 5: url += "todos"; break;
                    case 6: url += "users"; break;
                    default:
                        Console.WriteLine("Невірний номер, вибери від 1 до 6.");
                        return;
                }

                Console.WriteLine($"Завантаження ...");

                try
                {
                    using (var client = new HttpClient())
                    {
                        string response = await client.GetStringAsync(url);
                        string simpleText =  response.Replace("},", "------------------------------").Replace("{", " ").Replace("{", " ").Replace("[", " ").Replace("]", " ").Replace("}", " ");
                        Console.WriteLine(simpleText);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("А якби ввів число, було би все добре :) ");
            }
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //РОЗКОМЕНТУЙТЕ ТУТ
            //await Task1();
            //await Task2();

            Console.ReadKey();
        }
    }
}
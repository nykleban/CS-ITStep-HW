namespace SMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("----- Відправка Email -----");
            try
            {
                EmailService service = new EmailService();
                if (service.getEmail() == "" || service.getPassword() == "")
                {
                    Console.WriteLine("спочатку у класі EmailService.cs треба ввести свої дані 🙃");
                    return;
                }

                Console.Write("Введіть email отримувача: ");
                string toEmail = Console.ReadLine();

                Console.Write("Введіть тему листа: ");
                string subject = Console.ReadLine();

                Console.Write("Введіть повний шлях до файлу з текстом (txt або html): ");
                string bodyPath = Console.ReadLine().Trim('"').Trim(); 


                string attachPath = null;
                Console.Write("Бажаєте прикріпити файл? ( y / n ): ");
                string wantAttach = Console.ReadLine();

                if (wantAttach?.ToLower() == "y" || wantAttach?.ToLower() == "yes")
                {
                    Console.Write("Введіть повний шлях до файлу вкладення: ");
                    attachPath = Console.ReadLine().Trim('"');
                }

                Console.Write("\nВідправка...");
                for(int i = 0; i < 6; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(".");
                }
                Console.WriteLine();
               
                service.SendEmail(toEmail, subject, bodyPath, attachPath);

                Console.WriteLine("Лист успішно відправлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПомилка: {ex.Message}");
            }

            Console.WriteLine("\nEnter any key to leave........");
            Console.ReadKey();
        }
    }
}

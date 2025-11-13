using System.Text;
using System;


namespace String_tasks_5_7
{
    internal class Program
    {
        static void Task5()
        {
            Console.WriteLine("Завдання 5");
            Console.WriteLine("Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.\r\n");
            string input = "Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi";
            Console.WriteLine("Текст:");
            Console.WriteLine(input);
            Console.Write("Введи номер слова якого ти хочеш вивести: ");
            int idx = int.Parse(Console.ReadLine());

            string[] words = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try { 
            string result = words[idx-1];
            Console.WriteLine("Твоє слово:");
            Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }
        static void Task6()
        {
            Console.WriteLine("Завдання 6");
            Console.WriteLine(@"Дано рядок слів, розділених пробілами. 
Між словами може бути кілька пробілів, на початку і вкінці 
рядка також можуть бути пробіли. Ви повинні змінити рядок так, 
щоб на початку і вкінці пробілів не було,
а слова були розділені поодиноким символом ""*"" (зірочка).");
            string input = "   це    приклад    рядка   для   завдання     шість    ";
            Console.WriteLine("Текст:");
            Console.WriteLine($"|{input}|");
            string trimmedInput = input.Trim();
            string[] words = trimmedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join("*", words);
            Console.WriteLine($"Результат: {result}");

        }
        static void Task7()
        {
            Console.WriteLine("Завдання 7");
            Console.WriteLine(@"Користувач вводить слова, поки не 
буде введено слово з символом крапки вкінці. Сформувати
з введених слів рядок, розділивши їх комою з пробілом.");

            string result = "";

            while (true)
            {
                Console.Write("Введи слово: ");
                string input = Console.ReadLine();

                if (input.EndsWith("."))
                {
                    result += input;
                    break;
                }

                result += input + ", ";
            }

            Console.WriteLine("Результат:");
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Task5();
            Task6();
            Task7();
        }
    }
}

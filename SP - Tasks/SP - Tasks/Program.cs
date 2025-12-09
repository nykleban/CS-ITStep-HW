
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SP___Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("--- Завдання 1 Відображення часу трьома способами ---");
            Task1();
            Console.WriteLine("\nНатисніть Enter для переходу далі...");
            Console.ReadLine();
            Console.WriteLine("\n--- Завдання 2 Прості числа 0-1000 ---");
            Task2();
            Console.WriteLine("\nНатисніть Enter для переходу далі...");
            Console.ReadLine();
            Console.WriteLine("\n--- Завдання 3 Прості числа (діапазон та кількість) ---");
            Task3();
            Console.WriteLine("\nНатисніть Enter для переходу далі...");
            Console.ReadLine();
            Console.WriteLine("\n--- Завдання 4 Статистика масиву через масив Task ---");
            Task4();
            Console.WriteLine("\nНатисніть Enter для переходу далі...");
            Console.ReadLine();
            Console.WriteLine("\n--- Завдання 5: Continuation Tasks (Дублі -> Сортування -> Пошук) ---");
            Task5();
            Console.WriteLine("\nКІНЕЦЬ :)");
            Console.ReadLine();
        }

        // task 1
        static void Task1()
        {
            Action showTime = () => Console.WriteLine($"Поточний час: {DateTime.Now:HH:mm:ss} (Потік: {Task.CurrentId})");

            // Start
            Task t1 = new Task(showTime);
            t1.Start();

            // Task.Factory.StartNew
            Task t2 = Task.Factory.StartNew(showTime);

            // Task.Run
            Task t3 = Task.Run(showTime);            
            Task.WaitAll(t1, t2, t3);
        }

        // task 2
        static void Task2()
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i <= 1000; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine(); 
            });

            task.Wait();
        }

        // task 3
        static void Task3()
        {
            int start = 100;
            int end = 500;

            Console.WriteLine($"Шукаємо прості числа від {start} до {end}...");


            Task<int> task = Task.Run(() =>
            {
                int count = 0;
                for (int i = start; i <= end; i++)
                {
                    if (IsPrime(i))
                    {
                        count++;
                    }
                }
                return count;
            });


            Console.WriteLine($"Кількість простих чисел у діапазоні = {task.Result}");
        }

        // функція для перевірки простого числа
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // task 4
        static void Task4()
        {
            int[] numbers = new int[20];
            Random rand = new Random();
            for (int i = 0; i < numbers.Length; i++) 
                numbers[i] = rand.Next(1, 100);

            Console.WriteLine("Масив: " + string.Join(", ", numbers));


            Task[] tasks = new Task[4];

            tasks[0] = Task.Run(() => Console.WriteLine($"Мінімум: {numbers.Min()}"));
            tasks[1] = Task.Run(() => Console.WriteLine($"Максимум: {numbers.Max()}"));
            tasks[2] = Task.Run(() => Console.WriteLine($"Середнє: {numbers.Average():F2}"));
            tasks[3] = Task.Run(() => Console.WriteLine($"Сума: {numbers.Sum()}"));

            Task.WaitAll(tasks);
        }

        // task 5
        static void Task5()
        {
            int[] data = { 5, 1, 8, 5, 2, 8, 9, 1, 10, 3 };
            int searchValue = 8;

            Console.WriteLine($"Початковий масив: {string.Join(", ", data)}");
            Console.WriteLine($"Шукаємо число: {searchValue}");
            Task<int> singleTask = Task.Run(() =>
            {       
                int[] data2 = data.Distinct().ToArray();
                Array.Sort(data2);
                Console.WriteLine($"Масив після сортування та видалення дублікатів: {string.Join(", ", data2)}");
                Console.WriteLine("Бінарний пошук...");
                return Array.BinarySearch(data2, searchValue);
            });
            Console.WriteLine($"Результат пошуку (індекс): {singleTask.Result}");


            try
            {
                Console.WriteLine("--- БІНАРНИЙ ПОШУК ---");
                int index = singleTask.Result;
                if (index >= 0)
                    Console.WriteLine($"Значення {searchValue} знайдено під індексом {index} (у відсортованому масиві без дублікатів).");
                else
                    Console.WriteLine($"Значення {searchValue} не знайдено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex}");
            }
        }
    }
}
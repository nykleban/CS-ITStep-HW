using System;
using System.IO;
using System.Threading;
using System.Text;

namespace ThreadTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("=== Многопоточність. Варіанти завдань ===");
                Console.WriteLine("1 - Завдання 1 (потік виводить числа 0..50)");
                Console.WriteLine("2 - Завдання 2 (діапазон задає користувач)");
                Console.WriteLine("3 - Завдання 3 (кілька потоків + діапазон)");
                Console.WriteLine("4 - Завдання 4 і 5 (100 чисел, min/max/avg + файл)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4And5();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        // Завдання 1:
        // Створити потік, який виводить числа від 0 до 50

        static void Task1()
        {
            Thread thread = new Thread(() => PrintNumbers(0, 50));
            thread.Start();
            thread.Join(); // чекаємо завершення потоку
        }


        // Завдання 2:
        // Користувач вводить початок і кінець діапазону
        // Потік виводить числа в цьому діапазоні
        static void Task2()
        {
            int s = -10000;
            int e = -10000;
            Console.Write("Введіть початок діапазону: ");
            try
            {
                int start = int.Parse(Console.ReadLine()!);
                s = start;
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                return;
            }

            Console.Write("Введіть кінець діапазону: ");
            try
            {
                int end = int.Parse(Console.ReadLine()!);
                e = end;
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                return;
            }

            if (e != -10000 && s != -10000)
            {
                Thread thread = new Thread(() => PrintNumbers(s, e));
                thread.Start();
                thread.Join();
            }
            else
            {
                Console.WriteLine("Некоректне введення діапазону.");
            }
        }

        // Завдання 3:
        // Користувач задає кількість потоків + діапазон
        // Кожен потік виводить числа в цьому діапазоні
        
        static void Task3()
        {
            int threadCount = 0;
            try
            {
                Console.Write("Введіть кількість потоків: ");
                threadCount = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                return;

            }
            int s = -10000;
            int e = -10000;
            Console.Write("Введіть початок діапазону: ");
            try
            {
                int start = int.Parse(Console.ReadLine()!);
                s = start;
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                return;
            }

            Console.Write("Введіть кінець діапазону: ");
            try
            {
                int end = int.Parse(Console.ReadLine()!);
                e = end;
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
                return;
            }


            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int localIndex = i;
                threads[i] = new Thread(() => {
                    Console.WriteLine($"--- Потік #{localIndex + 1}, ID = {Thread.CurrentThread.ManagedThreadId} ---");
                    PrintNumbers(s, e);
                });

                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }
         //Завдання 4:
         //Згенерувати масив із 10000 чисел.(я взяв на 100)
         //За допомогою потоків знайти min, max, середнє.
         //
         //Завдання 5:
         //Окремий потік записує набір чисел та результати в файл.

        static void Task4And5()
        {
            const int N = 100;
            int[] numbers = new int[N];
            Random rand = new Random();

            for (int i = 0; i < N; i++)
            {
                numbers[i] = rand.Next(0, 1000);
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            double avg = 0;

            Thread tMin = new Thread(() => {
                int localMin = int.MaxValue;
                foreach (int n in numbers)
                {
                    if (n < localMin) localMin = n;
                }
                min = localMin;
                Console.WriteLine($"Мінімум обчислено в потоці {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread tMax = new Thread(() =>
            {
                int localMax = int.MinValue;
                foreach (int n in numbers)
                {
                    if (n > localMax) localMax = n;
                }
                max = localMax;
                Console.WriteLine($"Максимум обчислено в потоці {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread tAvg = new Thread(() =>
            {
                long sum = 0;
                foreach (int n in numbers)
                {
                    sum += n;
                }
                avg = sum / (double)numbers.Length;
                Console.WriteLine($"Середнє обчислено в потоці {Thread.CurrentThread.ManagedThreadId}");
            });

            tMin.Start();
            tMax.Start();
            tAvg.Start();

            tMin.Join();
            tMax.Join();
            tAvg.Join();

            Console.WriteLine();
            Console.WriteLine($"Мінімум: {min}");
            Console.WriteLine($"Максимум: {max}");
            Console.WriteLine($"Середнє: {avg:F2}");

            // Завдання 5 – запис у файл в окремому потоці поміг чатгпт
            Thread tWrite = new Thread(() =>

            {
                string fileName = "results.txt";
                WriteResultsToFile(fileName, numbers, min, max, avg);
                Console.WriteLine($"Дані записано до файлу \"{fileName}\" у потоці {Thread.CurrentThread.ManagedThreadId}");
            });

            tWrite.Start();
            tWrite.Join();
        }

        // Допоміжні методи
        //цей написаний мною
        static void PrintNumbers(int start, int end)
        {
            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(10);
            }
        }

        //поміг чатгпт
        static void WriteResultsToFile(string fileName, int[] numbers, int min, int max, double avg)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Набір чисел (10000 елементів):");
                for (int i = 0; i < numbers.Length; i++)
                {
                    sw.Write(numbers[i]);
                    sw.Write(' ');

                    if ((i + 1) % 50 == 0)
                        sw.WriteLine();
                }

                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine($"Мінімум: {min}");
                sw.WriteLine($"Максимум: {max}");
                sw.WriteLine($"Середнє: {avg:F2}");
            }
        }
    }
}

using System;

namespace Struct__ref__out__params
{
    internal class Program
    {
        public class Worker
        {
            // ви казали про проперті, то я загуглив що можна не писати змінні окремо, а просто зразу проперті
            public string Surname { get; set; }
            public char NameInitial { get; set; }
            public char PobatkoviInitial { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
            public DateTime HireDate { get; set; }

            public Worker(string surname, char nameInitial, char pobatkoviInitial,
                          int age, double salary, DateTime hireDate)
            {
                if (string.IsNullOrWhiteSpace(surname))
                    throw new ArgumentException("Прізвище не може бути порожнім");

                if (!char.IsLetter(nameInitial) || !char.IsLetter(pobatkoviInitial))
                    throw new FormatException("Ініціали повинні бути літерами");

                if (age <= 0 || age > 65)
                    throw new ArgumentOutOfRangeException("Вік введено некоректно");

                if (salary < 0)
                    throw new ArgumentOutOfRangeException("Зарплата не може бути від’ємною");

                Surname = surname;
                NameInitial = nameInitial;
                PobatkoviInitial = pobatkoviInitial;
                Age = age;
                Salary = salary;
                HireDate = hireDate;
            }

            public TimeSpan GetExperience()
            {
                return DateTime.Now - HireDate;
            }

            public override string ToString()
            {
                return @$"--- {Surname} {NameInitial}.{PobatkoviInitial}. ---
Вік: {Age}, Зарплата: {Salary}
Дата прийняття на роботу: {HireDate.ToShortDateString()}";
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Worker[] workers = new Worker[5];

            Console.WriteLine("=== Введення даних працівників ===");

            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine($"\nПрацівник #{i + 1}");

                string surname;
                while (true)
                {
                    try
                    {
                        Console.Write("Прізвище: ");
                        surname = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(surname))
                            throw new Exception("Прізвище не може бути порожнім");

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                char initName;
                while (true)
                {
                    try
                    {
                        Console.Write("Ініціал імені (одна літера): ");
                        string input = Console.ReadLine();

                        if (input.Length != 1 || !char.IsLetter(input[0]))
                            throw new Exception("Потрібно ввести одну літеру");

                        initName = input[0];
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                char initFather;
                while (true)
                {
                    try
                    {
                        Console.Write("Ініціал по-батькові (одна літера): ");
                        string input = Console.ReadLine();

                        if (input.Length != 1 || !char.IsLetter(input[0]))
                            throw new Exception("Потрібно ввести одну літеру");

                        initFather = input[0];
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                int age;
                while (true)
                {
                    try
                    {
                        Console.Write("Вік: ");
                        if (!int.TryParse(Console.ReadLine(), out age) || age <= 0 || age > 100)
                            throw new Exception("Вік повинен бути числом від 1 до 100");

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                double salary;
                while (true)
                {
                    try
                    {
                        Console.Write("Зарплата: ");
                        if (!double.TryParse(Console.ReadLine(), out salary) || salary < 0)
                            throw new Exception("Зарплата повинна бути невід’ємним числом");

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                DateTime hireDate;
                while (true)
                {
                    try
                    {
                        Console.Write("Дата прийняття (рррр-мм-дд): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out hireDate))
                            throw new Exception("Неправильний формат дати");

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }

                workers[i] = new Worker(surname, initName, initFather, age, salary, hireDate);
            }

            //для тесту можна розкоментувати цей блок і закоментувати ввід з клавіатури

            //workers[0] = new Worker("Іваненко", 'І', 'П', 30, 5000, new DateTime(2015, 6, 1));
            //workers[1] = new Worker("Петров", 'П', 'С', 45, 7000, new DateTime(2010, 3, 15));
            //workers[2] = new Worker("Сидоренко", 'С', 'В', 28, 4500, new DateTime(2018, 11, 20));
            //workers[3] = new Worker("Коваленко", 'М', 'М', 50, 8000, new DateTime(2003, 1, 10));
            //workers[4] = new Worker("Мельник", 'М', 'І', 35, 6000, new DateTime(2012, 8, 5));



            Array.Sort(workers, (a, b) => a.Surname.CompareTo(b.Surname));
            Console.WriteLine("Готово");

            //3
            Console.WriteLine("1.вивід на екран прізвища працівника, стаж роботи якого перевищує введене з клавіатури значення");
            Console.Write("Введіть кількість років стажу: ");
            try
            {
                int years = int.Parse(Console.ReadLine()!);
                foreach (var worker in workers)
                {
                    if (worker.GetExperience().TotalDays / 365 > years)
                        Console.WriteLine(worker.Surname);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}

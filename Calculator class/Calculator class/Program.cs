using System;
using System.Text;
namespace Calculator_class
{
    public class Program
    {
        public class Calculator
        {
            private double a;
            private double b;
            public double A { get; set; }
            public double B { get; set; }
            public double Add(double a, double b)
            {
                return a + b;
            }
            public double Subtract(double a, double b)
            {
                return a - b;
            }
            public double Multiply(double a, double b)
            {
                return a * b;
            }
            public double Divide(double a, double b)
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero.");
                }
                return a / b;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Вас вітає калькулятор Назара ---");
            Calculator calculator = new Calculator();

            double a;
            while (true)
            {
                try
                {
                    Console.Write("Введіть перше число: ");
                    a = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }

          
            double b;
            while (true)
            {
                try
                {
                    Console.Write("Введіть друге число: ");
                    b = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }

            int operation;
            while (true)
            {
                try
                {
                    Console.WriteLine(@$"Введіть номер операції яку хочете виконати:
1 - Сума
2 - Віднімання
3 - Множення
4 - Ділення {a} / {b}
5 - Ділення {b} / {a}");

                    operation = Convert.ToInt32(Console.ReadLine());

                    if (operation < 1 || operation > 5)
                        throw new Exception("Операції з таким номером не існує.");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
            double result = 0;

            while (true)
            {
                try
                {
                    switch (operation)
                    {
                        case 1:
                            result = calculator.Add(a, b);
                            break;

                        case 2:
                            result = calculator.Subtract(a, b);
                            break;

                        case 3:
                            result = calculator.Multiply(a, b);
                            break;

                        case 4:
                            if (b == 0)
                                throw new Exception("Не можна ділити на нуль!");
                            result = calculator.Divide(a, b);
                            break;

                        case 5:
                            if (a == 0)
                                throw new Exception("Не можна ділити на нуль!");
                            result = calculator.Divide(b, a);
                            break;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                    return; 
                }
            }

            Console.WriteLine($"Результат: {result}");
        }


    }
}

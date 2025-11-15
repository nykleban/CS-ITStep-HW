using System;
using System.Text;

namespace Exceptions__namespace
{
    internal class Program
    {
        static void Task1()
        {
            Console.WriteLine(@"Користувач вводить до рядка з клавіатури набір сим-
волів від 0-9. Необхідно перетворити рядок на число цілого типу. 
Передбачити випадок виходу за межі діапазону,
який визначається типом int. Використовуйте механізм
виключень.");
            Console.Write("Введіть рядок з цифр (0-9): ");
            string input = Console.ReadLine();
            while (true)
            {
                try
                {
                    int result = int.Parse(input!);
                    if (result < 0123456789 || result > 9876543210)
                    {
                        throw new IndexOutOfRangeException("Число введене не вірно(вихід за межі масиву завдання)");
                    }

                    Console.WriteLine($"Перетворене число: {result}");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: рядок має містити тільки цифри від 0 до 9");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Помилка: число виходить за межі типу int (-2147483648 ... 2147483647).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }

        // Task 2
            public struct PIB
            {
                string name;
                string surname;
                string pobatkovi;
                public PIB(string name, string surname, string pobatkovi)
                {
                    this.name = name;
                    this.surname = surname;
                    this.pobatkovi = pobatkovi;
                }
                public override string ToString() {
                return $"{surname} {name} {pobatkovi}";
                }
            }
        public class CreditCard
        {
            private string number;
            private PIB pib;
            private string cvc;
            private DateTime expirationDate;

            void ValidateNumber(string number)
            {
                if (number.Length != 16)
                {
                    throw new ArgumentException("Номер картки повинен містити 16 цифр.");
                }
                try
                {
                    long res = long.Parse(number);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Номер картки повинен містити тільки цифри.");
                }
            }
            public CreditCard(string number, PIB pib, string cvc, DateTime expirationDate)
            {
                ValidateNumber(number);
                this.number = number;
                this.pib = pib;
                this.cvc = cvc;
                this.expirationDate = expirationDate;
            }
            public override string ToString() {
                return @$"          --- {this.pib} ---
    Номер карти:            {this.number}
    Дата завершення карти:  {this.expirationDate.ToString("dd-MM-yyyy")}
    CVC:                    {this.cvc}";                   
            }
        }
        static void Task2() { 
            Console.WriteLine(@"Створіть клас «Кредитна картка». Вам необхідно зберіга-
ти інформацію про номер картки, ПІБ власника, CVC, дату
завершення роботи картки і т.д. Передбачити механізми
ініціалізації полів класу. Якщо значення для ініціалізації
неправильне, генеруйте виняток.");
                try {

                CreditCard creditCard = new CreditCard("1234567890123456", new PIB("Іван", "Іванов", "Іванович"), "123", new DateTime(2025, 12, 31));
                Console.WriteLine(creditCard);
            }
                catch  (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
        
        }


        // 3
        public static void Task3()
        {
            Console.WriteLine(@"Користувач вводить математичний вираз,
наприклад 3*2*1*4.
Можна вводити тільки цілі числа та оператор *");

            Console.Write("Введіть вираз: ");
            string input = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new FormatException("Вираз не може бути порожнім.");

                string[] parts = input.Split('*', StringSplitOptions.RemoveEmptyEntries);

                int[] numbers = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    numbers[i] = int.Parse(parts[i]);
                }
                int result = 1;
                foreach (int n in numbers)
                    result *= n;

                Console.WriteLine($"Відповідь: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Помилка: одне з чисел виходить за межі типу int.");
            }


            catch (Exception ex)
            {
                Console.WriteLine("Невідома помилка: " + ex.Message);
            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //Task1();
            //Task2();
            Task3();
        }
    }
}

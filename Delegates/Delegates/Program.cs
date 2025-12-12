using System;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

namespace Delegates
{
    internal class Program
    {

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        static bool IsFibonacci(BigInteger num)
        {
            if (num < 0) return false;
            return IsPerfectSquare(5 * num * num + 4) || IsPerfectSquare(5 * num * num - 4);
        }

        static bool IsPerfectSquare(BigInteger x)
        {
            if (x < 0) return false;
            BigInteger root = (BigInteger)Math.Sqrt((double)x);
            return root * root == x || (root + 1) * (root + 1) == x;
        }

        static int[] GetFromArray(int[] arr, Predicate<int> predicate)
        {
            List<int> resultList = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (predicate(arr[i]))
                {
                    resultList.Add(arr[i]);
                }
            }
            return resultList.ToArray();
        }

        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }

        delegate int GetCountDelegate(int[] arr, int min, int max);
        static void Task1()
        {
            Console.WriteLine("--- Task 1 ---");
            int[] array = { 12, 214, -5, 47, 12, 07, 8, 5, 3, -1412, 34, -78, 13, 5, 33, 1 };
            Console.WriteLine("Array:");
            PrintArray(array);
            Console.Write("Even: ");
            int[] even = GetFromArray(array, x => x % 2 == 0);
            PrintArray(even);

            Console.Write("Odd:  ");
            int[] odd = GetFromArray(array, x => x % 2 != 0);
            PrintArray(odd);

            Console.Write("Prime: ");
            int[] prime = GetFromArray(array, IsPrime);
            PrintArray(prime);

            Console.Write("Fibonacci: ");
            int[] fibonacci = GetFromArray(array, x => IsFibonacci(x));
            PrintArray(fibonacci);
            Console.WriteLine("--- ------ ---\n");
        }
        static void Task2()
        {
            Console.WriteLine("--- Task 2 ---");
            Action<DateTime> timeNow = (time) =>
            {
                Console.WriteLine($"Current time: {time.Hour}:{time.Minute}:{time.Second}");
            };

            Action<DateTime> dateNow = (time) =>
            {
                Console.WriteLine($"Current date: {time.Date.ToShortDateString()}");
            };
            Action<DateTime> dayOfWeak = (time) =>
            {
                Console.WriteLine($"Day of week: {time.DayOfWeek}");
            };
            Action<DateTime> dateAndTimeNow = (time) =>
            {
                timeNow(time);
                dateNow(time);
                dayOfWeak(time);
            };

            dateAndTimeNow(DateTime.Now);
            Func<Rectangle, double> rectangleArea = (rect) => rect.GetArea();
            Func<Triangle, double> triangleArea = (tri) => tri.GetArea();
            double area = rectangleArea(new Rectangle(4.5, 3.5));
            Console.WriteLine($"Triangle area = {area:F2}. Sides = 4.5, 3.5, 5");
            area = triangleArea(new Triangle(4.5, 3.5, 5));
            Console.WriteLine($"Rectangle area = {area:F2}. Sides = 4.5, 3.5");
            Console.WriteLine("--- ------ ---\n");
        }

        static void Task3()
        {
            Console.WriteLine("--- Task 3 ---");
            string[] colors = { "red", "orange", "yellow", "green", "cyan", "blue", "sky", "purple", "black" };
            Func<string, string> ColorToRGB = (color) =>
            {
                switch (color.ToLower().Trim())
                {
                    case "red":
                        return "255, 0, 0";
                    case "orange":
                        return "255, 165, 0";
                    case "yellow":
                        return "255, 255, 0";
                    case "green":
                        return "0, 128, 0";
                    case "cyan":
                        return "0, 191, 255";

                    case "blue":
                    case "sky":
                        return "0, 0, 255";

                    case "purple":
                        return "128, 0, 128";
                    default:
                        return null;
                }


            };
            foreach (var cl in colors)
            {
                string rgb = ColorToRGB(cl);
                if (rgb != null)
                {
                    Console.WriteLine($"Color |{cl}| - {rgb}");
                }
                else
                {
                    Console.WriteLine($"Color |{cl}| is not recognized.");
                }
            }
            ;
            Console.WriteLine("--- ------ ---\n");
        }
        static void Task4()
        {
            Console.WriteLine("--- Task 4 ---");
            int[] data = { 1, 24, 3, -3, 5, 6, 5, 7, -54, 6, 345, 34, 523, 5, -324, 6, 47, 7, 24, -5, 5, 234, 34, 23, 423, -52, 4356, -34, 523, 413, 439, 86, 865, 4 };
            GetCountDelegate getCount = (arr, min, max) =>
            {
                int count = 0;
                foreach (var item in arr)
                {
                    if (item >= min && item <= max)
                    {
                        count++;
                    }
                }
                return count;
            };
            Console.WriteLine("Array:");
            PrintArray(data);
            int countInRange = getCount(data, 0, 300);
            Console.WriteLine($"Count of arrays elems between 0 and 300 = {countInRange}");
            countInRange = getCount(data, -50, 50);
            Console.WriteLine($"Count of arrays elems between -50 and 50 = {countInRange}");

            Console.WriteLine("--- ------ ---\n");
        }
        static void Task5()
        {
            Console.WriteLine("--- Task 5 ---");
            Func<string, string, string> isInText = (word, text) =>
            {
                if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word))
                    return default;
                char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string wordLower = word.ToLower();
                int count = 0;
                foreach (string w in words)
                    if (w.ToLower().Equals(wordLower)) count++;
                if (count > 0)
                    return $"Word |{word}| founded {count} times";
                else
                    return $"Word |{word}| dont exist in text";
            };
            string sampleText = "Lorem ipsum dolor sit amet, consectetur uT adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            Console.WriteLine(sampleText);
            Console.WriteLine(isInText("ut", sampleText));
            Console.WriteLine("--- ------ ---\n");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
    }
}
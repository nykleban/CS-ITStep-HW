using System;

namespace _4_6_tasks
{
    internal class Program
    {
        static void Fibonachi(int end)
        {
            int first = 0;
            int second = 1;

            while (first <= end)
            {
                Console.Write(first + " ");
                int next = first + second;
                first = second;
                second = next;
            }
        }
        static void PiramidNumberValue(int start, int end)
        {
            if(start > end) {
               int temp = start;
                start = end;
                end = temp;
            }
            for (int i = start; i <= end; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        static void LineBySymbol(int lenght, char symbol = '+', bool horizontael = true) { 
            for (int i = 0; i < lenght; i++) {
                Console.Write(symbol);
                if (!horizontael) {
                    Console.WriteLine();
                }
            }

        }
            static void Main(string[] args)
        {
            //task 4
            while (true) {
                try
                {
                    Console.Write("Enter number:");
                    int number = int.Parse(Console.ReadLine());
                    Fibonachi(number);
                    break;
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            //task 5
            while (true) {
                try
                {
                    Console.Write("Enter start:");
                    int start = int.Parse(Console.ReadLine());
                    Console.Write("Enter end:");
                    int end = int.Parse(Console.ReadLine());
                    PiramidNumberValue(start, end);
                    break;
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            // task 6

            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                try
                {
                    Console.Write("Enter lenght of line:");
                    int lenght = int.Parse(Console.ReadLine());
                    Console.Write("Enter symbol for line:");
                    char symbol = Convert.ToChar(Console.ReadLine());
                    
                    Console.Write("Do you want horizontal line?? (y - yes, n - no) ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "n")
                    {
                        LineBySymbol(lenght, symbol, false);
                    }
                    else if (answer == "y")
                    {
                        LineBySymbol(lenght, symbol);
                        break;
                    }
                    else { throw new Exception(""); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
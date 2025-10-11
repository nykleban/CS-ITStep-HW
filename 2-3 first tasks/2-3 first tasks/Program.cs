namespace _2_3_first_tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 2
            Console.WriteLine("Enter 5 numbers:");
            int sum = 0;
            int arrSize = 5;
            int[] numbers = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                try
                {
                    Console.Write($"Number {i + 1}: ");
                    numbers[i] = int.Parse(Console.ReadLine());
                    sum += numbers[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid integer. Error: {ex.Message}");
                    i--;
                    continue;
                }
            }

            int min = numbers.Min();
            int max = numbers.Max();
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Sum: {sum}");
            // Task 3
            while (true) { 
                try
            {
                Console.Write("Enter a six-char number : ");
                string str = Console.ReadLine();
                    if (str.Length != 6 )
                    {
                       throw new Exception("The number must be exactly six characters long.");
                    }
                int number = int.Parse(str);
                string reversedStr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedStr += str[i];
            }
            Console.Write($"Reverse number : {reversedStr} ");
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input. Please enter a valid integer. Error: {ex.Message}");
                    continue;
            }
            }
        }
    }
}

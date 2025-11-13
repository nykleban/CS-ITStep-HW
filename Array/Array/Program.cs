using System;
using System.Text;

namespace Array
{
    internal class Program
    {
        static void Task1()
        {
            // Створіть додаток, який відображає кількість парних,
            // непарних, унікальних елементів масиву.
            Console.WriteLine("Завдання 1");
            int[] array = { 1, 2, 3, 4, 5, 4, 5, 4, 2, 6, 7, 8, 9, 10 };

            int countEven = 0;
            int countOdd = 0;
            int uniqueCount = 0;

            Console.WriteLine("Елементи масиву:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");

                if (array[i] % 2 == 0) countEven++;
                else countOdd++;

                bool isUnique = true;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique) uniqueCount++;
            }

            Console.WriteLine();
            Console.WriteLine($"Кількість парних = {countEven}");
            Console.WriteLine($"Кількість непарних = {countOdd}");
            Console.WriteLine($"Кількість унікальних = {uniqueCount}\n");
        }

        static void Task2()
        {
            // Створіть додаток, який відображає кількість значень у
            // масиві менше заданого параметра користувачем.
            Console.WriteLine("Завдання 2");

            int[] array2 = { 1, 21, 3, 4, 5, 6, 27, 8, 9, 10, 11, 122, 13, 14, 15, 16, 166 };

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Введи число і я покажу всі елементи масиву які менші за нього:");
            int number = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i] < number)
                {
                    Console.Write(array2[i] + " ");
                }
            }

            Console.WriteLine("\n");
        }

        static void Task3()
        {
            // Оголосити A (5 елементів) і B (3x4)
            // Заповнити А з клавіатури, B — випадковими.
            // Вивести A в один рядок, B як матрицю.
            // Знайти max, min, суму, добуток, суму парних A, суму непарних стовпців B.
            Console.WriteLine("Завдання 3");

            int[] A = new int[5];
            int[,] B = new int[3, 4];

            Console.WriteLine("Enter 5 elements for array A:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine()!);
            }

            Console.WriteLine("A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }

            Console.WriteLine("\n\nB:");
            Random random = new Random();

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next(1, 10);
                    Console.Write($"{B[i, j]}\t");
                }
                Console.WriteLine();
            }

            int max = A[0];
            int min = A[0];
            long sum = 0;
            long product = 1;
            int sumEvenA = 0;
            int sumOddColumnsB = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > max) max = A[i];
                if (A[i] < min) min = A[i];
                sum += A[i];
                product *= A[i];
                if (A[i] % 2 == 0) sumEvenA += A[i];
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    int val = B[i, j];

                    if (val > max) max = val;
                    if (val < min) min = val;

                    sum += val;
                    product *= val;

                    if (j % 2 == 1)
                        sumOddColumnsB += val;
                }
            }

            Console.WriteLine($"\nЗагальний max = {max}");
            Console.WriteLine($"Загальний min = {min}");
            Console.WriteLine($"Сума всіх елементів = {sum}");
            Console.WriteLine($"Добуток всіх елементів = {product}");
            Console.WriteLine($"Сума парних елементів A = {sumEvenA}");
            Console.WriteLine($"Сума непарних стовпців B = {sumOddColumnsB}\n");
        }

        static void Task4()
        {
            // Дано масив 5×5. Визначити суму елементів між мінімальним і максимальним.
            Console.WriteLine("Завдання 4");

            int[,] array4 = new int[5, 5];
            Random random = new Random();

            int min = int.MaxValue;
            int max = int.MinValue;
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 0; i < array4.GetLength(0); i++)
            {
                for (int j = 0; j < array4.GetLength(1); j++)
                {
                    array4[i, j] = random.Next(-100, 101);
                    int index = i * 5 + j;

                    if (array4[i, j] < min)
                    {
                        min = array4[i, j];
                        minIndex = index;
                    }
                    if (array4[i, j] > max)
                    {
                        max = array4[i, j];
                        maxIndex = index;
                    }

                    Console.Write(array4[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            int sum = 0;
            for (int k = start + 1; k < end; k++)
            {
                int i = k / 5;
                int j = k % 5;
                sum += array4[i, j];
            }

            Console.WriteLine($"Сума між мінімальним та максимальним елементами = {sum}\n");
        }

        static void Task5()
        {
            // Визначити кількість елементів в масиві, що відрізняються від мінімального на 5.
            Console.WriteLine("Завдання 5");

            int[] array5 = { 10, 15, 20, 25, 30, 5, 0, -5, -10, 15, 20 };

            int min = array5[0];
            for (int i = 0; i < array5.Length; i++)
            {
                if (array5[i] < min) min = array5[i];
            }

            int count = 0;
            for (int i = 0; i < array5.Length; i++)
            {
                if (array5[i] == min + 5) count++;
            }

            Console.WriteLine($"Кількість елементів, що відрізняються від мінімального на 5: {count}\n");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
    }
}

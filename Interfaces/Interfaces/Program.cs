namespace Interfaces
{
    internal class Program
    {
        interface IOutput
        {
            void Show();
            void Show(string info);
        }
        interface IMath
        {
            int Max();
            int Min();
            double Avg();
            bool Search(int valueToSearch);
        }
        interface ISort
        {
            void SortAsc();
            void SortDesc();
            void SortByParam(bool isAsc);
        }
        class Array : IOutput, IMath, ISort
        {
            private int[] arr = { 1, 2, 3, 4, 5 };
            public Array() { }
            public Array(params int[] array)
            {
               arr = array;
            }

            public double Avg()
            {
               double sum = 0;
                foreach (var item in arr)
                {
                     sum += item;
                }
                return sum * 1.0 / arr.Length ;
            }

            public int Max()
            {
                int max = arr[0];
                foreach (var item in arr)
                {
                    if (item > max)
                        max = item;
                }
                return max;
            }

            public int Min()
            {
                int min = arr[0];
                foreach (var item in arr)
                {
                    if (item < min)
                        min = item;
                }
                return min;
            }

            public bool Search(int valueToSearch)
            {
               foreach (var item in arr)
                {
                    if (item == valueToSearch)
                        return true;
                }
                return false;
            }

            public void Show()
            {
                foreach (var item in arr)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
            public void Show(string info)
            {
                Console.WriteLine(info);
                Show();
            }

            public void SortAsc()
            {
               for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }

            public void SortDesc()
            {
               for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }
            public void SortByParam(bool isAsc)
            {
               if (isAsc)
                    SortAsc();
                else
                    SortDesc();
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Task 1 ----------");
            Array array = new Array(10, 20, 30, 40, 50);

            array.Show();
            array.Show("Array elements:");
            Console.WriteLine("----------------------------");


            Console.WriteLine("---------- Task 2 ----------");
            array.Show("Array elements:");
            Console.WriteLine("Max: " +  array.Max());
            Console.WriteLine("Min: " +  array.Min());
            Console.WriteLine("Avg: " +  array.Avg());
            int valueToSearch = 30;
            Console.WriteLine("Search " + valueToSearch + ": " + array.Search(valueToSearch));
            Console.WriteLine("----------------------------");

            Console.WriteLine("---------- Task 3 ----------");
            array = new Array(50, 20, 40, 10, 30);
            array.Show("Original array:");
            array.SortAsc();
            array.Show("Sorted array in ascending order:");
            array.SortDesc();
            array.Show("Sorted array in descending order:");
            array.SortByParam(true);
            array.Show("Sorted array by parameter (ascending):");
            array.SortByParam(false);
            array.Show("Sorted array by parameter (descending):");
            Console.WriteLine("----------------------------");

        }
    }
}

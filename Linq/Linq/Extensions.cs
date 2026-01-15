using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public static class Extensions 
    {
        public static void Print<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                Console.WriteLine("КОЛЕКЦІЯ ПУСТА!");
                Console.WriteLine("--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---");

                return;
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);

                if (item is Firma firma && firma.Employees.Count > 0)
                {
                    Console.WriteLine(" [Список працівників:]");
                    foreach (var emp in firma.Employees)
                    {
                        Console.WriteLine(emp);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---");
        }
    }
}

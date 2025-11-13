using System;
using System.Text;

namespace Classes__Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            // знизу написав Copilot, бо ліньки самому :)
            Freezer[] freezers = {
                new Freezer("FrostX"),
                new Freezer("Nord", 300),
                new Freezer("IceCube", -25),
                new Freezer(250, 190, 70),
                new Freezer("MegaCold", 400, -22, 200, 80, "A+++")
            };

            Console.WriteLine("Список морозильних камер:");

            foreach (Freezer freezer in freezers)
            {
                Console.WriteLine(freezer);
                Console.WriteLine();

            }
        }
    }
}

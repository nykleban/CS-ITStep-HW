using _03_Files;
using System.Text;
using System.Text.Unicode;

namespace FileManegerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            FileManager fm = new FileManager();
            fm.Start();
        }
    }
}

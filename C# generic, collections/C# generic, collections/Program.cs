using System.Text;
using System;
using System.Xml.Serialization;

namespace C__generic__collections
{
    internal class Program
    {
        /*Завдання 1


Завдання 2
Створіть додаток "Англо-український словник". Необхідно зберігати таку інформацію:

Слово англійською мовою;
Варіанти перекладу українською.
Для зберігання інформації використовуйте Dictionary<T>.

Додаток має надавати таку функціональність:

Додавання слова та варіантів перекладу;
Видалення слова;
Видалення варіанта перекладу;
Зміна слова;
Зміна варіанта перекладу;
Пошук перекладу слова.*/

        // Створіть generic-версію методу Swap для обміну значеннями двох змінних.
        static void Swap<T>(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Завдання 1");
            int a = 0;
            int b = 10;
            Console.WriteLine("a = "+ a + "; b = " + b);
            Console.WriteLine("Після Swap():");
            Swap<int>(a, b);
            Console.WriteLine("a = " + a + "; b = " + b);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Завдання 2");
            DictionaryApp dictionaryApp = new DictionaryApp();
            dictionaryApp.AddWord("apple", "яблуко");
            dictionaryApp.AddWord("apple", "апельсин");
            dictionaryApp.AddWord("run", "бігти, керувати, проганяти, запускати програму");
            dictionaryApp.AddWord("automobile", "автомобіль, машинка");
            dictionaryApp.RemoveTranslate("проганяти");
            dictionaryApp.ChangeEnWord("automobile", "car");
            dictionaryApp.ChangeUaWord("машинка", "авто");
            dictionaryApp.AddWord("book", "книга");
            dictionaryApp.SearchTranslate("apple");
            Console.WriteLine("------ Весь словник ------");
            dictionaryApp.PrintAll();
            Console.WriteLine("--------------------------");

        }
    }
}

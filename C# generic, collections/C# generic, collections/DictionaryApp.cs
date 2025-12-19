using System;
using System.Collections.Generic;
using System.Linq;

namespace C__generic__collections
{
    /*Завдання 2
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
    internal class DictionaryApp
    {
        private Dictionary<string, List<string>> dictionary;

        public DictionaryApp()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public void AddWord(string ENword, string UAword)
        {
            ENword = ENword.Trim().ToLower();
            if (!dictionary.ContainsKey(ENword))
            {
                dictionary[ENword] = new List<string>();
                Console.WriteLine($"Слово '{ENword}' додано до словника.");
            }
            string[] translations = UAword.Split(',');

            foreach (string item in translations)
            {
                string cleanTranslation = item.Trim().ToLower();

                if (!string.IsNullOrWhiteSpace(cleanTranslation))
                {
                    if (!dictionary[ENword].Contains(cleanTranslation))
                    {
                        dictionary[ENword].Add(cleanTranslation);
                        Console.WriteLine($" + додано переклад: {cleanTranslation}");
                    }
                }
            }
        }

        public void RemoveWord(string ENword)
        {
            if (dictionary.ContainsKey(ENword))
            {
                dictionary.Remove(ENword);
                Console.WriteLine($"Слово {ENword} видалено.");
            }
            else
            {
                Console.WriteLine($"Cлова {ENword} немає в словнику.");
            }
        }

        public void RemoveTranslate(string UAword)
        {
            bool found = false;
            foreach (string key in dictionary.Keys)
            {
                if (dictionary[key].Remove(UAword))
                {
                    Console.WriteLine($"Переклад '{UAword}' видалено зі слова '{key}'.");
                    found = true;
                }
            }
            if (!found) Console.WriteLine($"Переклад '{UAword}' не знайдено.");
        }

        public void ChangeEnWord(string oldWord, string newWord)
        {
            if (dictionary.ContainsKey(oldWord))
            {
                if (dictionary.ContainsKey(newWord))
                {
                    Console.WriteLine($"Слово {newWord} вже існує!");
                    return;
                }
                List<string> translations = dictionary[oldWord];
                dictionary.Remove(oldWord);
                dictionary.Add(newWord, translations);
                Console.WriteLine($"Слово EN '{oldWord}' замінено на '{newWord}'.");
            }
            else
            {
                Console.WriteLine($"Слово '{oldWord}' не знайдено.");
            }
        }

        public void ChangeUaWord(string oldWord, string newWord)
        {
            foreach (string key in dictionary.Keys)
            {
                List<string> translations = dictionary[key];
                int index = translations.IndexOf(oldWord);
                if (index != -1)
                {
                    translations[index] = newWord;
                    Console.WriteLine($"У слові '{key}' переклад '{oldWord}' замінено на '{newWord}'.");
                }
            }
        }

        public void SearchTranslate(string ENword)
        {
            if (dictionary.ContainsKey(ENword))
            {
                Console.Write($"Переклади для слова {ENword}: ");
                Console.WriteLine(string.Join(", ", dictionary[ENword]));
            }
            else
            {
                Console.WriteLine($"Слова {ENword} немає в словнику.");
            }
        }
        public void PrintAll()
        {
            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Thread_Synchronization;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string folderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test";
        string[] files = Directory.GetFiles(folderPath, "*.txt");
        Console.WriteLine($"Знайдено файлів: {files.Length}\n");

        GlobalStat globalStat = new GlobalStat();
        List<Thread> threads = new List<Thread>();

        foreach (string file in files)
        {
            string currentFile = file; // Копія змінної для потоку

            Thread t = new Thread(() =>
            {
                AnalyzeFile(currentFile, globalStat);
            });

            t.Start();
            threads.Add(t);
        }

        foreach (var t in threads) {
            t.Join();
        }


        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("ЗАГАЛЬНИЙ РЕЗУЛЬТАТ:");
        Console.WriteLine($"Слів:       {globalStat.TotalWords}");
        Console.WriteLine($"Рядків:     {globalStat.TotalLines}");
        Console.WriteLine($"Пунктуації: {globalStat.TotalPunctuation}");
        Console.WriteLine("----------------------------------------------");
    }

    static void AnalyzeFile(string filePath, GlobalStat global)
    {
        try
        {
            string content = File.ReadAllText(filePath);

            int localWords = content.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int localLines = content.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

            string punctMarks = ".,;:—‒…!?\"'«»(){}[]<>/";
            int localPunct = content.Count(c => punctMarks.Contains(c));

            Interlocked.Add(ref global.TotalWords, localWords);
            Interlocked.Add(ref global.TotalLines, localLines);
            Interlocked.Add(ref global.TotalPunctuation, localPunct);

            Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} обробив файл {Path.GetFileName(filePath)}");
            Console.WriteLine($"  Слів: {localWords}, Рядків: {localLines}, Пунктуації: {localPunct}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
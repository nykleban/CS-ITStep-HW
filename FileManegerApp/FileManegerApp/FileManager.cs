using System;
using System.Collections.Generic;
using System.IO;

namespace _03_Files
{
    public class FileManager
    {
        string rootPath;
        string currentPath;
        int currentPos;

        public FileManager()
        {
            rootPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            currentPath = rootPath;
            currentPos = 0;
        }

        public void ShowItems()
        {
          
            var dirs = GetDirectories();
            var files = GetFiles();

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < dirs.Count; i++)
            {
                var dir = dirs[i];
                var symbol = (i == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}{dir.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var symbol = (i + dirs.Count == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}{file.Name}");
            }
            Console.ResetColor();
        }

        private bool CheckIsFile()
        {
            return currentPos >= GetDirectories().Count;
        }

        private void Update()
        {
            Console.Clear();
            ShowItems();
        }

        public void Start()
        {
            ShowItems();
            ConsoleKey key = ConsoleKey.Escape;
            do
            {
                key = Console.ReadKey(true).Key;
                var total = GetDirectories().Count + GetFiles().Count;

                if (key == ConsoleKey.UpArrow && currentPos > 0)
                {
                    currentPos--;
                    Update();
                }
                else if (key == ConsoleKey.DownArrow && currentPos < total - 1)
                {
                    currentPos++;
                    Update();
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (CheckIsFile())
                    {
                        OpenFile();
                    }
                    else
                    {
                        OpenDir();
                    }
                }
                else if (key == ConsoleKey.Backspace)
                {
                    BackDir();
                }
                else if (key == ConsoleKey.Delete)
                {
                    if (CheckIsFile())
                    {
                        DeleteFile();
                    }
                    else
                    {
                        DeleteDir();
                    }
                }
                    Update();

            } while (key != ConsoleKey.Escape);
        }

        private void OpenDir()
        {
            var dirs = GetDirectories();

                var dir = dirs[currentPos];
                currentPath = dir.FullName;
                currentPos = 0; 
                Update();
            
        }

        private void OpenFile()
        {
            var dirs = GetDirectories();
            var files = GetFiles();

            int fileIndex = currentPos - dirs.Count;
            FileInfo file = files[fileIndex];
            if(file.Extension == ".exe" || file.Extension == ".pak") return;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"--- {file.Name} ---");
            try
            {
                Console.WriteLine(File.ReadAllText(file.FullName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cant read this file");
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Update();
        }

        private void BackDir()
        {

            var lastPath = Directory.GetParent(currentPath);
            if (lastPath != null)
            {
                currentPath = lastPath.FullName;
                currentPos = 0;
                Update();
            }
        }

        private void DeleteFile()
        {
            var dirs = GetDirectories();
            var files = GetFiles();
            int fileIndex = currentPos - dirs.Count;

            try
            {
                File.Delete(files[fileIndex].FullName);
                if (currentPos > 0) currentPos--;

            }
            catch { }
        }
        private void DeleteDir()
        {
            var dirs = GetDirectories();
            try
            {
                Directory.Delete(dirs[currentPos].FullName, true);
                if (currentPos > 0) currentPos--;
            }
            catch { }
        }

        public List<DirectoryInfo> GetDirectories()
        {
            var res = new List<DirectoryInfo>();
            try
            {
                var dirs = Directory.GetDirectories(currentPath);
                foreach (var dir in dirs)
                {
                    res.Add(new DirectoryInfo(dir));
                }
            }
            catch {}
            return res;
        }

        public List<FileInfo> GetFiles()
        {
            var res = new List<FileInfo>();
            try
            {
                var files = Directory.GetFiles(currentPath);
                foreach (var file in files)
                {
                    res.Add(new FileInfo(file));
                }
            }
            catch {}
            return res;
        }
    }
}
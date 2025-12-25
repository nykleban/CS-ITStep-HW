using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleExam
{
    public partial class MainWindow : Window
    {


        public class DataItem
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public int Count { get; set; }
        }
        List<DataItem> results = new List<DataItem>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string path = PathBox.Text;
            string word = WordBox.Text;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Папки не існує!");
                return;
            }

            results.Clear();
            ResultList.ItemsSource = null;

            string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);

            MyProgressBar.Maximum = files.Length;
            MyProgressBar.Value = 0;

            foreach (string file in files)
            {
                try
                {
                    string text = await File.ReadAllTextAsync(file);
                    int count = text.Split(new string[] { word }, StringSplitOptions.None).Length - 1;

                    if (count > 0)
                    {
                        results.Add(new DataItem
                        {
                            FileName = Path.GetFileName(file),
                            FilePath = file,
                            Count = count
                        });
                    }
                }
                catch
                {
                }
                MyProgressBar.Value++;
                await Task.Delay(1);
            }

            ResultList.ItemsSource = results;
            MessageBox.Show("Пошук завершено!");
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (results.Count == 0) return;



            List<string> lines = new List<string>();
            lines.Add("ЗВІТ:");

            foreach (var item in results)
            {
                lines.Add($"Назва файлу: {item.FileName}");
                lines.Add($"Шлях до файлу: {item.FilePath}");
                lines.Add($"Кількість входження слова: {item.Count}");
                lines.Add("-----------------");
            }

            await File.WriteAllLinesAsync("Result.txt", lines);
            MessageBox.Show("Збережено у файл Result.txt (біля .exe файлу)");
        }
    }
}
// шукайте слово "екзамен"
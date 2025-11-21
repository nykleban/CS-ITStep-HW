using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // grid.ItemsSource = Process.GetProcesses();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           grid.ItemsSource = Process.GetProcesses();
           
            
        }

        private void Button_Kill(object sender, RoutedEventArgs e)
        {
            Process selected = (Process)grid.SelectedItem;
            selected.Kill();
        }

        private void Button_ShowInfo(object sender, RoutedEventArgs e)
        {
            Process selected = (Process)grid.SelectedItem;
            string info = $"Process Name: {selected.ProcessName}\n" +
                          $"ID: {selected.Id}\n" +
                          $"Physical Memory Usage: {selected.WorkingSet64 / 1024} KB\n";
                         
            MessageBox.Show(info, selected.ProcessName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            string exe = textBox.Text.Trim();
            try
            {
             Process.Start(exe);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting process: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
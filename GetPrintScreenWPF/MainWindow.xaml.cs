using GetPrintScreenWPF.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetPrintScreenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FolderPath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadExcelFile_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = Selenium.MakePrintScreen(wwwTextBlock.Text, folderTextBlock.Text);
                       
            OpenLastFolderButton.IsEnabled = true;
            FolderPath = folderPath;

        }

        private void wwwTextBlock_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void wwwTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wwwTextBlock.SelectAll();
        }

        private void wwwTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            wwwTextBlock.SelectAll();
        }

        private void folderTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            folderTextBlock.SelectAll();
        }

        private void OpenLastFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (FolderPath != null)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = FolderPath;
                process.StartInfo.Arguments = @" ";
                process.Start();
            }
            
        }
    }
}

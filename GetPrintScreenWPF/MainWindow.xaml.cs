using GetPrintScreenWPF.Services;
using System.Windows;
using System.Windows.Input;

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
                Files.OpenFolder(FolderPath);
            }
        }
    }
}

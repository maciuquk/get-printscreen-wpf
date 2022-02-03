using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace GetPrintScreenWPF.Services
{
    internal class Selenium
    {
        internal static string MakePrintScreen(string wwwPath, string folderPath)
        {
            string name = Files.ExtractName(wwwPath);
            string directoryPath = Path.Combine(folderPath, name);

            if (!Directory.Exists(directoryPath))
            {
                Files.CreateFolder(directoryPath);
            }
            
           
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string filePath = Path.Combine(directoryPath, "Printscreen strony WWW " + name) + " " + date + ".png";
            if (File.Exists(filePath))
            {
                date = DateTime.Now.ToString("MM/dd/yyyy/HH/MM/ss");
            }

            filePath = Path.Combine(directoryPath, "Printscreen strony WWW " + name) + " " + date + ".png";

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(wwwPath);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            driver.Close();
            driver.Dispose();

            return directoryPath;
        }
    }
}

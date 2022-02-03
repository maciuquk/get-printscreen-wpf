using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrintScreenWPF.Services
{
    internal class Selenium
    {
        public static string MakePrintScreen(string wwwPath, string folderPath)
        {
            string name = Files.ExtractName(wwwPath);
            string directoryPath = Path.Combine(folderPath, name);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            string filePath = Path.Combine(directoryPath, "Printscreen strony WWW " + name) + " " + DateTime.Now.ToString("MM/dd/yyyy") + ".png";

            if (File.Exists(filePath))
            {
                filePath = Path.Combine(directoryPath, "Printscreen strony WWW " + name) + " " + DateTime.Now.ToString("MM/dd/yyyy/HH/MM/ss") + ".png";
            }

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

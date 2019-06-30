using OpenQA.Selenium;
using Microsoft.Win32;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Edge;
using System;

namespace Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            if (InstalledBrowsers.Contains("chrome"))
            {
                return new ChromeDriver();
            }
            else if (InstalledBrowsers.Contains("firefox"))
            {
                return new FirefoxDriver();
            }
            else
            {
                //return new EdgeDriver();
                //return new InternetExplorerDriver();
                throw new InvalidOperationException("Install Chrome or Firefox web browser on your computer. Please...");
            }
        }

        private static string InstalledBrowsers
        {
            get
            {
                var browsers = Registry.LocalMachine
                                       .OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet")
                                       .GetSubKeyNames();

                return string.Concat(browsers)
                             .ToLower();
            }
        }
    }
}

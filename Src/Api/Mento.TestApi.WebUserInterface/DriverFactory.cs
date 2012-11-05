using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Mento.Framework;
using System.Configuration;
using Mento.Framework.Constants;
using System.IO;
using System.Drawing;

namespace Mento.TestApi.WebUserInterface
{
    public class DriverFactory
    {
        /// <summary>
        /// Construct the driver 
        /// </summary>
        /// <param name="browser"></param>
        /// <returns>The driver instance</returns>
        public static IWebDriver GetDriver(Browser browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case Browser.IE:
                    driver = new InternetExplorerDriver(new InternetExplorerOptions() { });
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriver(new ChromeOptions() { });
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver(new FirefoxProfile() { AcceptUntrustedCertificates = true });
                    break;
                default:
                    driver = null;
                    break;
            }

            Maxmize(driver);

            return driver;
        }

        private static void Maxmize(IWebDriver driver)
        {
            //ITakesScreenshot shot = (ITakesScreenshot)driver;
            //var s = shot.GetScreenshot();
            //s.SaveAsFile();

            driver.Manage().Window.Position = new Point(0,0);
            driver.Manage().Window.Maximize();

            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            //Selenium.ISelenium
            //jsExecutor.ExecuteScript();
        }

        private static string GetFirefoxLocation()
        {
            string[] firefoxPossibleLocations = new string[]
            {
                //"\"C:\\Program Files\\Mozilla Firefox\\firefox.exe\"",
                //"\"C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe\"",
                //"\"D:\\Program Files\\Mozilla Firefox\\firefox.exe\"",
                //"\"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe\"",
                @"C:\Program Files\Mozilla Firefox\firefox.exe",
                @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe",
                @"D:\Program Files\Mozilla Firefox\firefox.exe",
                @"D:\Program Files (x86)\Mozilla Firefox\firefox.exe",
            };

            string configuredFirefoxLocation = ConfigurationManager.AppSettings[ConfigurationKey.FIREFOX_LOCATION];

            if (!String.IsNullOrEmpty(configuredFirefoxLocation))
            {
                return configuredFirefoxLocation;
            }
            else
            {
                for (int i = 0; i < firefoxPossibleLocations.Length; i++)
                {
                    if (File.Exists(firefoxPossibleLocations[i]))
                        return firefoxPossibleLocations[i];
                }

                throw new Exception("Firefox can not be found.");
            }
        }
    }
}

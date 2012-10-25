using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Mento.Framework;

namespace Mento.TestApi.WebUserInterface
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.IE:
                    return new InternetExplorerDriver();
                case Browser.Chrome:
                    return new ChromeDriver();
                case Browser.Firefox:
                    return new FirefoxDriver();
                default:
                    return null;
            }
        }
    }
}

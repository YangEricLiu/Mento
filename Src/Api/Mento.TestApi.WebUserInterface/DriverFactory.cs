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
using Mento.Framework.Exceptions;
using Mento.Framework.Execution;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Get the instance of browser when execuation.
    /// </summary>
    internal static class DriverFactory
    {
        private static IWebDriver _driver;
        public static IWebDriver Instance
        {
            get
            {
                if (!ExecutionContext.Browser.HasValue)
                    throw new Exception("Execution context not initialized yet.");

                if (_driver == null)
                {
                    _driver = DriverFactory.GetDriver(ExecutionContext.Browser.Value);
                }

                return _driver;
            }
        }

        /// <summary>
        /// Construct the driver 
        /// </summary>
        /// <param name="browser"></param>
        /// <returns>The driver instance</returns>
        private static IWebDriver GetDriver(Browser browser)
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
                    try
                    {
                        driver = new FirefoxDriver(new FirefoxProfile() { AcceptUntrustedCertificates = true });
                    }
                    catch (WebDriverException ex)
                    {
                        throw new ApiException("Can not found firefox browser, you may need install firefox.", ex);
                    }
                    break;
                default:
                    driver = null;
                    break;
            }

            //maximize the browser
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Exceptions;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using Mento.Framework.Execution;
using Mento.Framework;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Mento.Framework.Configuration;

namespace Mento.TestApi.WebUserInterface
{
    public static class BrowserHandler
    {
        public static void Navigate(string url)
        {
            DriverFactory.Instance.Navigate().GoToUrl(url);
        }

        public static string GetPageTitle()
        {
            return DriverFactory.Instance.Title;
        }

        public static void Quit()
        {
            DriverFactory.Instance.Quit();
        }

        public static void TakeCapture(string fileName)
        {
            try
            {
                ITakesScreenshot ScreenShotter = (ITakesScreenshot)DriverFactory.Instance;

                Screenshot shot = ScreenShotter.GetScreenshot();
                shot.SaveAsFile(fileName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Capture image failed, may caused by illegal image path :'{0}'", fileName), ex);
            }
        }

        public static object ExecuteJavaScript(string script, params object[] args)
        {
            try
            {
                IJavaScriptExecutor JavaScriptExecutor = (IJavaScriptExecutor)DriverFactory.Instance;

                return JavaScriptExecutor.ExecuteScript(script, args);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Execution failed, please validate the provided javascript :'{0}'", script), ex);
            }
        }

        public static object ExecuteAsyncJavaScript(string script,params object[] args)
        {
            try
            {
                IJavaScriptExecutor JavaScriptExecutor = (IJavaScriptExecutor)DriverFactory.Instance;

                return JavaScriptExecutor.ExecuteAsyncScript(script, args);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Execution failed, please validate the provided javascript :'{0}'", script), ex);
            }
        }

        public static void DeleteCookies()
        {
            DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();
        }

        public static void Refresh()
        {
            DriverFactory.Instance.Navigate().Refresh();
        }

        public static void switchToWindow(string windowTitle)
        {
            DriverFactory.switchToWindow(DriverFactory.Instance, windowTitle);
        }
    }


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
        /// Construct the driver, OK
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
                    //这里需要改变chrome的下载目录
                    ChromeOptions options = new ChromeOptions();

                    if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
                        options.AddUserProfilePreference("download.default_directory", ExecutionConfig.expectedDataViewExcelFileDirectory);

                    else if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
                        options.AddUserProfilePreference("download.default_directory", ExecutionConfig.actualDataViewExcelFileDirectory);

                    driver = new ChromeDriver(options);              
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

        public static Boolean switchToWindow(IWebDriver driver, string windowTitle)
        { 
            Boolean flag = false;

            try
            {
                String currentHandle = driver.CurrentWindowHandle;
                List<string> handles = driver.WindowHandles.ToList();

                foreach (string s in handles) 
                {  
                    if (s.Equals(currentHandle))  
                    continue; 

                    else {  
                    driver.SwitchTo().Window(s);  
                    if (driver.Title.Contains(windowTitle)) 
                    {  
                        flag = true;  
                        break;  
                    } else  
                        continue;  
                    }  
                }
            }
            catch (NoSuchWindowException e) 
            {  
                flag = false;  
            } 

            return flag;
        }
    }
}

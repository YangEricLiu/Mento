using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Utility;
using Mento.Framework;
using Mento.Framework.Execution;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Communicate with webdriver, implement basic action, find element and so on.
    /// </summary>
    /// <remarks>This class is static, can't be heritted.</remarks>
    public static class ElementLocator
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
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
        /// Open Jazz with special browser and maximize the window
        /// </summary>
        /// <returns></returns>
        public static void OpenJazz()
        {
            //_driver = DriverFactory.GetDriver(ExecutionContext.Browser.Value); 

            Driver.Navigate().GoToUrl(ExecutionContext.Url);

            if (ExecutionContext.Browser == Browser.IE)
            {
                ClickHttpsSecurityWarning();
            }
        }

        /// <summary>
        /// Close the browser but NOT log out from Jazz
        /// </summary>
        /// <returns></returns>
        public static void CloseJazz()
        {
            Driver.Quit();
        }


        /// <summary>
        /// Get the IWebElement which reference to the element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>IWebElement which reference to the element</returns>
        public static IWebElement FindElement(Locator locator)
        {
            return Driver.FindElement(locator.ToBy());
        }

        /// <summary>
        /// Pause and wait for several milliseconds
        /// </summary>
        /// <param name="millisecs"></param>
        /// <returns></returns>
        public static void Pause(int millisecs)
        {
            System.Threading.Thread.Sleep(millisecs);
        }


        /// <summary>
        /// Judge that whether the element is present on web page
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>True if the element is present, false if not</returns>
        public static Boolean IsElementPresent(Locator locator)
        {
            Boolean present = false;

            try
            {
                FindElement(locator);
                present = true;
            }
            catch (NoSuchElementException)
            {              
                //Element Not Existed
            }

            return present;
        }


        /// <summary>
        /// Judge that whether the element is displayed within certain time
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOut"></param>
        /// <returns>True if this element is displayed within certain time, false if not</returns>
        public static Boolean WaitForElement(Locator locator, int timeOut)
        {
            Boolean elementExist = false;

            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
                wait.Until((d) => { return d.FindElement(locator.ToBy()); });

                elementExist = true;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                //it's better that, after output the exception message to notice the reason of failure, then also output the locator to 
                //know the error of finding which element.
                //add log here
            }

            Pause(1000);
            return elementExist;
        }

        /// <summary>
        /// Judge that whether the element is hidden or removed within certain time
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static bool WaitForElementToDisappear(Locator locator, int timeOut)
        {
            bool elementExist = true;

            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
                wait.Until<bool>(d =>
                {
                    var foundElement = d.FindElement(locator.ToBy());

                    if (foundElement == null)
                    {
                        return true;
                    }
                    else
                    {
                        string displayValue = foundElement.GetCssValue("display");

                        return displayValue.ToLower() == "none";
                    }
                });

                elementExist = false;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Pause(1500);
            return elementExist;
        }

        /// <summary>
        /// simulate mouse float on the element
        /// </summary>
        /// <param name="elementHandler"></param>
        /// <returns></returns>
        public static void FloatOn(IWebElement elementHandler)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(elementHandler).Perform();
        }

        /// <summary>
        /// simulate mouse focus on the element
        /// </summary>
        /// <param name="elementHandler"></param>
        /// <returns></returns>
        public static void FocusOn(IWebElement elementHandler)
        {
            Actions action = new Actions(Driver);
            action.Click(elementHandler).Perform();

            Pause(1000);
        }

        /// <summary>
        /// simulate mouse drag one element from one position to another position
        /// </summary>
        /// <param name="source"></param>
        /// <param name="desination"></param>
        /// <returns></returns>
        public static void DragAndDrop(IWebElement source, IWebElement desination)
        {
            Actions action = new Actions(Driver);
            action.DragAndDrop(source, desination).Perform();
        }

        /// <summary>
        /// simulate mouse double click one element
        /// </summary>
        /// <param name="elementHandler"></param>
        /// <returns></returns>
        public static void DoubleClick(IWebElement elementHandler)
        {
            Actions action = new Actions(Driver);
            action.DoubleClick(elementHandler).Perform();
        }

        /// <summary>
        /// Judge that whether the element is displayed, which check "style" attribute to determine visibility of an element.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>True if the element is present, false if not</returns>
        public static Boolean IsElementDisplayed(Locator locator)
        {
            return FindElement(locator).Displayed;
        }

        /*
        public static Boolean DeleteLoginCookie()
        {
            try
            {
                driver.Manage().Cookies.DeleteAllCookies();
                return true;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return true;
            }
        }*/

        private static void ClickHttpsSecurityWarning()
        {
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;

            //jsExecutor.ExecuteScript("document.getElementById('overridelink').click()");

            //Driver.FindElement(By.XPath(String.Format("a[href=\"{0}\"]", ExecutionContext.Url)));
            //IWebElement overrideLink = Driver.FindElement(By.Id("overridelink"));
            //string pageTitle = Driver.Title;

            //if (pageTitle.StartsWith("Certificate Error") && overrideLink != null)
            //{
            //    overrideLink.Click();
            //}

            //solution from http://stackoverflow.com/questions/7338128/regd-webdriver-on-secure-certificate
            //webDriver.navigate().to(javascript:document.getElementById('overridelink').click());

            string pageTitle = Driver.Title;
            if (pageTitle.StartsWith("Certificate Error"))
            {
                Driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            }
        }
    } 
}

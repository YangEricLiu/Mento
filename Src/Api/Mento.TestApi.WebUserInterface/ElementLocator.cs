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
    public static class ElementLocator
    {
        private static IWebDriver _driver;
        private static IWebDriver Driver
        {
            get 
            {
                if (!ExecutionContext.Browser.HasValue)
                    throw new Exception("Execution context not initialized yet.");

                //if (_driver == null)
                //{
                //    _driver = DriverFactory.GetDriver(ExecutionContext.Browser.Value);
                //}

                return _driver;
            }
        }

        public static void OpenJazz()
        {
            _driver = DriverFactory.GetDriver(ExecutionContext.Browser.Value); 
            Driver.Navigate().GoToUrl(ExecutionContext.Url);
        }

        public static void QuitJazz()
        {
            Driver.Quit();
        }

        private static By ByWrapper(Locator locator)
        {
            var type = locator.Type;
            var locatorValue = locator.Value;

            switch (type)
            {
                case ByType.ID: return By.Id(locatorValue);
                case ByType.Name: return By.Name(locatorValue);
                case ByType.Xpath: return By.XPath(locatorValue);
                case ByType.TagName: return By.TagName(locatorValue);
                case ByType.ClassName: return By.ClassName(locatorValue);
                case ByType.CssSelector: return By.CssSelector(locatorValue);
                case ByType.LinkText: return By.LinkText(locatorValue);
                case ByType.PartialLinkText: return By.PartialLinkText(locatorValue);
                default: return null;
            }
        }

        public static IWebElement FindElement(Locator locator)
        {
            return Driver.FindElement(ByWrapper(locator));
        }

        public static void pause(int millisecs)
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
                wait.Until((d) => { return d.FindElement(ByWrapper(locator)); });

                elementExist = true;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                //it's better that, after output the exception message to notice the reason of failure, then also output the locator to 
                //know the error of finding which element.
                //add log here
            }

            pause(1000);
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

            pause(1000);
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
    }
}

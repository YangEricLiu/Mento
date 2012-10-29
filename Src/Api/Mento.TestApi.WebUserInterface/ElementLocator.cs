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
    public class ElementLocator
    {
        private static IWebDriver driver;

        public static void OpenJazz()
        {
            driver = DriverFactory.GetDriver(ExecutionContext.Browser);
            driver.Navigate().GoToUrl(ExecutionContext.Url);
        }

        public static void QuitJazz()
        {
            driver.Quit();
        }

        private static By ByWrapper(string locator, ByType type)
        {
            switch (type)
            {
                case ByType.ID: return By.Id(locator);
                case ByType.Name: return By.Name(locator);
                case ByType.Xpath: return By.XPath(locator);
                case ByType.TagName: return By.TagName(locator);
                case ByType.ClassName: return By.ClassName(locator);
                case ByType.CssSelector: return By.CssSelector(locator);
                case ByType.LinkText: return By.LinkText(locator);
                case ByType.PartialLinkText: return By.PartialLinkText(locator);
                default: return null;
            }
        }

        public static IWebElement FindElement(string locator, ByType findType)
        {
            return driver.FindElement(ByWrapper(locator, findType));
        }

        public static void pause(int millisecs)
        {
            try
            {
                System.Threading.Thread.Sleep(millisecs);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                //add log here
            }
        }

        public static Boolean IsElementPresent(string locator, ByType findType)
        {
            Boolean present = false;

            try
            {
                driver.FindElement(ByWrapper(locator, findType));
                present = true;
            }
            catch (NoSuchElementException)
            {
                //add log here
            }

            return present;
        }

        public static Boolean WaitForElement(string locator, ByType findType, int timeOut)
        {
            Boolean elementExist = false;

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                wait.Until((d) => { return d.FindElement(ByWrapper(locator, findType)); });

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

        public static void FloatOn(IWebElement elementHandler)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elementHandler).Perform();
        }

        public static void FocusOn(IWebElement elementHandler)
        {
            Actions action = new Actions(driver);
            action.Click(elementHandler).Perform();

            pause(1000);
        }

        public static void DragAndDrop(IWebElement source, IWebElement desination)
        {
            Actions action = new Actions(driver);
            action.DragAndDrop(source, desination).Perform();
        }

        public static void DoubleClick(IWebElement elementHandler)
        {
            Actions action = new Actions(driver);
            action.DoubleClick(elementHandler).Perform();
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

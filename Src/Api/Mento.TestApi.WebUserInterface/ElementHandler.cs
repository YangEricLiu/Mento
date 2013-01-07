using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Mento.Framework.Exceptions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.Framework.Execution;
using System.IO;
using Mento.Framework.Log;
using NUnit.Framework;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public static class ElementHandler
    {
        #region Element Search
        public static IWebElement FindElement(Locator locator, ISearchContext container = null)
        {
            if (container == null)
                container = DriverFactory.Instance;

            try
            {
                return container.FindElement(locator.ToBy());
            }
            catch (NoSuchElementException ex)
            {
                //capture error image
                string fileName = TestContext.CurrentContext.Test.FullName.GetHashCode() + ".jpg";

                string ImageFilePath = Path.Combine(NUnit.Framework.TestContext.CurrentContext.WorkDirectory, fileName);
                BrowserHandler.TakeCapture(ImageFilePath);

                AppLog.Instance.LogInformation("Image: " + ImageFilePath);
                AppLog.Instance.LogError(ex.ToString());

                throw new ApiException(String.Format("Can not found element with locator {0}", locator.ToString()), ex);
                //throw ex;
            }
        }

        public static IWebElement[] FindElements(Locator locator, ISearchContext container = null)
        {
            if (container == null)
                container = DriverFactory.Instance;

            return container.FindElements(locator.ToBy()).ToArray();
        }

        public static bool Exists(Locator locator, ISearchContext container = null)
        {
            return FindElements(locator, container: container).Count() > 0;
        }

        public static bool Displayed(Locator locator, ISearchContext container = null)
        {
            var elements = FindElements(locator, container: container);

            if (elements == null || elements.Length != 1)
                return false;

            return elements.Single().Displayed;
        }
        #endregion

        #region Actions
        public static void Click(IWebElement element)
        {
            Actions action = new Actions(DriverFactory.Instance);

            action.Click(element).Perform();
        }

        public static void Click(IWebElement element, int offsetX,int offsetY)
        {
            Actions action = new Actions(DriverFactory.Instance);
            action.MoveToElement(element, offsetX, offsetY);
            action.Click(element).Perform();
        }

        public static void Click(Locator locator, ISearchContext container = null)
        {
            Click(FindElement(locator, container: container));
        }

        public static void DoubleClick(IWebElement element)
        {
            Actions action = new Actions(DriverFactory.Instance);

            action.DoubleClick(element).Perform();
        }

        public static void DoubleClick(Locator locator, ISearchContext container = null)
        {
            DoubleClick(FindElement(locator, container: container));
        }

        public static void Focus(Locator locator, ISearchContext container = null)
        {
            Focus(FindElement(locator, container: container));
        }

        public static void Focus(IWebElement element)
        {
            Actions action = new Actions(DriverFactory.Instance);
            action.Click(element).Perform();
        }

        public static void Float(Locator locator, ISearchContext container = null)
        {
            Float(FindElement(locator, container: container));
        }

        public static void Float(IWebElement element)
        {
            Actions action = new Actions(DriverFactory.Instance);
            action.MoveToElement(element).Perform();
        }

        public static void DragAndDrop(IWebElement source, IWebElement desination)
        {
            Actions action = new Actions(DriverFactory.Instance);
            action.DragAndDrop(source, desination).Perform();
        }

        public static bool Wait(Locator locator, WaitType waitType, ISearchContext container = null, int timeout = TimeManager.WAITELEMENTTIMEOUT)
        {
            Func<IWebDriver, bool> AppearCondition = (driver) => Displayed(locator, container: (container == null ? driver : container));

            Func<IWebDriver, bool> DisappearCondition = (driver) => !Displayed(locator, container: (container == null ? driver : container));

            WebDriverWait wait = new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(timeout));

            return wait.Until<bool>(waitType == WaitType.ToAppear ? AppearCondition : DisappearCondition);
        }
        #endregion
    }

    public enum WaitType
    {
        ToAppear = 1,
        ToDisappear = 2,
    }
}

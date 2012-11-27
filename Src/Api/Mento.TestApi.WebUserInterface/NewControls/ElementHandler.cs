using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public static class ElementHandler
    {
        public static void Wait(Locator locator, WaitType waitType, IWebElement parentElement=null, int timeOut = TimeManager.WAITELEMENTTIMEOUT)
        {
            switch (waitType)
            {
                case WaitType.ToDisappear:
                    ElementLocator.WaitForElementToDisappear(locator, timeOut);
                    break;

                //consider wait to appear as default action
                case WaitType.ToAppear:
                default:
                    ElementLocator.WaitForElement(locator, timeOut);
                    break;
            }
        }

        public static bool Exists(Locator locator, IWebElement parentElement = null)
        {
            var element = TryFindElement(locator, parentElement: parentElement);

            return element != null;
        }

        public static bool Displayed(Locator locator, IWebElement parentElement = null)
        {
            var element = TryFindElement(locator, parentElement: parentElement);

            if (element == null)
                return false;

            return element.Displayed;
        }

        public static void Focus(Locator locator, IWebElement parentElement = null)
        {
            IWebElement element = parentElement == null ? ElementLocator.FindElement(locator) : parentElement.FindElement(locator.ToBy());

            ElementLocator.FocusOn(element);
        }

        private static IWebElement TryFindElement(Locator locator, IWebElement parentElement = null)
        {
            IWebElement element = null;
            try
            {
                element = parentElement == null ? ElementLocator.FindElement(locator) : parentElement.FindElement(locator.ToBy());
            }
            catch (NoSuchElementException)
            {
            }

            return element;
        }
    }

    public enum WaitType
    {
        ToAppear = 1,
        ToDisappear = 2,
    }
}

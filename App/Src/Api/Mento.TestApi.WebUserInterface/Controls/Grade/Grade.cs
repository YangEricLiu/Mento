using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Grade : JazzControl
    {
        private static Locator GradeItemFrontLabel = new Locator("div/label[1]", ByType.XPath);
        private static Locator GradeItemUOMLabel = new Locator("div/label[last()]", ByType.XPath);
        private static Locator GradeItemLeftNumberField = new Locator("div/table[contains(@id,'numberfield')][1]", ByType.XPath);
        private static Locator GradeItemRightNumberField = new Locator("div/table[contains(@id,'numberfield')][2]", ByType.XPath);
        private static Locator GradeItemNumberFieldLabel = new Locator("tbody/tr/td[contains(@id,'numberfield') and contains(@id,'labelCell')]/label", ByType.XPath);
        private static Locator GradeItemNumberFieldInput = new Locator("tbody/tr/td[contains(@id,'numberfield') and contains(@id,'bodyEl')]/table/tbody/tr/td/input", ByType.XPath);

        /// <summary>
        /// locator parameter must be root element of a grid
        /// </summary>
        /// <param name="locator"></param>
        public Grade(Locator locator) : base(locator) { }

        protected IWebElement[] GradeItems
        {
            get 
            {
                return FindChildren(ControlLocatorRepository.GetLocator(ControlLocatorKey.GradeItems));
            }
        }

        public int GetCurrentGradeItemsNumber()
        {
            return GradeItems.Count();
        }

        public string GetFirstGradeItemLabel()
        {
            IWebElement FirstGradeItemLabel = ElementHandler.FindElement(GradeItemFrontLabel, container: GradeItems[0]);

            return FirstGradeItemLabel.Text;
        }

        public string GetLastGradeItemLabel()
        {
            int gradeCount = GetCurrentGradeItemsNumber();
            IWebElement LastGradeItemLabel = ElementHandler.FindElement(GradeItemFrontLabel, container: GradeItems[gradeCount - 1]);

            return LastGradeItemLabel.Text;
        }

        public string GetGradeItemUOMValue(int num)
        {
            IWebElement GradeItemUOM = ElementHandler.FindElement(GradeItemUOMLabel, container: GradeItems[num - 1]);

            return GradeItemUOM.Text;
        }

        public string GetGradeItemLeftNumberValue(int num)
        {
            IWebElement GradeItemLeftNumber = ElementHandler.FindElement(GradeItemLeftNumberField, container: GradeItems[num - 1]);
            IWebElement GradeItemLeftNumberInput = ElementHandler.FindElement(GradeItemNumberFieldInput, container: GradeItemLeftNumber);

            return GradeItemLeftNumberInput.Text;
        }

        public string GetGradeItemRightNumberValue(int num)
        {
            IWebElement GradeItemRightNumber = ElementHandler.FindElement(GradeItemRightNumberField, container: GradeItems[num - 1]);
            IWebElement GradeItemRightNumberInput = ElementHandler.FindElement(GradeItemNumberFieldInput, container: GradeItemRightNumber);

            return GradeItemRightNumberInput.Text;
        }

        public string GetGradeItemMiddleLabelValue(int num)
        {
            IWebElement GradeItemRightNumber = ElementHandler.FindElement(GradeItemRightNumberField, container: GradeItems[num - 1]);
            IWebElement GradeItemMiddleLabel = ElementHandler.FindElement(GradeItemNumberFieldLabel, container: GradeItemRightNumber);

            return GradeItemMiddleLabel.Text;
        }

        public void FillGradeItemLeftNumberValue(int num, string value)
        {
            IWebElement GradeItemLeftNumber = ElementHandler.FindElement(GradeItemLeftNumberField, container: GradeItems[num - 1]);
            IWebElement GradeItemLeftNumberInput = ElementHandler.FindElement(GradeItemNumberFieldInput, container: GradeItemLeftNumber);

            GradeItemLeftNumberInput.Clear();
            GradeItemLeftNumberInput.SendKeys(value);
        }

        public void FillGradeItemRightNumberValue(int num, string value)
        {
            IWebElement GradeItemRightNumber = ElementHandler.FindElement(GradeItemRightNumberField, container: GradeItems[num - 1]);
            IWebElement GradeItemRightNumberInput = ElementHandler.FindElement(GradeItemNumberFieldInput, container: GradeItemRightNumber);

            GradeItemRightNumberInput.Clear();
            GradeItemRightNumberInput.SendKeys(value);
        }

        public bool IsGradeItemLeftNumberFieldDisabled(int num)
        {
            IWebElement GradeItemLeftNumber = ElementHandler.FindElement(GradeItemLeftNumberField, container: GradeItems[num - 1]);

            return GradeItemLeftNumber.GetCssValue("class").Contains("x-item-disabled");
        }

        public bool IsGradeItemRightNumberFieldDisabled(int num)
        {
            IWebElement GradeItemRightNumber = ElementHandler.FindElement(GradeItemRightNumberField, container: GradeItems[num - 1]);

            return GradeItemRightNumber.GetCssValue("class").Contains("x-item-disabled");
        }
    }
}

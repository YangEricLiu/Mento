using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// CheckBoxField display whether the checkbox is checked
    /// </summary>
    public class CheckBoxField : JazzControl
    {
        protected const string CHECKEDCLASS = "x-form-cb-checked";
        protected const string PERMISSIONNAME = "permissionName";

        /// <summary>
        /// locator parameter must be root element of a CheckBoxField
        /// </summary>
        /// <param name="locator"></param>
        public CheckBoxField(Locator locator) : base(locator) { }

        public Boolean IsChecked(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);

            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }

        public void Check(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);

            if (!IsChecked(permissionName))
                checkbox.Click();
        }

        /// <summary>
        /// Judge if the checkbox item is enabled
        /// </summary>
        /// <returns>True if the checkbox item is enable, false if not </returns>
        public bool IsDisabled(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);
            return checkbox.GetAttribute("class").Contains("x-item-disabled");
        }

        public void Uncheck(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);

            if (IsChecked(permissionName))
                checkbox.Click();
        }

        #region private methods
        private Locator GetPermissonFieldLocator(string permissionName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxTable), PERMISSIONNAME, permissionName);
        }

        private IWebElement GetPermissonFieldElement(string permissionName)
        {
            return FindChild(GetPermissonFieldLocator(permissionName));
        }
        #endregion
    }
}

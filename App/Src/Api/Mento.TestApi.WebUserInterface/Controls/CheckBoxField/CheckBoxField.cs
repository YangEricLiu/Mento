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
        protected const string ITEMNAME = "itemName";

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

        public Boolean IsCommonChecked(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);

            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }
        //Verify checkbox in widget template is checked.
        public Boolean IsWidgetTemplateChecked(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElementInWidgetTemplate(itemName);

            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }

        /// <summary>
        /// verfiy whether the item unchecked.
        /// </summary>
        /// <param name="locator"></param>
        public Boolean IsCommonUnChecked(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);

            return !(checkbox.GetAttribute("class").Contains(CHECKEDCLASS));
        }
        /// <summary>
        /// verfiy whether the item unchecked in widget template.
        /// </summary>
        /// <param name="locator"></param>
        public Boolean IsWidgetTemplateUnChecked(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElementInWidgetTemplate(itemName);

            return !(checkbox.GetAttribute("class").Contains(CHECKEDCLASS));
        }



        public Boolean IsAllDataScopeItemChecked()
        {
            IWebElement checkbox = this.RootElement;

            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }

        public Boolean IsAllDataScopeItemDisabled()
        {
            IWebElement checkbox = this.RootElement;

            return checkbox.GetAttribute("class").Contains("x-item-disabled");
        }

        public void Check(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);

            if (!IsChecked(permissionName))
                checkbox.Click();
        }

        // common checkbox check
        public void CommonCheck(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElement(itemName);

            if (!IsCommonChecked(itemName))
                checkbox.Click();
        }

        // common uncheckbox check
        public Boolean CommonUnCheck(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);
            try
            {
                if (IsCommonChecked(itemName))
                {
                    checkbox.Click();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        // checkbox check in widget template
        public void CheckInWidgetTemplate(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElementInWidgetTemplate(itemName);

            if (!IsWidgetTemplateChecked(itemName))
                checkbox.Click();
        }

        // uncheckbox check in widget template
        public void UncheckInWidgetTemplate(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElementInWidgetTemplate(itemName);

            if (IsWidgetTemplateUnChecked(itemName))
                checkbox.Click();
        }

        //common checkbox disabled 
        public Boolean IsAllItemDisabled()
        {
            IWebElement checkbox = this.RootElement;

            return checkbox.GetAttribute("class").Contains("x-item-disabled");
        }


        public void DataAllHierarchyCheck()
        {
            IWebElement checkbox =this.RootElement;
            if (!IsDataAllhierarchyBoxChecked())
                checkbox.Click();
        }

         public Boolean IsDataAllhierarchyBoxChecked()
        {
            IWebElement checkbox =this.RootElement;
            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }
         //Get check in widget template

         private Locator GetCheckBoxFieldLocatorInWidgetTemplate(string itemName)
         {
             return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxTable), ITEMNAME, itemName);
         }

         private Locator GetCheckBoxInputLocatorInWidgetTemplate(string itemName)
         {
             return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxInput), ITEMNAME, itemName);
         }
         //for widget template---cathy

         private IWebElement GetCheckBoxFieldElementInWidgetTemplate(string itemName)
         {
             return FindChild(GetCheckBoxFieldLocatorInWidgetTemplate(itemName));
         }
         private IWebElement GetCheckBoxInputElementInWidgetTemplate(string itemName)
         {
             return FindChild(GetCheckBoxInputLocatorInWidgetTemplate(itemName));
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

        /// <summary>
        /// Judge if the common checkbox item is enabled
        /// </summary>
        /// <returns>True if the checkbox item is enable, false if not </returns>
        public bool IsCommonDisabled(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);
            return checkbox.GetAttribute("class").Contains("x-item-disabled");
        }

        /// <summary>
        /// Judge if the common checkbox item is displayed
        /// </summary>
        /// <returns>True if the checkbox item is enable, false if not </returns>
        public bool IsCommonNotDisplayed(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);
            return checkbox.GetAttribute("style").Contains("display: none");
        }

        public void Uncheck(string permissionName)
        {
            IWebElement checkbox = GetPermissonFieldElement(permissionName);

            if (IsChecked(permissionName))
                checkbox.Click();
        }

        /*
        public void CommonCheck(string item)
        {
            IWebElement checkbox = get

            if (IsChecked(permissionName))
                checkbox.Click();
        }
        */

        #region private methods
        private Locator GetPermissonFieldLocator(string permissionName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.PermissionCheckBoxTable), PERMISSIONNAME, permissionName);
        }

        // Get common check
        
        private Locator GetCheckBoxFieldLocator(string itemName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxTable), ITEMNAME, itemName);
        }

        private Locator GetCheckBoxInputLocator(string itemName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxInput), ITEMNAME, itemName);
        }
        /*
        private Locator GetCheckBoxFieldLocator(string itemName)
        {
            string CheckBoxLocatorFormat = Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxTable), ITEMNAME, itemName).Value;
            return new Locator(LanguageResourceRepository.ReplaceLanguageVariables(String.Format(CheckBoxLocatorFormat, itemName)), ByType.XPath);
        }
        */
        private IWebElement GetPermissonFieldElement(string permissionName)
        {
            return FindChild(GetPermissonFieldLocator(permissionName));
        }

        private IWebElement GetCheckBoxFieldElement(string itemName)
        {
            return FindChild(GetCheckBoxFieldLocator(itemName));
        }

        private IWebElement GetCheckBoxInputElement(string itemName)
        {
            return FindChild(GetCheckBoxInputLocator(itemName));
        }

        #endregion

    }
}

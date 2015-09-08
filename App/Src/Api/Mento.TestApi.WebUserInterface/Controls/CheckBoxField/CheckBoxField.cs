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
    /// <summary>
    /// CheckBoxField display whether the checkbox is checked ok
    /// </summary>
    public class CheckBoxField : JazzControl
    {
        protected const string CHECKEDCLASS = "x-form-cb-checked";
        protected const string PERMISSIONNAME = "permissionName";
        protected const string ITEMNAME = "itemName";
        private static string ITEMRESOURCEVARIABLE1 = "itemResourceVariable1";
        private static string ITEMRESOURCEVARIABLE2 = "itemResourceVariable2";
        

        /// <summary>
        /// locator parameter must be root element of a CheckBoxField
        /// </summary>
        /// <param name="locator"></param>
        public CheckBoxField(Locator locator) : base(locator) { }

        #region Jazz 2.x

        public void Alarm_Checked(string itemName)
        {
            IWebElement checkbox = Alarm_GetCheckBoxFieldElement(itemName);

            checkbox.Click();
        }

        private IWebElement Alarm_GetCheckBoxFieldElement(string itemName)
        {
            return FindChild(Alarm_GetCheckBoxFieldLocator(itemName));
        }

        private Locator Alarm_GetCheckBoxFieldLocator(string itemName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.Alarm_CheckBoxInput), ITEMNAME, itemName);
        }

        #endregion

        #region Pop

        public void Pop_CommonCheck(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElement(itemName);

            if (!IsCommonChecked(itemName))
                checkbox.Click();
        }

        public void Pop_CommonUnCheck(string itemName)
        {
            IWebElement checkbox = Pop_GetCheckBoxInputElement(itemName);
            
            try
            {
                if (Pop_IsCommonChecked(itemName))
                {
                    checkbox.Click();
                }
            }
            catch (Exception)
            {

            }

        }

        private IWebElement Pop_GetCheckBoxInputElement(string itemName)
        {
            return FindChild(Pop_GetCheckBoxInputLocator(itemName));
        }

        private Locator Pop_GetCheckBoxInputLocator(string itemName)
        {
            return Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.PopCheckBoxInput), ITEMNAME, itemName);
        }

        public Boolean Pop_IsCommonChecked(string itemName)
        {
            IWebElement checkbox = Pop_GetCheckBoxInputElement(itemName);
            Console.Out.Write(checkbox.GetAttribute("checked").ToString());

            return checkbox.GetAttribute("checked").Contains("");//other method
        }

        #endregion

        #region Jazz 1.x
        
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


        public Boolean IsWidgetTemplateChecked(string itemName1, string itemName2)
        {
            IWebElement checkbox = GetWidgetTemplateFieldElement(itemName1, itemName2);

            return checkbox.GetAttribute("class").Contains(CHECKEDCLASS);
        }
 
        public Boolean IsCommonUnChecked(string itemName)
        {
            IWebElement checkbox = GetCheckBoxFieldElement(itemName);

            return !(checkbox.GetAttribute("class").Contains(CHECKEDCLASS));
        }


        public Boolean IsWidgetTemplateUnChecked(string itemName1, string itemName2)
        {
            IWebElement checkbox = GetWidgetTemplateFieldElement(itemName1, itemName2);

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

        //check filter checkbox
        public void CheckInWidgetTemplate(string itemName1, string itemName2)
        {
            IWebElement checkbox = GetWidgetTemplateInputElement(itemName1, itemName2);
            if (!IsWidgetTemplateChecked(itemName1, itemName2))
            checkbox.Click();
        }
        //Uncheck filter checkbox
        //public Boolean UncheckInWidgetTemplate(string itemName1, string itemName2)
        //{
        //    IWebElement checkbox = GetWidgetTemplateInputElement(itemName1, itemName2);
        //    if (!IsWidgetTemplateChecked(itemName1, itemName2))
        //    {
        //        checkbox.Click();
        //        return true;
        //    }
        //    return false;
        //}
        public void UncheckInWidgetTemplate(string itemName1, string itemName2)
        {
            IWebElement checkbox = GetWidgetTemplateInputElement(itemName1, itemName2);
            if (IsWidgetTemplateChecked(itemName1, itemName2))
            {
                checkbox.Click();  
            } 
        }
        // common checkbox check
        public void CommonCheck(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElement(itemName);

            if (!IsCommonChecked(itemName))
                checkbox.Click();
        }

        public void CommonUnCheck(string itemName)
        {
            IWebElement checkbox = GetCheckBoxInputElement(itemName);
            try
            {
                if (IsCommonChecked(itemName))
                {
                    checkbox.Click();
                }
            }
            catch (Exception)
            {

            }

        }
        // common uncheckbox check
        public Boolean IsCommonUnCheck(string itemName)
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
        
        private IWebElement GetWidgetTemplateInputElement(string itemResourceVariable1, string itemResourceVariable2)
        {
            Hashtable variables = new Hashtable() { { ITEMRESOURCEVARIABLE1, itemResourceVariable1 }, { ITEMRESOURCEVARIABLE2, itemResourceVariable2 } };

            return FindChild(Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxWidgetTemplateInput), variables));
        }
        private IWebElement GetWidgetTemplateFieldElement(string itemResourceVariable1, string itemResourceVariable2)
        {
            Hashtable variables = new Hashtable() { { ITEMRESOURCEVARIABLE1, itemResourceVariable1 }, { ITEMRESOURCEVARIABLE2, itemResourceVariable2 } };

            return FindChild(Locator.GetVariableLocator(ControlLocatorRepository.GetLocator(ControlLocatorKey.CheckBoxWidgetTemplateTable), variables));
        }

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

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Constants;
using System.Collections;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Element locator string and location type
    /// </summary>
    public class Locator
    {
        /// <value>Value is element locator string</value>
        public string Value { get; set; }
        /// <value>Type is element location type, which is enumeration</value>
        public ByType Type { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Locator()
        { 
        }

        /// <summary>
        /// Another consturctor which initialize the 2 values
        /// </summary>
        /// <param name="value">Element locator string</param>
        /// <param name="byType">Element location type</param>
        public Locator(string value,ByType byType)
        {
            Value = value;
            Type = byType;
        }

        public static Locator GetVariableLocator(string locatorFormat, ByType locatorType, string variableName, string variableValue)
        {
            return GetVariableLocator(locatorFormat, locatorType, new Hashtable() { { variableName, variableValue } });
        }
        
        public static Locator GetVariableLocator(string locatorFormat, ByType locatorType, Hashtable variables)
        {
            string locatorValue = locatorFormat;
            foreach (var variableName in variables.Keys)
                locatorValue = locatorValue.Replace(Project.VARIABLEPREFIX + variableName.ToString(), variables[variableName].ToString());

            return new Locator(locatorValue, locatorType);
        }

        public By ToBy()
        {
            var type = this.Type;
            var locatorValue = this.Value;

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
    }
}

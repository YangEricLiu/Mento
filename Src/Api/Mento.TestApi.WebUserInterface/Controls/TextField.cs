using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class TextField : JazzControlBase
    {

        /// <summary>
        /// Fill the text to object text field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void FillIn(string obj, string content)
        {
            var locator = ElementDictionary[obj];

            ElementLocator.FindElement(locator).Clear();
            ElementLocator.FindElement(locator).SendKeys(content);
        }

        /// <summary>
        /// Append the text to object text field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Append(string obj, string content)
        {
            var locator = ElementDictionary[obj];

            ElementLocator.FindElement(locator).SendKeys(content);
        }

        /// <summary>
        /// Get the text field value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>the text value in the text field</returns>
        public string GetValue(string obj)
        {
            var locator = ElementDictionary[obj];

            return ElementLocator.FindElement(locator).GetAttribute("value");
        }
    }
}

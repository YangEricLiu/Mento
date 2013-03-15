using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// TextField is an Input or TextArea
    /// </summary>
    public class TextField : JazzControl
    {
        public TextField(Locator locator) : base(locator) { }

        /// <summary>
        /// Judge whether the textfield and its label are hidden
        /// </summary>
        /// <returns>True if it is hidden, false if not</returns>
        public Boolean IsTextFieldHidden()
        {
            return Exists(ControlLocatorRepository.GetLocator(ControlLocatorKey.TextFieldHiddenTable));
        }

        /// <summary>
        /// Fill the text to object text field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Fill(string content)
        {
            if (content != null)
            {
                this.RootElement.Clear();
                this.RootElement.SendKeys(content);
            }
        }

        /// <summary>
        /// Append the text to object text field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Append(string content)
        {
            if (content != null)
            {
                this.RootElement.SendKeys(content);
            }
        }

        /// <summary>
        /// Get the text field value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>the text value in the text field</returns>
        public string GetValue()
        {
            return this.RootElement.GetAttribute("value");
        }

        /// <summary>
        /// Return whether the value in text field is invalid
        /// </summary>
        /// <returns>True if invalid</returns>
        public bool IsTextFieldValueInvalid()
        {
            string invalid = this.RootElement.GetAttribute("aria-invalid");

            return String.Equals(invalid, "true", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Return the invalid input tooltips info
        /// </summary>
        /// <returns>the invalid input tooltips info</returns>
        public string GetInvalidTips()
        {
            return this.RootElement.GetAttribute("data-errorqtip");
        }

        /// <summary>
        /// Return whether the text field displayed 
        /// </summary>
        /// <returns>True if displayed</returns>
        public Boolean IsFieldDisplayed()
        {
            return this.RootElement.Displayed;
        }
    }
}

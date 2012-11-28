using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class TextField : JazzControl
    {
        public TextField(Locator locator) : base(locator) { }


        /// <summary>
        /// Fill the text to object text field, clear the field first, then input text
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Fill(string content)
        {
            this.RootElement.Clear();
            this.RootElement.SendKeys(content);
        }

        /// <summary>
        /// Append the text to object text field, not clear the field first, input text to the end
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void Append(string content)
        {
            this.RootElement.SendKeys(content);
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    /// <summary>
    /// Include the basic action of the toggle button.
    /// </summary>
    /// <remarks>Inherited from control base class.</remarks>
    public class ToggleButton : Button
    {
        public ToggleButton(Locator locator) : base(locator) { }

        /// <summary>
        /// Judge whether the toggle button is pressed
        /// </summary>
        /// <param name="buttonLocator"></param>
        /// <returns>True if the toggle button is pressed, false if not</returns>
        public Boolean IsButtonPressed()
        {
            return this.RootElement.GetAttribute("class").Contains("x-pressed x-btn-pressed");
        }
    }
}

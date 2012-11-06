using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Get the instance of the special control.
    /// </summary>
    public class ControlAccess
    {
        /// <summary>
        /// Get the instance of the special control.
        /// </summary>
        /// <returns>The instance of one special control</returns>
        public static T GetControl<T>() where T : JazzControlBase, new()
        {
            return new T();
        }
    }
}

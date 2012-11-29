using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public abstract class JazzControlCollection 
    {
        protected static T GetControl<T>(string key) where T : JazzControl
        {
            return String.IsNullOrEmpty(key) ? JazzControl.GetControl<T>() : JazzControl.GetControl<T>(locator: JazzControlLocatorRepository.GetLocator(key));
        }
    }
}

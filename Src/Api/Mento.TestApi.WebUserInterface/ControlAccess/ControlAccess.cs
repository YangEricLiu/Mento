using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class ControlAccess
    {
        public static T GetControl<T>() where T : new()
        {
            return new T();
        }
    }
}

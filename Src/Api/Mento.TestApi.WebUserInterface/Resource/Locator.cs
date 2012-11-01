using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class Locator
    {
        public string Value { get; set; }
        public ByType Type { get; set; }

        public Locator()
        { 
        }

        public Locator(string value,ByType byType)
        {
            Value = value;
            Type = byType;
        }
    }
}

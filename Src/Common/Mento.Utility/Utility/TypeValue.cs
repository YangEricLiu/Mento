using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility.Utility
{
    public enum byType
    {
        ID = 1,
        Name = 2,
        Xpath = 3,
        ClassName = 4,
        CssSelector = 5,
        LinkText = 6,
        PartialLinkText = 7,
        TagName = 8
    };
    
    public class TypeValue
    {
        public string value {get; set;}
        public byType type { get; set; }
    }
}

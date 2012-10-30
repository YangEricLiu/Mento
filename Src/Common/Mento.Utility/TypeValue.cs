using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public enum ByType
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
        public ByType type { get; set; }
    }
}

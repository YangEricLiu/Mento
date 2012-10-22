using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility.Utility
{
    public enum elementType
    {
        ID = 1,
        Name = 2,
        Xpath = 3
    };
    
    public class TypeValue
    {
        public string value {get; set;}
        public elementType type { get; set; }
    }
}

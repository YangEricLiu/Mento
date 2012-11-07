using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Enumeration of element location type
    /// </summary>
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
}

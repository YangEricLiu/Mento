using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class TreeView : ControllerBase
    {
        public static Boolean IsExpand(string nodeName)
        {
            string nodeExpandPath = "xxnodeName";//here should get the xpath of tree child node expand or not according to tree node name

            return ElementLocator.IsElementPresent(nodeExpandPath, byType.Xpath);
        }

        public static void Expand(string nodeName)
        {
            string nodePath = "xxnodeName";//here should get the xpath of tree child node according to tree node name

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, byType.Xpath);

            ElementLocator.FocusOn(nodeLocator);

            if (!IsExpand(nodeName))
            {
                ElementLocator.DoubleClick(nodeLocator);
            }
        }

        public static void Collapse(string nodeName)
        {
            string nodePath = "xxnodeName";//here should get the xpath of tree child node according to tree node name

            IWebElement nodeLocator = ElementLocator.FindElement(nodePath, byType.Xpath);

            ElementLocator.FocusOn(nodeLocator);

            if (IsExpand(nodeName))
            {
                ElementLocator.DoubleClick(nodeLocator);
            }
        }
    }
}

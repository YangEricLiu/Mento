using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public class SystemDimensionTree : TreeView
    {
        public static Boolean IsNodeSelected(string treeNodeName)
        {
            string checkedNodeButton = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Value.Replace(ManualElementName.dimensionNodeName, treeNodeName);
            ByType type = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Type;

            var typeValue = ElementDi

            return ElementLocator.FindElement(checkedNodeButton, type).Selected;
        }
        
        public static void CheckedBox(string treeNodeName)
        {
            if (!IsNodeSelected(treeNodeName))
            {
                string checkedNodeButton = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Value.Replace(ManualElementName.dimensionNodeName, treeNodeName);
                ByType type = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Type;

                ElementLocator.FindElement(checkedNodeButton, type).Click();
            }
        }

        public static void UnCheckedBox(string treeNodeName)
        {
            if (IsNodeSelected(treeNodeName))
            {
                string checkedNodeButton = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Value.Replace(ManualElementName.dimensionNodeName, treeNodeName);
                ByType type = DictDataLoad.dictElement[ElementKey.CheckNodeButton].Type;

                ElementLocator.FindElement(checkedNodeButton, type).Click();
            }
        }
    }
}

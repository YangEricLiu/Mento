using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class Element
    {
        private static Dictionary<string, TypeValue> dictElement = XMLHelper.GetElementMapValue();
        private static Dictionary<string, TypeValue> dictManualElement = XMLHelper.GetManualElementValue();

        public static string LoginName
        {
            get
            {
                return dictElement[ElementKey.LoginName].value;
            }
        }

        public static string LoginPassword
        {
            get
            {
                return dictElement[ElementKey.LoginPassword].value;
            }
        }

        public static string TreeNode
        {
            get
            {
                return dictManualElement[ElementKey.TreeNode].value;
            }
        }

        public static string FormulaField
        {
            get
            {
                return dictElement[ElementKey.FormulaField].value;
            }
        }

        public static string IsTreeNodeExpand
        {
            get
            {
                return dictManualElement[ElementKey.IsTreeNodeExpand].value;
            }
        }

        public static string TagNameRow
        {
            get
            {
                return dictManualElement[ElementKey.TagNameRow].value;
            }
        }
    }
}

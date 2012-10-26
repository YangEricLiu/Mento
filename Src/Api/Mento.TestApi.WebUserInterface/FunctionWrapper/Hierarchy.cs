using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;

namespace Mento.TestApi.WebUserInterface
{
    public class Hierarchy
    {
        private TreeView treeViewInstance = ControlAccess.GetControl<TreeView>();
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();

        private void PrepareToAddNode(string treeNodeName)
        {
            string addHierarchyButton = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].value;
            byType type = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].type;

            treeViewInstance.FocusOnTreeNode(treeNodeName);

            ElementLocator.FindElement(addHierarchyButton, type).Click();
        }

        public void AddHierarchynode(string treeNodeName, InputTestDataBase input)
        {
            PrepareToAddNode(treeNodeName);

            
        }
    }
}

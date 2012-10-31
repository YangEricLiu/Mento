using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration.Hierarchy.HierarchyManagement;

namespace Mento.ScriptCommon.Library.Functions
{
    public class Hierarchy
    {
        private TreeView treeViewInstance = ControlAccess.GetControl<TreeView>();
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();

        private void PrepareToAddNode(string treeNodeName)
        {
            string addHierarchyButton = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].value;
            ByType type = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].type;

            treeViewInstance.FocusOnTreeNode(treeNodeName);

            ElementLocator.FindElement(addHierarchyButton, type).Click();
        }

        public void ClickSaveButton()
        {
            string buttonLocator = DictDataLoad.dictElement[ElementKey.SaveButton].value;
            ByType type = DictDataLoad.dictElement[ElementKey.SaveButton].type;

            ElementLocator.FindElement(buttonLocator, type);
        }

        public void ClickCancelButton()
        {
            string buttonLocator = DictDataLoad.dictElement[ElementKey.CancelButton].value;
            ByType type = DictDataLoad.dictElement[ElementKey.CancelButton].type;

            ElementLocator.FindElement(buttonLocator, type);
        }

        public void AddHierarchyNode(string treeNodeName, HierarchyInputData input)
        {
            PrepareToAddNode(treeNodeName);

            textFieldInstance.FillIn(ElementKey.HierarchyName, input.Name);
            textFieldInstance.FillIn(ElementKey.HierarchyCode, input.Code);
            comboBoxInstance.DisplayItems(ElementKey.HierarchyType);
            comboBoxInstance.SelectItem(ElementKey.Orgnization);
            textFieldInstance.FillIn(ElementKey.HierarchyComment, input.Comment);

            ClickSaveButton();
        }

        public void WaitForCreateOKDisplay(int timeout)
        { 
            string CreateOK = DictDataLoad.dictElement[ElementKey.CreateOKText].value;
            ByType type = DictDataLoad.dictElement[ElementKey.CreateOKText].type;

            ElementLocator.WaitForElement(CreateOK, type, timeout);
        }

        public void ConfirmCreateOKMagBox()
        {
            string OKButton = DictDataLoad.dictElement[ElementKey.OKButton].value;
            ByType type = DictDataLoad.dictElement[ElementKey.OKButton].type;

            ElementLocator.FindElement(OKButton, type).Click();
        }
    }
}

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
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

        private TreeView treeViewInstance = ControlAccess.GetControl<TreeView>();
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();

        private void PrepareToAddNode(string treeNodeName)
        {
            //string addHierarchyButton = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].value;
            //ByType type = DictDataLoad.dictElement[ElementKey.AddHierarchyButton].type;
            var locator = ElementDictionary[ElementKey.AddHierarchyButton];

            treeViewInstance.FocusOnTreeNode(treeNodeName);

            ElementLocator.FindElement(locator).Click();
        }

        public void ClickSaveButton()
        {
            //string buttonLocator = DictDataLoad.dictElement[ElementKey.SaveButton].value;
            //ByType type = DictDataLoad.dictElement[ElementKey.SaveButton].type;
            var locator = ElementDictionary[ElementKey.SaveButton];

            ElementLocator.FindElement(locator);
        }

        public void ClickCancelButton()
        {
            //string buttonLocator = DictDataLoad.dictElement[ElementKey.CancelButton].value;
            //ByType type = DictDataLoad.dictElement[ElementKey.CancelButton].type;
            var locator = ElementDictionary[ElementKey.CancelButton];

            ElementLocator.FindElement(locator);
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
            //string CreateOK = DictDataLoad.dictElement[ElementKey.CreateOKText].value;
            //ByType type = DictDataLoad.dictElement[ElementKey.CreateOKText].type;
            var locator = ElementDictionary[ElementKey.CreateOKText];

            ElementLocator.WaitForElement(locator, timeout);
        }

        public void ConfirmCreateOKMagBox()
        {
            //string OKButton = DictDataLoad.dictElement[ElementKey.OKButton].value;
            //ByType type = DictDataLoad.dictElement[ElementKey.OKButton].type;
            var locator = ElementDictionary[ElementKey.OKButton];

            ElementLocator.FindElement(locator).Click();
        }
    }
}

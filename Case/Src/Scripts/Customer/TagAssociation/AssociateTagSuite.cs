using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagAssociation
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-24")]
    [ManualCaseID("TC-J1-FVT-TagAssociation-Associate")]
    public class AssociateTagSuite : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Association.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            Association.NavigateToNonAssociate();
        }

        private void AssociateOnWhichNode(AssociateTagData input)
        {
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            if (input.InputData.SystemDimensionPath != null)
            {
                //Navigate to systemdimension
                Association.NavigateToSystemDimensionAssociate();
                SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            }

            if (input.InputData.AreaDimensionPath != null)
            {
                //Navigate to areadimension
                Association.NavigateToAreaDimensionAssociate();
                AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            }       
        }

        private void CheckEVOnWhichNode(AssociateTagData input)
        {
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            if (input.InputData.SystemDimensionPath != null)
            {
                //Navigate to systemdimension
                //JazzFunction.EnergyAnalysisPanel.
                SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            }

            if (input.InputData.AreaDimensionPath != null)
            {
                //Navigate to areadimension
                Association.NavigateToAreaDimensionAssociate();
                AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-001-1")]
        public void AssociateThenCancel(AssociateTagData input)
        {
            //navigate and select node
            AssociateOnWhichNode(input);
            
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Do not select tag and click "Cancel" button directly
            Association.ClickCancelButton();
            TimeManager.ShortPause();

            //verify go back to the previous page
            Assert.IsTrue(Association.IsAssociateTagButtonDisplayed());

            //Select 2 tags and cancel
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Association.CheckedTags(input.InputData.TagNames);
            Association.ClickCancelButton();
            TimeManager.ShortPause();

            //verify go back to the previous page
            Assert.IsTrue(Association.IsAssociateTagButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-001-2")]
        public void NotSupportAssociateNode(AssociateTagData input)
        {
            //navigate and select node
            AssociateOnWhichNode(input);

            //verify can not associate
            Assert.IsFalse(Association.IsAssociateTagButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-001-3")]
        public void AssociatedSameTagFailed(AssociateTagData input)
        {
            //navigate and select node
            AssociateOnWhichNode(input);

            //verify can associated
            Assert.IsTrue(Association.IsAssociateTagButtonDisplayed());

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            //Click associate tag button
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check if tag existed
            Assert.IsFalse(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-001-4")]
        public void ModifyToSameAssociatedTagFailed(AssociateTagData input)
        {
            //navigate to ptag setting
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            TimeManager.MediumPause();

            //select the ptag and modify it 
            JazzFunction.PTagSettings.FocusOnPTagByName(input.InputData.TagNames[0]);
            JazzFunction.PTagSettings.ClickModifyButton();
            JazzFunction.PTagSettings.FillInName(input.InputData.TagNames[1]);

            JazzFunction.PTagSettings.ClickSaveButton();
            TimeManager.LongPause();

            //Check if message displayed
            Assert.IsTrue(JazzFunction.PTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData.CommonName));

            //navigate to vtag setting
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            TimeManager.MediumPause();

            //select the vtag and modify it 
            JazzFunction.VTagSettings.FocusOnVTagByName(input.InputData.TagNames[2]);
            JazzFunction.VTagSettings.ClickModifyButton();
            JazzFunction.VTagSettings.FillInName(input.InputData.TagNames[3]);

            JazzFunction.VTagSettings.ClickSaveButton();
            TimeManager.LongPause();

            //Check if message displayed
            Assert.IsTrue(JazzFunction.VTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData.CommonName));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-101-1")]
        public void AssociateTagsThenVerify(AssociateTagData input)
        {
            //navigate and select node
            AssociateOnWhichNode(input);

            //Select 3 tags and removed 2, then click "associate"
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            Association.CheckedTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //check the removed tags disappeared and unchecked 
            Association.RemoveTags(input.InputData.RemovedTagNames);
            TimeManager.ShortPause();

            foreach (string tagName in input.InputData.RemovedTagNames)
            {
                Assert.IsFalse(Association.IsRemoveTagExisted(tagName));
            }

            foreach (string tagName in input.InputData.RemovedTagNames)
            {
                Assert.IsFalse(Association.IsTagChecked(tagName));
            }
            
            Association.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));
            Assert.IsFalse(Association.IsTagOnAssociatedGridView(input.InputData.RemovedTagNames[0]));
            Assert.IsFalse(Association.IsTagOnAssociatedGridView(input.InputData.RemovedTagNames[1]));
            
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.TagName);
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-101-2")]
        public void AssociatedSameTagSuccessed(AssociateTagData input)
        {
            //Select building node
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            //Navigate to system dimension node and associate vtag 
            Association.NavigateToSystemDimensionAssociate();
            SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            TimeManager.ShortPause();

            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            Association.CheckedTag(input.InputData.TagName);
            TimeManager.ShortPause();

            Association.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            //Navigate to areadimension node and associate vtag
            Association.NavigateToAreaDimensionAssociate();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            TimeManager.ShortPause();

            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            Association.CheckedTag(input.InputData.TagName);
            TimeManager.ShortPause();

            Association.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            //Check the tag has been associated to these 2 node correctly
            Association.NavigateToSystemDimensionAssociate();
            SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();

            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            Association.NavigateToAreaDimensionAssociate();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();

            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-101-3")]
        public void NoAffectOnFormulaOrChart(AssociateTagData input)
        {
            string formulaValue = "{ptag|PtagCheckAssoc101_3}*2";

            //Select building node
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            //Associate ptag to this hierarchy node
            Association.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            Association.CheckedTag(input.InputData.TagName);
            TimeManager.ShortPause();

            Association.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Check on vtag formula
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            TimeManager.ShortPause();
            JazzFunction.VTagSettings.FocusOnVTagByName(input.ExpectedData.TagName);
            TimeManager.ShortPause();
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            TimeManager.ShortPause();
            Assert.AreEqual(formulaValue, JazzFunction.VTagSettings.GetFormulaValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-101-4")]
        public void FilterTagsWhileAssociatingTags(AssociateTagData input)
        {
            //Select one hierarchy node. 
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            //Click  '关联数据点'  button.
            Association.ClickAssociateTagButton();

            //Select some tags
            Association.CheckedTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //The tags can be display in 已选数据点.
            foreach (string tagName in input.InputData.TagNames)
            {
                Assert.IsTrue(Association.IsRemoveTagExisted(tagName));
            }

            //Click 关联状态 button.可关联 checkbox is checked and all the available tag is list.
            Assert.IsTrue(Association.IsCheckedAssociated(input.InputData.HeaderName[0]));
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Check 不可关联 checkbox.
            Association.UncheckAssociatedCheckbox(input.InputData.HeaderName[0]);
            Association.CheckAssociatedCheckbox(input.InputData.HeaderName[1]);

            //• Loading icon appear and check box is gray and cannot be select.
            TimeManager.LongPause();
            Association.IsAllTagsDisabled();
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.ExpectedData.TagName));//The tag in grid when check 可关联,why it in grid when check 不可关联?

            //Check 可关联 checkbox again.
            Association.CheckAssociatedCheckbox(input.InputData.HeaderName[0]);
            Association.UncheckAssociatedCheckbox(input.InputData.HeaderName[1]);       
            TimeManager.LongPause();

            //• Checkboxes of the tags selected in step3 are still checked.
            Assert.IsTrue(Association.IsTagChecked(input.InputData.TagNames[0]));

            //Select one tag of 可关联 and then click 关联 button.
            Association.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(Association.IsTagOnAssociatedGridView(input.InputData.TagNames[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Associate-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AssociateTagSuite), "TC-J1-FVT-TagAssociation-Associate-101-5")]
        public void VerifyTooltipOfAssociatedTags(AssociateTagData input)
        {
            //Select one hierarchy node. 
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            Association.FloatOnDisassociateButton(input.InputData.TagName);
            Assert.AreEqual(input.ExpectedData.AssociatedTooltips[0], Association.GetAssociateInfo());

            //Change the Tag1 from unlight to light.
            Association.LightenTag(input.InputData.TagName);
            TimeManager.MediumPause();

            //The tooltip can be display with "解除与以下节点的关联关系xxx/xxx." well.
            Association.FloatOnDisassociateButton(input.InputData.TagName);
            Assert.AreEqual(input.ExpectedData.AssociatedTooltips[0], Association.GetAssociateInfo());

            //Change the Tag1 from light to unlight.
            Association.DarkenTag(input.InputData.TagName);
            TimeManager.MediumPause();

            //The tooltip can be display with "解除与以下节点的关联关系xxx/xxx." well.
            Association.FloatOnDisassociateButton(input.InputData.TagName);
            Assert.AreEqual(input.ExpectedData.AssociatedTooltips[0], Association.GetAssociateInfo());

            //Mouse over the 关联状态 button of Tag2.
            Association.NavigateToAreaDimensionAssociate();
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();
            Association.FloatOnDisassociateButton(input.InputData.TagNames[0]);
            Assert.AreEqual(input.ExpectedData.AssociatedTooltips[1], Association.GetAssociateInfo());

            Association.NavigateToSystemDimensionAssociate();
            SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();
            Association.FloatOnDisassociateButton(input.InputData.TagNames[0]);
            Assert.AreEqual(input.ExpectedData.AssociatedTooltips[1], Association.GetAssociateInfo());
        }
    }
}

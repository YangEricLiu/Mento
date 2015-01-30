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
    [Owner("Greenie")]
    [CreateTime("2013-08-21")]
    [ManualCaseID("TC-J1-FVT-TagAssociation-Disassociate-101")]
    public class DisassociateTagSuite : TestSuiteBase
    {
        private AssociateSettings AssociateSettings = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaNodeSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemNodeSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            AssociateSettings.AssociateTagCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            AssociateSettings.AssociateTagCaseTearDown();
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        public void DisassociateTagVerify(AssociateTagData input)
        {
            //navigate and select node
            //AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            
            int i =0;
            while (i<=3)
            {
                AssociateSettings.NavigateToHierarchyAssociate();
                string[] HierarchyNewPath = new string[i+1];
                Array.Copy(input.InputData.HierarchyNodePath, HierarchyNewPath, i + 1);
                Assert.IsTrue(AssociateSettings.SelectHierarchyNodePath(HierarchyNewPath));
                //AssociateSettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[i]);
                //Navigate to system dimension node and disassociate ptag 
                //Select one hierarchy building node, select a associated tag and click  '解除关联'  button.
                AssociateSettings.FocusOnTag(input.InputData.TagNames[i]);
                AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[i]);
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.ShortPause();
                // It disappears from the associated grid and it appears in the unassociated grid;
                Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[i]));
                AssociateSettings.ClickAssociateTagButton();
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[i]));
                //Associate this tag again
                AssociateSettings.CheckedTag(input.InputData.TagNames[i]);
                AssociateSettings.ClickAssociateButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();
                Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[i]));
                AssociateSettings.ClickAssociateTagButton();
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[i]));
                AssociateSettings.ClickCancelButton();
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                //Go to Energy Usage Analysis, select above hierarchy node then select ‘全部数据点’ try to find the above tag.

                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
                JazzFunction.EnergyAnalysisPanel.SelectHierarchy(HierarchyNewPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.LongPause();
                Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[i]));

                i++;
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-2")]
        public void DisassociateOnDimension(AssociateTagData input)
        {
            //Find a tag which has been associated with a system dimension node and a area dimension node.
            AssociateSettings.NavigateToAreaDimensionAssociate();
            AreaNodeSettings.ShowHierarchyTree();
            AreaNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaNodeSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[0]));

            //Disassociate the tag on the condition of the system dimension node only.
            AssociateSettings.NavigateToSystemDimensionAssociate();
            SystemNodeSettings.ShowHierarchyTree();
            SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            AssociateSettings.FocusOnTag(input.InputData.TagNames[0]);
            AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[0]);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Check if the tag disassociation can be inflected in tag chart
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //select ‘全部数据点’ try to find the above tag.
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[0]));
            //Select '区域数据点' try to find the above tag.
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[0]));
            //select '系统数据点' try to find the above tag.
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SelectSystemDimension(input.InputData.SystemDimensionPath);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-3")]
        public void DisassociateMoreTags(AssociateTagData input)
        {
            //navigate and select node
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Navigate to system dimension node and disassociate ptag 
            int i = 0;
            while (i < input.InputData.TagNames.Length)
            {
                AssociateSettings.FocusOnTag(input.InputData.TagNames[i]);
                TimeManager.ShortPause();
                AssociateSettings.ClickDisassociateButton(input.InputData.TagNames[i]);
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();
                Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[i]));
                i++;
            }
          
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            i = 0;
            while (i < input.InputData.TagNames.Length)
            {
                Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[i]));
                i++;
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-4")]
        public void DisassociateTagWhichAssociatedToMultipleNodes(AssociateTagData input)
        {
            //select a tag which has been associated to two nodes (system node and area node)，click 解除关联 button.
            AssociateSettings.NavigateToSystemDimensionAssociate();
            SystemNodeSettings.ShowHierarchyTree();
            SystemNodeSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemNodeSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);
            TimeManager.MediumPause();

            AssociateSettings.FocusOnTag(input.InputData.TagName);
            AssociateSettings.ClickDisassociateButton(input.InputData.TagName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Go to the Area Dimension and select 可关联 checkbox.
            AssociateSettings.NavigateToAreaDimensionAssociate();
            AreaNodeSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);
            TimeManager.MediumPause();

            //Click  '关联数据点'  button.
            AssociateSettings.ClickAssociateTagButton();
            Assert.IsTrue(AssociateSettings.IsCheckedAssociated(input.InputData.HeaderName[0]));

            //The tag is list in there.
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Select 不可关联 checkbox.
            AssociateSettings.CheckAssociatedCheckbox(input.InputData.HeaderName[1]);
            TimeManager.ShortPause();
            AssociateSettings.UncheckAssociatedCheckbox(input.InputData.HeaderName[0]);

            //The tag is not list in there.
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-5")]
        public void DisassociateTagWhileOnAssociatingTagsPage(AssociateTagData input)
        {
            //Select one hierarchy node. 
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            //Click  '关联数据点'  button.
            AssociateSettings.ClickAssociateTagButton();

            //Select some tags
            AssociateSettings.CheckedTags(input.InputData.TagNames);
            TimeManager.ShortPause();

            //The tags can be display in 已选数据点.
            foreach (string tagName in input.InputData.TagNames)
            {
                Assert.IsTrue(AssociateSettings.IsRemoveTagExisted(tagName));
            }

            //Click 关联状态 button.可关联 checkbox is checked and all the available tag is list.
            Assert.IsTrue(AssociateSettings.IsCheckedAssociated(input.InputData.HeaderName[0]));
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Check 不可关联 checkbox.
            AssociateSettings.CheckAssociatedCheckbox(input.InputData.HeaderName[1]);
            TimeManager.ShortPause();
            AssociateSettings.UncheckAssociatedCheckbox(input.InputData.HeaderName[0]);      
            TimeManager.LongPause();

            //• Loading icon appear and check box is gray and cannot be select.
            TimeManager.LongPause();
            AssociateSettings.IsAllTagsDisabled();
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            //Click 解除关联 button in one tag which is associatied with one node.
            AssociateSettings.FocusOnTag(input.ExpectedData.TagName);
            TimeManager.ShortPause();
            AssociateSettings.ClickDisassociateButton(input.ExpectedData.TagName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Select checkbox of the tag disassociated in step6
            AssociateSettings.CheckAssociatedCheckbox(input.InputData.HeaderName[0]);
            TimeManager.ShortPause();
            AssociateSettings.UncheckAssociatedCheckbox(input.InputData.HeaderName[1]);
            TimeManager.LongPause();

            AssociateSettings.CheckedTag(input.ExpectedData.TagName);
            TimeManager.ShortPause();

            //The tag is displayed in '已选数据点' as well.
            Assert.IsTrue(AssociateSettings.IsRemoveTagExisted(input.ExpectedData.TagName));

            //Refresh the tag list or switch to other pages then switch back. The tag which was dissociated in step6 disappeared from '不可关联' list now.
            AssociateSettings.CheckAssociatedCheckbox(input.InputData.HeaderName[1]);
            TimeManager.ShortPause();
            AssociateSettings.UncheckAssociatedCheckbox(input.InputData.HeaderName[0]);      
            TimeManager.LongPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            //Click 关联 button.
            AssociateSettings.ClickAssociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.TagName));
            Assert.IsTrue(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagNames[0]));
        }
    }
}

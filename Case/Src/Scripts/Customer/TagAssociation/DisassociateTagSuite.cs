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
            AssociateSettings.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(DisassociateTagSuite), "TC-J1-FVT-TagAssociation-Disassociate-101-1")]
        public void DisassociateTagVerify(AssociateTagData input)
        {
            //navigate and select node
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            string[] HierarchyNewPath = new string[input.InputData.HierarchyNodePath.Length];
            Array.Copy(input.InputData.HierarchyNodePath,HierarchyNewPath,input.InputData.HierarchyNodePath.Length);
            int i =3;
            while (i>0)
            {
                AssociateSettings.SelectHierarchyNodePath(HierarchyNewPath);
                AssociateSettings.SelectHierarchyNode(input.InputData.HierarchyNodePath[i]);
                //Navigate to system dimension node and disassociate ptag 
                //Select one hierarchy building node, select a associated tag and click  '解除关联'  button.
                AssociateSettings.FocusOnTag(input.InputData.TagNames[i]);
                AssociateSettings.ClickDisassociateButton();
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
                Array.Copy(input.InputData.HierarchyNodePath, HierarchyNewPath, i+1);
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
                Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.SelectHierarchy(HierarchyNewPath));
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[i]));
                AssociateSettings.NavigateToHierarchyAssociate();
                i--;
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
            AssociateSettings.ClickDisassociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.InputData.TagName));

            //Check if the tag disassociation can be inflected in tag chart
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //select ‘全部数据点’ try to find the above tag.
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[0]));
            //Select '区域数据点' try to find the above tag.
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.TagNames[0]));
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
                AssociateSettings.ClickDisassociateButton();
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
    
    }
}

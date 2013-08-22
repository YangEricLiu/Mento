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
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

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
            //navigate and select node
            AssociateSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Navigate to system dimension node and disassociate ptag 
            AssociateSettings.FocusOnTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            AssociateSettings.ClickDisassociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            AssociateSettings.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            AssociateSettings.CheckedTag(input.ExpectedData.TagName);
            Assert.IsTrue(AssociateSettings.IsTagChecked(input.ExpectedData.TagName));

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.TagName));

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
            AssociateSettings.FocusOnTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();

            AssociateSettings.ClickDisassociateButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.TagName));

            AssociateSettings.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            AssociateSettings.CheckedTag(input.ExpectedData.TagName);
            Assert.IsTrue(AssociateSettings.IsTagChecked(input.ExpectedData.TagName));

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.TagName));

        }
    
    }
}

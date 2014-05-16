using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.Library;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-04")]
    [ManualCaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate")]
    public class DisassociateSytemDimension : TestSuiteBase
    {
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;

        [SetUp]
        public void ScriptSetUp()
        {
            SystemSettings.NavigateToSystemDimension();
            TimeManager.LongPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz();
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(DisassociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-1")]
        public void DisassociateNodesCancel(SystemDimensionData input)
        { 
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());
            TimeManager.ShortPause();
            //Message box popup and cancel it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.ShortPause();

            SystemSettings.CloseSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            TimeManager.MediumPause();
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(DisassociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-2")]
        public void DisssociateWithChild(SystemDimensionData input)
        {
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());
            TimeManager.MediumPause();
            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.LongPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            //SystemSettings.CloseSystemDimensionDialog();
            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            TimeManager.LongPause();
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.ExpectedData.SystemDimensionPath.Last()));
            TimeManager.MediumPause();
            if (!String.IsNullOrEmpty(input.ExpectedData.SystemDimensionNode))
            {
                Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.ExpectedData.SystemDimensionNode));
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(DisassociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Disassociate-101-1")]
        public void DisssociateWithoutChild(SystemDimensionData input)
        {
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
        
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());
            JazzMessageBox.LoadingMask.WaitLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.ShortPause();

            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Expand system dimension tree and verify the node is disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            TimeManager.LongPause();
            Assert.IsFalse(SystemSettings.IsSystemDimensionNodeDisplayed(input.ExpectedData.SystemDimensionPath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(DisassociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Disassociate-101-2")]
        public void DisssociateAndVerify(SystemDimensionData input)
        {
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            TimeManager.MediumPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //1. Expand system dimension tree and verify the node is not disassociated
            Assert.IsFalse(SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath));
            TimeManager.MediumPause();

            //2. Verify it on data association/system dimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            //SystemSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            //SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            Assert.IsFalse(SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionItemPath));
            
            //3. Verify it on energy view
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();

            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.SelectSystemDimension(input.ExpectedData.SystemDimensionPath));
        }
       
    }
}

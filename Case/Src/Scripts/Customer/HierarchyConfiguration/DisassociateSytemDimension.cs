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

        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(DisassociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Disassociate-001-1")]
        public void DisassociateNodesCancel(SystemDimensionData input)
        { 
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());

            //Message box popup and cancel it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.No();
            TimeManager.ShortPause();

            SystemSettings.CloseSystemDimensionDialog();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
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
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());

            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.OK();
            TimeManager.ShortPause();

            SystemSettings.CloseSystemDimensionDialog();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.ExpectedData.SystemDimensionPath.Last()));

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
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());

            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Yes();
            TimeManager.ShortPause();

            SystemSettings.ConfirmSystemDimensionDialog();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
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
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.disassociate system dimension node
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.UncheckSystemDimensionNodeWithoutConfirm(input.InputData.SystemDimensionItemPath.Last());

            //Message box popup and confirm it
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Message));
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Yes();
            TimeManager.ShortPause();

            SystemSettings.ConfirmSystemDimensionDialog();
            TimeManager.ShortPause();

            //1. Expand system dimension tree and verify the node is not disassociated
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsFalse(SystemSettings.IsSystemDimensionNodeDisplayed(input.ExpectedData.SystemDimensionPath.Last()));

            //2. Verify it on data association/system dimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            Assert.IsFalse(SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionItemPath));

            //3. Verify it on energy view
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.SelectSystemDimension(input.ExpectedData.SystemDimensionPath));
        }
       
    }
}

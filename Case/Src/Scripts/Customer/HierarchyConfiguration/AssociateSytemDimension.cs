using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.Library;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-04")]
    [ManualCaseID("TC-J1-FVT-SystemDimensionConfiguration-Associate")]
    public class AssociateSytemDimension : TestSuiteBase
    {
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Associate-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(AssociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Associate-101-1")]
        public void AssociateNodesCancel(SystemDimensionData input)
        { 
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //2.Associate Level 1 dimension node by select the checkbox: Select ‘动力’ checkbox.
            //The Level 1 dimension node ('动力') is associated.
            SystemSettings.CheckSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.CloseSystemDimensionDialog();
            TimeManager.MediumPause();

            //Expand system dimension tree and verify
            Assert.IsTrue(SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath));
            //Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Associate-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(AssociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Associate-101-2")]
        public void AssociateNodes(SystemDimensionData input)
        {
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Associate dimension node 
            SystemSettings.CheckSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            SystemSettings.ConfirmSystemDimensionDialog();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Associate-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(AssociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Associate-101-3")]
        public void AssociateChildNode(SystemDimensionData input)
        {
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Associate dimension node 
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            SystemSettings.CheckSystemDimensionNode(input.InputData.SystemDimensionItemPath.Last());
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }

        [Test]
        [CaseID("TC-J1-FVT-SystemDimensionConfiguration-Associate-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(AssociateSytemDimension), "TC-J1-FVT-SystemDimensionConfiguration-Associate-101-4")]
        public void AssociateAndVerify(SystemDimensionData input)
        {
            
            //Display hierarchy tree -> click hierarchy node "自动化测试"... -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Associate dimension node 
            SystemSettings.ExpandDialogSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.CheckSystemDimensionNode(input.InputData.SystemDimensionItemPath.Last());
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            SystemSettings.ConfirmSystemDimensionDialog();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Expand system dimension tree and verify
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));

            //1. Verify it is display on data associated
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            
            //SystemSettings.ShowHierarchyTree();
            //SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            //2. Verify it is display on energy analysis
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.SelectSystemDimension(input.ExpectedData.SystemDimensionPath));
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
        }
    }
}

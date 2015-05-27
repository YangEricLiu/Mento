using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Utility;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("greenie")]
    [CreateTime("2013-06-19")]
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-101")]
    public class ModifyValidAreaDimension : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;

        [SetUp]
        public void ScriptSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            AreaSettings.NavigateToNonAreaDimensionSetting();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1. add area dimension "ModifyArea1" ,"ModifyArea2" ,"ModifyArea3","ModifyArea4" ,"AreaNodeVerify" For the test
        /// </summary> 
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-101-ModifyAreaCancel")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-101-ModifyAreaCancel")]
        public void ModifyAreaCancel(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();
            
            //"Input  area name ,comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();

            // Verify the Area Node is not Modified 
            //TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //TimeManager.MediumPause();
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.MediumPause();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-101-ModifyValidAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-101-ModifyValidAreaNode")]
        public void ModifyValidAreaNode(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.AreEqual(AreaSettings.GetAreaDimensionName(),input.InputData.CommonName);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(), input.InputData.Comments);
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.LongPause();

            //Verify the area node has been created under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            TimeManager.MediumPause();
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));

        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-101-ModifyThenBack")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-101-ModifyThenBack")]
        public void ModifyThenBack(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            // Change back to initial area node
            AreaSettings.ClickModifyAreaDimensionButton();
            AreaSettings.FillAreaDimensionData(input.ExpectedData.CommonName, input.ExpectedData.Comments);
            AreaSettings.ClickSaveButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            //Verify the area node has been created under the correct hierarchy path
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.LongPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //TimeManager.MediumPause();
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.MediumPause();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            //Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath));

        }

        [Test]
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-101-ModifyValidAndVerify")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-101-ModifyValidAndVerify")]
        public void ModifyValidAndVerify(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            // click "modify" buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //check every where
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();

            //1. Check  area node Modified  on AssociationAreaDimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSettings);
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            //AreaSettings.ShowHierarchyTree();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();

            //2. Energy Analysis area node Modified
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.LongPause();
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath));
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
        }
  
    }
}

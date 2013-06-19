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
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-001")]
    public class ModifyValidAreaDimension : TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1. add area dimension "ModifyArea1" ,"ModifyArea2" ,"ModifyArea3","ModifyArea4" ,"AreaNodeVerify" For the test
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyAreaCancel")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-ModifyAreaCancel")]
        public void ModifyAreaCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            TimeManager.ShortPause();
            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.ShortPause();
            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();
            
            //"Input  area name ,comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();

            // Verify the Area Node is not Modified 
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyValidAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-ModifyValidAreaNode")]
        public void ModifyValidAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            TimeManager.MediumPause();
            AreaSettings.ShowHierarchyTree();
            TimeManager.LongPause();

            //Verify the area node has been created under the correct hierarchy path
            
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath));
            Assert.AreEqual(input.InputData.Comments, AreaSettings.GetAreaDimensionComment());
           
            
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyThenBack")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-ModifyThenBack")]
        public void ModifyThenBack(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            TimeManager.ShortPause();
            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            // Click "Modify " buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            TimeManager.LongPause();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            // Change back to initial area node
            AreaSettings.ClickModifyAreaDimensionButton();
            AreaSettings.FillAreaDimensionData(input.ExpectedData.CommonName, input.ExpectedData.Comments);
            AreaSettings.ClickSaveButton();
            TimeManager.MediumPause();
            //Verify the area node has been created under the correct hierarchy path
            AreaSettings.ShowHierarchyTree();
            TimeManager.LongPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            //Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath));

        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyValidAndVerify")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-ModifyValidAndVerify")]
        public void ModifyValidAndVerify(AreaDimensionData input)
        {
            
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();
            
            // click "modify" buttion
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            TimeManager.LongPause();

            //check every where

            //1. Check  area node Modified  on AssociationAreaDimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();
            

            
            //2. Energy Analysis area node Modified
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.LongPause();

            JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath);
            TimeManager.MediumPause();


        }
  
    }
}

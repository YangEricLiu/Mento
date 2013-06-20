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
    [CreateTime("2013-06-17")]
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-001")]
    public class DeleteAreaDimension : TestSuiteBase
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
        /// Precondition: make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1.[楼宇配置测试""DeleteArea1"] ,["楼宇配置测试","L1","L2","L3","L4",]   [  "楼宇配置测试","CheckAll"]
        ///                         2. an Vtag "VtagForAreaDimensionNode" has been assosiated under   [  "楼宇配置测试","CheckAll"]
        /// </summary>  
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-001-DeleteAreaNodeThenCancels")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-001-DeleteAreaNodeThenCancel")]
        public void DeleteAreaNodeThenCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            //Click "删除" button and "确定"
            AreaSettings.ClickDeleteButton();

            AreaSettings.ClickCancelDeleteButton();

            //Verify 
            // Verify the Area Node is not deleted
            TimeManager.LongPause();
            Assert.AreEqual(AreaSettings.GetAreaDimensionName(),input.InputData.CommonName);
            TimeManager.MediumPause();

        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteLeafAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteLeafAreaNode")]
        public void DeleteLeafAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            TimeManager.ShortPause();

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();
            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            AreaSettings.ClickDeleteConfirmButton();
            //AreaSettings

            //Verify the area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            //Assert.AreEqual(input.InputData.CommonName, AreaSettings.GetAreaDimensionName());


        }


        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteNonLeafAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteNonLeafAreaNode")]
        public void DeleteNonLeafAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            TimeManager.ShortPause();
            string[] AreaNode2 = new string[] {"楼宇配置测试","L1","L2" };
            string[] AreaNode1 = new string[] {"楼宇配置测试","L1"};
            //string Message = "删除区域维度节点“L1”吗？\r\n您将同时删除区域维度节点下所有的子节点，数据点关联关系，以及间接关联的所有信息。";

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();
            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            /*
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.GetMessage().Equals(input.ExpectedData.Message);
            TimeManager.MediumPause();
             */
            AreaSettings.ClickDeleteConfirmButton();

            //AreaSettings
            //Verify the area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath));

            //Verify the Child area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            //Assert.AreEqual(input.InputData.CommonName, AreaSettings.GetAreaDimensionName());

            
            // check  Level  1 deleted
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(AreaNode1);
            TimeManager.LongPause();
            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            /*
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.GetMessage().Equals(Message);
            TimeManager.MediumPause();
            */
            AreaSettings.ClickDeleteConfirmButton();
            //Verify the area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNode1));

            // check level 2 also deleted
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);

            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNode2));

        }



        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteandVerifyEverywhere")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteandVerifyEverywhere")]
        public void DeleteandVerifyEverywhere(AreaDimensionData input)
        {

            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();

            AreaSettings.ClickDeleteButton();
            AreaSettings.ClickDeleteConfirmButton();


            //check every where
            TimeManager.LongPause();
            //1. Check  on AssociationAreaDimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();



            //2. Energy Analysis area node added
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.LongPause();

            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();
        }
    }
}

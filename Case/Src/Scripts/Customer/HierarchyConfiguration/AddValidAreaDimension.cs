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
    public class AddValidAreaDimension : TestSuiteBase
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
        /// Prepare Data: 1. add area dimension "FirstFloor" for associate tag
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddAreaCancel")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-AddAreaCancel")]
        public void AddAreaCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();
            
            //Verify 
            Assert.AreEqual(input.ExpectedData.Message,AreaSettings.GetAreaDimensionName());
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddValidAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-AddValidAreaNode")]
        public void AddValidAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);


            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""Save"" button"	
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
            //Assert.AreEqual(input.InputData.CommonName, AreaSettings.GetAreaDimensionName());
           
            
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-FiveLevelsAreaNodes")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-FiveLevelsAreaNodes")]
        public void FiveLevelsAreaNodes(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            TimeManager.LongPause();
            int AreaNodeLength = input.ExpectedData.AreaNodePath.Length;
            for (int i = 1; i < (AreaNodeLength); i++)
            {
                              
                AreaSettings.ClickCreateAreaDimensionButton();
                AreaSettings.FillAreaDimensionData(input.ExpectedData.AreaNodePath[i], input.InputData.Comments);
                //Click "Save" button
                TimeManager.MediumPause();
                AreaSettings.ClickSaveButton(); 
                TimeManager.LongPause();

                //Verify whether
                Assert.AreEqual(input.ExpectedData.AreaNodePath[i],AreaSettings.GetAreaDimensionName());
            }

            // CreateAreaDimensionButton  is  disabled
            TimeManager.MediumPause();
            Assert.IsFalse(AreaSettings.IsCreateAreaDimensionButtonEnabled());

            // Verify the correct  areaNode is successfully created

        }


        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddLongestArea")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-AddLongestArea")]
        public void AddLongestArea(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);


            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), input.ExpectedData.CommonName);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(),input.ExpectedData.Comments);
        }


        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-OrgandSiteNodeAddArea")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-OrgandSiteNodeAddArea")]
        public void OrgandSiteNodeAddArea(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            Assert.IsFalse(AreaSettings.IsCreateAreaDimensionButtonEnabled());
            //"Input  area name: "area1", comment ,Click ""Save"" button"	
        }


        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddValidAndVerify")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-AddValidAndVerify")]
        public void AddValidAndVerify(AreaDimensionData input)
        {
            
            var AreaSettings = JazzFunction.AreaDimensionSettings;
/*
            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();
            

            //check every where

            //1. Check  area node added  on AssociationAreaDimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            Assert.IsTrue(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();
            

            */
            
            //2. Energy Analysis area node added
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();
            /*
            //3. Cost view  area node added
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CostUsage);
            TimeManager.MediumPause();
            JazzFunction.CostPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.CostPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.CostPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath));
            */

        }


        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-EmptyItemNotDisplay")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddValidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-EmptyItemNotDisplay")]
        public void EmptyItemNotDisplay(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.LongPause();

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""Save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(),string.Empty);
        }

    }
}

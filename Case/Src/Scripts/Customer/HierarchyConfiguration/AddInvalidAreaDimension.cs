﻿using System;
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
    [CreateTime("2013-06-18")]
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-001")]
    public class AddInvalidAreaDimension:TestSuiteBase
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
        /// Precondition:  1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1."AreaNodeForCheckSame "  added
        /// </summary> 
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddInvalidAreaCancel")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void AddInvalidAreaCancel(AreaDimensionData input)
        {
            
            string[] HierarchyNodePath = new string[] { "自动化测试", "测试楼宇园区", "楼宇配置测试" };
            string[] AreaNodePath = new string[] { "楼宇配置测试"};
            TimeManager.ShortPause();

            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();          
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            TimeManager.MediumPause();

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();

            // Verify the Area Node is not added 
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();

            string[] AreaNodePathNew = new string[2] ;
            AreaNodePathNew[0] = "楼宇配置测试";
            AreaNodePathNew[1] = input.InputData.CommonName;
            Assert.AreEqual(AreaNodePathNew[1], input.InputData.CommonName);

            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNodePathNew));       
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddInvalidAreaNode")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void AddInValidAreaNode(AreaDimensionData input)
        {
            string[] HierarchyNodePath = new string[]{"自动化测试","测试楼宇园区","楼宇配置测试"};
            string[] AreaNodePath = new string[]{"楼宇配置测试"};
            TimeManager.ShortPause();

            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            TimeManager.MediumPause();

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);

            TimeManager.LongPause();
            AreaSettings.ClickSaveButton();
            TimeManager.MediumPause();
            //Assert.IsFalse(AreaSettings.IsSaveButtonEnabled());

            //Verify 
            Assert.IsTrue(AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.CommonName));
            Assert.AreEqual(input.ExpectedData.Comments, AreaSettings.GetAreaDimensionComment());

            TimeManager.LongPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            TimeManager.MediumPause();
            //AreaSettings.ShowHierarchyTree();
            // TimeManager.MediumPause();
            // The Build don't need select hierarchy again 
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            //TimeManager.MediumPause();
            string[] AreaNodePathNew = new string[2];
            AreaNodePathNew[0] = "楼宇配置测试";
            AreaNodePathNew[1] = input.InputData.CommonName;
            Assert.AreEqual(AreaNodePathNew[1], input.InputData.CommonName);
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNodePathNew));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddInvalidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        public void SameAreaNodes(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            /*
            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name comment ,Click ""save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            TimeManager.MediumPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.MediumPause();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            //TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            */
            //Click "子区域" button to add same Area node.	
            AreaSettings.ClickCreateAreaDimensionButton();

            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            TimeManager.ShortPause();
            AreaSettings.ClickSaveButton();
            TimeManager.ShortPause();
            //Verify 
            AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.Message);
        }
    }
}

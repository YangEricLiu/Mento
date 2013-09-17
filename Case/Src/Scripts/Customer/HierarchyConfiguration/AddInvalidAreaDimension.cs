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
    [CreateTime("2013-06-18")]
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-001")]
    public class AddInvalidAreaDimension:TestSuiteBase
    {
         [SetUp]
        public void ScriptSetUp()
        {
             /*
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            */
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// Precondition:  1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1."AreaNodeForCheckSame "  added
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddInvalidAreaCancel")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void AddInvalidAreaCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            string[] HierarchyNodePath = new string[] { "自动化测试", "测试楼宇园区", "楼宇配置测试" };
            string[] AreaNodePath = new string[] { "楼宇配置测试"};
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
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
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            /*
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
             */
            string[] AreaNodePathNew = new string[2] ;
            AreaNodePathNew[0] = "楼宇配置测试";
            AreaNodePathNew[1] = input.InputData.CommonName;
            Assert.AreEqual(AreaNodePathNew[1], input.InputData.CommonName);
            
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNodePathNew));
            
           
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddInvalidAreaNode")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void AddInValidAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            string[] HierarchyNodePath = new string[]{"自动化测试","测试楼宇园区","楼宇配置测试"};
            string[] AreaNodePath = new string[]{"楼宇配置测试"};
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            AreaSettings.SelectHierarchyNodePath(HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
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
            Assert.IsTrue(AreaSettings.IsCommentsInvalidMsgCorrect(input.ExpectedData.Comments));

            TimeManager.LongPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
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
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddInvalidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        public void SameAreaNodes(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;

            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

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

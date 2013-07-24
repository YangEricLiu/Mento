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
    public class ModifyInvalidAreaDimension: TestSuiteBase
    {
         [SetUp]
        public void ScriptSetUp()
        {
             /*
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
              */
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// 1. add area dimension "ModifyAreaNodeForCheckSame","ModifyAreaNodeForCheckSame1" ,"AreaNodeForCheckAll" for the test
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyInvalidAreaCancel")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void ModifyInvalidAreaCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            string[] HierarchyNodePath = new string[] { "自动化测试", "测试楼宇园区", "楼宇配置测试" };
            string[] AreaNodePath = new string[] { "楼宇配置测试", "AreaNodeForCheckAll" };

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

            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name: comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();


            // Verify the Area Node is not  modified
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            //AreaSettings.ShowHierarchyTree();
            //TimeManager.MediumPause();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            //TimeManager.MediumPause();

            string[] AreaNodePathNew = new string[2] ;
            AreaNodePathNew[0] = "楼宇配置测试";
            AreaNodePathNew[1] = input.InputData.CommonName;
            Assert.AreEqual(AreaNodePathNew[1], input.InputData.CommonName);

            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNodePathNew));
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyInvalidAreaNode")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void ModifyInvalidAreaNode(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            string[] HierarchyNodePath = new string[]{"自动化测试","测试楼宇园区","楼宇配置测试"};
            string[] AreaNodePath = new string[] { "楼宇配置测试", "AreaNodeForCheckAll" };
            
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            AreaSettings.SelectHierarchyNodePath(HierarchyNodePath);
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name,comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);

            TimeManager.LongPause();
            AreaSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            //Verify 
            Assert.IsTrue(AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.CommonName));
            Assert.IsTrue(AreaSettings.IsCommentsInvalidMsgCorrect(input.ExpectedData.Comments));
            TimeManager.LongPause();

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            ///AreaSettings.ShowHierarchyTree();
            //TimeManager.MediumPause();
            //AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            //TimeManager.MediumPause();

            string[] AreaNodePathNew = new string[2];
            AreaNodePathNew[0] = "楼宇配置测试";
            AreaNodePathNew[1] = input.InputData.CommonName;
            Assert.AreEqual(AreaNodePathNew[1], input.InputData.CommonName);
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNodePathNew));
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-ModifyToSameAreaNodes")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(ModifyInvalidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-ModifyToSameAreaNodes")]
        public void ModifyToSameAreaNodes(AreaDimensionData input)
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
            AreaSettings.ClickModifyAreaDimensionButton();

            //"Input  area name, comment ,Click ""save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            TimeManager.LongPause();
            AreaSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            //Verify 
            AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.Message);
        }
    }
}

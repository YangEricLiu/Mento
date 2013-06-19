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
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-AddInvalidAreaCancel")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(AreaDimensionData[]))]
        public void AddInvalidAreaCancel(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            string[] HierarchyNodePath = new string[] { "自动化测试", "测试楼宇园区", "楼宇配置测试" };
            string[] AreaNodePath = new string[] { "楼宇配置测试" };
            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);
            TimeManager.MediumPause();

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickCancelButton();


            // Verify the Area Node is not added
            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), "楼宇配置测试");
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

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            TimeManager.ShortPause();

            //Select a Building node.	
            //The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            AreaSettings.SelectHierarchyNodePath(HierarchyNodePath);
            TimeManager.MediumPause();
            AreaSettings.SelectAreaDimensionNodePath(AreaNodePath);

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "area1", comment ,Click ""cancel"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            // @@@@@@@@@@@@@@@@@@
            AreaSettings.ClickSaveButton();
            //Assert.IsFalse(AreaSettings.IsSaveButtonEnabled());

            //Verify 
            Assert.IsTrue(AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.CommonName));
            Assert.IsTrue(AreaSettings.IsCommentsInvalidMsgCorrect(input.ExpectedData.Comments));
        }

        [Test]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AddInvalidAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-001-SameAreaNodes")]
        public void SameAreaNodes(AreaDimensionData input)
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



            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: "AreaNode1", comment ,Click ""save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            TimeManager.MediumPause();

            //AreaSettings.SelectAreaDimensionNode(input.InputData.AreaNodePath);
            AreaSettings.ClickCreateAreaDimensionButton();
            //"Input  area name: "AreaNode1", comment ,Click ""save"" button"	
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            //Verify 
            AreaSettings.IsNameInvalidMsgCorrect(input.ExpectedData.Message);
        }
    }
}

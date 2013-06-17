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
    [CreateTime("2012-11-19")]
    [ManualCaseID("TC-J1-SmokeTest-015")]
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
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        /// Prepare Data: 1. add area dimension "FirstFloor" for associate tag
        /// </summary> 
        [Test]
        [CaseID("TC-J1-SmokeTest-AreaDimension-001")]
        [Priority("16")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(SmokeTestAreaDimensionSuite), "TC-J1-SmokeTest-AreaDimension-001")]
        public void SmokeTestAddAreaDimension(AreaDimensionData input)
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

            //"Input  area name: "FirstFloor", comment ,Click ""save"" button"	
            //Add Area node successfully.
            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            TimeManager.ShortPause();

            //Assert.IsTrue(AreaSettings.IsShownSuccessMessage());

            //AreaSettings.CloseSuccessMessage();

            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), input.InputData.CommonName);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(), input.InputData.Comments);
        }
    }
}

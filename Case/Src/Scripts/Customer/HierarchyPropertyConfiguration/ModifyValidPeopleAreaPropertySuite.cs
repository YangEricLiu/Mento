using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-07")]
    [ManualCaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101")]
    public class ModifyValidPeopleAreaPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyPeopleAreaSettings PeopleAreaSetting = JazzFunction.HierarchyPeopleAreaSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }


        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-1")]
        public void ModifyWithoutChange(PeopleAreaPropertyData input)
        {
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();

            //Verify the "人口面积" tab is available and click
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.LongPause();

            //Click "+人口面积"/"修改" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.LongPause();

            //Modify nothing value and save
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify save successful
            Assert.IsFalse(PeopleAreaSetting.IsSaveButtonDisplayed());
            Assert.IsFalse(PeopleAreaSetting.IsCancelButtonDisplayed());

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), input.ExpectedData.PeopleEffectiveDate);
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), input.ExpectedData.PeopleNumber);
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.IntegerValue);
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-2")]
        public void ModifyToViewSPeopleScrollbar(PeopleAreaPropertyData input)
        {
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();

            //Verify the "人口面积" tab is available and click
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.LongPause();

            //Click "+人口面积"/"修改" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.LongPause();

            //modify population 
            PeopleAreaSetting.FillInPeopleValue(input.InputData);
            TimeManager.ShortPause(); 

            //save modify
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause(); 

            //Verify modify success
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), input.ExpectedData.PeopleEffectiveDate);
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), input.ExpectedData.PeopleNumber);
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-3")]
        public void ModifyToDeletePeopleItems(PeopleAreaPropertyData input)
        {
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();

            //Verify the "人口面积" tab is available and click
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.LongPause();

            //Click "+人口面积"/"修改" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.LongPause();

            //modify population 
            PeopleAreaSetting.FillInPeopleValue(input.InputData);
            TimeManager.ShortPause();

            //save modify
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify modify success
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), input.ExpectedData.PeopleEffectiveDate);
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), input.ExpectedData.PeopleNumber);
        }


        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-5")]
        public void PAAddValidAreaAndCheck(PeopleAreaPropertyData input)
        {
            string areaTitle = "面积属性";

            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.LongPause();

            //Verify the "人口面积" tab is available and click
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.LongPause();

            //Click "+人口面积"/"修改" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.LongPause();

            //Fill valid value to area and save
            PeopleAreaSetting.FillValidOrInvalidAreaValue(input.InputData);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //verify that area property display
            Assert.IsTrue(PeopleAreaSetting.IsAreaPropertyTitleDisplay(areaTitle));

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.IntegerValue);

            //Verify it on formula, which delay to automated
        }
    }
}

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
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-05")]
    [ManualCaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-001")]
    public class AddInvalidPeopleAreaPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyPeopleAreaSettings PeopleAreaSetting = JazzFunction.HierarchyPeopleAreaSettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySetting.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-001-1")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(PeopleAreaPropertyData[]))]
        public void AddInvalidPopulationValue(PeopleAreaPropertyData input)
        {
            string[] hierarchyPath = {"自动化测试", "AddCalendarProperty", "AddPeopleProperty"};
            
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(hierarchyPath);
            TimeManager.LongPause();

            //Verify the "人口面积" tab is available and click
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.LongPause();

            //Click "+人口面积"/"修改" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.LongPause();

            //Click "+" button at the end of population
            if (PeopleAreaSetting.GetPeopleItemsNumber() < 1)
            {
                PeopleAreaSetting.ClickPeopleCreateButton();
                TimeManager.LongPause();
            }
            
            //Input population value and save
            PeopleAreaSetting.FillValidOrInvalidPeopleValue(input.InputData);
            TimeManager.LongPause();

            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify save failed
            Assert.IsTrue(PeopleAreaSetting.IsSaveButtonDisplayed());
            Assert.IsTrue(PeopleAreaSetting.IsCancelButtonDisplayed());

            //Verify the error message displayed correctly
            Assert.IsTrue(PeopleAreaSetting.IsPeopleNumberInvalid());
            Assert.IsTrue(PeopleAreaSetting.IsPeopleNumberInvalidMsgCorrect(input.ExpectedData.IntegerValue));
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-001-2")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddInvalidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-001-2")]
        public void AddInvalidArea(PeopleAreaPropertyData input)
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

            //Fill valid value to area and save
            PeopleAreaSetting.FillInAreaValue(input.InputData);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify the error message displayed correctly
            Assert.IsTrue(PeopleAreaSetting.IsTotalAreaInvalid());
            Assert.IsTrue(PeopleAreaSetting.IsTotalAreaInvalidMsgCorrect(input.ExpectedData.TotalArea));
            Assert.IsTrue(PeopleAreaSetting.IsHeatingAreaInvalid());
            Assert.IsTrue(PeopleAreaSetting.IsHeatingAreaInvalidMsgCorrect(input.ExpectedData.HeatingArea));
            Assert.IsTrue(PeopleAreaSetting.IsCoolingAreaInvalid());
            Assert.IsTrue(PeopleAreaSetting.IsCoolingAreaInvalidMsgCorrect(input.ExpectedData.CoolingArea));
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-001-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddInvalidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-001-3")]
        public void AddEmptyAndInvalidPopulation(PeopleAreaPropertyData input)
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

            //Click "+" button at the end of population
            PeopleAreaSetting.ClickPeopleCreateButton();
            TimeManager.LongPause();

            //Scroll to the bottom
            PeopleAreaSetting.PeopleItemToView_N(2);
            TimeManager.ShortPause();

            //Input nothing and save
            PeopleAreaSetting.FillInPeopleValue_N(input.InputData, 2);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify save failed
            Assert.IsTrue(PeopleAreaSetting.IsSaveButtonDisplayed());
            Assert.IsTrue(PeopleAreaSetting.IsCancelButtonDisplayed());

            //Verify the error message displayed correctly
            Assert.IsTrue(PeopleAreaSetting.IsEffectiveDateInvalid_N(2));
            Assert.IsTrue(PeopleAreaSetting.IsEffectiveDateInvalidMsgCorrect_N(input.ExpectedData.PeopleEffectiveDate, 2));
            Assert.IsTrue(PeopleAreaSetting.IsPeopleNumberInvalid_N(2));
            Assert.IsTrue(PeopleAreaSetting.IsPeopleNumberInvalidMsgCorrect_N(input.ExpectedData.PeopleNumber,2));
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-001-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddInvalidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-001-4")]
        public void AddDupPopulationDate(PeopleAreaPropertyData input)
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

            //Click "+" button at the end of population
            PeopleAreaSetting.ClickPeopleCreateButton();
            TimeManager.LongPause();

            //Scroll to the bottom
            PeopleAreaSetting.PeopleItemToView_N(2);
            TimeManager.ShortPause();

            //Input nothing and save
            PeopleAreaSetting.FillInPeopleValue_N(input.InputData, 2);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify save failed
            Assert.IsTrue(PeopleAreaSetting.IsSaveButtonDisplayed());
            Assert.IsTrue(PeopleAreaSetting.IsCancelButtonDisplayed());

            //Verify the error message displayed correctly
            Assert.IsTrue(PeopleAreaSetting.GetPeopleContainerErrorTips().Contains(input.ExpectedData.PeopleEffectiveDate));
        }
    }
}

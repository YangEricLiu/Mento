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
    public class ModifyInvalidPeopleAreaPropertySuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-001-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyInvalidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-001-2")]
        public void ModifyAreaThenCancel(PeopleAreaPropertyData input)
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
            PeopleAreaSetting.ClickCancelButton();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Verify the value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.TotalArea);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.HeatingArea);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.CoolingArea);
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyInvalidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-001-1")]
        public void ModifyDateToDup(PeopleAreaPropertyData input)
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

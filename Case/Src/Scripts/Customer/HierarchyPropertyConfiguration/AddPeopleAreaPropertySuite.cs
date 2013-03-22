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
    [CreateTime("2013-01-06")]
    [ManualCaseID("TC-J1-SmokeTest-021")]
    public class AddPeopleAreaPropertySuite : TestSuiteBase
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

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        /// </summary>  
        /// 
        [Test]
        [CaseID("TC-J1-SmokeTest-021")]
        [Priority("38")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddPeopleAreaPropertySuite), "TC-J1-SmokeTest-021")]
        public void AddAreaProperty(PeopleAreaPropertyData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            
            //Click "人口面积" tab button
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();
            //Click "+人口面积" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            //Input value and save
            PeopleAreaSetting.FillInAreaValue(input.InputData);
            TimeManager.ShortPause();

            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.TotalArea);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.HeatingArea);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.CoolingArea);
        }

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        /// </summary>  
        ///
        [Test]
        [CaseID("TC-J1-SmokeTest-021")]
        [Priority("38")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddPeopleAreaPropertySuite), "TC-J1-SmokeTest-021")]
        public void AddPeoplePeoperty(PeopleAreaPropertyData input)
        {
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Click "人口面积" tab button
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            //Click "人口面积" tab button
            PeopleAreaSetting.ClickPeopleCreateButton();
            TimeManager.ShortPause();

            //select effective year and input value
            PeopleAreaSetting.FillInPeopleValue(input.InputData);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), input.ExpectedData.PeopleEffectiveDate);
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), input.ExpectedData.PeopleNumber);
        }
    }
}

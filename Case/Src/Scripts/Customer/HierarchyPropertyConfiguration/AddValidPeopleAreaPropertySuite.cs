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
    [CreateTime("2013-06-05")]
    [ManualCaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101")]
    public class AddValidPeopleAreaPropertySuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-1")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-1")]
        public void PANotSupportHierarchy(PeopleAreaPropertyData input)
        {
            //Select not buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify the "人口面积" tab is unavailable
            Assert.IsFalse(PeopleAreaSetting.IsPeopleAreaTabEnable());
            
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-2")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-2")]
        public void PASaveCancelWithoutInput(PeopleAreaPropertyData input)
        {
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify the "人口面积" tab is available and click
            Assert.IsTrue(PeopleAreaSetting.IsPeopleAreaTabEnable());
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();

            //Click "+人口面积" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            //Fill nothing and save
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //Verify "+人口面积" button displayed 
            Assert.IsTrue(PeopleAreaSetting.IsPeopleAreaCreateButtonDisplayed());

            //Click "+人口面积" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();

            //Fill nothing and cancel
            PeopleAreaSetting.ClickCancelButton();
            TimeManager.ShortPause();

            //Verify "+人口面积" button displayed 
            Assert.IsTrue(PeopleAreaSetting.IsPeopleAreaCreateButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-3")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-3")]
        public void PAAddValidPupolation(PeopleAreaPropertyData input)
        {
            //Select one buidling node
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Verify the "人口面积" tab is unavailable
            PeopleAreaSetting.ClickPeopleAreaTab();
            TimeManager.ShortPause();

            //Click "+人口面积"/"修改" button
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
    }
}

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
using Mento.TestApi.WebUserInterface.ControlCollection;

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
            HierarchySetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySetting.NavigatorToNonHierarchy();
        }

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        /// </summary>  
        /// 
        [Test]
        [Category("P4_Emma")]
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
        [Category("P4_Emma")]
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
            TimeManager.ShortPause();

            //Fill nothing and save
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify "+人口面积" button displayed 
            Assert.IsTrue(PeopleAreaSetting.IsPeopleAreaCreateButtonDisplayed());

            //Click "+人口面积" button
            PeopleAreaSetting.ClickPeopleAreaCreateButton();
            TimeManager.ShortPause();

            //Fill nothing and cancel
            PeopleAreaSetting.ClickCancelButton();
            TimeManager.LongPause();

            //Verify "+人口面积" button displayed 
            Assert.IsTrue(PeopleAreaSetting.IsPeopleAreaCreateButtonDisplayed());
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-3")]
        public void PAAddValidPupolation(PeopleAreaPropertyData input)
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

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetEffectiveDateValue(), input.ExpectedData.PeopleEffectiveDate);
            Assert.AreEqual(PeopleAreaSetting.GetPeopleNumberValue(), input.ExpectedData.IntegerValue);
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-4")]
        public void PAAddEmptyAreaAndCheck(PeopleAreaPropertyData input)
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

            //Fill nothing to area and save
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //verify that area property not display
            Assert.IsFalse(PeopleAreaSetting.IsAreaPropertyTitleDisplay(input.InputData.areaTitle));

            //Verify it on formula, which delay to automated
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-5")]
        public void PAAddValidAreaAndCheck(PeopleAreaPropertyData input)
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
            PeopleAreaSetting.FillValidOrInvalidAreaValue(input.InputData);
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.ShortPause();

            //verify that area property display
            Assert.IsTrue(PeopleAreaSetting.IsAreaPropertyTitleDisplay(input.InputData.areaTitle));

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.IntegerValue);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.IntegerValue);

            //Verify it on formula, which delay to automated
        }
    }
}

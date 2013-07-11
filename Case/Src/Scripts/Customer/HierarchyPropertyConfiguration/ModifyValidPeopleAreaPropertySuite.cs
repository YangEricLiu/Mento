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
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.TotalArea);
            Assert.AreEqual(PeopleAreaSetting.GetHeatingAreaValue(), input.ExpectedData.HeatingArea);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.CoolingArea);
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
            Assert.AreEqual(input.ExpectedData.PeopleEffectiveDate, PeopleAreaSetting.GetEffectiveDateValue());
            Assert.AreEqual(input.ExpectedData.PeopleNumber, PeopleAreaSetting.GetPeopleNumberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-3")]
        public void ModifyToDeletePeopleItemsThenCancel(PeopleAreaPropertyData input)
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

            //delete some items and cancel 
            PeopleAreaSetting.ClickDeletePeopleItemButton(1);
            PeopleAreaSetting.ClickDeletePeopleItemButton(2);

            PeopleAreaSetting.ClickCancelButton();
            TimeManager.LongPause();

            //Verify not delete
            Assert.AreEqual(PeopleAreaSetting.GetPeopleItemsNumber(), 5);
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-4")]
        public void ModifyToDeleteSomePeopleItems(PeopleAreaPropertyData input)
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
            
            PeopleAreaSetting.PeopleItemToView_N(3);
            
            //delete some items and save 
            PeopleAreaSetting.ClickDeletePeopleItemButton(1);

            int n = PeopleAreaSetting.GetPeopleItemsNumber();
            PeopleAreaSetting.ClickDeletePeopleItemButton(n);

            PeopleAreaSetting.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            
            //Verify not delete
            Assert.AreEqual(PeopleAreaSetting.GetPeopleItemsNumber(), 1);

            //Verify left value displayed correct
            Assert.AreEqual(input.ExpectedData.PeopleEffectiveDate, PeopleAreaSetting.GetEffectiveDateValue());
            Assert.AreEqual(input.ExpectedData.PeopleNumber, PeopleAreaSetting.GetPeopleNumberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-5")]
        public void ModifyToDeleteAllPeopleItems(PeopleAreaPropertyData input)
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

            //delete all items and save 
            int n = PeopleAreaSetting.GetPeopleItemsNumber();
            int i = 0;
            while (i < n)
            {
                PeopleAreaSetting.ClickDeletePeopleItemButton(1);
                i++;
            }
            
            PeopleAreaSetting.ClickSaveButton();
            TimeManager.LongPause();

            //Verify all deleted
            Assert.IsTrue(PeopleAreaSetting.IsCreateModifyButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Modify-101-6")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(ModifyValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Modify-101-6")]
        public void ModifyValidArea(PeopleAreaPropertyData input)
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
            PeopleAreaSetting.FillInAreaValue(input.InputData);
            PeopleAreaSetting.ClickSaveButton();
            
            TimeManager.ShortPause();

            //verify that area property display
            Assert.IsTrue(PeopleAreaSetting.IsAreaPropertyTitleDisplay(areaTitle));

            //Verify the input value displayed correct
            Assert.AreEqual(PeopleAreaSetting.GetTotalAreaValue(), input.ExpectedData.TotalArea);
            Assert.AreEqual(PeopleAreaSetting.GetCoolingAreaValue(), input.ExpectedData.CoolingArea);
        }
    }
}

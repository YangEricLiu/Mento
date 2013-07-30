using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-07-26")]
    [ManualCaseID("TC-J1-FVT-TargetConfiguration-Modify-101")]
    public class ModifyValidTargetBaselineSuite : TestSuiteBase
    {
        private static TagTargetBaselineSettings PVtagTargetBaselineSettings = JazzFunction.TagTargetBaselineSettings;
        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.NavigatorToTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private void PickupPtagOrVtag(KPITargetBaselineData input)
        {
            if (String.Equals(input.InputData.TagType, "Ptag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
                PVtagTargetBaselineSettings.FocusOnPTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            }

            if (String.Equals(input.InputData.TagType, "Vtag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
                PVtagTargetBaselineSettings.FocusOnVTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            } 
        }
      
        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-101-1")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyValidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-101-1")]
        public void CheckViewPageAndSave(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsCreateCalculationRuleButtonDisplayed());

            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsCreateCalculationRuleButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-101-2")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyValidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-101-2")]
        public void SettingCalculationRuleForWorkday(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            for (int i = 0; i < input.InputData.WorkdayRuleRecordNumber; i++ )
            {
                PVtagTargetBaselineSettings.SelectWorkdayRuleEndTime(input.InputData.WorkdayRuleEndTime[i], i+1);
                PVtagTargetBaselineSettings.FillInWorkdayRuleValue(input.InputData.WorkdayRuleValue[i], i+1);
            }           

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            for (int i = 0; i < input.InputData.WorkdayRuleRecordNumber; i++)
                Assert.AreEqual(input.ExpectedData.WorkdayRuleValue[i], PVtagTargetBaselineSettings.GetWorkdayRuleValue(i+1));
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-101-3")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyValidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-101-3")]
        public void ModifyCalculationRuleForWorkday(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            
            //Modify the workday endtime from 8:30 to 7:00
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectWorkdayRuleEndTime(input.InputData.WorkdayRuleEndTime[0], 1);


            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            for (int i = 0; i < input.InputData.WorkdayRuleRecordNumber; i++)
            {
                Assert.AreEqual(input.ExpectedData.WorkdayRuleEndTime[i], PVtagTargetBaselineSettings.GetWorkdayEndtimeValue(i + 1));
                Assert.AreEqual(input.ExpectedData.WorkdayRuleValue[i], PVtagTargetBaselineSettings.GetWorkdayRuleValue(i + 1));
            }

            //Modify the workday end time from 7:00 to 21:00
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectWorkdayRuleEndTime(input.InputData.WorkdayRuleEndTime[1], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            for (int i = 0; i < (input.InputData.WorkdayRuleRecordNumber-1); i++)
            {
                Assert.AreEqual(input.ExpectedData.WorkdayRuleEndTime[i+3], PVtagTargetBaselineSettings.GetWorkdayEndtimeValue(i + 1));
                Assert.AreEqual(input.ExpectedData.WorkdayRuleValue[i+3], PVtagTargetBaselineSettings.GetWorkdayRuleValue(i + 1));
            }

            //Clear one rule value and save
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.FillInWorkdayRuleValue(input.InputData.WorkdayRuleValue[0], 2);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(input.ExpectedData.WorkdayRuleEndTime[3], PVtagTargetBaselineSettings.GetWorkdayEndtimeValue(1));
            Assert.AreEqual(input.ExpectedData.WorkdayRuleValue[3], PVtagTargetBaselineSettings.GetWorkdayRuleValue(1));
            Assert.AreEqual(1, PVtagTargetBaselineSettings.GetWorkdayRuleItemsNumber());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-101-4")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyValidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-101-4")]
        public void SettingCalculationRuleForNonWorkday(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            
            //Fill in non-workday end time and value
            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();
            
            for (int i = 0; i < input.InputData.NonworkdayRuleRecordNumber; i++)
            {
                PVtagTargetBaselineSettings.SelectNonworkdayRuleEndTime(input.InputData.NonworkdayRuleEndTime[i], i + 1);
                PVtagTargetBaselineSettings.FillInNonworkdayRuleValue(input.InputData.NonworkdayRuleValue[i], i + 1);
            }

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            for (int i = 0; i < (input.InputData.NonworkdayRuleRecordNumber - 1); i++)
            {
                Assert.AreEqual(input.ExpectedData.NonworkdayRuleEndTime[i], PVtagTargetBaselineSettings.GetNonworkdayEndtimeValue(i + 1));
                Assert.AreEqual(input.ExpectedData.NonworkdayRuleValue[i], PVtagTargetBaselineSettings.GetNonworkdayRuleValue(i + 1));
            }

            Assert.AreEqual(3, PVtagTargetBaselineSettings.GetNonworkdayRuleItemsNumber());
            
            //Fill in ‘补充日期’ 
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[0], 1);
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[0], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[0], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1));

            //Change ‘补充日期’ 
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[1], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[1], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[1], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[1], 1);
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[1], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[1], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1));
            
            //Delete one special day rule then cancel, not delete 
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickDeletepecialdayRuleButton(1);
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickCancelButton();
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[1], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1));

            //Delete one special day rule then save, delete successful 
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickDeletepecialdayRuleButton(1);
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.AreEqual(0, PVtagTargetBaselineSettings.GetSpecialdayRuleItemsNumber());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-101-5")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyValidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-101-5")]
        public void SettingCalculationRuleForInteger(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //Fill in non-workday end time and value
            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            //Fill in ‘补充日期’
            PVtagTargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[0], 1);
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[0], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[0], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1));

            //Modify nothing and save
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[0], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1));
        }
    }
}

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
    [CreateTime("2013-07-30")]
    [ManualCaseID("TC-J1-FVT-TargetConfiguration-Modify-001")]
    public class ModifyInvalidTargetBaselineSuite : TestSuiteBase
    {
        private static TagTargetBaselineSettings PVtagTargetBaselineSettings = JazzFunction.TagTargetBaselineSettings;
        private static PTagSettings PTagSettings  = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseTearDown();
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
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-001-1")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyInvalidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-001-1")]
        public void InvalidValueDateForCalculationRule(KPITargetBaselineData input)
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

            //Fill in ‘补充日期’, not input value and click save
            PVtagTargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[0], 1);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[0], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartDateInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartTimeInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndDateInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndTimeInvalid(1));

            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayValueInvalid(1));
            Assert.IsFalse(PVtagTargetBaselineSettings.GetSpecialdayRuleValue(1).Contains(input.ExpectedData.SpecialdayRuleValue[0]));

            //fill in value with max value 99999999999999999999999
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[0], 1);
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayValueInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.GetSpecialdayStartDateInvalidMsg(1).Contains(input.ExpectedData.SpecialdayRuleValue[1]));

            //Cancel, then add one item, only input value, then save
            PVtagTargetBaselineSettings.ClickCancelButton();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[1], 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartDateInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartTimeInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndDateInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndTimeInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayValueInvalid(1));

            Assert.IsTrue(PVtagTargetBaselineSettings.GetSpecialdayStartDateInvalidMsg(1).Contains(input.ExpectedData.SpecialdayRuleStartDate[0]));
            Assert.IsFalse(PVtagTargetBaselineSettings.GetSpecialdayStartTimeInvalidMsg(1).Contains(input.ExpectedData.SpecialdayRuleStartTime[0]));
            Assert.IsFalse(PVtagTargetBaselineSettings.GetSpecialdayEndDateInvalidMsg(1).Contains(input.ExpectedData.SpecialdayRuleEndDate[0]));
            Assert.IsFalse(PVtagTargetBaselineSettings.GetSpecialdayEndTimeInvalidMsg(1).Contains(input.ExpectedData.SpecialdayRuleEndTime[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-001-2")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyInvalidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-001-2")]
        public void ModifyEndRange(KPITargetBaselineData input)
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
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            for (int i = 0; i < input.InputData.SpecialdayRuleRecordNumber; i++)
            {
                PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[i], 1);
                PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[i], 1);
                
                PVtagTargetBaselineSettings.ClickSaveButton();
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.MediumPause();

                Assert.AreEqual(input.ExpectedData.SpecialdayRuleStartDate[i], PVtagTargetBaselineSettings.GetSpecialdayStartDateValue(1));
                Assert.AreEqual(input.ExpectedData.SpecialdayRuleStartTime[i], PVtagTargetBaselineSettings.GetSpecialdayStartTimeValue(1));
                Assert.AreEqual(input.ExpectedData.SpecialdayRuleEndDate[i], PVtagTargetBaselineSettings.GetSpecialdayEndDateValue(1));
                Assert.AreEqual(input.ExpectedData.SpecialdayRuleEndTime[i], PVtagTargetBaselineSettings.GetSpecialdayEndTimeValue(1));

                PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
                TimeManager.ShortPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-001-3")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyInvalidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-001-3")]
        public void DupDateReviseCancel(KPITargetBaselineData input)
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
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();

            for (int i = 0; i < input.InputData.SpecialdayRuleRecordNumber; i++)
            {
                PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[i], 2);
                PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[i], 2);
                PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[i], 2);
                PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[i], 2);

                Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartDateInvalid(2));
                Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayStartTimeInvalid(2));
                Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndDateInvalid(2));
                Assert.IsTrue(PVtagTargetBaselineSettings.IsSpecialdayEndTimeInvalid(2));
                //Assert.IsFalse(PVtagTargetBaselineSettings.IsSpecialdayValueInvalid(2));
                Assert.IsTrue(PVtagTargetBaselineSettings.GetSpecialdayStartDateInvalidMsg(2).Contains(input.ExpectedData.SpecialdayRuleStartDate[0]));
            }

            //Fill in no overlap date 
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartDate(input.InputData.SpecialdayRuleStartDate[2], 2);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleStartTime(input.InputData.SpecialdayRuleStartTime[2], 2);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndDate(input.InputData.SpecialdayRuleEndDate[2], 2);
            PVtagTargetBaselineSettings.SelectSpecialdayRuleEndTime(input.InputData.SpecialdayRuleEndTime[2], 2);
            PVtagTargetBaselineSettings.FillInSpecialdayRuleValue(input.InputData.SpecialdayRuleValue[0], 2);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            
            Assert.AreEqual(input.ExpectedData.SpecialdayRuleValue[0], PVtagTargetBaselineSettings.GetSpecialdayRuleValue(2));

            //Fill invalid workday value
            PVtagTargetBaselineSettings.ClickModifyCalculationRuleButton();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.FillInWorkdayRuleValue(input.InputData.WorkdayRuleValue[0], 1);
            PVtagTargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsWorkdayRuleValueInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.GetWorkdayRuleValueInvalidMsg(1).Contains(input.ExpectedData.WorkdayRuleValue[0]));

            //Fill invalid non-workday value
            PVtagTargetBaselineSettings.FillInNonworkdayRuleValue(input.InputData.NonworkdayRuleValue[0], 1);
            PVtagTargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.IsNonworkdayRuleValueInvalid(1));
            Assert.IsTrue(PVtagTargetBaselineSettings.GetNonworkdayRuleValueInvalidMsg(1).Contains(input.ExpectedData.NonworkdayRuleValue[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-Modify-001-4")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ModifyInvalidTargetBaselineSuite), "TC-J1-FVT-TargetConfiguration-Modify-001-4")]
        public void ModifynamewithInvalidInfo(KPITargetBaselineData input)
        {
            //Select an exist Ptag
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //make the input box empty.
            PVtagTargetBaselineSettings.FillTargetName(input.InputData.TargetBaselineName);
            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            TimeManager.LongPause();

            //The input box display with gray value of "基准值名称" to note user input the name and showing error message of "必填项".
            Assert.AreEqual(input.ExpectedData.TargetBaselineName, PVtagTargetBaselineSettings.GetBaselineNameFieldInvalidMsg());
        }
    }
}

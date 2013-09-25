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
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.TOU
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-04")]
    public class TOUPulsePeakModifyValidSuite : TestSuiteBase
    {
        private static TOUPulsePeakTariffSettings TOUPulsePeakTariffSettings = JazzFunction.TOUPulsePeakTariffSettings;
        [SetUp]
        public void CaseSetUp()
        {
            TOUPulsePeakTariffSettings.NavigatorToPriceSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ModifyValidPulsePeak
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        public void ModifyValidPulsePeak(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            //Click 'Modify' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            //Change the price with a valid input.
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.ExpectedData.Price);

            //Change  范围1 to be '4月2日 - 5月31日 00:30-23:30'
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartMonth(testData.ExpectedData.PulsePeakRange[0].StartMonth, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartDate(testData.ExpectedData.PulsePeakRange[0].StartDate, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndMonth(testData.ExpectedData.PulsePeakRange[0].EndMonth, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndDate(testData.ExpectedData.PulsePeakRange[0].EndDate, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.ExpectedData.PulsePeakRange[0].StartTime, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndTime(testData.ExpectedData.PulsePeakRange[0].EndTime, 1);

            //Change the start date, start time of 范围2
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartDate(testData.ExpectedData.PulsePeakRange[1].StartDate, 2);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.ExpectedData.PulsePeakRange[1].StartTime, 2);

            //Change the start month, start date, start time of 范围3
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartMonth(testData.ExpectedData.PulsePeakRange[2].StartMonth, 3);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartDate(testData.ExpectedData.PulsePeakRange[2].StartDate, 3);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.ExpectedData.PulsePeakRange[2].StartTime, 3);

            //Change the end date, end time of 范围4
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndDate(testData.ExpectedData.PulsePeakRange[3].EndDate, 4);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndTime(testData.ExpectedData.PulsePeakRange[3].EndTime, 4);

            //Change the end month, end time of 范围5
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndMonth(testData.ExpectedData.PulsePeakRange[4].EndMonth, 5);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndTime(testData.ExpectedData.PulsePeakRange[4].EndTime, 5);

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify modification is saved successfully.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertySaveButtonDisplayed());
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPropertyModifyButtonDisplayed());
            //Verify price is changed to be new.
            Assert.AreEqual(testData.ExpectedData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());
            //Verify time range1 is changed to be new.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(1));
            //Verify time range2 is auto-rounding to be a new endtime.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(2));
            //Verify time range3 is auto-rounding to be a new endmonth, enddate, endtime.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(3));
            //Verify time range4 is auto-rounding to be a new starttime.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[3].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(4));
            //Verify time range5 is auto-rounding to be a new startmonth, startdate, starttime.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[4].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(5));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[4].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(5));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[4].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(5));

        }
        #endregion

        #region TestCase2 ModifyPulsePeakToAddMoreTime
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        public void ModifyPulsePeakToAddMoreTime(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify modification is saved successfully.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertySaveButtonDisplayed());
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPropertyModifyButtonDisplayed());
            //Verify time range2，and 3 are added below original time range1.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(3));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[2].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(3));

        }
        #endregion

        #region TestCase3 ModifyToDeleteOnePulsePeak
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        public void ModifyToDeleteOnePulsePeak(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyRangeItemDeleteButtonDisplayed(1));

            //Click 'x' icon to delete some pulse peak items, e.g. delete range2
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify modification is saved successfully.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertySaveButtonDisplayed());
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPropertyModifyButtonDisplayed());
            //Verify after range2 is deleted, then orginal range3 move up to position 2.
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(2));
        }
        #endregion

        #region TestCase4 ModifyToDeleteWholePulsePeak
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        public void ModifyToDeleteWholePulsePeak(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            //Verify there is no 'x' icon near range1.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyRangeItemDeleteButtonDisplayed(1));

            //Click 'x' icons to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify '+峰值季节电价' button is displayed and clickable when whole range has been deleted.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();
        }
        #endregion

    }
}

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
    public class TOUPulsePeakModifyInvalidSuite : TestSuiteBase
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

        #region TestCase1 ModifyPulsePeakCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        public void ModifyPulsePeakCancelled(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            //Swith to PulsePeak tab.
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            //Click 'Save' button directly without any modification.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();
            //Verify saved successfull.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCancelButtonDisplayed());
            
            //Click 'Modify' button again.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            //Change some fields with valid input.
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartMonth(testData.InputData.PulsePeakRange[0].StartMonth, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartDate(testData.InputData.PulsePeakRange[0].StartDate, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndMonth(testData.InputData.PulsePeakRange[0].EndMonth, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndDate(testData.InputData.PulsePeakRange[0].EndDate, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.InputData.PulsePeakRange[0].StartTime, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndTime(testData.InputData.PulsePeakRange[0].EndTime, 1);
            //Click 'Cancel' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();
            //Verify cancelled successfull and 'Cancel' button is NOT displayed.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCancelButtonDisplayed());

            //Click 'Modify' button again.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            //Click 'x' icon to delete some pulse peak item, e.g. delete range2
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);
            //Click 'Cancel' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();
            //Verify cancelled successfull and 'Cancel' button is NOT displayed.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCancelButtonDisplayed());
            
            //Click 'Modify' button again.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            //Click 'x' icon to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();
            //Click 'Cancel' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();
            //Verify pulse peak information remains as before without any change.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            Assert.AreEqual(testData.ExpectedData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[0].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(1));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(2));
            Assert.AreEqual(testData.ExpectedData.PulsePeakRange[1].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(2));
        }
        #endregion

        #region TestCase2 ModifyInvalidPulsePeak
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        public void ModifyInvalidPulsePeak(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which has already set pulse peak, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            //Swith to PulsePeak tab.
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();

            //Click 'Modify' button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            
            //Change the price to be empty.
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Change the time range to be conflicted， e.g. change end month and end date of range1 to be same as range2.
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndMonth(testData.InputData.PulsePeakRange[0].EndMonth, 1);
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndDate(testData.InputData.PulsePeakRange[0].EndDate, 1);
                        
            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify error message 'required field' is displayed under price field.
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPriceInvalid());
            //Verify error message 'time ranges are conflicted' are displayed under time range fields.
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 2));

            //Click 'Cancel' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();
            //Click 'Modify' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();
            //Verify previous error message are NOT displayed after cancelled then modify again.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPriceInvalid());
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 2));
            //Click 'Cancel' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
        }
        #endregion
        
    }
}

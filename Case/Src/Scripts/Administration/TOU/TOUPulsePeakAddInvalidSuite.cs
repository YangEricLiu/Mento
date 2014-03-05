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
    [CreateTime("2013-03-13")]
    public class TOUPulsePeakAddInvalidSuite : TestSuiteBase
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

        #region TestCase1 AddPulsePeakCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        public void AddPulsePeakCancelled(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which doesn't set pulse peak yet, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click Cancel button directly.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click Save button directly.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click '+' icon
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();
            //Input valid price and valid range
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);
            //Click Cancel button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click '+' icon
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();
            //Input valid price and valid range
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);
            //Click 'X' icon near '峰值季节电价(元/千瓦时)' field;
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();
            //Click '+' icon and Input valid price and valid range again
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);
            //Click 'X' icon near '峰值季节电价(元/千瓦时)' field again;
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();
            //Click Save button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();
            //Verify that '+峰值季节电价' button is displayed and 'Modify' button is NOT displayed.
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCreateButtonDisplayed());
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyModifyButtonDisplayed());

            TimeManager.MediumPause();
        }
        #endregion

        #region TestCase2 AddWithRequiredFieldsEmpty
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        public void AddWithRequiredFieldsEmpty(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which doesn't set pulse peak yet, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click '+' icon
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();
            //Without any input, click Save button directly.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();
            
            //Verify that error messages are displayed under required fields.
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPriceInvalid());
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCancelButton();
            TimeManager.MediumPause();

        }
        #endregion

        #region TestCase3 AddWithConflictedRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-003")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-003")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-003")]
        public void AddWithConflictedRanges(TOUPulsePeakTariffData testData)
        {
            //Select a TOU which doesn't set pulse peak yet, and go to PulsePeak property tab.
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();

            //Click '+ 峰值季节电价' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            //Click '+' icon
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();
            //Input valid price
            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);            
            //Click '添加峰值季节时间' link and Input invalid overlapped time ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click Save button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();

            //Verify that error messages are displayed under overlapped time ranges.
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakRangeInvalidMsgCorrect(testData.ExpectedData, 2));

            //Revise one of the range, so that no overlap, e.g. change starttime of range2 to be same as endtime of rangeIndustry, and click Save.
            TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.InputData.PulsePeakRange[0].EndTime, 2);

            //Click Save button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.LongPause();

            //Verify saved successfull and 'Modify' button is displayed.
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUPulsePeakTariffSettings.IsPulsePeakPropertyModifyButtonDisplayed());
            Assert.IsFalse(TOUPulsePeakTariffSettings.IsPulsePeakPropertyCreateButtonDisplayed());

            TimeManager.MediumPause();

        }
        #endregion
    }
}

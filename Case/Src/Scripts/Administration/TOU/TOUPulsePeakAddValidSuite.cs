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
    public class TOUPulsePeakAddValidSuite : TestSuiteBase
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

        #region TestCase1 AddValidPulsePeak
        /// <summary>
        /// Precondition: Industry. make sure there is a TOU basic tariff
        ///               2. make sure the TOU tariff hasn't defined Pulse Peak property yet.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-101")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-101")]
        public void AddValidPulsePeak(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff(testData.InputData.CommonName);
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();  
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.MediumPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);            

            //Click the 'X' icon near one added range, to delete one range (e.g. delete range2).
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click Save button.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Verify the price
            Assert.AreEqual(testData.InputData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());

            //Verify 'Start Month', 'Start Date', 'End Month', 'End Date', 'Start Time' and 'End Time' of the record(s)
            for (int elementPosition = 1; elementPosition <= testData.ExpectedData.PulsePeakRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(elementPosition));
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(elementPosition));
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(elementPosition));
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(elementPosition));
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(elementPosition));
                Assert.AreEqual(testData.ExpectedData.PulsePeakRange[inputDataArrayPosition].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(elementPosition));
            }
        }
        #endregion
    
    }
}

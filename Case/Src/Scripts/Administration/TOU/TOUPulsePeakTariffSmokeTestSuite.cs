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
    [ManualCaseID("TC-J1-SmokeTest")]
    public class TOUPulsePeakTariffSmokeTestSuite : TestSuiteBase
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
        }

        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略1'
        ///               2. make sure the TOU tariff hasn't defined Pulse Peak property yet.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-026")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakTariffSmokeTestSuite), "TC-J1-SmokeTest-026")]
        public void AddTOUPulsePeakTariff(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略1");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();  
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();

            //Verify the price
            Assert.AreEqual(testData.InputData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());

            //Verify 'Start Month', 'Start Date', 'End Month', 'End Date', 'Start Time' and 'End Time' of the record(s)
            //for (int elementPosition = 1; elementPosition <= testData.InputData.PulsePeakRange.Length; elementPosition++)
            //{
            //    int inputDataArrayPosition = elementPosition - 1;
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndMonth, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndDate, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].StartTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.PulsePeakRange[inputDataArrayPosition].EndTime, TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(elementPosition));
            //}
        }       
    }
}

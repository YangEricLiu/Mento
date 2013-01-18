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
    public class TOUPulsePeakTariffSuite : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-SmokeTest-026")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakTariffSuite), "TC-J1-SmokeTest-026")]
        public void AddTOUPulsePeakTariff(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("pricename");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.PrepareToAddTOUPulsePeakProperty();            
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Input 'Start Month', 'Start Date', 'End Month', 'End Date', 'Start Time' and 'End Time' for the pulse peak record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                //Click '添加峰值季节时间' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TOUPulsePeakTariffSettings.ClickAddMorePulsePeakRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartMonth(testData.InputData.StartMonth[inputDataArrayPosition], elementPosition);
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartDate(testData.InputData.StartDate[inputDataArrayPosition], elementPosition);
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndMonth(testData.InputData.EndMonth[inputDataArrayPosition], elementPosition);
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndDate(testData.InputData.EndDate[inputDataArrayPosition], elementPosition);
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyStartTime(testData.InputData.StartTime[inputDataArrayPosition], elementPosition);
                TOUPulsePeakTariffSettings.SelectPulsePeakPropertyEndTime(testData.InputData.EndTime[inputDataArrayPosition], elementPosition);
                
                TimeManager.ShortPause();
            }

            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.MediumPause();

            //Verify the price
            Assert.AreEqual(testData.InputData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());

            //Verify 'Start Month', 'Start Date', 'End Month', 'End Date', 'Start Time' and 'End Time' of the record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.StartMonth[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.StartDate[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartDateValue(elementPosition));
                Assert.AreEqual(testData.InputData.EndMonth[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.EndDate[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndDateValue(elementPosition));
                Assert.AreEqual(testData.InputData.StartTime[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.EndTime[inputDataArrayPosition], TOUPulsePeakTariffSettings.GetPulsePeakPropertyEndTimeValue(elementPosition));
            }
        }       
    }
}

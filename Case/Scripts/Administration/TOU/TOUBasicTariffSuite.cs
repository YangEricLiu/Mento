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
    public class TOUBasicTariffSuite : TestSuiteBase
    {
        private static TOUBasicTariffSettings TOUBasicTariffSettings = JazzFunction.TOUBasicTariffSettings;
        [SetUp]
        public void CaseSetUp()
        {
            TOUBasicTariffSettings.NavigatorToPriceSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-025")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffSuite), "TC-J1-SmokeTest-025")]
        public void AddTOUBasicTariff(TOUBasicTariffData testData)
        {
            TOUBasicTariffSettings.PrepareToAddTOUBasicProperty();
            TimeManager.ShortPause();

            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.Name);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Input 'Start Time' and 'End Time' for the peak record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.PeakRecordNumber; elementPosition++)
            {
                //Click '添加峰时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TOUBasicTariffSettings.ClickAddMorePeakRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime(testData.InputData.PeakStartTime[inputDataArrayPosition], elementPosition);
                TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime(testData.InputData.PeakEndTime[inputDataArrayPosition], elementPosition);
                
                TimeManager.ShortPause();
            }

            //Input 'Start Time' and 'End Time' for the valley record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ValleyRecordNumber; elementPosition++)
            {
                //Click '添加谷时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TOUBasicTariffSettings.ClickAddMoreValleyRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TOUBasicTariffSettings.SelectBasicPropertyValleyStartTime(testData.InputData.ValleyStartTime[inputDataArrayPosition], elementPosition);
                TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime(testData.InputData.ValleyEndTime[inputDataArrayPosition], elementPosition);

                TimeManager.ShortPause();
            }

            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.Name, TOUBasicTariffSettings.GetBasicPropertyNameValue());

            //Verify the plain price
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());

            //Verify the peak price
            Assert.AreEqual(testData.InputData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());

            //Verify the valley price
            Assert.AreEqual(testData.InputData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

            //Verify 'Start Time' and 'End Time' of the peak record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.PeakRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.PeakStartTime[inputDataArrayPosition], TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.PeakEndTime[inputDataArrayPosition], TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(elementPosition));
            }

            //Verify 'Start Time' and 'End Time' of the valley record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.ValleyRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.ValleyStartTime[inputDataArrayPosition], TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.ValleyEndTime[inputDataArrayPosition], TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(elementPosition));
            }
        }       
    }
}

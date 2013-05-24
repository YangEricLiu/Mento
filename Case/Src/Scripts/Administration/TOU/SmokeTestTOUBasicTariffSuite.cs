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
    public class SmokeTestTOUBasicTariffSuite : TestSuiteBase
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
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(SmokeTestTOUBasicTariffSuite), "TC-J1-SmokeTest-025")]
        public void AddTOUBasicTariff(TOUBasicTariffData testData)
        {
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click '添加峰时范围''添加谷时范围' links and also Fill in the ranges
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.ShortPause();

            //Verify
            Assert.AreEqual(testData.InputData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.InputData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.InputData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

            //Verify 'Start Time' and 'End Time' of the peak record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.PeakRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.PeakRange[inputDataArrayPosition].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.PeakRange[inputDataArrayPosition].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(elementPosition));
            }

            //Verify 'Start Time' and 'End Time' of the valley record(s)
            for (int elementPosition = 1; elementPosition <= testData.InputData.ValleyRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.ValleyRange[inputDataArrayPosition].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.ValleyRange[inputDataArrayPosition].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(elementPosition));
            }
        }       
    }
}

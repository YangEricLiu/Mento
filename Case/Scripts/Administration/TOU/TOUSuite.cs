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
    public class TOUSuite : TestSuiteBase
    {
        private static TOUSettings TOUSettings = JazzFunction.TOUSettings;
        [SetUp]
        public void CaseSetUp()
        {
            TOUSettings.NavigatorToPriceSettings();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-025")]
        [MultipleTestDataSource(typeof(TOUData[]), typeof(TOUSuite), "TC-J1-SmokeTest-025")]
        public void AddTOUBasicTariff(TOUData testData)
        {
            TOUSettings.PrepareToAddTOUBasicProperty();
            TimeManager.ShortPause();

            TOUSettings.FillInBasicPropertyName(testData.InputData.Name);
            TOUSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Input 'Start Time' and 'End Time' for the peak record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.PeakRecordNumber; elementPosition++)
            {
                //Click '添加峰时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TOUSettings.ClickAddMorePeakRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TOUSettings.SelectBasicPropertyPeakStartTime(testData.InputData.PeakStartTime[inputDataArrayPosition], elementPosition);
                TOUSettings.SelectBasicPropertyPeakEndTime(testData.InputData.PeakEndTime[inputDataArrayPosition], elementPosition);
                
                TimeManager.ShortPause();
            }

            //Input 'Start Time' and 'End Time' for the valley record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.ValleyRecordNumber; elementPosition++)
            {
                //Click '添加谷时范围' button if more than one record need to be entered
                if (elementPosition > 1)
                {
                    TOUSettings.ClickAddMoreValleyRangesButton();
                    TimeManager.ShortPause();
                }

                int inputDataArrayPosition = elementPosition - 1;
                TOUSettings.SelectBasicPropertyValleyStartTime(testData.InputData.ValleyStartTime[inputDataArrayPosition], elementPosition);
                TOUSettings.SelectBasicPropertyValleyEndTime(testData.InputData.ValleyEndTime[inputDataArrayPosition], elementPosition);

                TimeManager.ShortPause();
            }

            TOUSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Verify the name
            Assert.AreEqual(testData.InputData.Name, TOUSettings.GetBasicPropertyNameValue());
            
            //Verify 'Start Time' and 'End Time' of the record(s)
            //for (int elementPosition = 1; elementPosition <= testData.InputData.RecordNumber; elementPosition++)
            //{
            //    int inputDataArrayPosition = elementPosition - 1;
            //    Assert.AreEqual(testData.InputData.StartTime[inputDataArrayPosition], TimeSettingsWorktime.GetStartTimeValue(elementPosition));
            //    Assert.AreEqual(testData.InputData.EndTime[inputDataArrayPosition], TimeSettingsWorktime.GetEndTimeValue(elementPosition));
            //}
        }       
    }
}

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
    public class TOUBasicTariffAddValidSuite : TestSuiteBase
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

        #region TestCase1 AddValid
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-101")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddValidSuite), "TC-J1-FVT-TOUTariffSetting-Add-101")]
        public void AddValid(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Fill in all fields with valid inputs
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click '添加峰时范围''添加谷时范围' links and also Fill in the ranges
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify all the information displayed in Modify status are samed as input when addition.            
            TOUBasicTariffSettings.SelectTOU(testData.ExpectedData.CommonName);
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.ExpectedData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.ExpectedData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.ExpectedData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

            //需要优化时间范围的verify
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
            //需要优化时间范围的verify
            
        }
        #endregion

        #region TestCase2 ComplexedOperationsForTimeRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-102")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-102")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddValidSuite), "TC-J1-FVT-TOUTariffSetting-Add-102")]
        public void ComplexedOperationsForTimeRanges(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Fill in all fields with valid inputs, especially containing complex operations for time ranges
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click '添加峰时范围''添加谷时范围' links and also Fill in the ranges
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click 'x' icons to delete some peak/valley items
            TOUBasicTariffSettings.ClickDeletePeakRangeItemButton(2);
            TOUBasicTariffSettings.ClickDeleteValleyRangeItemButton(2);

            //Change a range with new start/end time
            TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime("08:00", 1);
            TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime("11:30", 1);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName); 
            //Verify
            Assert.AreEqual(testData.InputData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.InputData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.InputData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());
                        
        }
        #endregion

        #region TestCase3 EmptyItemNotDisplay
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-103")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-103")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddValidSuite), "TC-J1-FVT-TOUTariffSetting-Add-103")]
        public void EmptyItemNotDisplay(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Fill in all fields with valid inputs, without plain price
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);        
            //Verify the plain price is not displayed in view mode.
            Assert.IsTrue(TOUBasicTariffSettings.IsPlainPriceHidden());
        }
        #endregion
        
    }
}

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
            //TOUBasicTariffSettings.NavigatorToTimeSettings();
            //TimeManager.MediumPause();
        }

        #region TestCase1 AddValidTOU
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-101")]
        public void AddValidTOU(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Verify the label text
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUBasicPropertyTextCorrect(testData.ExpectedData.LabelText));

            //Fill in text fields with valid inputs
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Add Peak1 and Valley1 time ranges
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();
            

            //verify add successful
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());

            //Verify all the information displayed in Modify status are correct.            
            TOUBasicTariffSettings.SelectTOU(testData.ExpectedData.CommonName);
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.InputData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.InputData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

            //Verify Peak1 and Valley1 time ranges are added successfully.
            Assert.AreEqual(testData.InputData.PeakRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(1));
            Assert.AreEqual(testData.InputData.PeakRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(1));                     
            Assert.AreEqual(testData.InputData.ValleyRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(1));
            Assert.AreEqual(testData.InputData.ValleyRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(1));            
        }
        #endregion

        #region TestCase2 AddTOUComplexedTimeRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-102")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-102")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-102")]
        public void AddTOUComplexedTimeRanges(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Fill in text fields with valid inputs
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Add Peak1,2 and Valley1,2,3 time ranges
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click 'x' icons to delete peak2, delete valley2
            TOUBasicTariffSettings.ClickDeletePeakRangeItemButton(2);
            TOUBasicTariffSettings.ClickDeleteValleyRangeItemButton(2);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());

            //Verify all the information displayed in View status are same as input when addition.            
            TOUBasicTariffSettings.SelectTOU(testData.InputData.CommonName);
            Assert.AreEqual(testData.InputData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.InputData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.InputData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.InputData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

            //Verify Peak1 and Valley1,3 time ranges are added successfully.
            Assert.AreEqual(testData.InputData.PeakRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyPeakStartTimeValue(1));
            Assert.AreEqual(testData.InputData.PeakRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyPeakEndTimeValue(1));
            Assert.AreEqual(testData.InputData.ValleyRange[0].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(1));
            Assert.AreEqual(testData.InputData.ValleyRange[0].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(1));
            Assert.AreEqual(testData.InputData.ValleyRange[2].StartTime, TOUBasicTariffSettings.GetBasicPropertyValleyStartTimeValue(2));
            Assert.AreEqual(testData.InputData.ValleyRange[2].EndTime, TOUBasicTariffSettings.GetBasicPropertyValleyEndTimeValue(2));                          
        }
        #endregion

    }
}

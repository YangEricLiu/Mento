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
    public class TOUBasicTariffAddInvalidSuite : TestSuiteBase
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

        #region TestCase1 AddTOUCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-001")]
        public void AddTOUCancelled(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Fill in fields with invalid inputs, e.g. input name only
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //Click '+峰谷电价' button again
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());

            //Fill in fields with valid inputs
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
        }
        #endregion

        #region TestCase2 AddWithRequiredFieldsEmpty
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-002")]
        public void AddWithRequiredFieldsEmpty(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Click '添加峰时范围''添加谷时范围' links
            TOUBasicTariffSettings.ClickAddMorePeakRangesButton();
            TOUBasicTariffSettings.ClickAddMoreValleyRangesButton();

            //Click "Save" button directly without any input
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Verify that Error message '必填项' is displayed below each required fields: '名称',  '峰时电价',  '谷时电价',  '峰时范围',  '谷时范围'. There is no message below '平时电价'.
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsFalse(TOUBasicTariffSettings.IsPlainPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsPlainPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyPriceInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the addition failed and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase3 AddWithDuplicatedName
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-003")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-003")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-003")]
        public void AddWithDuplicatedName(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Input duplicated Name just as the existing one
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();                      

            //Verify the message below the field. 
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalid());
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalidMsgCorrect(testData.ExpectedData));                      

            //verify that the addition failed.
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsTrue(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();
        }
        #endregion

        #region TestCase4 AddWithConflictedRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-004")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-004")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-004")]
        public void AddWithConflictedRanges(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Input Conflicted Ranges
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();
                        
            //Verify the message below the field. 
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakRangeInvalidMsgCorrect(testData.ExpectedData, 2));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyRangeInvalidMsgCorrect(testData.ExpectedData, 2));
            
            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the addition failed and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());

        }
        #endregion

        #region TestCase5 AddTOUNotCover24Hours
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-005")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Add-005")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Add-005")]
        public void AddTOUNotCover24Hours(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Input time range not cover 24 hours, and plain price is empty
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();
                     

            //Verify the message below the field. 
            Assert.IsTrue(TOUBasicTariffSettings.IsTOU24HoursMsgCorrect(testData.ExpectedData.PlainPrice));
            
            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the addition failed and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertySaveButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyCancelButtonDisplayed());
            Assert.IsFalse(TOUBasicTariffSettings.IsBasicPropertyModifyButtonDisplayed());
        }
        #endregion
    
    }
}

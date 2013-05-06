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
        }

        #region TestCase1 AddThenCancel
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-001")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSetting-Add-001")]
        public void AddThenCancel(TOUBasicTariffData testData)
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
            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());

            //Fill in fields with valid inputs，
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase2 AddWithRequiredFieldsEmpty
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-002")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSetting-Add-002")]
        public void AddWithRequiredFieldsEmpty(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //Input required fields as empty
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Verify that Error message '必输项' is displayed below each required fields: '名称',  '峰时电价',  '谷时电价'.
            Assert.IsTrue(TOUBasicTariffSettings.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsPeakPriceInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TOUBasicTariffSettings.IsValleyPriceInvalidMsgCorrect(testData.ExpectedData));

            //Verify the pop message for blank time range. 
            //Note: At the moment, invalid '峰时范围-开始/结束时间' '谷时范围-开始/结束时间' are pop message, later will be changed to be not popup. 
            Assert.IsTrue(TOUBasicTariffSettings.IsPopMsgCorrect(testData.ExpectedData));

            //verify that the addition failed and NOT exists in the list.
            Assert.IsFalse(TOUBasicTariffSettings.IsTOUExist(testData.InputData.CommonName));
        }
        #endregion

        #region TestCase3 AddInvalid
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSetting-Add-003")]
        [CaseID("TC-J1-FVT-TOUTariffSetting-Add-003")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffAddInvalidSuite), "TC-J1-FVT-TOUTariffSetting-Add-003")]
        public void AddInvalid(TOUBasicTariffData testData)
        {
            //Click '+峰谷电价' button
            TOUBasicTariffSettings.ClickBasicPropertyCreateButton();
            TimeManager.ShortPause();

            //TestDataGroup1:Input same Name just as the existing one, Other fields are all valid,
            //TestDataGroup2:Input invalid time ranges, other fields are valid.
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);
            TOUBasicTariffSettings.AddPeakRanges(testData);
            TOUBasicTariffSettings.AddValleyRanges(testData);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();
            TimeManager.MediumPause();

            //Verify the pop message for duplicated name. 
            Assert.IsTrue(TOUBasicTariffSettings.IsPopMsgCorrect(testData.ExpectedData));
            TimeManager.MediumPause();

            //Click 'x' icon to close the pop message box.
            TOUBasicTariffSettings.ClickMsgBoxCloseButton();

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
        }
        #endregion
    }
}

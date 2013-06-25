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
    public class TOUBasicTariffModifyInvalidSuite : TestSuiteBase
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

        #region TestCase1 ModifyTOUCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-001")]
        public void ModifyTOUCancelled(TOUBasicTariffData testData)
        {
            //Select a TOU, using the one '价格ForModify无效' prepared in other case
            TOUBasicTariffSettings.SelectTOU("价格ForModify无效");
            TimeManager.ShortPause();

            //Click 'Modify' button
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            ///Fill in fields with valid inputs，
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Cancel" button
            TOUBasicTariffSettings.ClickBasicPropertyCancelButton();
            TimeManager.MediumPause();

            //verify that the modification is cancelled and original name still exists in the list.
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUExist("价格ForModify无效"));            
        }
        #endregion

        #region TestCase2 ModifyInvalidTOU
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-002")]
        public void ModifyInvalidTOU(TOUBasicTariffData testData)
        {
            //Select a TOU, using the one '价格ForModify无效' prepared in other case
            TOUBasicTariffSettings.SelectTOU("价格ForModify无效");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();

            //Input same Name just as the existing one, Other fields are all valid.
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();

            //Verify the pop message. 
            Assert.IsTrue(TOUBasicTariffSettings.IsPopMsgCorrect(testData.ExpectedData));
            TimeManager.MediumPause();

            //Click 'x' icon to close the pop message box.
            TOUBasicTariffSettings.ClickMsgBoxCloseButton();
        }
        #endregion

        #region TestCase3 ModifyWithInvalidTimeRanges
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyInvalidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-003")]
        public void ModifyWithInvalidTimeRanges(TOUBasicTariffData testData)
        {
            //Select a TOU, using the one '价格ForModify无效' prepared in other case
            TOUBasicTariffSettings.SelectTOU("价格ForModify无效");
            TimeManager.ShortPause();

            //Click 'Modify' button            
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
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

            //verify that the modification failed and original TOU name still exists in the list.
            Assert.IsTrue(TOUBasicTariffSettings.IsTOUExist("价格ForModify无效"));
        }
        #endregion

    }
}

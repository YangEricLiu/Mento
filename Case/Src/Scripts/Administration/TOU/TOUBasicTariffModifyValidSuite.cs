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
    public class TOUBasicTariffModifyValidSuite : TestSuiteBase
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

        #region TestCase1 ModifyTOUBasicFields
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModify名称有效', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-101")]
        public void ModifyTOUBasicFields(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU("价格ForModify名称有效");

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();
            TimeManager.ShortPause();
            //Click "Save" button directly without any change
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Click 'Modify' button again
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

            //Modify the basic fields with new values
            TOUBasicTariffSettings.FillInBasicPropertyName(testData.InputData.CommonName);
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            TOUBasicTariffSettings.FillInBasicPropertyPeakPriceValue(testData.InputData.PeakPrice);
            TOUBasicTariffSettings.FillInBasicPropertyValleyPriceValue(testData.InputData.ValleyPrice);            

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //verify
            TOUBasicTariffSettings.SelectTOU(testData.ExpectedData.CommonName);
            Assert.AreEqual(testData.ExpectedData.CommonName, TOUBasicTariffSettings.GetBasicPropertyNameValue());
            Assert.AreEqual(testData.ExpectedData.PlainPrice, TOUBasicTariffSettings.GetBasicPropertyPlainPriceValue());
            Assert.AreEqual(testData.ExpectedData.PeakPrice, TOUBasicTariffSettings.GetBasicPropertyPeakPriceValue());
            Assert.AreEqual(testData.ExpectedData.ValleyPrice, TOUBasicTariffSettings.GetBasicPropertyValleyPriceValue());

        }
        #endregion

        #region TestCase2 ModifyPlainPriceToBeEmpty
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-102")]
        public void ModifyPlainPriceToBeEmpty(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

            //Modify plain price field to be empty
            TOUBasicTariffSettings.FillInBasicPropertyPlainPriceValue(testData.InputData.PlainPrice);
            //Also need change the range to cover 24 hours
            //TOUBasicTariffSettings.SelectBasicPropertyPeakStartTime("00:00", 1);
            //TOUBasicTariffSettings.SelectBasicPropertyPeakEndTime("12:00", 1);
            //TOUBasicTariffSettings.SelectBasicPropertyValleyStartTime("12:00", 1);
            //TOUBasicTariffSettings.SelectBasicPropertyValleyEndTime("24:00", 1);

            //Click "Save" button
            TOUBasicTariffSettings.ClickBasicPropertySaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");        
            //Verify the plain price is not displayed in view mode.
            Assert.IsTrue(TOUBasicTariffSettings.IsPlainPriceHidden());
        }
        #endregion

        #region TestCase3 ModifyTOUTimeRanges
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModify时间', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-103")]
        public void ModifyTOUTimeRanges(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

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
            JazzMessageBox.LoadingMask.WaitLoading();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");
            //Verify： 对timerange的验证需优化

        }
        #endregion

        #region TestCase4 ModifyTOUToAddMoreTime
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModify时间', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-104")]
        public void ModifyTOUToAddMoreTime(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

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
            JazzMessageBox.LoadingMask.WaitLoading();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");
            //Verify： 对timerange的验证需优化

        }
        #endregion

        #region TestCase5 ModifyTOUToDeleteTimeRange
        /// <summary>
        /// Pre-condition: Prepare a TOU with name '价格ForModify时间', make sure it has been used by a hierarchy node.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        [CaseID("TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUBasicTariffData[]), typeof(TOUBasicTariffModifyValidSuite), "TC-J1-FVT-TOUTariffSettingBasic-Modify-105")]
        public void ModifyTOUToDeleteTimeRange(TOUBasicTariffData testData)
        {
            //Select a TOU, make sure it is not beeing used by any hierarchy node.
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");

            //Click 'Modify' button
            TimeManager.ShortPause();
            TOUBasicTariffSettings.ClickBasicPropertyModifyButton();

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
            JazzMessageBox.LoadingMask.WaitLoading();

            //Start to verify
            TOUBasicTariffSettings.SelectTOU("价格ForModify时间");
            //Verify： 对timerange的验证需优化

        }
        #endregion

    }
}

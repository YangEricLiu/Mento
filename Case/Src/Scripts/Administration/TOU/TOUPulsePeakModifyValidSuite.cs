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
    public class TOUPulsePeakModifyValidSuite : TestSuiteBase
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

        #region TestCase1 ModifyValidPulsePeak
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-101")]
        public void ModifyValidPulsePeak(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略2");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click 'x' icons to delete some pulse peak items
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click 'x' icons to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();

            //Verify '+峰值季节电价' button is displayed and clickable when whole range has been deleted.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
        }
        #endregion

        #region TestCase2 ModifyPulsePeakToAddMoreTime
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-102")]
        public void ModifyPulsePeakToAddMoreTime(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略2");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click 'x' icons to delete some pulse peak items
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click 'x' icons to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();

            //Verify '+峰值季节电价' button is displayed and clickable when whole range has been deleted.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
        }
        #endregion

        #region TestCase3 ModifyToDeleteOnePulsePeak
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-103")]
        public void ModifyToDeleteOnePulsePeak(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略2");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click 'x' icons to delete some pulse peak items
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click 'x' icons to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();

            //Verify '+峰值季节电价' button is displayed and clickable when whole range has been deleted.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
        }
        #endregion

        #region TestCase4 ModifyToDeleteWholePulsePeak
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-104")]
        public void ModifyToDeleteWholePulsePeak(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略2");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyModifyButton();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            //Click 'x' icons to delete some pulse peak items
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakRangeItemButton(2);

            //Click 'x' icons to delete whole pulse peak range
            TOUPulsePeakTariffSettings.ClickDeletePulsePeakWholeRangeButton();

            //Click 'Save' button
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();

            //Verify '+峰值季节电价' button is displayed and clickable when whole range has been deleted.
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
        }
        #endregion

    }
}

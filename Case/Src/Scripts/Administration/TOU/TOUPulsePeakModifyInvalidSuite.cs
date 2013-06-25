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
    public class TOUPulsePeakModifyInvalidSuite : TestSuiteBase
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

        #region TestCase1 ModifyPulsePeakCancelled
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-001")]
        public void ModifyPulsePeakCancelled(TOUPulsePeakTariffData testData)
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

        #region TestCase2 ModifyInvalidPulsePeak
        /// <summary>
        /// Precondition: 1. make sure there is a TOU basic tariff with name '价格策略2'
        ///               2. make sure the TOU tariff has already defined Pulse Peak property.
        /// </summary>
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        [Priority("7")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakModifyValidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Modify-002")]
        public void ModifyInvalidPulsePeak(TOUPulsePeakTariffData testData)
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

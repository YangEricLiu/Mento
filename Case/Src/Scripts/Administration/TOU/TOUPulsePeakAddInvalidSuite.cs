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
    public class TOUPulsePeakAddInvalidSuite : TestSuiteBase
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

        #region TestCase1 AddPulsePeakCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-001")]
        public void AddPulsePeakCancelled(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略1");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();

            //Verify the price
            Assert.AreEqual(testData.InputData.Price, TOUPulsePeakTariffSettings.GetPulsePeakPropertyPriceValue());
        }
        #endregion

        #region TestCase2 AddInvalidPulsePeak
        [Test]
        [ManualCaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        [CaseID("TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        [Priority("2")]
        [MultipleTestDataSource(typeof(TOUPulsePeakTariffData[]), typeof(TOUPulsePeakAddInvalidSuite), "TC-J1-FVT-TOUTariffSettingPulse-Add-002")]
        public void AddInvalidPulsePeak(TOUPulsePeakTariffData testData)
        {
            TOUPulsePeakTariffSettings.FocusOnTOUTariff("价格策略1");
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.SwitchToPulsePeakPropertyTab();
            TimeManager.ShortPause();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyCreateButton();
            TOUPulsePeakTariffSettings.ClickPulsePeakPropertyPlusIcon();
            TimeManager.ShortPause();

            TOUPulsePeakTariffSettings.FillInPulsePeakPropertyPriceValue(testData.InputData.Price);

            //Click '添加峰值季节时间' link and also Fill in the ranges
            TOUPulsePeakTariffSettings.AddPulsePeakRanges(testData);

            TOUPulsePeakTariffSettings.ClickPulsePeakPropertySaveButton();
            TimeManager.ShortPause();

        }
        #endregion
    }
}

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

namespace Mento.Script.Administration.IndustryBenchmark
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-10-1y2")]
    public class BenchmarkModifyValidSuite : TestSuiteBase
    {
        private static IndustryBenchmarkSetting IndustryBenchmarkSetting = JazzFunction.IndustryBenchmarkSetting;
        [SetUp]
        public void CaseSetUp()
        {
            IndustryBenchmarkSetting.NavigatorToBenchMarkSetting();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            TimeManager.MediumPause();
        }

        #region TestCase1 ViewMapAndLocation
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-101")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-101-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkModifyValidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Modify-101-1")]
        public void ModifyIndustryBenchmarkValid(IndustryBenchmarkData input)
        {
            //Industry. Click a benchmark(行业=酒店; 区域=全部地区+严寒地区A区 ) from list and click 修改 button.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickModifyBenchMark();
            TimeManager.ShortPause();

            //· The benchmark combox is gray and can't not be modified.
            //· The benchmark combox display the correct industry.
            //· All the checked and unchecked 区域 display in modify mode.
            Assert.IsFalse(IndustryBenchmarkSetting.IsIndustryComboxEnabled());
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.InputData.ClimaticRegions));
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.ExpectedData.ClimaticRegions));

            //Check some 区域=温和地区；uncheck some 区域=全部地区 checkbox. Click Save button.
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[4]);
            IndustryBenchmarkSetting.UnCheckClimateRegion(input.InputData.ClimaticRegions[0]);
            IndustryBenchmarkSetting.ClickSaveBenchMark();
            TimeManager.ShortPause();

            //· The modified benchmark save to benchmark list successfully.
            //· The 行业 is gray out and can't be modified.
            Assert.IsFalse(IndustryBenchmarkSetting.IsIndustryComboxEnabled());

            //Click the modified menchmark from list.
            //Go to view status and the 行业=通讯 and checked 区域=温和地区+严寒地区A区 display.
            Assert.AreEqual(input.InputData.Industry, IndustryBenchmarkSetting.GetSelectedIndustry());
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.ExpectedData.Industrys));


            //2.Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //· There isn't any 行业=酒店 can be selected from dropdown list. 
            Assert.IsFalse(IndustryBenchmarkSetting.IsDropdownItemExist(input.InputData.Industry));

            //Select 行业=通讯. The 区域 display all item unchecked. 
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsUnChecked(input.InputData.ClimaticRegions));

            //Click other benchmark from list and click 修改 button. Go to 行业 dropdown list to check.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickModifyBenchMark();
            Assert.IsFalse(IndustryBenchmarkSetting.IsDropdownItemExist(input.InputData.Industry));

        }
        #endregion

        #region TestCase2 SaveBenchmarkWithoutModify
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-101")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-101-2")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkModifyValidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Modify-101-2")]
        public void SaveBenchmarkWithoutModify(IndustryBenchmarkData input)
        {
            //Industry. Click a benchmark(行业=全行业; 区域=全部地区 ) from list and click 修改 button.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickModifyBenchMark();
            TimeManager.ShortPause();

            //· The benchmark combox is gray and can't not be modified.
            //· The benchmark combox display the correct industry.
            //· All the checked and unchecked 区域 display in modify mode.
            Assert.IsFalse(IndustryBenchmarkSetting.IsIndustryComboxEnabled());
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.ExpectedData.ClimaticRegions));

            //· checked区域=全部地区 and other regions are unchecked.
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsChecked(input.InputData.ClimaticRegions));

            //Click save directly without modification.
            //· Go to view status and the 行业=全行业 and checked 区域=全部地区 display.
            IndustryBenchmarkSetting.ClickSaveBenchMark();
            TimeManager.ShortPause();
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsChecked(input.InputData.ClimaticRegions));
        }
        #endregion
    }
}

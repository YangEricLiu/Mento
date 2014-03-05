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
    [CreateTime("2013-1y0-10")]
    public class BenchmarkDeleteValidSuite : TestSuiteBase
    {
        private static IndustryBenchmarkSetting IndustryBenchmarkSetting = JazzFunction.IndustryBenchmarkSetting;
        [SetUp]
        public void CaseSetUp()
        {
            IndustryBenchmarkSetting.NavigatorToBenchMarkSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 DeleteIndustryBenchmarkValid
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Delete-101")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Delete-101-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkDeleteValidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Delete-101-1")]
        public void DeleteIndustryBenchmarkValid(IndustryBenchmarkData input)
        {
            //Click a benchmark(行业=酒店; 区域=全部地区+严寒地区A区 ) from list and click 删除 button.
            //·Pop up window show 是否删除.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickDeleteBenchMark();

            //After click confirmation 确定 button.Delete benchmark successfully.
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            //· Deleted benchmark can't display in benchmark list correctly.
            Assert.IsFalse(IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industry));

            //Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //Select 行业=酒店 and check 区域=全部地区+严寒地区A区. Click Save button.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);
            Assert.AreEqual(input.InputData.Industry,IndustryBenchmarkSetting.GetSelectedIndustry());
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[1]);
            IndustryBenchmarkSetting.ClickSaveBenchMark();

            //· The benchmark the same as deleted one save to menchmark list successfully.
            IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industry);
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[0]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[1]));
        }
        #endregion

    }
}

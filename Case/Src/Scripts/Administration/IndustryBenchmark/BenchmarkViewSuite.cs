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
    public class BenchmarkViewSuite : TestSuiteBase
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

        #region TestCase1 ViewMapAndLocation
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-View-101")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-View-101-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkViewSuite), "TC-J1-FVT-IndustryBenchmarkSetting-View-101-1")]
        public void ViewMapAndLocation(IndustryBenchmarkData input)
        {
            //Click one Benchmark from Benchmark List.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);

            //·Display properties 行业 and 区域 of selected benchmark in View mode. 
            //· Only the checked 区域 display in view mode.The checkboxes are disabled in View mode.

            Assert.AreEqual(input.InputData.Industry,IndustryBenchmarkSetting.GetSelectedIndustry());
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[1]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[6]));

            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[2]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[3]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[4]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[5]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[0]));

            //Verify benchmark list column filter and sort.Not support filter and sort for any column.

        }
        #endregion

    }
}

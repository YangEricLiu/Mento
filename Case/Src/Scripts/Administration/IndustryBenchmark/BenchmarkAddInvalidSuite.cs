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
    [CreateTime("2013-10-12")]
    public class BenchmarkAddInvalidSuite : TestSuiteBase
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

        #region TestCase1 AddIndustryBenchmarkCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkAddInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Add-001-1")]
        public void AddIndustryBenchmarkCancelled(IndustryBenchmarkData input)
        {

            //Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //Select 行业=酒店 from dropdown list.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);

        }
        #endregion

        #region TestCase2 AddIndustryBenchmarkInvalid
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-001-2")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkAddInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Add-001-2")]
        public void AddIndustryBenchmarkInvalid(IndustryBenchmarkData input)
        {

            //Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //Select 行业=酒店 from dropdown list.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);

        }
        #endregion

    }
}

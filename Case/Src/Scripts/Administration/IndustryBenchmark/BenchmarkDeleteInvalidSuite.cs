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
    [CreateTime("2013-10-1y0")]
    public class BenchmarkDeleteInvalidSuite : TestSuiteBase
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

        #region TestCase1 DeleteIndustryBenchmarkCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Delete-001")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Delete-001-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkDeleteInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Delete-001-1")]
        public void DeleteIndustryBenchmarkCancelled(IndustryBenchmarkData input)
        {
            //Click a benchmark(行业=酒店; 区域=全部地区+严寒地区A区 ) from list and click 删除 button.
            //·Pop up window show 是否删除.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickDeleteBenchMark();

            //After click confirmation Cancel button.
            JazzMessageBox.MessageBox.Cancel();

            //The benchmark still display in menchmark list.
            Assert.IsTrue(IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industry));

            //After click confirmation "X" button.
            IndustryBenchmarkSetting.ClickDeleteBenchMark();
            JazzMessageBox.MessageBox.Close();

            //The benchmark still display in menchmark list.
            Assert.IsTrue(IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industry));
        }
        #endregion

    }
}

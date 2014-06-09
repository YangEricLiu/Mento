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

            //Click Cancel button before select any 行业 and 区域.
            IndustryBenchmarkSetting.ClickCancelBenchMark();

            //·Cancel and there isn't any beachmark added to list.
            int i = 0;
            while (i < input.InputData.Industrys.Length)
            {
                Assert.IsFalse(IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industrys[i]));
                i++;
            }
            
            //Click +行业对标 buttons. Select 行业=酒店五星级 and click Save button. 
            IndustryBenchmarkSetting.ClickAddBenchMark();
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickSaveBenchMark();

            //After note show "请至少选择一项。", Click Cancel button.
            Assert.IsTrue(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());
            IndustryBenchmarkSetting.ClickCancelBenchMark();

            //Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //·There isn't pop up note at 区域 "请至少选择一项。" when add agin.
            Assert.IsFalse(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());

            //Select 行业=酒店五星级  and check one 区域=严寒地区B区. 
            //Click Cancel button.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryBenchmarkSetting.CheckClimateRegions(input.InputData.ClimaticRegions);
            IndustryBenchmarkSetting.ClickCancelBenchMark();

            //Then click +行业对标 buttons.
            //·Cancel and there isn't any beachmark added to list.
            //· The dropdown list can still select 行业=酒店五星级  and there isn't any 区域 is checked.
            IndustryBenchmarkSetting.ClickAddBenchMark();
            Assert.IsTrue(IndustryBenchmarkSetting.IsIndustryInDropdownList(input.InputData.Industry));
            Assert.IsTrue(IndustryBenchmarkSetting.AreClimateRegionsUnChecked(input.ExpectedData.ClimaticRegions));
            IndustryBenchmarkSetting.ClickCancelBenchMark();
            Assert.IsFalse(IndustryBenchmarkSetting.IsRowExistBenchMarkList(input.InputData.Industry));

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

            //Click Save button before select any 行业 and 区域.
            IndustryBenchmarkSetting.ClickSaveBenchMark();

            //·Red line display at 行业.
            Assert.AreEqual(input.ExpectedData.InvalidMessage[0], IndustryBenchmarkSetting.GetIndustrysAddMessageInvalidMsg());

            //Select 行业=酒店五星级 and Click Save button.
            //·Save failed with pop up note at 区域 "请至少选择一项。"
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryBenchmarkSetting.ClickSaveBenchMark();
            Assert.IsTrue(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());
        }
        #endregion

    }
}

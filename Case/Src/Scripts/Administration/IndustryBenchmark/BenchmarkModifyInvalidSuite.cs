//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using Mento.Framework;
//using Mento.Utility;
//using Mento.TestApi.TestData;
//using Mento.TestApi.WebUserInterface;
//using Mento.ScriptCommon.Library.Functions;
//using Mento.Framework.Attributes;
//using Mento.Framework.Script;
//using Mento.ScriptCommon.TestData.Administration;
//using Mento.ScriptCommon.Library;
//using Mento.TestApi.WebUserInterface.Controls;
//using Mento.TestApi.WebUserInterface.ControlCollection;

//namespace Mento.Script.Administration.IndustryBenchmark
//{
//    [TestFixture]
//    [Owner("Greenie")]
//    [CreateTime("2013-10-12")]
//    public class BenchmarkModifyInvalidSuite : TestSuiteBase
//    {
//        private static IndustryBenchmarkSetting IndustryBenchmarkSetting = JazzFunction.IndustryBenchmarkSetting;
//        [SetUp]
//        public void CaseSetUp()
//        {
//            IndustryBenchmarkSetting.NavigatorToBenchMarkSetting();
//            TimeManager.MediumPause();
//        }

//        [TearDown]
//        public void CaseTearDown()
//        {
//            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
//            //TimeManager.MediumPause();
//        }

//        #region TestCase1 ModifyIndustryBenchmarkCancelled
//        [Test]
//        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-001")]
//        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-001-1")]
//        [Priority("4")]
//        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkModifyInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Modify-001-1")]
//        public void ModifyIndustryBenchmarkCancelled(IndustryBenchmarkData input)
//        {
//            //Click a benchmark(行业=酒店; 区域=温和地区+严寒地区A区 ) from list and click 修改 button.
//            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
//            IndustryBenchmarkSetting.ClickModifyBenchMark();
//            //Click Cancel button directly.
//            IndustryBenchmarkSetting.ClickCancelBenchMark();

//            //·Modify canceled and the benchmark display old view status.
//            IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.InputData.ClimaticRegions);
//            IndustryBenchmarkSetting.AreClimateRegionsNotDisplay(input.ExpectedData.ClimaticRegions);

//            //Click a benchmark from list and click 修改 button. 
//            //Check some 区域=温和地区；uncheck some 区域=全部地区. Click Cancel button.
//            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
//            IndustryBenchmarkSetting.ClickModifyBenchMark();
//            IndustryBenchmarkSetting.UnCheckClimateRegion(input.InputData.ClimaticRegions[1]);
//            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[2]);
//            IndustryBenchmarkSetting.ClickCancelBenchMark();

//             //·Modify canceled and the benchmark display old view status before modify.
//            IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.InputData.ClimaticRegions);
//            IndustryBenchmarkSetting.AreClimateRegionsNotDisplay(input.ExpectedData.ClimaticRegions);
           
//            // (行业=酒店; 区域=全部地区+严寒地区A区)
//            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);

//            //click 修改 button.Click save directly without modification.
//            IndustryBenchmarkSetting.ClickModifyBenchMark();
//            IndustryBenchmarkSetting.ClickSaveBenchMark();

//            //The benchmark display old view status before modify. (行业=酒店; 区域=全部地区+严寒地区A区 )
//            IndustryBenchmarkSetting.AreClimateRegionsDisplay(input.InputData.ClimaticRegions);
//            IndustryBenchmarkSetting.AreClimateRegionsNotDisplay(input.ExpectedData.ClimaticRegions);

//        }
//        #endregion

//        #region TestCase1 ModifyIndustryBenchmarkInvalid
//        [Test]
//        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-001")]
//        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Modify-001-2")]
//        [Priority("4")]
//        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkModifyInvalidSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Modify-001-2")]
//        public void ModifyIndustryBenchmarkInvalid(IndustryBenchmarkData input)
//        {
//            //Click a benchmark from list and click 修改 button.
//            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);
//            IndustryBenchmarkSetting.ClickModifyBenchMark();
//            //Uncheck all 区域 checkbox and Click Save button.
//            IndustryBenchmarkSetting.UnCheckClimateRegions(input.InputData.ClimaticRegions);
//            IndustryBenchmarkSetting.ClickSaveBenchMark();

//            //·Save failed with pop up note at 区域 "请至少选择一项。"
//            Assert.IsTrue(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());

//            //Check one 区域=严寒地区B区.·  "请至少选择一项。" disappeared.

//           IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);
//           Assert.IsFalse(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());
//            //Uncheck 区域=严寒地区B区.Not pop up note at 区域 "请至少选择一项。" again.
//           IndustryBenchmarkSetting.UnCheckClimateRegion(input.InputData.ClimaticRegions[0]);
//           Assert.IsFalse(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());
//            //Click Save button.Save failed with pop up note at 区域 "请至少选择一项。"
//           IndustryBenchmarkSetting.ClickSaveBenchMark();
//           Assert.IsTrue(IndustryBenchmarkSetting.IsCliamteRegionsMessageDisplayed());

//            //Check one 区域=严寒地区B区 and saved.
//            //The modified benchmark save to benchmark list successfully.
//           IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[2]);
//           IndustryBenchmarkSetting.ClickSaveBenchMark();
//           TimeManager.ShortPause();
            
//        }
//        #endregion

//    }
//}

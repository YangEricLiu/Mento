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
    public class BenchmarkAddValidgSuite : TestSuiteBase
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
        [ManualCaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-101")]
        [CaseID("TC-J1-FVT-IndustryBenchmarkSetting-Add-101-1")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryBenchmarkData[]), typeof(BenchmarkAddValidgSuite), "TC-J1-FVT-IndustryBenchmarkSetting-Add-101-1")]
        public void AddIndustryBenchmarkValid(IndustryBenchmarkData input)
        {
            /*
            //Click +行业对标 buttons.
            IndustryBenchmarkSetting.ClickAddBenchMark();

            //Select 行业=酒店 from dropdown list.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);

            //Display properties of selected benchmark in add mode. 
            Assert.AreEqual(input.InputData.Industry,IndustryBenchmarkSetting.GetSelectedIndustry());

            //Check some 区域=全部地区+严寒地区A区 checkbox. Click Save button.
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[1]);
            IndustryBenchmarkSetting.ClickSaveBenchMark();

            //· Only the checked 区域=全部地区+严寒地区A区 display in view status. The unchecked 区域 not display
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[0]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[1]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[2]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[3]));
            Assert.IsTrue(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[4]));
            
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[0]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[1]));

            //Click the saved menchmark from list.
            IndustryBenchmarkSetting.FocusOnBenchMark(input.InputData.Industry);

            //· Go to view status and the 行业=酒店 and 区域= display successfully the same as before save.
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[0]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[1]));

            //Click +行业对标 buttons. Go to 行业 dropdown list to check.
            IndustryBenchmarkSetting.ClickAddBenchMark();
            IndustryBenchmarkSetting.DisplayIndustryItems();
            //· The saved benchmark 行业 will not display in the dropdown list.
            Assert.IsFalse(IndustryBenchmarkSetting.IsIndustryInDropdownList(input.InputData.Industry));

            //Select 行业=酒店三星级 from dropdown list, Check all 区域=全部地区+严寒地区A区_...... checkbox box. Click Save button.
            IndustryBenchmarkSetting.SelectIndustryCombox(input.ExpectedData.Industry);
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[1]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[0]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[1]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[2]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[3]);
            IndustryBenchmarkSetting.CheckClimateRegion(input.ExpectedData.ClimaticRegions[4]);
            IndustryBenchmarkSetting.ClickSaveBenchMark();

            //· The benchmark with all 区域 save to bmenchmark list successfully.
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[0]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.InputData.ClimaticRegions[1]));

            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[0]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[1]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[2]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[3]));
            Assert.IsFalse(IndustryBenchmarkSetting.IsClimateRegionNotDisplay(input.ExpectedData.ClimaticRegions[4]));
            */
            //Add all 行业 from dropdown list. Click +行业对标 buttons. 21 Industrys
            int i = 0;
            while (i < input.InputData.Industrys.Length)
            {
                IndustryBenchmarkSetting.ClickAddBenchMark();
                IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industrys[i]);
                IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);
                IndustryBenchmarkSetting.ClickSaveBenchMark();
                i++;
            }
            IndustryBenchmarkSetting.ClickAddBenchMark();
            //· There isn't any 行业 item can be selected from dropdown list.
            //· 行业=全部；区域=全部区域 can be selected and save successfully.

            //Assert.IsTrue(IndustryBenchmarkSetting.GetIndustryLists().Equals(""));
        }
        #endregion

    }
}

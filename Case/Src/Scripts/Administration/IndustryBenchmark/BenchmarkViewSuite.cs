﻿using System;
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
    [CreateTime("2013-10-10")]
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
            //·Display blank benchmark list, when there isn't any Benchmark defind.
            //· Display Add System buttons.

            Assert.IsTrue(IndustryBenchmarkSetting.IsAddButtonDisplay());

            IndustryBenchmarkSetting.ClickAddBenchMark();

            IndustryBenchmarkSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryBenchmarkSetting.CheckClimateRegion(input.InputData.ClimaticRegions[0]);

            IndustryBenchmarkSetting.ClickCancelBenchMark();

            //Verify benchmark list column filter and sort.

        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.TestApi.TestData;
using System.Data;
using Mento.Utility;

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101"), CreateTime("2013-08-13"), Owner("Emma")]
    public class MultipleIntervalsComparasionDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-1")]
        [MultipleTestDataSource(typeof(TimeSpansData[]), typeof(MultipleIntervalsComparasionDataViewSuite), "TC-J1-FVT-MultipleIntervalsComparasion-DataView-101-1")]
        public void AddTimeSpanDataViewAndVerify(TimeSpansData input)
        {
            //"+时间段" button is disabled when there is no tag selected
            Assert.IsFalse(EnergyViewToolbar.IsTimeSpanButtonEnable());
            
            //Select one tag and view data view
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();
            
            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());

            EnergyViewToolbar.AddTimeSpan(new DateTime(2013, 1, 11));

            //EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);

            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            
        }


    }
}

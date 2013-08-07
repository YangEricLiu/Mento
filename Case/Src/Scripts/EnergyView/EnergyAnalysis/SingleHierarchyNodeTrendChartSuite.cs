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
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101"), CreateTime("2013-07-31"), Owner("Emma")]
    public class SingleHierarchyNodeTrendChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;



        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        public void ViewLineChartOfTagThenClear(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Uncheck v1, and select another tag under area dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            EnergyAnalysis.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Uncheck v2, and select another tag under system dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.SwitchTagTab(TagTabs.SystemDimensionTab);
            EnergyAnalysis.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Uncheck v3 with clear all data
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.ShortPause();
            Assert.IsTrue(EnergyAnalysis.IsAllGridTagsUnchecked());
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        public void TestExcelToDataTable(EnergyViewOptionData input)
        {
            //string filePath = "D:\\data3.xls";
            string filePath2 = "D:\\dataExpected1.xls";


            //DataTable test = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath2, JazzFunction.DataViewOperation.sheetNameExpected);
            //Assert.IsNotNull(test);

            JazzFunction.UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            JazzFunction.UnitKPIPanel.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            TimeManager.ShortPause();

            JazzFunction.UnitKPIPanel.CheckTag(input.InputData.TagNames[0]);
            

            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            DataTable actual = JazzFunction.UnitKPIPanel.GetAllData();
            Assert.IsNotNull(actual);
        }

    }
}

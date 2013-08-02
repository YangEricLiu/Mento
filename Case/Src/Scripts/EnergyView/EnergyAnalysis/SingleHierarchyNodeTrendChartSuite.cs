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
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
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
        public void ViewLineChartOfTagThenClear(EnergyViewOptionData option)
        {


            EnergyAnalysis.SelectHierarchy(option.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.CheckTag(option.InputData.TagNames[0]);

            EnergyViewToolbar.ClickViewButton();

            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            EnergyViewToolbar.View(EnergyViewType.Column);
            //EnergyViewToolbar.ClickViewButton();

            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        public void TestExcelToDataTable(EnergyViewOptionData option)
        {
            string filePath = "D:\\data3.xls";
            string filePath2 = "D:\\dataExpected1.xls";

            /*
            DataTable test = JazzFunction.DataViewOperation.ImportToDataTable(filePath, "SheetExpected");
            Assert.IsNotNull(test);

            Assert.AreEqual(2, test.Columns.Count);
            Assert.AreEqual(22, test.Rows.Count);
            */
            
            JazzFunction.UnitKPIPanel.SelectHierarchy(option.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyViewToolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 12, 31));
            TimeManager.ShortPause();

            JazzFunction.UnitKPIPanel.CheckTag(option.InputData.TagNames[0]);
            

            EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();

            DataTable actual = EnergyAnalysis.GetAllData();
            Assert.IsNotNull(actual);

            //Assert.AreEqual(2, actual.Columns.Count);
            //Assert.AreEqual(22, actual.Rows.Count);

            JazzFunction.DataViewOperation.ExportDataTableToExcel(actual, filePath2, "SheetExpected");

            //Assert.IsTrue(JazzFunction.DataViewOperation.CompareDataTables(test, actual));
        }

    }
}

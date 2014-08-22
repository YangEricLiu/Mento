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
    [ManualCaseID("TC-J1-FVT-EnergyConsumption-PieChart-101"), CreateTime("2014-05-30"), Owner("Emma")]
    public class EnergyConsumptionPieChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            //JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [Test]
        [CaseID("TC-J1-FVT-EnergyConsumption-PieChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(EnergyConsumptionPieChartSuite), "TC-J1-FVT-EnergyConsumption-PieChart-101-1")]
        public void EnergyConsumptionPieChart01(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Go to UT tool. Go to Energy Analysis. Select NancyOtherCustomer3->BuildingRanking1+BuildingRanking2+…BuildingRanking30, select different time range to view pie chart.
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select the BuildingBC node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis.
            for (int i = 0; i < input.InputData.MultipleHierarchyAndtags.Length; i++)
            {
                MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[i].HierarchyPath);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.ShortPause();

                MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[i].TagsName[0]);
                TimeManager.ShortPause();
            }
            
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //Time range = A. 2012/12/31 20:00 to 2013/01/01 4:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Time range = B. 2013/01/01 23:00 to 2013/01/05 2:00.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[1], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            var dashboard = input.InputData.DashboardInfos;
            EnergyViewToolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.LongPause();

            //Time range = C. 2013/01/01 23:00 to 2013/03/01 3:00.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[2].StartDate, ManualTimeRange[2].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[2].StartTime, ManualTimeRange[2].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[2], input.ExpectedData.expectedFileName[2]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Time range = D. 2013/01/01 23:00 to 2014/01/01 1:00.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[3].StartDate, ManualTimeRange[3].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[3].StartTime, ManualTimeRange[3].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(60);
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[3], input.ExpectedData.expectedFileName[3]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            EnergyViewToolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            TimeManager.LongPause();

            //Time range = E. 2012/12/13 23:00 to 2014/03/01 4:00.
            EnergyViewToolbar.SetDateRange(ManualTimeRange[4].StartDate, ManualTimeRange[4].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[4].StartTime, ManualTimeRange[4].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading(60);
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[4], input.ExpectedData.expectedFileName[4]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            EnergyViewToolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-EnergyConsumption-PieChart-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(EnergyConsumptionPieChartSuite), "TC-J1-FVT-EnergyConsumption-PieChart-101-2")]
        public void EnergyConsumptionPieChart02(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);

            //Time range = 2013/01/01 to 2013/10/26 21:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //·Message show 新增数据点与已绘制数据点介质不同，无法共同绘制饼状图！
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.NotDrawPieMessage[0]));

            //After click "好".
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.EntirelyNoChartDrawn());

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);

            //Time range = 2013/08/18 12:00 to 2013/10/18 21:00
            EnergyViewToolbar.SetDateRange(ManualTimeRange[1].StartDate, ManualTimeRange[1].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[1].StartTime, ManualTimeRange[1].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //·Message show 新增数据点与已绘制数据点介质不同，无法共同绘制饼状图！
            msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.NotDrawPieMessage[1]));

            //After click "好".
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.EntirelyNoChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-EnergyConsumption-PieChart-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(EnergyConsumptionPieChartSuite), "TC-J1-FVT-EnergyConsumption-PieChart-101-3")]
        public void EnergyConsumptionPieChart03(EnergyViewOptionData input)
        {
            //Go to UT tool. Go to Energy Analysis. Select NancyCustomer1, select 10 tags under the same hierarchy node BuildingPieVerify to pie chart.
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTags(input.InputData.TagNames);

            //Time range = 2013/01/01 23:00 to 2013/03/01 3:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }

        [Test]
        [CaseID("TC-J1-FVT-EnergyConsumption-PieChart-101-4")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(EnergyConsumptionPieChartSuite), "TC-J1-FVT-EnergyConsumption-PieChart-101-4")]
        public void EnergyConsumptionPieChart04(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTags(input.InputData.TagNames);

            //Time range = A. 2012/12/31 20:00 to 2013/01/01 4:00.
            var ManualTimeRange = input.InputData.ManualTimeRange;

            for (int i = 0; i < ManualTimeRange.Length; i++)
            {
                EnergyViewToolbar.SetDateRange(ManualTimeRange[i].StartDate, ManualTimeRange[i].EndDate);
                EnergyViewToolbar.SetTimeRange(ManualTimeRange[i].StartTime, ManualTimeRange[i].EndTime);
                TimeManager.ShortPause();

                //Check tag and view pie chart
                EnergyViewToolbar.View(EnergyViewType.Distribute);
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.MediumPause();

                EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[i], input.ExpectedData.expectedFileName[i]);
                TimeManager.MediumPause();
                EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[i], input.InputData.failedFileName[i]);
            }         
        }

        [Test]
        [CaseID("TC-J1-FVT-EnergyConsumption-PieChart-101-5")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(EnergyConsumptionPieChartSuite), "TC-J1-FVT-EnergyConsumption-PieChart-101-5")]
        public void EnergyConsumptionPieChart05(EnergyViewOptionData input)
        {
            //Go to NancyOtherCustomer3->Labellingtag1.
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);

            //Select time 2013/11/26 11:00 to 12:00 view data view. 1KWH.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);

            //Select time 2013/11/26 11:00 to 12:00 view pie view. should display 1KWH.
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryToExcel(input.InputData.Hierarchies, ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }
    }
}

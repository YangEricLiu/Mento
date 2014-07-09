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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SaveToDashboard-101"), CreateTime("2014-07-09"), Owner("Emma")]
    public class SaveToDashboardSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static SaveToDashboardDialog SaveToDs = new SaveToDashboardDialog();
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;

        [SetUp]
        public void CaseSetUp()
        {
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-1")]
        public void EnergyAnalysisSingleHierarchySaveTDashboard(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //A. Select Single Hierarchy node 楼宇A BuildingA_P1_Electricity.
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view line chart , A. 之前七天, line chart
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //非工作时间
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarNonWorkday);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last30Day);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, pie
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //之前30天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

        [Test]
        [CaseID("TC-J1-FVT-SaveToDashboard-101-2")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(SaveToDashboardSuite), "TC-J1-FVT-SaveToDashboard-101-2")]
        public void EnergyAnalysisMultiHierarchySaveTDashboard(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            var dashboard = input.InputData.DashboardInfos;

            //B. Select Multiple Hierarchy node 楼宇A BuildingA_P1_Electricity+楼宇B BuildingB_P1_Electricity+BuildingB_P2_Water. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

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

            //之前12月, line
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.Last12Month);
            TimeManager.MediumPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //冷暖季
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ShowCalendarHeatCool);
            TimeManager.LongPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //本月, Column
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.ThisMonth);
            TimeManager.MediumPause();
            EnergyViewToolbar.View(EnergyViewType.Column);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WigetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //今年, pie
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WigetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[2].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //昨天, data view
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WigetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[2].WigetName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[3].WigetName)); 
        }

    }
}

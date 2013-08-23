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
    [ManualCaseID("TC-J1-FVT-MultipleTagsComparision-002"), CreateTime("2013-08-21"), Owner("Emma")]
    public class SingleHierarchyMultiTagsTrendChartSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-MultipleTagsComparision-TrendChart-001-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyMultiTagsTrendChartSuite), "TC-J1-FVT-MultipleTagsComparision-TrendChart-001-1")]
        public void MultipleTagsSingleHieTrendChart(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            EnergyAnalysis.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 7));
            TimeManager.ShortPause();

            //Select V(6) under Area dimension node to draw Data view.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Keep V(6) checked, and select V(1) to draw Data view.
            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Check one more vtag V(2) on system dimension
            EnergyAnalysis.SwitchTagTab(TagTabs.SystemDimensionTab);
            EnergyAnalysis.SelectSystemDimension(input.InputData.SystemDimensionPath);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //checked one more ptag P(1) checkbox.
            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[3]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Check other 5 vtags.
            EnergyAnalysis.CheckTags(input.InputData.MoreTagNames);

            //Check vtag V(Null) checkbox. V(Null) is new created, not offline calculation, no energy data display. 
            EnergyAnalysis.CheckTag(input.InputData.TagNames[4]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //can't check any tags checkbox on All Tag list/System dimension/Area dimension tab
            Assert.IsTrue(EnergyAnalysis.IsNoEnabledCheckbox());
            EnergyAnalysis.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsNoEnabledCheckbox());
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsNoEnabledCheckbox());

            //Remove selection vtag V(14) from checkbox, The checkbox can be checked 
            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[4]);
            TimeManager.ShortPause();
            Assert.IsTrue(EnergyAnalysis.IsAllEnabledCheckbox());

            //Select one more vtag V(13) in the display tags list.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[5]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Click "Save to dashboard"to save the Data view to Hierarchy node dashboard
            var dashboard = input.InputData.DashboardInfo;
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            TimeManager.LongPause();

            //Click  "删除所有" option then cancel
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();

            //Click  "删除所有" option then confirm
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.MediumPause();
            Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());

            //On homepage, check the dashboard
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
        }
    }
}

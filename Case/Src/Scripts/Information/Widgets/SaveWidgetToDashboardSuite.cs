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


namespace Mento.Script.Information.Widgets
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Widget-Add-101"), CreateTime("2013-10-10"), Owner("Emma")]
    public class SaveWidgetToDashboardSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [SetUp]
        public void CaseSetUp()
        {
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Add-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(SaveWidgetToDashboardSuite), "TC-J1-FVT-Widget-Add-101-1")]
        public void SaveWidgetToExistingDashboard(MaximizeWidgetData input)
        {
            string[] deleteMessage = { "删除小组件“Widget_Delete_101_1_1”吗？", "删除小组件“Widget_Delete_101_1_2”吗？", "删除小组件“Widget_Delete_101_1_3”吗？", "删除小组件“Widget_Delete_101_1_4”吗？" };

            var dashboard = input.InputData.DashboardInfo;

            //Add a widget whose name is the same as the deleted widget for the same dashboard of the Hiearchy node. 
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
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

            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));            
        }
    }
}

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
    [ManualCaseID("TC-J1-FVT-Widget-Annotation-101"), CreateTime("2014-2-18"), Owner("Emma")]
    public class AnnotationViewSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Widget-Annotation-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(AnnotationViewSuite), "TC-J1-FVT-Widget-Annotation-101-1")]
        public void SaveWidgetWithBlankAnnotation(MaximizeWidgetData input)
        {
            //nothing      
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Annotation-101-2")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(AnnotationViewSuite), "TC-J1-FVT-Widget-Annotation-101-2")]
        public void SaveWidgetWithAnnotation(MaximizeWidgetData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Navigate to Energy Analysis, 
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Save to Dashboard without annotation
            EnergyAnalysis.Toolbar.SaveToDashboardwithAnnotation(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName, dashboard[0].Comment);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Navigate to Homepage->Dashboard
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            //Click the dashboard and verify the widget.
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //A widget with default name, proper annotation and are added into the selected dashboard successfully.

        }
    }
}

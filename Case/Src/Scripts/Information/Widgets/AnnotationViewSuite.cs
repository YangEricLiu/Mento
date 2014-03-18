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

            //Save to Dashboard with annotation
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
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.widgetComment[0], HomePagePanel.GetExistedCommentMinWdiget());

            //Go to check favorite dashboard.The widget with added annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.widgetComment[0], HomePagePanel.GetExistedCommentMinWdiget());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Annotation-101-3")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(AnnotationViewSuite), "TC-J1-FVT-Widget-Annotation-101-3")]
        public void AnnotationViewInMaximumWindow(MaximizeWidgetData input)
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
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Navigate to Homepage->Dashboard
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click the dashboard and click the widget.Widget display in maximum size.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);

            //Verify annotation in the bottom.The annotation is blank with Add button
            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();

            //Click Add button.The Edit widget annotation window display.
            //Add some annotation in annotation field and click Confirm button.The annotation can be added properly.
            Widget.EditAnnotationWindow(dashboard[0].Comment);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Verify annotation in the bottom.The tooltip display with the new annotation. The Edit button display.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.widgetComment[0], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.The widget with modify new annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.widgetComment[0], HomePagePanel.GetExistedCommentMinWdiget());

            //Navigate to Homepage->Dashboard
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click the dashboard and click the widget.Widget display in maximum size.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);

            //Click Edit button.Modify the annotation.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();

            Widget.EditAnnotationWindow(input.ExpectedData.widgetComment[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //The annotation can be modified properly.
            Assert.AreEqual(input.ExpectedData.widgetComment[1], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.widgetComment[1], HomePagePanel.GetExistedCommentMinWdiget());

            //Navigate to Homepage->Dashboard
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Change the annotation to blank and click Confirm button.
            //The annotation can be change to blank with no error.Edit button change to Add button properly. The icon is highlight.
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();

            Widget.EditAnnotationWindow(input.ExpectedData.widgetComment[2]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.The widget with no annotation display
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }
    }
}

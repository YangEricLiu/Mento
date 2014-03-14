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

namespace Mento.Script.Information.WidgetCollaborativeShare
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101"), CreateTime("2014-03-14"), Owner("Emma")]
    public class WidgetCollaborativeAnnotationSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static Widget Widget = JazzFunction.Widget;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static ShareWindow ShareWindow = new ShareWindow();
        private static ShareInfoWindow ShareInfoWindow = new ShareInfoWindow();
        private static int WAITSHAREINFOTAB = 5000;
        
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.ExitJazz();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //logout Jazz
            HomePagePanel.ExitJazz();

            JazzFunction.LoginPage.LoginWithOption("PerfTestCustomer", "123456Qq", "NancyCustomer1");
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-1")]
        public void ShareWidgetWithNoAnnotation(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with userA. Navigate to homepage, then to hierarchynodeA.  Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA and click "ShareCollaborative" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB in the left panel and then click Confirm button.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserA.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the blank annotation.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Click the schema picture area in widgetA.The annotation is blank with Add button.
            //Click Add button and add the annotation.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //The annotation is added with Edit button.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB.Navigate to homepage, then to "Collaborative Widget " tab, and then click the schema picture area in widgetA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //The annotation add to new the same as UserA.
            Assert.AreEqual(dashboard[0].widgetComments[0], Widget.GetMaxWidgetComment());

            //The annotation window  without Edit button
            Assert.IsFalse(Widget.IsEditMaxWidgetCommentButtonDisplayed());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-2")]
        public void ShareWidgetWithAddAnnotation(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with userA. Navigate to homepage, then to hierarchynodeA.  Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA and click "ShareCollaborative" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB in the left panel ,add some annotation and then click Confirm button.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            ShareWindow.FillEnjoyWindowComment(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the annotation.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            //Click the schema picture area in widgetA
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //The annotation can be display well with Edit button.
            Assert.AreEqual(dashboard[0].widgetComments[0], Widget.GetMaxWidgetComment());
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-3")]
        public void ShareWidgetWithPriorAnnotationCanbeModify(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with userA. Navigate to homepage, then to hierarchynodeA.  Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA and click "ShareCollaborative" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ////Check UserB in the left panel ,Modify the annotation in field.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());
            ShareWindow.FillEnjoyWindowComment(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //·There is a widgetA appear in "Collaborative Widget " with the modified annotation.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-4")]
        public void ShareWidgetWithPriorAnnotationExistCanbeEmpty(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with userA. Navigate to homepage, then to hierarchynodeA.  Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA and click "ShareCollaborative" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ////Check UserB in the left panel ,Modify the annotation to empty in field.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());
            ShareWindow.FillEnjoyWindowComment(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the empty annotation in field.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-5")]
        public void VerifyAnnotationIconAndTooltips(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Mouse over the annotation icon.The tooltip display with Add button.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Click Add button.The Edit annotation dialog pops up. The field is blank
            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Assert.AreEqual("", Widget.GetAnnotationWindowText());

            //Add annotation in annotation field and click "Confirm" button.
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.ShortPause();

            //·Annotation can be display and add properly.The new add annotation display well in tooltip with Edit button.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());
            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            TimeManager.ShortPause();
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Mouse over the annotation icon. The tooltip display properly.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Mouse over the annotation icon.The tooltip display well with Edit button
            //Click Edit button and modify the annotation to empty and then click Confirm button.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());
            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[2]);
            TimeManager.ShortPause();
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.ShortPause();

            //Mouse over the annotation icon. The tooltip display with Add button.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-6")]
        public void VerifyAnnotationInMaximizeWindow(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click the schema picture area in widgetA.Go to verify annotation.The annotation is blank.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Assert.IsFalse(Widget.IsAddMaxWidgetCommentButtonDisplayed());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click the schema picture area in widgetA.The annotation is blank with Add button is available.
            //Add annotation in annotation field and click "Confirm" button.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Click Edit button and modify the widget name and annotation  and then click Confirm button.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();

            //Go to verify annotation.The annotation is display with UserA.
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());
            
            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);
            
            //Click the schema picture area in widgetA.Click Edit button in annotation.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[2]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
            
            //The annotation is blank with Add button available.
            TimeManager.LongPause();
            HomePagePanel.FloatOnMyShareEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Annotation-101-7")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeAnnotationSuite), "TC-J1-FVT-WidgetCollaborative-Annotation-101-7")]
        public void SubscriberCannotEditAnnotation(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with userB. Navigate to homepage,then to "Collaborative Widget " tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();

            //Click schema picture of blank field.The annotation field is gray and cannot be edit.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            Assert.IsFalse(Widget.IsEditMaxWidgetCommentButtonDisplayed());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }
    }
}


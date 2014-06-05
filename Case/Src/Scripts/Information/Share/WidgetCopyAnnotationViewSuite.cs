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

namespace Mento.Script.Information.Share
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-WidgetCopy-Annotation-101"), CreateTime("2014-03-10"), Owner("Emma")]
    public class WidgetCopyAnnotationViewSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        public void ShareWithNoAnnotationSuccess(ShareDashboardData input)
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

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with no annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //Share widget successfully to userB and userD with no annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-2")]
        public void ShareWithAnnotationSuccess(ShareDashboardData input)
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

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with add annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //·Share widget successfully to userB and userD with add annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-3")]
        public void OriginalAnnotationDisplayAndModifySuccess(ShareDashboardData input)
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

            //.Modify the annotation then share
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());   

            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with modify annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //·Share widget successfully to userB and userD with modify annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-4")]
        public void OriginalAnnotationDisplayAndEmptySuccess(ShareDashboardData input)
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

            //.Modify the annotation then share
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation is display properly.
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with modify annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //·Share widget successfully to userB and userD with empty annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-5")]
        public void AnnotationIconAndTooltipsView(ShareDashboardData input)
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

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with no annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //·Share widget successfully to userB and userD with no annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Navigate to Homepage->Dashboard,Click the dashboard and verify the widget.Mouse over the icon.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Add some annotation in annotation field and click Confirm button.s
            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Mouse over the icon.The tooltip display with the new annotation.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            //The Edit button display.
            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Go to check favorite dashboard.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            //The widget with modify new annotation display
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            //Navigate to Homepage->Dashboard.Click the dashboard and verify the widget.
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Mouse over the icon.The tooltip display with Edit button.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Modify the annotation.The annotation can be modified properly.
            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Go to check favorite dashboard.The widget with modify new annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());

            //Navigate to Homepage->Dashboard.Change the annotation to blank and click Confirm button.
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation can be change to blank with no error.Edit button change to Add button properly. The icon is highlight.
            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[2]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Go to check favorite dashboard.The widget with no annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Login in with UserB.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Verify the share copy of widget's annotation can be add/edit by receiver. 
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], HomePagePanel.GetExistedCommentMinWdiget());

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickEditAnnotationButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], HomePagePanel.GetExistedCommentMinWdiget());
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-6")]
        public void AnnotationViewInMaximumWindow(ShareDashboardData input)
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

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with no annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //·Share widget successfully to userB and userD with no annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Navigate to Homepage->Dashboard,Click the dashboard and verify the widget.Widget display in maximum size.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Add some annotation in annotation field and click Confirm button.s
            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            //Mouse over the icon.The tooltip display with the new annotation.
            Assert.AreEqual(dashboard[0].widgetComments[0], Widget.GetMaxWidgetComment());

            //The Edit button display.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            //The widget with modify new annotation display
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Navigate to Homepage->Dashboard.Click the dashboard and verify the widget.
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //maxmize the widget
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Modify the annotation.The annotation can be modified properly.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.The widget with modify new annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Navigate to Homepage->Dashboard.Change the annotation to blank and click Confirm button.
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.The annotation can be change to blank with no error.Edit button change to Add button properly. The icon is highlight.
            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[2]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();

            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to check favorite dashboard.The widget with no annotation display.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Login in with UserB.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Verify the share copy of widget's annotation can be add/edit by receiver. 
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Widget.ClickAddMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[0]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();
            Assert.AreEqual(dashboard[0].widgetComments[0], Widget.GetMaxWidgetComment());

            Widget.ClickEditMaxWidgetCommentButton();
            TimeManager.ShortPause();
            Widget.EditAnnotationWindow(dashboard[0].widgetComments[1]);
            Widget.ClickSaveAnnotationWindowButton();
            TimeManager.MediumPause();
            Assert.AreEqual(dashboard[0].widgetComments[1], Widget.GetMaxWidgetComment());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }
    }
}


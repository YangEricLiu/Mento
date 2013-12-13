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
    [ManualCaseID("TC-J1-FVT-Widget-MarkRead-101"), CreateTime("2013-10-11"), Owner("Emma")]
    public class MarkWidgetReadValidSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static Widget Widget = JazzFunction.Widget;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static ShareWindow ShareWindow = new ShareWindow();
        private static ShareInfoWindow ShareInfoWindow = new ShareInfoWindow();
        
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.NavigateToAllDashboard();
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
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-1")]
        public void MarkWidgetRead01(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_1_A”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //select shared dashboard
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the widgetA to maximize, then minimize.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //The widget unread mark is removed. 
            Assert.IsFalse(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-2")]
        public void MarkWidgetRead02(ShareDashboardData input)
        {
            //Share widgetA to userB successfully with new name dashboardA+timestamp.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_2_B”成功。", HomePagePanel.GetPopNotesValue());

        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-3")]
        public void MarkWidgetRead03(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_3_B”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //select shared dashboard
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the widgetA to maximize, then minimize.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //The widget unread mark is removed. 
            Assert.IsFalse(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-4")]
        public void MarkWidgetRead04(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“WidgetMark1014A”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //select shared dashboard
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the widgetA to maximize, then minimize.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //The widget unread mark is removed. 
            Assert.IsFalse(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-5")]
        public void MarkWidgetRead05(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_5_A”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //select shared dashboard
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the unread widgetA to rename.
            HomePagePanel.RenameWidgetOpen(dashboard[0].WidgetName);
            Widget.CancelModifyWidgetName();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the unread widgetA to share.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            ShareWindow.ClickGiveupButton();
            TimeManager.MediumPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-6")]
        public void MarkWidgetRead06(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share widgetB to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_6_B”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyFavorite();

            //Click the dashboardA name from favorite dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Unfavorite the dashboardA.
            HomePagePanel.ClickUnFavoriteDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            //Back to all dashboard
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();
            //The widget display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));

            //Select the widgetA to maximize, then minimize.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //The widget unread mark is removed. 
            Assert.IsFalse(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-7")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-7")]
        public void MarkWidgetRead07(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share widgetA/C/E to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetNames[0]);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_7_A”成功。", HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetNames[2]);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_7_C”成功。", HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetNames[4]);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享小组件“Widget_MarkRead_101_7_E”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The widgets display unread mark. 
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetNames[2]));
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetNames[4]));

            //Maximize widget1. Click ">" to view to widget3.
            HomePagePanel.MaximizeWidget(dashboard[0].WidgetNames[0]);
            TimeManager.ShortPause();
            Widget.ClickNextButton();

            //Back to click dashboardA again.
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //The widget5 unread mark is removed.
            Assert.IsFalse(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetNames[2]));

            //Delete a widget2.
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WidgetNames[2]);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            //Widget5 localtion is moved ahead
            Assert.AreEqual(2, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Verify the widget5 unread mark,still display unread mark.
            Assert.IsTrue(HomePagePanel.IsShareWidgetUnread(dashboard[0].WidgetNames[4]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-MarkRead-101-8")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkWidgetReadValidSuite), "TC-J1-FVT-Widget-MarkRead-101-8")]
        public void MarkWidgetRead08(ShareDashboardData input)
        {

        }
    }
}


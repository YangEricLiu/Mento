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
    [ManualCaseID("TC-J1-FVT-Dashboard-MarkFavorite-101"), CreateTime("2013-10-11"), Owner("Emma")]
    public class MarkDashboardReadValidSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-1")]
        public void MarkDashboardRead01(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D”成功。", HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is new dashboardA is unread dashboard with mark icon . 
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Click the dashboardA name from dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Remove the unread mark of the dashboard when open the dashboard.
            Assert.IsFalse(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Remove the unread mark of share info
            //Assert.IsFalse(HomePagePanel.IsShareInfoUnread());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-2")]
        public void MarkDashboardRead02(ShareDashboardData input)
        {

        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-3")]
        public void MarkDashboardRead03(ShareDashboardData input)
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

            Assert.AreEqual("分享小组件“Dashboard_MarkRead_101_3_B”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is no new dashboardA is unread dashboard with mark icon . 
            Assert.IsFalse(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-4")]
        public void MarkDashboardRead04(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D4”成功。", HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D4”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is new dashboardA is unread dashboard with mark icon . 
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Click the dashboardA name from dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Remove the unread mark of the dashboard when open the dashboard.
            Assert.IsFalse(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Remove the unread mark of share info
            //Assert.IsFalse(HomePagePanel.IsShareInfoUnread());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-5")]
        public void MarkDashboardRead05(ShareDashboardData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D5”成功。", HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual("分享仪表盘“D5”成功。", HomePagePanel.GetPopNotesValue());

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Select the unread dashboard to rename.
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            HomePagePanel.ClickRenameDashboardCancel();
            //The dashboard unread mark can't removed.
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Select the unread dashboard to delete
            HomePagePanel.ClickDeleteDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            JazzMessageBox.MessageBox.GiveUp();
            //The dashboard unread mark can't removed.
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Select the unread dashboard to share
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();
            ShareWindow.ClickGiveupButton();
            
            //The dashboard unread mark can't removed.
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //Select the unread dashboard to add to favorite.
            HomePagePanel.ClickFavoriteDashboardButton(dashboard[0].DashboardName);
            TimeManager.LongPause();

            //The dashboard unread mark can't removed
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));

            //The dashboard in favorite don't show unread mark
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.LongPause();
            Assert.IsFalse(HomePagePanel.IsShareDashboardUnread(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-MarkRead-101-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(MarkDashboardReadValidSuite), "TC-J1-FVT-Dashboard-MarkRead-101-6")]
        public void MarkDashboardRead06(ShareDashboardData input)
        {

        }
    }
}


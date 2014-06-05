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
            //logout Jazz
            HomePagePanel.ExitJazz();

            JazzFunction.LoginPage.LoginWithOption("PerfTestCustomer", "123456Qq", "NancyCustomer1");
            TimeManager.MediumPause();
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

            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.messages[1], HomePagePanel.GetPopNotesValue());

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
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA to userB successfully, 2 times
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());
            TimeManager.Pause(60000);

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.messages[1], HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userB. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is new dashboardA+timestamp is unread dashboard with mark icon . 
            Assert.IsTrue(HomePagePanel.IsShareDashboardUnreadPosition(2));
            string newName = dashboard[0].DashboardName + "_" + HomePagePanel.GetShareCurrentTime();
            Assert.IsTrue(HomePagePanel.GetOneDashboardNamePosition(1).Contains(newName));

            //Click the dashboardA+timestamp name from dashboard list.
            HomePagePanel.ClickDashboardButtonPosition(2);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();
            Assert.IsFalse(HomePagePanel.IsShareDashboardUnreadPosition(2));
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

            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

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

            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.messages[1], HomePagePanel.GetPopNotesValue());

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
            //TimeManager.Pause(60000);
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

            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.messages[1], HomePagePanel.GetPopNotesValue());

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

            //Click cancel or 'x' icon of rename.
            HomePagePanel.ClickRenameDashboardCancel();
            TimeManager.ShortPause();

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
            var dashboard = input.InputData.DashboardInfo;

            //Go to chart view to save multiple dashboards to hierarchynodeA and add multiple dashboars to favorite.
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            for (int i = 0; i < dashboard.Length; i++)
            {
                EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[i].WidgetName, dashboard[i].HierarchyName, dashboard[i].IsCreateDashboard, dashboard[i].DashboardName);
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();
                TimeManager.LongPause();
            }

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Default open the hierarchy node first dashboard in dashboard list.
            Assert.IsTrue(HomePagePanel.IsDashboardButtonPressed(1));

            //Go to homepage to select hierarchynodeA to view dashboard list sequence.
            for (int j = 1; j < (dashboard.Length + 1); j++)
            {
                Assert.AreEqual(dashboard[dashboard.Length - j].DashboardName, HomePagePanel.GetOneDashboardNamePosition(j));
                TimeManager.ShortPause();
            }

            //Go to favorite to select hierarchynodeA to view dashboard list sequence.
            for (int k = 0; k < dashboard.Length; k++)
            {
                HomePagePanel.ClickDashboardButton(dashboard[k].DashboardName);
                JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
                TimeManager.LongPause();

                HomePagePanel.ClickFavoriteDashboardButton(dashboard[k].DashboardName);
                TimeManager.LongPause();
            }

            HomePagePanel.NavigateToMyFavorite();
            TimeManager.LongPause();

            //Default open the hierarchy node first dashboard in dashboard list.
            Assert.IsTrue(HomePagePanel.IsDashboardButtonPressed(1));
        }
    }
}


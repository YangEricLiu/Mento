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
    [ManualCaseID("TC-J1-FVT-Dashboard-Share-104"), CreateTime("2013-10-18"), Owner("Emma")]
    public class ShareDashboardInfoSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Dashboard-Share-104-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-1")]
        public void ViewSharerInfo01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //UserA Share widgetA to UserB
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_104_1”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();
            
            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureTimeExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[0].ReceiveUsers[0], HomePagePanel.GetShareResoureUser());

            //Mouse over to the sender realname.
            //Manual Test this part
            //HomePagePanel.FloatOnShareResoureUser();
            //HomePagePanel.FloatOnShareResoureUser();;
            //Assert.IsTrue(HomePagePanel.IsTextsExisted(input.ExpectedData.TooltipTexts[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-2")]
        public void ViewSharerInfo02(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //UserA Share widgetA to UserB
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_104_2”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureTimeExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[0].ReceiveUsers[0], HomePagePanel.GetShareResoureUser());

            //Mouse over to the sender realname.
            //Manual Test this part
            //HomePagePanel.FloatOnShareResoureUser();
            //HomePagePanel.FloatOnShareResoureUser();
            //Assert.IsTrue(HomePagePanel.IsTextsExisted(input.ExpectedData.TooltipTexts[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-3")]
        public void ViewSharerInfo03(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //UserA Share widgetA to UserB
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Dashboard_Share_104_3_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(Widget.IsShareResoureCommonExisted());
            Assert.IsTrue(Widget.IsShareResoureTimeExisted());
            Assert.IsTrue(Widget.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[0].ReceiveUsers[0], Widget.GetShareResoureUser());

            Widget.ClickCloseMaxDialogButton();
            TimeManager.LongPause();
            //Mouse over to the sender realname.
            //Manual Test this part
            //Widget.FloatOnShareResoureUser();
            //Widget.FloatOnShareResoureUser();
            //Assert.IsTrue(Widget.IsTextsExisted(input.ExpectedData.TooltipTexts[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-4")]
        public void ViewSharerInfo04(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //UserA Share widgetA to UserB
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Dashboard_Share_104_4_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WidgetName);
            TimeManager.MediumPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(Widget.IsShareResoureCommonExisted());
            Assert.IsTrue(Widget.IsShareResoureTimeExisted());
            Assert.IsTrue(Widget.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[0].ReceiveUsers[0], Widget.GetShareResoureUser());

            //Mouse over to the sender realname.
            //Manual Test this part
            //Widget.FloatOnShareResoureUser();
            //Widget.FloatOnShareResoureUser();
            //Assert.IsTrue(Widget.IsTextsExisted(input.ExpectedData.TooltipTexts[0]));

            Widget.ClickCloseMaxDialogButton();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-5")]
        public void ViewSharerInfo05(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Add a shared dashboardA to favorite.
            HomePagePanel.ClickFavoriteDashboardButton(dashboard[0].DashboardName);
            TimeManager.LongPause();

            HomePagePanel.ClickFavoriteDashboardButton(dashboard[1].DashboardName);
            TimeManager.LongPause();

            HomePagePanel.NavigateToMyFavorite();
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The "分享来源" of dashboard still display.
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[1].WidgetName);
            TimeManager.MediumPause();

            //The "分享来源" of widget still display.
            Assert.IsTrue(Widget.IsShareResoureCommonExisted());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.LongPause();

            //Rename the received dashboardA. Go to favorite to check.
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            string newDashboard1 = dashboard[0].DashboardName + "M1";

            HomePagePanel.FillInNewDashboardName(newDashboard1);
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.MediumPause();

            HomePagePanel.NavigateToMyFavorite();
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(newDashboard1);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The "分享来源" of dashboard in favorite  still display
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Rename the received widgetA. Go to favorite to check.
            HomePagePanel.RenameWidgetOpen(dashboard[1].WidgetName);
            TimeManager.MediumPause();

            string newWidget1 = dashboard[1].WidgetName + "M2";

            Widget.FillNewWidgetName(newWidget1);
            Widget.ClickSaveWidgetNameButton();
            TimeManager.MediumPause();

            HomePagePanel.NavigateToMyFavorite();
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(newWidget1);
            TimeManager.MediumPause();

            //The "分享来源" of widget still display.
            Assert.IsTrue(Widget.IsShareResoureCommonExisted());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Go to hierarchynodeA chart view, add new widgetB to dashboardA
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[2].WidgetName, dashboard[2].HierarchyName, dashboard[2].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.LongPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(newDashboard1);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //The "分享来源" of dashboard in favorite  still display
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-6")]
        public void ViewSharerInfo06(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //UserA Share dashboard to UserB
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_104_6_2”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[1].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //UserA Share widgetA to UserB
            HomePagePanel.ClickShareWidgetButton(dashboard[1].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Dashboard_Share_104_6_1_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userC. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[1].Receivers[0].LoginName, dashboard[1].Receivers[0].Password, dashboard[1].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(HomePagePanel.IsShareResoureCommonExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureTimeExisted());
            Assert.IsTrue(HomePagePanel.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[0].ReceiveUsers[0], HomePagePanel.GetShareResoureUser());

            //Mouse over to the sender realname.
            //Manual Test this part
            //HomePagePanel.FloatOnShareResoureUser();
            //HomePagePanel.FloatOnShareResoureUser(); ;
            //Assert.IsTrue(HomePagePanel.IsTextsExisted(input.ExpectedData.TooltipTexts[0]));

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.MaximizeWidget(dashboard[1].WidgetName);
            TimeManager.MediumPause();

            //Check there is "分享来源" display at the dashboard right header.
            Assert.IsTrue(Widget.IsShareResoureCommonExisted());
            Assert.IsTrue(Widget.IsShareResoureTimeExisted());
            Assert.IsTrue(Widget.IsShareResoureUserExisted());
            Assert.AreEqual(dashboard[1].ReceiveUsers[0], Widget.GetShareResoureUser());

            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //Mouse over to the sender realname.
            //Manual Test this part
            //Widget.FloatOnShareResoureUser();
            //Widget.FloatOnShareResoureUser();
            //Assert.IsTrue(Widget.IsTextsExisted(input.ExpectedData.TooltipTexts[1]));
        }
    }
}


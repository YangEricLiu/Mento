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
    [ManualCaseID("TC-J1-FVT-Dashboard-Share-001"), CreateTime("2013-10-16"), Owner("Emma")]
    public class ShareDashboard1ValidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Dashboard-Share-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboard1ValidSuite), "TC-J1-FVT-Dashboard-Share-101-1")]
        public void ShareDashboardSuccess02(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB and D
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_101_1”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login to Jazz with userB
            HomePagePanel.ExitJazz();
            TimeManager.MediumPause();

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //Login to Jazz with userD
            HomePagePanel.ExitJazz();
            TimeManager.MediumPause();

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboard1ValidSuite), "TC-J1-FVT-Dashboard-Share-101-2")]
        public void ShareDashboardSuccess01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB and D
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“D2”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //login userD and get new dashboard name
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Make sure dashboard name field is renamed to originaldashboardname+timestamp.Click "share" again.
            string newName1 = HomePagePanel.GetOneDashboardNamePosition(1);
            
            //login back again
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            HomePagePanel.FillInNewDashboardName(newName1);
            TimeManager.ShortPause();

            //Input the valid  and click save
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.ShortPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(newName1);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB and D
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            string tmp = "分享仪表盘“" + newName1 + "”成功。";

            Assert.AreEqual(tmp, HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();
            
            //login userD and check
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            string newname2 = newName1 + "_" + HomePagePanel.GetShareCurrentTime();
            Assert.IsTrue(HomePagePanel.GetOneDashboardNamePosition(1).Contains(newname2));
            Assert.IsTrue(HomePagePanel.GetOneDashboardNamePosition(2).Contains(newName1));
            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboard1ValidSuite), "TC-J1-FVT-Dashboard-Share-101-3")]
        public void ShareDashboardSuccess03(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //UserA share a widgetA to UserB, then again
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“DS_Widget_101_3_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Click "share dashboard" button again
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //UserA share a widgetA to UserB, then again
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            //This is not easy for share in 2 minutes, So will be manual test
            //Assert.AreEqual("分享小组件“DS_Widget_101_3_A”失败，无法分享给这些人：ShareUserB。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //login userB and check
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click the dashboardA name from dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WidgetName));
            Assert.AreEqual(2, HomePagePanel.GetWidgetsNumberOfDashboard());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboard1ValidSuite), "TC-J1-FVT-Dashboard-Share-101-4")]
        public void ShareDashboardSuccess04(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //UserA share a widgetA to UserB, then again
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“DS_Widget_101_4_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //login userB and check
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click the dashboardA name from dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WidgetName));
            Assert.AreEqual(2, HomePagePanel.GetWidgetsNumberOfDashboard());

            //delete the widget
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();

            //The other dashboard/widget of UserA can delete successfully.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboard1ValidSuite), "TC-J1-FVT-Dashboard-Share-101-5")]
        public void ShareDashboardSuccess05(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.LongPause();

            Assert.AreEqual("请选择层级结构", HomePagePanel.GetHierarchyText());
        }
    }
}


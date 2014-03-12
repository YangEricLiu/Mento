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
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-Share-101"), CreateTime("2014-03-11"), Owner("Emma")]
    public class WidgetCollaborativeShareValidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareValidSuite), "TC-J1-FVT-WidgetCollaborative-Share-101-1")]
        public void ShareWidgetWithValidInfo(ShareDashboardData input)
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

            //Select widgetA and click "Share link" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is UserB and UserC display in receivers list.
            Assert.IsTrue(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //·There isn't UserD display in receivers list.
            Assert.IsFalse(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserC checkbox.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();
            Assert.AreEqual(2, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Navigate to homepage, then to "Collaborative Widget " tab.  
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA mirror display at the top of thumbnail list of under UserA.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA mirror display at the top of thumbnail list of under UserA.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA mirror display at the top of thumbnail list of under UserA.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }


        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareValidSuite), "TC-J1-FVT-WidgetCollaborative-Share-101-2")]
        public void ShareWidgettoSameUserTwice(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA with nameA appears in "Collaborative Widget " tab.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserA.Select widgetA with nameA , click "Share link" button and check UserB , click Confirm button.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA and click "Share link" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB checkbox.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //·There is a new widgetA with the same nameA appear in "Collaborative Widget " and will not appear error message for duplicate name .
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
            Assert.AreEqual(2, HomePagePanel.GetSameWidgetNameNumberofMyShare(dashboard[0].WidgetName));
        }


        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareValidSuite), "TC-J1-FVT-WidgetCollaborative-Share-101-3")]
        public void ShareSameNameWidgetFromTwoDashboard(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Select widgeB with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[1].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[1].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There are two widget appear in "Collaborative Widget " tab. One is widgetA with nameA, the other is widgetB with nameA.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
            Assert.AreEqual(2, HomePagePanel.GetSameWidgetNameNumberofMyShare(dashboard[0].WidgetName));
            
            //Login to Jazz with UserA.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click Edit button in widgetA in thumbnail list.
            HomePagePanel.CancelMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Click Confirm button.Remove the widgetA mirror fromUserB successfully .
            JazzMessageBox.MessageBox.CancelShare();
            TimeManager.MediumPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[1].WidgetName));
            TimeManager.ShortPause();
            Assert.AreEqual(1, HomePagePanel.GetSameWidgetNameNumberofMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareValidSuite), "TC-J1-FVT-WidgetCollaborative-Share-101-4")]
        public void ShareWidgetWithNoDataPermissionUser(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            // to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareValidSuite), "TC-J1-FVT-WidgetCollaborative-Share-101-5")]
        public void ShareWidgetWithNoFunctionPermissionUser(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            Assert.AreEqual(1, ShareWindow.GetEnjoyUserNumber());

            //Click "共享 button"
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            // to "Collaborative Widget " tab.
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }


    }
}


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
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-Share-001"), CreateTime("2014-03-13"), Owner("Emma")]
    public class WidgetCollaborativeShareInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-001-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareInvalidSuite), "TC-J1-FVT-WidgetCollaborative-Share-001-1")]
        public void VerifyCancelAndCloseWhenShareCollaborativeWidget(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list.
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

            //check UserB in the left panel.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            //Mouse over the UserB in the right panel.Click Close button or Uncheck the checkbox for UserB.
            ShareWindow.ClickRemoveEnjoyUserButton(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            //UserB disappears in SharetoUser list in the right panel.
            Assert.IsFalse(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[0]));

            //Check UserB and UserC in left panel and then click "Cancel" button.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            ShareWindow.ClickGiveUpEnjoyButton();
            TimeManager.ShortPause();

            //WidgetA cannot appear in UserA,UserB and UserC's Collaborative Widget  tab page
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list.
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA, click "Share link" button and check UserB in left panel.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            ShareWindow.ClickGiveUpEnjoyButton();
            TimeManager.ShortPause();

            //WidgetA cannot appear in UserA,UserB and UserC's Collaborative Widget  tab page
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-001-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareInvalidSuite), "TC-J1-FVT-WidgetCollaborative-Share-001-2")]
        public void VerifyNoSubscriberCanNotShare(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA, click "Share link" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There isn't users(UserB and UserC) in SharetoUser list.
            Assert.IsFalse(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsFalse(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //Confirm button is gray and disabled.
            Assert.IsFalse(ShareWindow.IsEnjoyButtonEnable());

            ShareWindow.ClickGiveUpEnjoyButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Share-001-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeShareInvalidSuite), "TC-J1-FVT-WidgetCollaborative-Share-001-3")]
        public void VerifyNotCheckSubscriberCanNotShare(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the dashboardA name from dashboard list.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Select widgetA, click "Share link" button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //UserC is available,UserB is not display in subscriber list in left panel.
            Assert.IsFalse(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            ////Confirm button is gray and disabled.
            Assert.IsFalse(ShareWindow.IsEnjoyButtonEnable());

            ShareWindow.ClickGiveUpEnjoyButton();
            TimeManager.ShortPause();
        }
    }
}


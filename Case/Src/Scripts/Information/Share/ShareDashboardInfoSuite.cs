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
            JazzFunction.Navigator.NavigateHome();
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
            HomePagePanel.FloatOnShareResoureUser();
            HomePagePanel.FloatOnShareResoureUser();;
            Assert.IsTrue(HomePagePanel.IsTextsExisted(input.ExpectedData.TooltipTexts));
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
            HomePagePanel.FloatOnShareResoureUser();
            HomePagePanel.FloatOnShareResoureUser();
            Assert.IsTrue(HomePagePanel.IsTextsExisted(input.ExpectedData.TooltipTexts));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-104-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInfoSuite), "TC-J1-FVT-Dashboard-Share-104-3")]
        public void ViewSharerInfo03(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

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

            //Mouse over to the sender realname.
            Widget.FloatOnShareResoureUser();
            Widget.FloatOnShareResoureUser();
            Assert.IsTrue(Widget.IsTextsExisted(input.ExpectedData.TooltipTexts));
        }
    }
}


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
    [ManualCaseID("TC-J1-FVT-Widget-Share-101"), CreateTime("2013-10-21"), Owner("Emma")]
    public class ShareWidgetValidSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetValidSuite), "TC-J1-FVT-Widget-Share-101-1")]
        public void ShareWidgetSuccess01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share Widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There is userB and UserD display in receivers list.There isn't userC display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Widget_Share_101_1_A”成功。", HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is a new created dashboardA with widgetA in dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Only 1 widgetA display in dashboard.
            HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WidgetName);
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());
            TimeManager.LongPause();
            
            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //There is a new created dashboardA with widgetA in dashboard list.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Add a widgetA display at the end of dashboardA.
            HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WidgetName);
            Assert.AreEqual(2, HomePagePanel.GetWidgetsNumberOfDashboard());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetValidSuite), "TC-J1-FVT-Widget-Share-101-2")]
        public void ShareWidgetSuccess02(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share Dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB checkbox and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“WidgetShare1012”成功。", HomePagePanel.GetPopNotesValue());

            //Click the widgetA. Click "share widget" button. Check UserB checkbox and click "share".
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share Widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB checkbox and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“WidgetShare1012A”成功。", HomePagePanel.GetPopNotesValue());

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

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[1].WidgetName, dashboard[1].HierarchyName, dashboard[1].IsCreateDashboard, dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Click the widgetB. Click "share widget" button. Check UserB checkbox and click "share".
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[1].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share Widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[1].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserB checkbox and click "share".
            ShareWindow.CheckShareUser(dashboard[1].ShareUsers[0]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“WidgetShare1012B”成功。", HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Share dashboardA successfully to userB name with timestamp.
            Assert.AreEqual(2, HomePagePanel.GetDashboardsNumber());

            //Share widget successfully without error, the widgetA is share to dashboardA with name widgetA+timestamp.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //3 widgets display in dashboard.
            Assert.AreEqual(3, HomePagePanel.GetWidgetsNumberOfDashboard());

            HomePagePanel.NavigateToMyFavorite();
            Assert.AreEqual(1, HomePagePanel.GetDashboardsNumber());

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //3 widgets display in dashboard.
            Assert.AreEqual(3, HomePagePanel.GetWidgetsNumberOfDashboard());

            //There isn't dashbardA+timestamp added in favorite
            string newName = dashboard[0].DashboardName + "_" + HomePagePanel.GetShareCurrentTime();
            Assert.IsFalse(HomePagePanel.GetOneDashboardNamePosition(1).Contains(newName));
            Assert.IsFalse(HomePagePanel.GetOneDashboardNamePosition(2).Contains(newName));

            //There is widgetA+timestamp added in favorite.
            string newWidgetName = dashboard[0].WidgetName + "_" + HomePagePanel.GetShareCurrentTime();
            Assert.IsTrue(HomePagePanel.GetOneWidgetMinName(2).Contains(newWidgetName));
        }
    }
}


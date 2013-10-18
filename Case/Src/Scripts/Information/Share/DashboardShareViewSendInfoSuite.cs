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
    [ManualCaseID("TC-J1-FVT-Dashboard-Share-102"), CreateTime("2013-10-17"), Owner("Emma")]
    public class DashboardShareViewSendInfoSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Dashboard-Share-102-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(DashboardShareViewSendInfoSuite), "TC-J1-FVT-Dashboard-Share-102-1")]
        public void ViewSendReceiveInfo01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_102_1_1”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            HomePagePanel.ClickShareWidgetButton(dashboard[1].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Dashboard_Share_102_1_B”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Click "Share info" link.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();

            //Click Send info tab. 
            ShareInfoWindow.ClickShareInfoSendedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);

            //check send info
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[0].DashboardName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[0].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[1].WidgetName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[1].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[1].ShareUsers[0]));

            ShareInfoWindow.Close();
            TimeManager.MediumPause();

            //Login to Jazz with userA
            HomePagePanel.ExitJazz();
            TimeManager.MediumPause();

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //Click receive info tab. Verify the unread history display bold line.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();
            ShareInfoWindow.ClickShareInfoReceivedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            Assert.IsTrue(ShareInfoWindow.IsRowBold(2, dashboard[0].DashboardName));
            Assert.IsTrue(ShareInfoWindow.IsRowBold(2, dashboard[1].WidgetName));

            //Click the bold line to read dashboard.
            ShareInfoWindow.ClickRowColumn(2, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitJumpFavoriteLoading(10);
            TimeManager.MediumPause();

            //Jump to the dashboard and open. Change from unread to read.
            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //Click the bold line to read widget.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();
            ShareInfoWindow.ClickShareInfoReceivedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            ShareInfoWindow.ClickRowColumn(2, dashboard[1].WidgetName);
            JazzMessageBox.LoadingMask.WaitJumpFavoriteLoading(10);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //The widget is open and Maximize. Change from unread to read
            Assert.AreEqual(dashboard[1].WidgetName, Widget.GetMaxWidgetName());
            
            //Click "X" to close .
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //nobold
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();
            ShareInfoWindow.ClickShareInfoReceivedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            Assert.IsFalse(ShareInfoWindow.IsRowBold(2, dashboard[0].DashboardName));
            Assert.IsFalse(ShareInfoWindow.IsRowBold(2, dashboard[1].WidgetName));
            ShareInfoWindow.Close();
            TimeManager.ShortPause();
        }


        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-102-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(DashboardShareViewSendInfoSuite), "TC-J1-FVT-Dashboard-Share-102-4")]
        public void ViewSendInfo04(ShareDashboardData input)
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

            Assert.AreEqual("分享小组件“Dashboard_Share_102_4_1_A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //UserA Share widgetB to UserB
            HomePagePanel.ClickShareWidgetButton(dashboard[1].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserA
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Dashboard_Share_102_4_2_B”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //the send history include widgetA and widgetB record.
            //Click "Share info" link.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();

            //Click Send info tab. 
            ShareInfoWindow.ClickShareInfoSendedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);

            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[0].WidgetName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[0].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[1].WidgetName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[1].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[1].ShareUsers[0]));
            ShareInfoWindow.Close();
            TimeManager.ShortPause();

            //Delete the shared widgetA of userA
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();
            
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WidgetName);
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();

            //Click "Share info" link.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();

            //Click Send info tab. 
            ShareInfoWindow.ClickShareInfoSendedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            Assert.IsFalse(ShareInfoWindow.IsRowExisted(2, dashboard[0].WidgetName));
            ShareInfoWindow.Close();
            TimeManager.ShortPause();

            //Delete the shared widgetB of userA
            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();
            
            HomePagePanel.DeleteWidgetOpen(dashboard[1].WidgetName);
            TimeManager.MediumPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();

            //Click "Share info" link.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();

            //Click Send info tab. 
            ShareInfoWindow.ClickShareInfoSendedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            Assert.IsFalse(ShareInfoWindow.IsRowExisted(2, dashboard[1].WidgetName));
            ShareInfoWindow.Close();
            TimeManager.ShortPause();
        }
    }
}


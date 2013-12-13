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
    [ManualCaseID("TC-J1-FVT-Widget-Share-001"), CreateTime("2013-10-16"), Owner("Emma")]
    public class ShareWidgetInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Widget-Share-001-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-1")]
        public void ShareWidgetFailed01(ShareDashboardData input)
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

            //There isn't any users(UserC and UserB) display
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            // "share" button is gary out and disabled
            Assert.IsFalse(ShareWindow.IsShareButtonEnable());

            //Close share window
            ShareWindow.Close();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-001-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-2")]
        public void ShareWidgetFailed02(ShareDashboardData input)
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

            //There is UserD display
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));

            // "share" button is gary out and disabled
            Assert.IsFalse(ShareWindow.IsShareButtonEnable());

            //check receivers, then change all unchecked
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();

            ShareWindow.UncheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.MediumPause();

            // "share" button is gary out and disabled
            Assert.IsFalse(ShareWindow.IsShareButtonEnable());

            //Close share window
            ShareWindow.Close();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-001-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-3")]
        public void ShareWidgetFailed03(ShareDashboardData input)
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

            //Share widget successfully to userD
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Widget_Share0013A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Select widgetA of userA. Select receiver UserB.Click "share" Button again
            //Click "share Widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Share widget successfully to userD
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“Widget_Share0013A”失败，无法分享给这些人：ShareUserD。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //The widgetA is rename to widgetA+timestamp on UserD
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            Assert.AreEqual(2, HomePagePanel.GetWidgetsNumberOfDashboard());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-001-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-4")]
        public void ShareWidgetFailed04(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There is UserE/D display
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[3]));

            //Check UserE checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[3]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“WidgetShare0014A”失败，无法分享给这些人：ShareUserE。", HomePagePanel.GetPopNotesValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-001-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-5")]
        public void ShareWidgetFailed05(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There is UserE/D display
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[3]));

            //Check UserD checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[2]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享小组件“WidgetShare0015A”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton("WidgetShare0015A_201310210719");
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserD checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[2]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Assert.AreEqual("分享小组件“WidgetShare0015A_201310210719”失败，无法分享给这些人：ShareUserD。", HomePagePanel.GetPopNotesValue());
            Assert.AreEqual("分享小组件“WidgetShare0015A_201310210719”成功。", HomePagePanel.GetPopNotesValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Share-001-7")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareWidgetInvalidSuite), "TC-J1-FVT-Widget-Share-001-7")]
        public void ShareWidgetFailed07(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserF checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            Assert.AreEqual("分享小组件“Widget_Share_001_7_1_A”失败，无法分享给这些人：ShareUserF。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.Cancel();

            //Click "share widget" button
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.Close();
            
            //Not share successful to ShareUserF
        }
    }
}


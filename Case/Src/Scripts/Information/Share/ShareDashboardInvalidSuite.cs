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
    public class ShareDashboardInvalidSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Dashboard-Share-001-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInvalidSuite), "TC-J1-FVT-Dashboard-Share-001-1")]
        public void ShareDashboardFailed01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There isn't any users(UserC and UserB) display
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            // "share" button is gary out and disabled
            Assert.IsFalse(ShareWindow.IsShareButtonEnable());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-001-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInvalidSuite), "TC-J1-FVT-Dashboard-Share-001-2")]
        public void ShareDashboardFailed02(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
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
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-001-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInvalidSuite), "TC-J1-FVT-Dashboard-Share-001-3")]
        public void ShareDashboardFailed03(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //There is UserE/D display
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //Check UserE checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_001_2”失败，无法分享给这些人：ShareUserE。", HomePagePanel.GetPopNotesValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-001-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInvalidSuite), "TC-J1-FVT-Dashboard-Share-001-4")]
        public void ShareDashboardFailed04(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
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

            Assert.AreEqual("分享仪表盘“DS0014”失败，无法分享给这些人：ShareUserE。", HomePagePanel.GetPopNotesValue());

            //Delete a dashboard from UserE(Not delete dashboardA).Click "share" again.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[1].Receivers[0].LoginName, dashboard[1].Receivers[0].Password, dashboard[1].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[1].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDeleteDashboardButton(dashboard[1].DashboardName);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();

            //Share dashboard successfully UserE again
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Check UserE checkbox and click "share" directly.
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[3]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“DS0014”成功。", HomePagePanel.GetPopNotesValue());

            //Click "Cancel" button in share dashboard window.
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[3]);
            TimeManager.ShortPause();

            ShareWindow.ClickGiveupButton();
            TimeManager.ShortPause();

            //Click "Close" button in share dashboard window.
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[3]);
            TimeManager.ShortPause();

            ShareWindow.Close();
            TimeManager.ShortPause();

            //UserE dashboard include dashboardA and dashboardA+timestamp.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[1].Receivers[0].LoginName, dashboard[1].Receivers[0].Password, dashboard[1].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[1].HierarchyName);
            TimeManager.LongPause();

            string newName = dashboard[0].DashboardName + "_" + HomePagePanel.GetShareCurrentTime();
            Assert.IsTrue(HomePagePanel.GetOneDashboardNamePosition(1).Contains(newName));
            Assert.IsTrue(HomePagePanel.GetOneDashboardNamePosition(2).Contains(dashboard[0].DashboardName));
            Assert.IsFalse(HomePagePanel.GetOneDashboardNamePosition(3).Contains(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-001-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardInvalidSuite), "TC-J1-FVT-Dashboard-Share-001-5")]
        public void ShareDashboardFailed05(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            //Click "share dashboard" button
            HomePagePanel.ClickShareDashboardButton(dashboard[0].DashboardName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check UserE checkbox and click "share" directly.
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            ShareWindow.ClickShareButton();
            TimeManager.LongPause();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);

            Assert.AreEqual("分享仪表盘“Dashboard_Share_001_5123456789”失败，无法分享给这些人：ShareUserD。", HomePagePanel.GetPopNotesValue());
        }
    }
}


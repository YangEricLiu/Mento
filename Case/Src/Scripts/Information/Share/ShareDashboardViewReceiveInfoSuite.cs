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
    [ManualCaseID("TC-J1-FVT-Dashboard-Share-103"), CreateTime("2013-10-18"), Owner("Emma")]
    public class ShareDashboardViewReceiveInfoSuite : TestSuiteBase
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
            HomePagePanel.NavigateToEnergyView();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-103-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ShareDashboardViewReceiveInfoSuite), "TC-J1-FVT-Dashboard-Share-103-4")]
        public void ViewReceiveInfo04(ShareDashboardData input)
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

            Assert.AreEqual("分享小组件“Dashboard_Share_103_4_1_A”成功。", HomePagePanel.GetPopNotesValue());
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

            Assert.AreEqual("分享小组件“Dashboard_Share_103_4_2_B”成功。", HomePagePanel.GetPopNotesValue());
            TimeManager.LongPause();

            //Login with userA. Navigate to homepage to select the hierarchynodeA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //the send history include widgetA and widgetB record.
            //Click "Share info" link.
            HomePagePanel.ClickShareInfoButton();
            TimeManager.MediumPause();

            //Click receive info tab. 
            ShareInfoWindow.ClickShareInfoReceivedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);

            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[0].WidgetName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[0].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[0].ReceiveUsers[0]));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(2, dashboard[1].WidgetName));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(3, dashboard[1].HierarchyName.Last()));
            Assert.IsTrue(ShareInfoWindow.IsRowExisted(4, dashboard[1].ReceiveUsers[0]));
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

            //Click receive info tab. 
            ShareInfoWindow.ClickShareInfoReceivedButton();
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

            //Click receive info tab. 
            ShareInfoWindow.ClickShareInfoReceivedButton();
            TimeManager.Pause(WAITSHAREINFOTAB);
            Assert.IsFalse(ShareInfoWindow.IsRowExisted(2, dashboard[1].WidgetName));
            ShareInfoWindow.Close();
            TimeManager.ShortPause();
        }
    }
}


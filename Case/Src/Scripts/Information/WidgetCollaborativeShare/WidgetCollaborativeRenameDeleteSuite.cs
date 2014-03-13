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
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-Rename-101"), CreateTime("2014-03-13"), Owner("Emma")]
    public class WidgetCollaborativeRenameDeleteSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCollaborative-Rename-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Rename-101-1")]
        public void VerifySponsorCanRenameTheCollaborativeWidget(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to Collaborative Widget tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in thumbnail list in "Collaborative Widget " tab
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Modify the widget name and click Confirm button.
            HomePagePanel.RenameMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Widget.FillNewWidgetName(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            Widget.ClickSaveWidgetNameButton();
            TimeManager.ShortPause();

            //The widget name can be modify properly.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to Collaborative Widget tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA' name is change to as Sponsor modify in thumbnail list.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Rename-001-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Rename-001-1")]
        public void ShareCollaborativeWidgetFail7(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage, then to Collaborative Widget tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in thumbnail list in "Collaborative Widget " tab
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Modify the widget name change to widgetB.
            HomePagePanel.RenameMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Widget.FillNewWidgetName(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            
            //click cancel button
            Widget.ClickGiveupButtonOnWindow();
            TimeManager.ShortPause();

            //The widget name also display "widgetA".
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Modify the widget name change to widgetB.
            HomePagePanel.RenameMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Widget.FillNewWidgetName(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();

            //Click close button.
            Widget.CloseRenameWidgetButton();
            TimeManager.ShortPause();

            //The widget name also display "widgetA".
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserC. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA' name is change to as Sponsor modify in thumbnail list.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Delete-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Delete-101-1")]
        public void VerifyMirrorExistAfterOriginalWidgetDelete(ShareDashboardData input)
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

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA with nameA appear in "Collaborative Widget " tab. 
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserA. Navigate to homepage-> hierarchynodeA->DashboardA. Click the Edit button in the widgetA .
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Click Delete button and then click Confirm button.WidgetA delete successfully.
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WidgetName));

            //Login to Jazz with UserB.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //·There is a widgetA with nameA appear in "Collaborative Widget " tab and the Collaborative Widget  is also exist. 
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Delete-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Delete-101-2")]
        public void VerifyMirrorExistAfterOriginalDashboardDelete(ShareDashboardData input)
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

            //Select widgetA with nameA , click "Share link" button and check UserB, click Confirm button.
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA with nameA appear in "Collaborative Widget " tab. 
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();

            //Login to Jazz with UserA. Navigate to homepage, then to hierarchynodeA. Click the Edit button in the dashboardA.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToAllDashboard();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            HomePagePanel.ClickDeleteDashboardButton(dashboard[0].DashboardName);
            TimeManager.ShortPause();

            //Click Delete button and then click Confirm button.DashboardA delete successfully.
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();
            Assert.IsFalse(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //Login to Jazz with UserB.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //·There is a widgetA with nameA appear in "Collaborative Widget " tab and the Collaborative Widget  is also exist. 
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Delete-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Delete-101-3")]
        public void VerifySponsorCanDeleteMirrorInEditWidgetDialog(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click RemoveCollaborative Widget button, Click Confirm button.
            HomePagePanel.CancelMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.messages[0]));

            JazzMessageBox.MessageBox.CancelShare();
            TimeManager.MediumPause();

            //WidgetA is disappear in thumbnail list of UserA.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA is disappear in thumbnail list of UserB.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserC. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA is disappear in thumbnail list of UserC.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserD. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[3].LoginName, dashboard[0].Receivers[3].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA is disappear in thumbnail list of UserD.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-Delete-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeRenameDeleteSuite), "TC-J1-FVT-WidgetCollaborative-Delete-101-4")]
        public void VerifySubscriberCannotDeleteMirrorAndUpdateWidgetName(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA display in thumbnail list.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Verify buttons in the toolbar.The Edit button doesn't exist for subscriber
            Assert.IsFalse(HomePagePanel.IsRenameMyShareWidgetButtonExisted(dashboard[0].WidgetName));
        }
    }
}


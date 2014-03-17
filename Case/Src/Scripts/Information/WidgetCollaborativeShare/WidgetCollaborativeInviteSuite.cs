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
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101"), CreateTime("2014-03-17"), Owner("Emma")]
    public class WidgetCollaborativeInviteSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-1")]
        public void VerifySponsorCanInviteOtherUsers(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.UserA,UserB appear in the subscriber user list.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[1]));

            //Click "Invitation" button, check UserC and UserD add the new annotation and then click Confirm button.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[2]);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[3]);

            //UserC and UserD appear in SharetoUser list in the right panel.          
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[3]));

            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserC.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the new annotation.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserD.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[3].LoginName, dashboard[0].Receivers[3].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the new annotation.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }


        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-2")]
        public void VerifySubscriberCanInviteOtherUsers(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.UserA,UserB appear in the subscriber user list.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[1]));

            //Click "Invitation" button, check UserC and UserD add the new annotation and then click Confirm button.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[2]);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[3]);

            //UserC and UserD appear in SharetoUser list in the right panel.          
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[3]));

            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserC.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the new annotation.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserD.Navigate to homepage, then to "Collaborative Widget " tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[3].LoginName, dashboard[0].Receivers[3].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //There is a widgetA appear in "Collaborative Widget " with the new annotation.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-3")]
        public void VerifyCancelAndCloseWhenInviteOtherUsers(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click "Subscriber User List"  button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //.UserA,UserB,UserC appear in Subscriber User List.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[2]));

            //Click "Invitation" button, Check UserD in the left panel.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[3]);

            //UserD appear in SharetoUser list in the right panel.          
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[3]));

            //Click Cancel button.then close share user list window
            ShareWindow.ClickGiveUpEnjoyButton();
            TimeManager.ShortPause();

            //Click "Subscriber User List"  button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Click "Invitation" button, Check UserD in the left panel.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[3]);

            ShareWindow.Close();
            TimeManager.ShortPause();

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            //Only one widgetA keep display in thumbnail list of UserA . The new widgetA doesn't display in UserA.
            Assert.AreEqual(1, HomePagePanel.GetSameWidgetNameNumberofMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //.Only one widgetA keep display in thumbnail list of UserB.The new widgetA doesn't display in UserB.
            Assert.AreEqual(1, HomePagePanel.GetSameWidgetNameNumberofMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-4")]
        public void SponserViewTheSubscriberList(ShareDashboardData input)
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

            //Select widgetA and click "Share link" button
            HomePagePanel.ClickEnjoyWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //UserB and UserC in the left panel.Check UserB.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[1]);

            //.UserB is checked in the left panel.
            Assert.IsTrue(ShareWindow.IsEnjoyUserChecked(dashboard[0].ShareUsers[1]));

            //Mouse float the UserB in the right panel.Click Close button.
            ShareWindow.ClickRemoveEnjoyUserButton(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            //.UserB disappear in the right panel and uncheck in the left panel.
            Assert.IsFalse(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[1]));
            Assert.IsFalse(ShareWindow.IsEnjoyUserChecked(dashboard[0].ShareUsers[1]));

            //Check UserB and UserC.UserB and UserC are checked in the left panel.
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[1]);
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[2]);
            TimeManager.ShortPause();
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserChecked(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserChecked(dashboard[0].ShareUsers[2]));

            //Click Confirm button.
            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-5")]
        public void SubscriberViewTheSubscriberList(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Open subscriber user list window.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Mouse to UserB's line.The Quitsubscriber button display.
            ShareWindow.FloatOnSubscriberUser(dashboard[0].ShareUsers[1]);
            Assert.AreEqual("退出订阅", ShareWindow.GetRemoveorQuitSubcriberText(dashboard[0].ShareUsers[1]));
            ShareWindow.CloseSubcriberListWindow();
            TimeManager.ShortPause();

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Open subscriber user list window.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Mouse to UserB's line.The Quitsubscriber button display.
            ShareWindow.FloatOnSubscriberUser(dashboard[0].ShareUsers[1]);
            Assert.AreEqual("移除订阅者", ShareWindow.GetRemoveorQuitSubcriberText(dashboard[0].ShareUsers[1]));

            //Click Invitation button.Check UserC.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[2]);

            //Mouse to UserC's line and click Close button.
            ShareWindow.ClickRemoveEnjoyUserButton(dashboard[0].ShareUsers[2]);

            //.UserC disappear in the right panel and uncheck in the left panel.
            Assert.IsFalse(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[2]));
            Assert.IsFalse(ShareWindow.IsEnjoyUserChecked(dashboard[0].ShareUsers[2]));

            //Confirm is gray.
            Assert.IsFalse(ShareWindow.IsEnjoyButtonEnable());

            ShareWindow.Close();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-6")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-6")]
        public void VerifyUnsubscriberOneUserCanBeAddAgain(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //UserA,UserB,UserC and UserD appear in Subscriber User List.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[3]));

            //Mouse over the UserB and UserD, Click RemoveSubscriber button.
            ShareWindow.FocusOnSubscriberUser(dashboard[0].ShareUsers[1]);
            ShareWindow.ClickRemoveorQuitSubcriberButton(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();
            ShareWindow.FocusOnSubscriberUser(dashboard[0].ShareUsers[3]);
            ShareWindow.ClickRemoveorQuitSubcriberButton(dashboard[0].ShareUsers[3]);
            TimeManager.ShortPause();

            //Click Close button.
            ShareWindow.CloseSubcriberListWindow();
            TimeManager.ShortPause();

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

            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //UserA,UserC appear in Subscriber User List.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSubscribeUserList(dashboard[0].ShareUsers[2]));

            //Click "Invitation" button.UserB and UserD become available in left panel.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();
            Assert.IsTrue(ShareWindow.IsEnjoyUserInShareList(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInShareList(dashboard[0].ShareUsers[3]));

            //Check UserB, and then click Confirm button
            ShareWindow.CheckEnjoyUser(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            ShareWindow.ClickEnjoyButton();
            TimeManager.ShortPause();

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA is display in thumbnail list of UserB.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-7")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-7")]
        public void VerifySponsorCanRemoveAllSubscribers(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Mouse over the UserB ,UserC and click Removesubscriber button.
            ShareWindow.FloatOnSubscriberUser(dashboard[0].ShareUsers[1]);
            ShareWindow.ClickRemoveorQuitSubcriberButton(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();
            ShareWindow.FloatOnSubscriberUser(dashboard[0].ShareUsers[2]);
            ShareWindow.ClickRemoveorQuitSubcriberButton(dashboard[0].ShareUsers[2]);
            TimeManager.ShortPause();

            //Click Invitation button.
            ShareWindow.ClickInviteOtherButton();
            TimeManager.ShortPause();

            //A dialog pops up and UserB,UserC and UserD available in the left panel and UserA display in the right panel.
            Assert.IsTrue(ShareWindow.IsEnjoyUserInShareList(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInShareList(dashboard[0].ShareUsers[2]));
            Assert.IsTrue(ShareWindow.IsEnjoyUserInSendedList(dashboard[0].ShareUsers[0]));

            ShareWindow.Close();
            TimeManager.ShortPause();

            //WidgetA is display in thumbnail list of UserA.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //.WidgetA is disappear in thumbnail list of UserB.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-8")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeInviteSuite), "TC-J1-FVT-WidgetCollaborative-SubscriberListInvite-101-8")]
        public void VerifySubscriberCanQuitMirror(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserB. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);
            
            //Click "Subscriber User List" button in widgetA.
            HomePagePanel.ClickShareMyShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            
            //Mouse over the UserB  and click Quitsubscriber button.
            ShareWindow.FloatOnSubscriberUser(dashboard[0].ShareUsers[1]);
            ShareWindow.ClickRemoveorQuitSubcriberButton(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            //.WidgetA is disappear in thumbnail list of UserB.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
        }

    }
}


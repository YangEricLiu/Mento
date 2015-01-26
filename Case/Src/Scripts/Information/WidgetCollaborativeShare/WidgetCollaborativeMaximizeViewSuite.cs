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
    [ManualCaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101"), CreateTime("2014-03-17"), Owner("Emma")]
    public class WidgetCollaborativeMaximizeViewSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static Widget Widget = JazzFunction.Widget;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static ShareWindow ShareWindow = new ShareWindow();
        private static ShareInfoWindow ShareInfoWindow = new ShareInfoWindow();
        private static int WAITSHAREINFOTAB = 5000;
        private UserSettings UserSettings = JazzFunction.UserSettings;
        
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
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-3")]
        public void CommentWindowViewAndWorkWell(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Widget Mirror tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();

            //Click the schema picture for widgetA.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Verify Comment window.Comment box and Confirm button display at the top. The Confirm button is gray.
            Assert.IsFalse(Widget.IsMaxWidgetRightCommentButtonEnable());

            //Add comments in comment field and click "Confirm" button.
            Widget.FillMaxWidgetRightComment(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            Widget.ClickMaxWidgetRightCommentButton();
            TimeManager.ShortPause();

            Assert.AreEqual(1, Widget.GetCommentNumberOnMaxWidgetRight());
            Assert.IsTrue(Widget.GetCommentOfOnePosition(1).Contains(dashboard[0].widgetComments[0]));

            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-7")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-7")]
        public void SponsorNameWillNotBeUpdateOnCommentField(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserD. Change the UserA name to UserAA.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[3].LoginName, dashboard[0].Receivers[3].Password, "“云能效”系统管理");
            UserSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();

            UserSettings.FocusOnUser(dashboard[0].ShareUsers[0]);
            UserSettings.ClickModifyButton();
            TimeManager.ShortPause();
            UserSettings.FillInRealName(dashboard[0].ShareUsers[4]);
            TimeManager.ShortPause();
            UserSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Login to Jazz with UserAA. Navigate to homepage, then to Collaborative Widget tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();

            //.The info in widgetA of "由UserA共享" cannot change to "由UserAA共享"。
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetMyShareWidgetShareUser(dashboard[0].WidgetName));

            //Verify the comment send by UserA.The user's name cannot be change.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Assert.IsTrue(Widget.GetCommentOfOnePosition(1).Contains(dashboard[0].widgetComments[0]));
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-8")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-8")]
        public void VerifyCloseButtonInMaximizeDialog(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Login to Jazz with UserA. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[0].LoginName, dashboard[0].Receivers[0].Password, null);
            HomePagePanel.NavigateToMyShare();

            //.Display the Collaborative Widget  in maximized size.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            //Add annotation in the top-right annotation box without click Confirm button..The Confirm button active.
            Widget.FillMaxWidgetRightComment(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            Assert.IsTrue(Widget.IsMaxWidgetRightCommentButtonEnable());

            //Click Close button..The dialog can be closed properly without error.
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();

            //Click the schema picture..Display the Collaborative Widget  in maximized size and the new annotation doesn't display in the annotation list.
            HomePagePanel.MaximizeMyShareWidget(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Assert.AreEqual(0, Widget.GetCommentNumberOnMaxWidgetRight());
            Widget.ClickCloseMaxDialogButton();
            TimeManager.ShortPause();
        }
    }
}


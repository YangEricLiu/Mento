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

            //Modify the widget name change to widgetB.Click Cancel button.
            HomePagePanel.RenameMyShareWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            Widget.FillNewWidgetName(dashboard[0].widgetComments[0]);
            TimeManager.ShortPause();
            Widget.ClickGiveupButtonOnWindow();
            TimeManager.ShortPause();

            //The widget name also display "widgetA".
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));

            //Login to Jazz with UserC. Navigate to homepage->Dashboard->Collaborative Widget  tab.
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToMyShare();
            TimeManager.Pause(15);

            //WidgetA' name is change to as Sponsor modify in thumbnail list.
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].widgetComments[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnMyShare(dashboard[0].WidgetName));
            TimeManager.ShortPause();
        }
        
    }
}


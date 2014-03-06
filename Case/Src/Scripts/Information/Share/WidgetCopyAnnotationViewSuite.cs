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
    [ManualCaseID("TC-J1-FVT-WidgetCopy-Annotation-101"), CreateTime("2014-03-10"), Owner("Emma")]
    public class WidgetCopyAnnotationViewSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        public void ShareWithNoAnnotationSuccess(ShareDashboardData input)
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

            //Select widgetA and click "share Copy of widget" button.
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //·There is userB and UserD display in receivers list.
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[1]));

            //There isn't userC display in receivers list.
            Assert.IsFalse(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[2]));

            //Check UserB and UserD checkbox, with no annotation in annotation field and click "share".
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);

            //Share widget successfully to userB and userD with no annotation.
            ShareWindow.ClickShareButton();
            JazzMessageBox.LoadingMask.WaitPopNotesAppear(5);
            //Pop up note show share successfully and disappear in little seconds.
            Assert.AreEqual("分享小组件“WidgetCopyAnnotation_101_1_1”成功。", HomePagePanel.GetPopNotesValue());

            //Login to Jazz with userB. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[1].LoginName, dashboard[0].Receivers[1].Password, null);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();

            //Login to Jazz with userD. Navigate to homepage, then to hierarchynodeA.  
            HomePagePanel.ExitJazz();
            JazzFunction.LoginPage.LoginWithOption(dashboard[0].Receivers[2].LoginName, dashboard[0].Receivers[2].Password, dashboard[0].HierarchyName[0]);
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Click dashboardA.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //·Only 1 widgetA display in dashboard.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Check the annotation in widgetA.The annotation is blank.
            HomePagePanel.FloatOnEditCommentButton(dashboard[0].WidgetName);
            TimeManager.ShortPause();

            HomePagePanel.ClickAddAnnotationButton();
            TimeManager.ShortPause();
            Widget.ClickQuitAnnotationWindowButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCopyAnnotationViewSuite), "TC-J1-FVT-WidgetCopy-Annotation-101-1")]
        public void ShareWithAnnotationSuccess(ShareDashboardData input)
        {

        }
    }
}


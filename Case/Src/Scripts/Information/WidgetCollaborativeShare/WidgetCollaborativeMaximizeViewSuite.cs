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
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-1")]
        public void MaximizeDialogCheck(ShareDashboardData input)
        {
            //Manual Test for UI
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-2")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-2")]
        public void VerifyPageButtonInMaximizeDialog(ShareDashboardData input)
        {
            //Manual Test for UI
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-3")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-3")]
        public void CommentWindowViewAndWorkWell(ShareDashboardData input)
        {
            //Manual Test for UI
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-4")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-4")]
        public void VerifyRefreshPreviousComment(ShareDashboardData input)
        {
            //Manual Test for UI
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetCollaborative-MaximizeView-101-5")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(WidgetCollaborativeMaximizeViewSuite), "TC-J1-FVT-WidgetCollaborative-MaximizeView-101-5")]
        public void VerifyRefreshNewComment(ShareDashboardData input)
        {
            //Manual Test for UI
        }
    }
}


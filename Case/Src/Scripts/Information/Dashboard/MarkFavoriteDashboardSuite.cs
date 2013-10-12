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
    [ManualCaseID("TC-J1-FVT-Dashboard-MarkRead-101"), CreateTime("2013-10-11"), Owner("Emma")]
    public class MarkFavoriteDashboardSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        
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
        [CaseID("TC-J1-FVT-Dashboard-MarkFavorite-101-1")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(MarkFavoriteDashboardSuite), "TC-J1-FVT-Dashboard-MarkFavorite-101-1")]
        public void MarkOneFavoriteDashboard(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            //Mouse over a dashboard which hasn't been marked as favorite, 
            //Click the 'star' icon which is unlighted now.
            HomePagePanel.ClickFavoriteDashboardButton(dashboard[0].DashboardNames[0]);
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsDashboardFavorited(dashboard[0].DashboardNames[0]));

            //The favorite dashboards list is displayed on the page.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardNames[0]));
            Assert.IsTrue(HomePagePanel.IsDashboardFavorited(dashboard[0].DashboardNames[0]));

            //Click the link of the hierarchy node.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            Assert.AreEqual("所在层级：", HomePagePanel.GetGetFavoriteLevelButtonCommonValue());
            Assert.AreEqual(dashboard[0].HierarchyName.Last(), HomePagePanel.GetFavoriteLevelButtonValue());
            HomePagePanel.ClickFavoriteLevelButton();
            JazzMessageBox.LoadingMask.WaitJumpFavoriteLoading();
            TimeManager.MediumPause();

            //User is navigated back to the hierarchy node successfully.
            Assert.AreEqual(dashboard[0].DashboardNames[0], HomePagePanel.GetDashboardHeaderName());

            //pick a favorite dashboard which is empty (with a message '该仪表盘为空'), then click the link of the hierarchy node.
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardNames[1]);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();
            HomePagePanel.ClickFavoriteLevelButton();
            JazzMessageBox.LoadingMask.WaitJumpFavoriteLoading();
            TimeManager.LongPause();

            Assert.AreEqual(dashboard[0].DashboardNames[1], HomePagePanel.GetDashboardHeaderName());
            Assert.AreEqual(input.ExpectedData.NoneWidgetMessage, HomePagePanel.GetDashboardPanelValue());
        }

    }
}


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

namespace Mento.Script.Information.Dashboard
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Dashboard-Delete-101"), CreateTime("2013-10-10"), Owner("Emma")]
    public class DeleteDashboardSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-Dashboard-Delete-101-1")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(DeleteDashboardSuite), "TC-J1-FVT-Dashboard-Delete-101-1")]
        public void DeleteOneDashboard(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            //Click 'Delete' button on top of the dashboard.
            HomePagePanel.ClickDeleteDashboardButton(dashboard[0].DashboardName);
            TimeManager.ShortPause();

            //Warning message is prompted to user for confirmation on the deletion.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteMessages[0]));
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteCommonMessage));

            //Click 'Cancel' (取消) or 'x' icon in the pop up confirmation window.
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.ShortPause();

            //The deletion is cancelled and the dashboard is still displayed in the dashboards tab list of this node.
            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
            Assert.AreEqual(dashboard[0].DashboardName, HomePagePanel.GetDashboardHeaderName());

            //Click 'Delete' button on top of the dashboard.
            HomePagePanel.ClickDeleteDashboardButton(dashboard[0].DashboardName);
            TimeManager.ShortPause();

            //Warning message is prompted to user for confirmation on the deletion.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteMessages[0]));
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteCommonMessage));

            //Click 'Yes' (确定) in the pop up confirmation window.
            JazzMessageBox.MessageBox.Delete();
            TimeManager.LongPause();

            // The dashboard is deleted successfully and removed from the dashboards list of this node.
            Assert.IsFalse(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //No new focus on any other dashboard and message '请选择一个仪表盘' is displayed on right panel.
            Assert.AreEqual(input.ExpectedData.NoFocusDashboardMessage, HomePagePanel.GetDashboardPanelValue());

            //Check if the deleted dashboard is removed from the page 'My favorite' as well: 
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.ShortPause();

            //The dashboard is deleted from the dashboards list of 'My favorite' page as well.
            Assert.IsFalse(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));

            //On 'My favorite' page, there is no 'Delete' button on any favorite dashboard.
            HomePagePanel.ClickDashboardButton(input.InputData.DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            Assert.IsFalse(HomePagePanel.IsDeleteDashboardButtonExisted(input.InputData.DashboardNames[0]));

            //Check if the deleted dashboard is removed from the window "Save widget to dashboard"
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Delete-101-2")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(DeleteDashboardSuite), "TC-J1-FVT-Dashboard-Delete-101-2")]
        public void DeleteDashboards(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            //Delete all dashboards of a H-Node
            for (int i = 0; i < dashboard[0].DashboardNames.Length; i++)
            {
                HomePagePanel.ClickDashboardButton(dashboard[0].DashboardNames[i]);
                JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
                TimeManager.LongPause();

                //Click 'Delete' button on top of the dashboard.
                HomePagePanel.ClickDeleteDashboardButton(dashboard[0].DashboardNames[i]);
                TimeManager.ShortPause();

                //Warning message is prompted to user for confirmation on the deletion.
                Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteMessages[i]));
                Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.DeleteCommonMessage));

                //Click "Delete"
                JazzMessageBox.MessageBox.Delete();
                TimeManager.LongPause();

                // The dashboard is deleted successfully and removed from the dashboards list of this node.
                Assert.IsFalse(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardNames[i]));
            }

            //Message like '该节点下没有仪表盘' is displayed. 
            Assert.AreEqual(input.ExpectedData.NoneDashboardMessage, HomePagePanel.GetDashboardPanelValue());

            //Add a valid dashboard whose name is the same as the deleted dashboard under the same Node
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardNames[0]));
        }
    }
}


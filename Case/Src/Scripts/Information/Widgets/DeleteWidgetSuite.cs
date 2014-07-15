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


namespace Mento.Script.Information.Widgets
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Widget-Delete-101"), CreateTime("2013-10-09"), Owner("Emma")]
    public class DeleteWidgetSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;

        [SetUp]
        public void CaseSetUp()
        {
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Delete-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(DeleteWidgetSuite), "TC-J1-FVT-Widget-Delete-101-1")]
        public void DeleteWidget(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //From the dashboard, select a widget, click 'Delete' button on the widget title.
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();

            //Warning message is prompted to user for confirmation on the deletion.
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.messages[0]));

            //Click 'Cancel' (取消) in the pop up confirmation window.
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();

            //The deletion is cancelled and the widget is still displayed on the dashboard.
            Assert.AreEqual(4, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));

            //Click 'Yes' (确定) in the pop up confirmation window.
            HomePagePanel.DeleteWidgetOpen(dashboard[0].WigetNames[0]);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            //The widget is removed from the dashboard.
            Assert.AreEqual(3, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            
            //Swtich to other dashboard/function, back to the dashboard.
            Widget.NavigateToEnergyView();
            TimeManager.ShortPause();
            Widget.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //The widget deletion is saved successfully.The dashboard and locations of the widgets are dispalyed correctly.
            Assert.AreEqual(3, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            //Mouse over a dashboard which hasn't been marked as favorite,
            //Click the 'star' icon which is unlighted now.
            HomePagePanel.ClickFavoriteDashboardButton(dashboard[0].DashboardName);
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsDashboardFavorited(dashboard[0].DashboardName));

            //Switch to 'My Favorite' (我的收藏) tab.
            Widget.NavigateToMyFavorite();
            TimeManager.ShortPause();

            //View the dashboard that the deleted widget belonged to.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //The widget is deleted from the favorite dashboard on 'My favorite' page as well.
            Assert.AreEqual(3, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));

            //back to 
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //Delete all widgets of the dashboard. 
            for (int i = 1; i < dashboard[0].WigetNames.Length; i++)
            {
                HomePagePanel.DeleteWidgetOpen(dashboard[0].WigetNames[i]);
                TimeManager.ShortPause();
                JazzMessageBox.MessageBox.Delete();
                TimeManager.MediumPause();

                //Assert.AreEqual((dashboard[0].WigetNames.Length - i - 1), HomePagePanel.GetWidgetsNumberOfDashboard());
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[i]));
            }

            //The dashboard becomes empty with a message '该仪表盘为空'. 
            //Assert.IsTrue(HomePagePanel.IsEmptyDashboardLabelExisted());

            //The favorite dashboard becomes empty as well since the hierachy based one has been empty.
            Widget.NavigateToMyFavorite();
            TimeManager.ShortPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsEmptyDashboardLabelExisted());

            //back to
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            //The dashboard becomes empty with a message '该仪表盘为空'. 
            Assert.IsTrue(HomePagePanel.IsEmptyDashboardLabelExisted());

            //Add a widget whose name is the same as the deleted widget for the same dashboard of the Hiearchy node. 
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

            //Add widget successfully into the dashboard and displayed in the last available space.
            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();

            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));            
        }
    }
}

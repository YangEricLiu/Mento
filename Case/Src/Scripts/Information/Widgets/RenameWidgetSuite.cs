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
    [ManualCaseID("TC-J1-FVT-Widget-Rename-101"), CreateTime("2013-10-09"), Owner("Emma")]
    public class RenameWidgetSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        
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
        [CaseID("TC-J1-FVT-Widget-Rename-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(RenameWidgetSuite), "TC-J1-FVT-Widget-Rename-101-1")]
        public void RenameWidgetValid(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.LongPause();

            // select a widget, click 'Rename' button on the widget title.
            HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[0]);

            //Input the valid name, and click cancel or 'x' icon.
            Widget.FillNewWidgetName(input.InputData.newWidgetName[0]);
            Widget.CancelModifyWidgetName();

            //The widget rename cancelled
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));

            //Input the valid name like '小工具_123', and click save.
            HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[0]);
            Widget.FillNewWidgetName(input.InputData.newWidgetName[0]);
            Widget.ClickSaveWidgetNameButton();
            TimeManager.MediumPause();

            //The widget rename saved
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[0]));
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
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //The new name is displayed on the widget of the favorite dashboard.
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[0]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));

            //On 'My favorite' page, there is no 'Rename' button on any widget.
            Assert.IsFalse(HomePagePanel.IsRenameButtonDisplayed(input.ExpectedData.newWidgetName[0]));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Rename-101-1-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(RenameWidgetSuite), "TC-J1-FVT-Widget-Rename-101-1")]
        public void RenameWidgetValid2(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.LongPause();

            //Without any modification, just save the original name directly.
            HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[1]);
            Widget.ClickSaveWidgetNameButton();
            TimeManager.MediumPause();

            //The widget rename saved
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[1]));
            TimeManager.MediumPause();

            //valid name (e.g. '小组件  Widget_1xxxxx')
            for (int i = 1; i < 3; i++)
            {
                HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[i]);
                TimeManager.ShortPause();
                Widget.FillNewWidgetName(input.InputData.newWidgetName[i]);
                Widget.ClickSaveWidgetNameButton();
                TimeManager.MediumPause();

                //The widget rename saved
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[i]));
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[i]));
            }

            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //valid name (e.g. '小组件  Widget_1xxxxx')
            for (int j = 3; j < 5; j++)
            {
                HomePagePanel.RenameWidgetOpen(dashboard[1].WigetNames[j-3]);
                TimeManager.ShortPause();
                Widget.FillNewWidgetName(input.InputData.newWidgetName[j]);
                Widget.ClickSaveWidgetNameButton();
                TimeManager.MediumPause();

                //The widget rename saved
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[j]));
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[1].WigetNames[j - 3]));
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Rename-101-2")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(RenameWidgetSuite), "TC-J1-FVT-Widget-Rename-101-2")]
        public void RenameWidgetInvalid(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.LongPause();

            // select a widget, click 'Rename' button on the widget title.
            HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[0]);

            //Input the invalid name, and click save
            for (int i = 1; i < (input.ExpectedData.newWidgetName.Length); i++)
            {
                Widget.FillNewWidgetName(input.InputData.newWidgetName[i]);
                Widget.ClickSaveWidgetNameButton();
                TimeManager.ShortPause();

                Assert.IsTrue(Widget.IsWidgetNameFieldInvalid());
                Assert.IsTrue(Widget.GetWidgetNameFieldInvalidMsg().Contains(input.ExpectedData.newWidgetName[i]));
            }

            //Revise above invalid name to be valid, and click Save.
            Widget.FillNewWidgetName(input.InputData.newWidgetName[0]);
            Widget.ClickSaveWidgetNameButton();
            TimeManager.ShortPause();

            //The widget rename saved
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(input.ExpectedData.newWidgetName[0]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
        }
    }
}


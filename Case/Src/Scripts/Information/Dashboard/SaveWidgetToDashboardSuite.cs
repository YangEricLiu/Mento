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
    public class SaveWidgetToDashboardSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static SaveToDashboardDialog SaveToDs = new SaveToDashboardDialog();
        
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Add-101-2")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(SaveWidgetToDashboardSuite), "TC-J1-FVT-Widget-Add-101-2")]
        public void SaveWidgetToFullWidgets(RenameDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Go back to chart view
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click 'Save widget to dashboard'.
            EnergyAnalysis.Toolbar.SelectMoreOption(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();

            //Input invalid widget name, and click '保存':
            //Widget name already exist under the same Dashboard. (e.g. an existing widget named '能效分析', add another widget with name '能效分析')
            SaveToDs.SelectDashboard(input.InputData.DashboardNames[0]);
            SaveToDs.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(SaveToDs.IsWidgetNameInvalid());
            Assert.IsTrue(SaveToDs.GetWidgetNameInvalidMsg().Contains(input.ExpectedData.WidgetMessage[0]));

            //blank
            SaveToDs.FillWidgetName("");
            SaveToDs.ClickSaveButton();
            Assert.IsTrue(SaveToDs.IsWidgetNameInvalid());
            Assert.IsTrue(SaveToDs.GetWidgetNameInvalidMsg().Contains(input.ExpectedData.NoneWidgetMessage));

            SaveToDs.FillWidgetName(dashboard[0].WidgetName);
            SaveToDs.Close();
            TimeManager.MediumPause();

            //Input valid widget name, and click '放弃' icon.
            EnergyAnalysis.Toolbar.SelectMoreOption(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();
            SaveToDs.SelectDashboard(input.InputData.DashboardNames[0]);
            SaveToDs.FillWidgetName(dashboard[0].WidgetName);
            SaveToDs.ClickCancelButton();

            //Add several valid widgets to same dashboard continuously, until no available space in the dashboard.

            for (int i = 0; i < 4; i++)
            {
                EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[i].WidgetName, dashboard[i].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();
            }
                
            //Save one more widget
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[4].WidgetName, dashboard[4].HierarchyName, dashboard[4].IsCreateDashboard, dashboard[4].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Message ‘该仪表盘已满’ is displayed near the dashboard name when clicking save button.
            Assert.IsTrue(SaveToDs.GetExistedDashboardMsg().Contains(input.ExpectedData.DashboardMessage[0]));

            //Select another dashboard which is not full and add widget into it.
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[5].WidgetName, dashboard[5].HierarchyName, dashboard[5].IsCreateDashboard, dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Widget can be added to it successfully without error.
            Assert.AreEqual("Widget_Add_101_2_13已保存", HomePagePanel.GetPopNotesValue());

            //Delete a widget from the dashboard which is full
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitWidgetsLoading(30);
            TimeManager.MediumPause();

            HomePagePanel.DeleteWidgetOpen(dashboard[0].WidgetName);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            //The widget can be added to the dashboard's last available space now.
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[4].WidgetName, dashboard[4].HierarchyName, dashboard[4].IsCreateDashboard, dashboard[4].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Widget can be added to it successfully without error.
            Assert.AreEqual("Widget_Add_101_2_13已保存", HomePagePanel.GetPopNotesValue());

            //Add one more, Message ‘该仪表盘已满’ is displayed again near the dashboard name.
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[6].WidgetName, dashboard[6].HierarchyName, dashboard[6].IsCreateDashboard, dashboard[6].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Message ‘该仪表盘已满’ is displayed near the dashboard name when clicking save button.
            Assert.IsTrue(SaveToDs.GetExistedDashboardMsg().Contains(input.ExpectedData.DashboardMessage[0]));
            SaveToDs.ClickCancelButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Add-101-3")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(SaveWidgetToDashboardSuite), "TC-J1-FVT-Widget-Add-101-3")]
        public void SaveWidgetToFullDashboards(RenameDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;

            //Go back to chart view
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            
            //Check '新建仪表盘' radio button
            EnergyAnalysis.Toolbar.SelectMoreOption(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();
            SaveToDs.ClickCreateNewDashboardButton();

            //Input invalid Dashboard Name into the textbox and click '保存'. 
            //A. Dashboard name already exist under the same H-Node   
            SaveToDs.FillDashboard(dashboard[0].DashboardName);
            SaveToDs.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(SaveToDs.GetNewDashboardMsg().Contains(input.ExpectedData.DashboardMessage[0]));

            //Blank
            SaveToDs.FillDashboard("");
            SaveToDs.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(SaveToDs.GetNewDashboardMsg().Contains(input.ExpectedData.NoneDashboardMessage));

            //Input valid Dashboard name (e.g. 新仪表盘1) and click '取消'.
            SaveToDs.FillDashboard(dashboard[1].DashboardName);
            SaveToDs.ClickCancelButton();

            //Input valid Dashboard name (e.g. '新仪表盘Dash 1') and click '保存'.
            EnergyAnalysis.Toolbar.SelectMoreOption(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();
            SaveToDs.ClickCreateNewDashboardButton();
            SaveToDs.FillWidgetName(dashboard[1].WidgetName);
            SaveToDs.FillDashboard(dashboard[1].DashboardName);
            SaveToDs.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            Assert.AreEqual("Widget_Add_101_3_7_A已保存", HomePagePanel.GetPopNotesValue());

            //For the same hierarchy node, create several new dashboards and save widget to it one by one, until the total dashboard number of the node is 10.
            for (int i = 2; i < 5; i++)
            {
                EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[i].WidgetName, dashboard[i].HierarchyName, dashboard[i].IsCreateDashboard, dashboard[i].DashboardName);
                JazzMessageBox.LoadingMask.WaitLoading();
                TimeManager.LongPause();
            }
            
            //Radio button '新建仪表盘' becomes disabled and unchecked, message '仪表盘数目已满' is displayed. radio button '已存在仪表盘' becomes checked automatically.
            EnergyAnalysis.Toolbar.SelectMoreOption(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();

            Assert.IsTrue(SaveToDs.IsCreateNewDashboardButtonDisabled());
            Assert.IsTrue(SaveToDs.IsExistedDashboardButtonChecked());
            Assert.AreEqual("仪表盘数目已满", SaveToDs.GetCreateNewDashboardText());
            SaveToDs.ClickCancelButton();

            //Delete a dashboard from above hierarchy node,
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            HomePagePanel.SelectHierarchyNode(dashboard[3].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitWidgetsLoading(30);
            TimeManager.MediumPause();

            HomePagePanel.ClickDeleteDashboardButton(dashboard[3].DashboardName);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();

            //Check '新建仪表盘' radio button,Input valid Dashboard name, and click '保存' again.
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[3].WidgetName, dashboard[3].HierarchyName, dashboard[3].IsCreateDashboard, dashboard[3].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Select another hierarchy node which doesn't related to selected tags, Check '新建仪表盘' radio button,Input valid Dashboard name, and click '保存'.
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[5].WidgetName, dashboard[5].HierarchyName, dashboard[5].IsCreateDashboard, dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //Select above hierarchy node which doesn't related to selected tags,Select an existing dashboard, click '保存'.
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[6].WidgetName, dashboard[6].HierarchyName, dashboard[6].IsCreateDashboard, dashboard[6].DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //check 
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            HomePagePanel.SelectHierarchyNode(dashboard[5].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[5].DashboardName);
            JazzMessageBox.LoadingMask.WaitWidgetsLoading(30);
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[5].WidgetName));

            HomePagePanel.SelectHierarchyNode(dashboard[6].HierarchyName);
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[6].DashboardName));
        }
    }
}


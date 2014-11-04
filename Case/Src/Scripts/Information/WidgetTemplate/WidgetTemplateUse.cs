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


namespace Mento.Script.Information.WidgetTemplate
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-WidgetTemplate-Use-101"), CreateTime("2014-10-9"), Owner("Cathy")]
    public class WidgetTemplateUseSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static UserDataScopePermission UserDataScope = JazzFunction.UserDataScopePermission;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static CostPanel costPanel = JazzFunction.CostPanel;
        private static ShareWindow ShareWindow = new ShareWindow();
       
        [SetUp]
        public void CaseSetUp()
        {
            //HomePagePanel.SelectCustomer("CommodityTestCustomer");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetTemplate-Use-101")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateUseSuite), "TC-J1-FVT-WidgetTemplate-Use-101")]
        public void WidgetTemplateUse101(MaximizeWidgetData input)
        {
            var hierarchy = input.InputData.HierarchyInfo;
            HomePagePanel.SelectHierarchyNode(hierarchy[0]);
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
            //判断
           Assert.AreEqual(Widget.GetSelectHierarchyButtonText(), "buildingA");
            EnergyAnalysis.IsAllGridTagsUnchecked();
             Assert.AreEqual(input.ExpectedData.UnitTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());
            
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
            UserDataScope.IsHierarchyNodeChecked(hierarchy[1]);
           Assert.AreEqual(Widget.GetSelectHierarchyButtonText(), hierarchy[1]);
            //判断 "该节点为非楼宇节点，请重新选择节点"
            Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[6]);
            Assert.IsFalse(UserDataScope.IsHierarchyNodeChecked(hierarchy[1]));
            Assert.AreEqual(input.ExpectedData.UnitTypeValue[1], Widget.GetUnitTypeButtonText());
            Assert.AreEqual(input.ExpectedData.FuncTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[0]);
            EnergyAnalysis.IsAllGridTagsUnchecked();
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.RadioTypeValue[1], Widget.GetRadioTypeConvertTargetButtonText());
            TimeManager.LongPause();

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[4]);
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.FuncTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.UnitTypeValue[0], Widget.GetUnitTypeButtonText());
            TimeManager.LongPause();

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[7]);
            EnergyAnalysis.IsAllGridTagsUnchecked();

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[3]);
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.CarbonConvertTypeValue[1], Widget.GetCarbonConvertTargetButtonText());

            //年逐月成本
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickOnWidgetTemplateField(input.InputData.WidgetNames[1]);
            TimeManager.LongPause();
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());


            //年逐月电峰谷用电成本 with config TOU building
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(costPanel.IsCommodityChecked(input.ExpectedData.CommodityValue[0]));
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsPeakValleyButtonPressed());
            Assert.IsTrue(costPanel.IsColumnChartDrawn());
            TimeManager.LongPause();

            //年逐月电峰谷用电成本 without config TOU building
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsPopMsgCorrect(input.ExpectedData.messages[1]));
            Widget.ClickNotConfigPeakValleyMessageCloseButton();
            Assert.IsFalse(costPanel.IsCommodityChecked(input.ExpectedData.CommodityValue[0]));
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());

            //年逐月电峰谷用电成本 no electricity
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[4]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsFalse(costPanel.IsCommodityChecked(input.ExpectedData.CommodityValue[0]));
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());

            //年逐月电峰谷用电成本 no building
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());

            //年逐月电峰谷用电成本 without hierarchy
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            Assert.AreEqual(Widget.GetSelectHierarchyButtonText(), "请选择层级结构");
            TimeManager.LongPause();
            Assert.IsFalse(costPanel.IsCommodityChecked(input.ExpectedData.CommodityValue[0]));
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());

            //from map page
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            JazzFunction.Navigator.NavigateHome();
            HomePagePanel.ClickOnBuildingField("zy");
            TimeManager.LongPause();
            Widget.ClickCheckEnergyInfoLinkButton();
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            TimeManager.LongPause();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
         }
        [CaseID("TC-J1-FVT-WidgetTemplate-Use-102")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateUseSuite), "TC-J1-FVT-WidgetTemplate-Use-102")]
        public void WidgetTemplateUse102(MaximizeWidgetData input)
        {
            var hierarchy = input.InputData.HierarchyInfo;
            var dashboard = input.InputData.DashboardInfo;
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            EnergyViewToolbar.IsMoreMenuItemDisabled(input.InputData.MoreMenuItems[0]);
            EnergyViewToolbar.IsMoreMenuItemDisabled(input.InputData.MoreMenuItems[1]);
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[0]));
            TimeManager.LongPause();
            HomePagePanel.RenameWidgetOpen(dashboard[0].WigetNames[0]);
            TimeManager.LongPause();
            Widget.FillNewWidgetName(input.InputData.newWidgetName[0]);
            Widget.ClickSaveWidgetNameButton();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.ClickShareWidgetButton(input.InputData.newWidgetName[0]);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);
            Assert.IsTrue(ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ShareUsers[0]));
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.LongPause();
            ShareWindow.ClickShareButton();
            TimeManager.LongPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
            TimeManager.LongPause();
            HomePagePanel.DeleteWidgetOpen(input.InputData.newWidgetName[0]);
            TimeManager.ShortPause();
            JazzMessageBox.MessageBox.Delete();
            TimeManager.MediumPause();
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnDashboard(input.InputData.newWidgetName[0]));

            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[6]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            CorporateRanking.ClickSelectHierarchyButton();
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(hierarchy[2]);
            TimeManager.LongPause();
            CorporateRanking.OnlyCheckHierarchyNode(hierarchy[3]);
            TimeManager.LongPause();
            CorporateRanking.ClickConfirmHiearchyButton();
            TimeManager.LongPause();
            CorporateRanking.SelectCommodity(input.ExpectedData.CommodityValue[0]);
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[1], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.LongPause();
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard[0].WigetNames[1]));
        }
    }
}

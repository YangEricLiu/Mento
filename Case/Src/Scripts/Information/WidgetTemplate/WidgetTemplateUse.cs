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
           // HomePagePanel.SelectHierarchyNode(hierarchy[0]);
           // Widget.ClickWidgetTemplateQuickCreateButton();
           // HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
           // //判断
           //Assert.AreEqual(Widget.GetSelectHierarchyButtonText(), hierarchy[0]);
           // EnergyAnalysis.IsAllGridTagsUnchecked();
            // Assert.AreEqual(input.ExpectedData.UnitTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());
            
           // Widget.NavigateToAllDashboard();
           // TimeManager.MediumPause();
           // HomePagePanel.SelectHierarchyNode(hierarchy[1]);
           // Widget.ClickWidgetTemplateQuickCreateButton();
           // HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[5]);
           // UserDataScope.IsHierarchyNodeChecked(hierarchy[1]);
           //Assert.AreEqual(Widget.GetSelectHierarchyButtonText(), hierarchy[1]);
           // //判断 "该节点为非楼宇节点，请重新选择节点"
           // Assert.AreEqual(input.ExpectedData.messages[0], HomePagePanel.GetPopNotesValue());

            //Widget.NavigateToAllDashboard();
            //TimeManager.MediumPause();
            //HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            //Widget.ClickWidgetTemplateQuickCreateButton();
            //HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[6]);
            //Assert.IsFalse(UserDataScope.IsHierarchyNodeChecked(hierarchy[1]));
            //Assert.AreEqual(input.ExpectedData.UnitTypeValue[1], Widget.GetUnitTypeButtonText());
            //Assert.AreEqual(input.ExpectedData.FuncTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());

            //Widget.NavigateToAllDashboard();
            //TimeManager.MediumPause();
            //HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            //Widget.ClickWidgetTemplateQuickCreateButton();
            //HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[0]);
            //EnergyAnalysis.IsAllGridTagsUnchecked();
            //TimeManager.LongPause();
            //Assert.AreEqual(input.ExpectedData.RadioTypeValue[1], Widget.GetRadioTypeConvertTargetButtonText());
            //TimeManager.LongPause();

            //Widget.NavigateToAllDashboard();
            //TimeManager.MediumPause();
            //TimeManager.LongPause();
            //HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            //TimeManager.LongPause();
            //Widget.ClickWidgetTemplateQuickCreateButton();
            //HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[4]);
            //TimeManager.LongPause();
            //Assert.AreEqual(input.ExpectedData.FuncTypeValue[0], Widget.GetFuncModeConvertTargetButtonText());
            //TimeManager.LongPause();
            //Assert.AreEqual(input.ExpectedData.UnitTypeValue[0], Widget.GetUnitTypeButtonText());
            //TimeManager.LongPause();

            //Widget.NavigateToAllDashboard();
            //TimeManager.MediumPause();
            //TimeManager.LongPause();
            //HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            //TimeManager.LongPause();
            //Widget.ClickWidgetTemplateQuickCreateButton();
            //HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[7]);
            //EnergyAnalysis.IsAllGridTagsUnchecked();

            //Widget.NavigateToAllDashboard();
            //TimeManager.MediumPause();
            //TimeManager.LongPause();
            //HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            //TimeManager.LongPause();
            //Widget.ClickWidgetTemplateQuickCreateButton();
            //HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[3]);
            //TimeManager.LongPause();
            //Assert.AreEqual(input.ExpectedData.CarbonConvertTypeValue[1], Widget.GetCarbonConvertTargetButtonText());

            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickOnWidgetTemplateField(input.InputData.WidgetNames[1]);
            TimeManager.LongPause();
            Assert.IsFalse(Widget.IsPeakValleyButtonEnabled());
            //costPanel.IsCommodityChecked(input.InputData.);


            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
            TimeManager.LongPause();
            HomePagePanel.SelectHierarchyNode(hierarchy[2]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateQuickCreateButton();
            HomePagePanel.ClickWidgetTemplateField(input.InputData.WidgetNames[2]);
            TimeManager.LongPause();
            //Assert.IsTrue(Widget.IsSingleCommodityElectricCheckBoxChecked("电"));
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsPeakValleyButtonPressed());
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsEnergyDisplayStepMonthButtonPressed());
        }
    }
}

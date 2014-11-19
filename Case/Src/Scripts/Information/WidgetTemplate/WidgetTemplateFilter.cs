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
    [ManualCaseID("TC-J1-FVT-WidgetTemplate-Filter-101"), CreateTime("2014-10-13"), Owner("Cathy")]
    public class WidgetTemplateFilterSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [SetUp]
        public void CaseSetUp()
        { 
            //HomePagePanel.SelectCustomer("NancyCostCustomer2");
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetTemplate-Filter-101"), CreateTime("2014-11-19"), Owner("Cathy")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateFilterSuite), "TC-J1-FVT-WidgetTemplate-Filter-101")]
        public void WidgetTemplateFilter101(MaximizeWidgetData input)
        {
            //var filtercondition = input.InputData.FilterConditionInfo;
            var widgetname = input.ExpectedData.WidgetNames;
            Widget.ClickWidgetTemplateQuickCreateButton();
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Check 行为，filter 年逐月能耗工休比
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            //Click applyfilter button, 行为 still check, 年逐月能耗工休比 still display
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            //verify 行为 check, other uncheck
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsWidgetTemplateChecked(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]));
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[2]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[4]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[5]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[6]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[7]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[8]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[9]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[10]));

            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[11]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[12]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[13]));

            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[14]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[15]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[16]));

            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[17]));
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[18]));

            //uncheck 行为
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            

            //check 建筑 单位指标
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[3]);
            
            //Check 管理，行为，能源消耗，按年
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[5]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[6]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[7]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);

            //Check 建筑，按年
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[1]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[2]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[3]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);

            //check 管理，集团排名，能效分析，柱状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[6]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[6]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[6]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);

            //check 管理，碳排放，成本，柱状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[1]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[2]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[3]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[2]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);
            
            //check 能效标识图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[2]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[5]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[2]);

            //check 时段能耗比，线状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[4]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[0]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[4]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[0]);

            //check all
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[3]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[4]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[5]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[6]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[1]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[2]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[3]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[5]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[6]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[7]));
            TimeManager.LongPause();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[2]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[2]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[3]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[4]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[5]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[6]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[2]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[1]);

            //check 能效分析，碳排放
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[1]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[1]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[2]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[3]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[5]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[6]));
            Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[7]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[1]);

        }

        }
    }

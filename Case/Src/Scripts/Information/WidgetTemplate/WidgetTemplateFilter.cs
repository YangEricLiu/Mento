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
        public void FilterWidgetTemplateValid(MaximizeWidgetData input)
        {
            var widgetname = input.ExpectedData.WidgetNames;
            Widget.ClickWidgetTemplateQuickCreateButton();
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            //Check 行为，filter 年逐月能耗工休比
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //行为criteria display
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[3]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            //Click applyfilter button, 行为 still check, 年逐月能耗工休比 still display
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            //verify 行为 check, other uncheck
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsWidgetTemplateChecked(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]));
            TimeManager.LongPause();
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]));
            }
            for (int i = 4; i < 19; i++)
            {
                Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]));
            }
            //uncheck 行为
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);


            //check 建筑 单位指标
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[7], input.InputData.TargetObject[7]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //建筑 单位指标 criteria display
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[1]));
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[7]));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[4]));
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[7], input.InputData.TargetObject[7]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check 管理，行为，能源消耗，按年
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[11], input.InputData.TargetObject[11]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[17], input.InputData.TargetObject[17]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            for (int i = 4; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[11], input.InputData.TargetObject[11]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[17], input.InputData.TargetObject[17]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check 建筑，按年
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[17], input.InputData.TargetObject[17]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            for (int i = 1; i < 5; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[17], input.InputData.TargetObject[17]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check 管理，集团排名，能效分析，柱状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[4]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[10], input.InputData.TargetObject[10]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[15], input.InputData.TargetObject[15]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[6]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[4]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[10], input.InputData.TargetObject[10]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[15], input.InputData.TargetObject[15]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check 管理，碳排放，成本，柱状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[5], input.InputData.TargetObject[5]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[6], input.InputData.TargetObject[6]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[15], input.InputData.TargetObject[15]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            for (int i = 1; i < 4; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[0]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[5], input.InputData.TargetObject[5]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[6], input.InputData.TargetObject[6]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[15], input.InputData.TargetObject[15]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check 能效标识图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[16], input.InputData.TargetObject[16]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[5]));
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[16], input.InputData.TargetObject[16]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check 时段能耗比，线状图
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[8], input.InputData.TargetObject[8]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[14], input.InputData.TargetObject[14]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            TimeManager.LongPause();
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[8], input.InputData.TargetObject[8]);
            TimeManager.LongPause();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[14], input.InputData.TargetObject[14]);
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check all
            for (int i = 0; i < 19; i++)
            {
                Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]);
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            for (int i = 0; i < 19; i++)
            {
                Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]);
            }
            TimeManager.LongPause();
            TimeManager.LongPause();

            //check 能效分析，碳排放
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[4]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[12], input.InputData.TargetObject[12]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            for (int i = 0; i < 8; i++)
            {
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[4], input.InputData.TargetObject[4]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[12], input.InputData.TargetObject[12]);
            TimeManager.LongPause();
            TimeManager.LongPause();

        }
        [CaseID("TC-J1-FVT-WidgetTemplate-Filter-001"), CreateTime("2014-11-20"), Owner("Cathy")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateFilterSuite), "TC-J1-FVT-WidgetTemplate-Filter-001")]
        public void FilterWidgetTemplateCancelled(MaximizeWidgetData input)
        {
            var widgetname = input.ExpectedData.WidgetNames;
            Widget.ClickWidgetTemplateQuickCreateButton();
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();

            //Uncheck any checkbox
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //All template display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            //All criteria not display when no checkbox check
            for (int i = 0; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button not display
            Assert.IsFalse(Widget.IsClearFilterButtonExisted());

            //Click filter button, check one checkbox,then uncheck, then applyfilter
            Widget.ClickWidgetTemplateFilterButton();
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[14], input.InputData.TargetObject[14]);
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[14], input.InputData.TargetObject[14]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //All template display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            //All criteria not display when no checkbox check
            for (int i = 0; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button not display
            Assert.IsFalse(Widget.IsClearFilterButtonExisted());

            //Click filter button, check one checkbox,then cancel, then applyfilter
            Widget.ClickWidgetTemplateFilterButton();
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[14], input.InputData.TargetObject[14]);
            Widget.ClickWidgetTemplateCancelFilterButton();
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //All template display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
            //All criteria not display when no checkbox check
            for (int i = 0; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button not display
            Assert.IsFalse(Widget.IsClearFilterButtonExisted());

            //Click filter button, check 行为 checkbox,then applyfilter
            Widget.ClickWidgetTemplateFilterButton();
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[0], input.InputData.TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //Template "年逐月工休比" display there
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            //All criteria not display when no checkbox check
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[3]));
            for (int i = 0; i < 2; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            for (int i = 4; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button display
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());

            //Click filter button,then applyfilter, keep above check
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            //Template "年逐月工休比" display there
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            //行为 criteria display 
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[3]));
            for (int i = 0; i < 2; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            for (int i = 4; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button display
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());

            //Click filter button,uncheck 行为， check 设备， then cancel, then applyfilter, keep above check
            Widget.ClickWidgetTemplateFilterButton();
            Widget.UncheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]);
            Widget.ClickWidgetTemplateCancelFilterButton();
            TimeManager.LongPause();
            //Template "年逐月工休比" display there
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            //All criteria not display when no checkbox check
            Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[3]));
            for (int i = 0; i < 2; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            for (int i = 4; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //Verify clearfilter button display
            TimeManager.LongPause();
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());

            //Click filter button,行为 is check， check 设备,建筑， then cancel, then applyfilter, keep above check
            Widget.ClickWidgetTemplateFilterButton();
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[1], input.InputData.TargetObject[1]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]);
            Widget.ClickWidgetTemplateQuickCreateButtonCloseButton();
            TimeManager.LongPause();
            //Verify 快速创建 button exist
            Assert.IsTrue(Widget.IsWidgetTemplateQuickCreateButtonExisted());
        }
        [CaseID("TC-J1-FVT-WidgetTemplate-Filter-002"), CreateTime("2014-11-20"), Owner("Cathy")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateFilterSuite), "TC-J1-FVT-WidgetTemplate-Filter-002")]
        public void CleanFilterCriteria(MaximizeWidgetData input)
        {
            var widgetname = input.ExpectedData.WidgetNames;
            Widget.ClickWidgetTemplateQuickCreateButton();
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();

            //Check 设备 行为 checkboxs
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]);
            Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            
            //Verify clearfilter button  display
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());
            //click 行为 close button.
            Widget.ClickWidgetTemplateCloseFilterButton(input.InputData.TargetObject[3]);
            //Verify 行为 criteria and widget template not display 
            Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[3]));
            //All template not display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }

            //Click 'Filter Criteria' ('模板筛选') button to view
            Widget.ClickWidgetTemplateFilterButton();
            //Verify 行为 unchecked
            Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[3], input.InputData.TargetObject[3]));
            //Verify 设备 checked
            Assert.IsTrue(Widget.IsWidgetTemplateChecked(input.InputData.FilterPropertiesName[2], input.InputData.TargetObject[2]));
            //All template not display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsFalse(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }

            //Click Cancel button
            Widget.ClickWidgetTemplateCancelFilterButton();
            //Verify clearfilter button still display
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());
            

            //Click close button to 设备
            Widget.ClickWidgetTemplateCloseFilterButton(input.InputData.TargetObject[2]);
            //Verify 设备 criteria and widget template  display 
            Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[2]));
            //All template display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
             //verify clearall button not display
            Assert.IsFalse(Widget.IsClearFilterButtonExisted());

            //Click 'Filter Criteria' ('模板筛选') button 
            Widget.ClickWidgetTemplateFilterButton();
            //Check all checkboxs
            for (int i = 0; i < 19; i++)
            {
                Widget.CheckWidgetTemplateCheckBox(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]);
            }
            //click 'ApplyFilter' button.
            Widget.ClickWidgetTemplateApplyFilterButton();
            //All criteria display when all checkbox check
            for (int i = 0; i < 19; i++)
            {
                Assert.IsTrue(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //verity clearall button  display
            Assert.IsTrue(Widget.IsClearFilterButtonExisted());

            //Click 'Clean Criteria' ('清空筛选条件') button.
            Widget.ClickWidgetTemplateClearFilterButton();
            //All criteria not display when all checkbox check
            for (int i = 0; i < 19; i++)
            {
                Assert.IsFalse(Widget.IsCriteriaLabelTextCorrect(input.InputData.TargetObject[i]));
            }
            //All templates display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }

            //Click 'Filter Criteria' ('模板筛选') button 
            Widget.ClickWidgetTemplateFilterButton();
            //All checkbox are unchecked
            for (int i = 0; i < 19; i++)
            {
                Assert.IsTrue(Widget.IsWidgetTemplateUnChecked(input.InputData.FilterPropertiesName[i], input.InputData.TargetObject[i]));
            }
            //All templates display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[i]));
            }
        }
      }
    }

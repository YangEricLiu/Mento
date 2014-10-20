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
        [CaseID("TC-J1-FVT-WidgetTemplate-Filter-101")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateFilterSuite), "TC-J1-FVT-WidgetTemplate-Filter-101")]
        public void WidgetTemplateFilter101(MaximizeWidgetData input)
        {
            var filtercondition = input.InputData.FilterConditionInfo;
            var widgetname = input.ExpectedData.WidgetNames;
            Widget.ClickWidgetTemplateQuickCreateButton();
            Widget.ClickWidgetTemplateFilterButton();
            TimeManager.LongPause();
            //Check 行为，filter 年逐月能耗工休比
            //Widget.CheckWidgetTemplateCheckBox(filtercondition[0].TargetObject[3]);
            TimeManager.LongPause();
            Widget.ClickWidgetTemplateApplyFilterButton();
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            //Click applyfilter button, 行为 still check, 年逐月能耗工休比 still display
            Widget.ClickWidgetTemplateFilterButton();
            //Widget.IsWidgetTemplateChecked(filtercondition[0].TargetObject[3]);
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));
            //Widget.UncheckTargetObjectInWidgetTemplateCheckBox(filtercondition[0].TargetObject[3]);
            //TimeManager.LongPause();
            //Widget.ClickWidgetTemplateApplyFilterButton();
            //Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(widgetname[0]));          
        }
    }
}

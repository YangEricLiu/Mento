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
using System.Data;

namespace Mento.Script.EnergyView.Usage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-SmokeTest-039"), CreateTime("2013-01-06"), Owner("Aries")]
    public class SmokeTestSingleTagSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1)
        ///     The trend chart of selected V(1) display.
        /// 4.	Click "Save to dashboard"(保存到仪表盘), 
        ///     Click the dashboard addtion button "新增仪表盘"
        ///     Input valid dashboard name like "仪表盘_A1",and click save.
        ///     The widget is saved to the new dashboard successfully
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-037")]
        [Priority("30")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SmokeTestSingleTagSuite), "TC-J1-SmokeTest-037")]
        public void SingTagTrendChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            Assert.IsTrue(DataPanel.IsTrendChartDrawn());

            //save to dashboard
            var dashboard = option.InputData.DashboardInfo;
            DataPanel.Toolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
        }

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1), click "Column chart", set date range to last month	
        ///     The Column chart of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-038")]
        [Priority("31")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SmokeTestSingleTagSuite), "TC-J1-SmokeTest-038")]
        public void SingleTagColumnChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            DataPanel.Toolbar.View(option.InputData.ViewType); //column

            DataPanel.Toolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);

            Assert.IsTrue(DataPanel.IsTrendChartDrawn());
        }
        
        /// <summary>
        /// 1. Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	
        ///    Successfully navigate to Energy Analysis window.
        /// 2. select a hierarchy node
        /// 3. Go to Tag select panel, Select V(1), click "data view", set date range to last year
        ///    The data view of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-039")]
        [Priority("32")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SmokeTestSingleTagSuite), "TC-J1-SmokeTest-039")]
        public void SingleTagDataView(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            DataPanel.Toolbar.View(option.InputData.ViewType);

            DataPanel.Toolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            Assert.AreEqual(12, DataPanel.GetRecordCount());
            Assert.AreEqual(1, DataPanel.GetPageCount());
        }

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node
        /// 3.	Go to Tag select panel, Select V(1), click "pie chart", set date range from 2012.1.1 to 2012.4.15
        ///     The pie chart of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-040")]
        [Priority("33")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SmokeTestSingleTagSuite), "TC-J1-SmokeTest-040")]
        public void SingleTagDistributionChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            DataPanel.Toolbar.SetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 4, 15));

            DataPanel.Toolbar.View(option.InputData.ViewType);

            Assert.IsTrue(DataPanel.IsDistributionChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-041")]
        public void TestDatePicker()
        {
            DatePicker EnergyUsageStartDate = JazzDatePicker.EnergyUsageStartDateDatePicker;
            DatePicker EnergyUsageEndDate = JazzDatePicker.EnergyUsageEndDateDatePicker;

            
            EnergyUsageEndDate.SelectDateItem(new DateTime(2012, 7, 14));
            TimeManager.MediumPause();
            EnergyUsageStartDate.SelectDateItem(new DateTime(2012, 6, 10));
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-000")]
        public void KPIRankRadio()
        {
            /*
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
            TimeManager.MediumPause();
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.Line);

            
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyRadio);
            TimeManager.MediumPause();
            */
            //string[] hierarchyNodePath = { "AutoOrg001", "AutoSite001", "AutoBuilding001" };
            string[] systemNodePath = {  "系统维度", "空调" };
            string[] hierarchyNodePath = { "AutoOrg001" };

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Rank);
            /*
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();

            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(hierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            JazzFunction.EnergyAnalysisPanel.CheckTag("Ptag2YNAME1");

            //JazzFunction.RankPanel.CheckHierarchyNode(hierarchyNodePath);
            //JazzFunction.RankPanel.ClickConfirmHiearchyButton();
            //JazzFunction.RankPanel.SwitchSystemDimensionTab();

            //JazzFunction.RankPanel.SelectSystemDimensionNode(systemNodePath);
            //JazzFunction.EnergyViewToolbar.View(EnergyViewType.Line);
            JazzFunction.EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            string[] hPath = { "自动化测试"  };
            DataPanel.Toolbar.SaveToDashboard("test", hPath, true, "newname");

            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTrendChartDrawn());
            */
            string[] hPath = { "NancyCustomer1", "GreenieSite" };
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Rank);
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CarbonUsage);
            TimeManager.LongPause();

            //JazzFunction.RankPanel.CheckHierarchyNode(hPath);
            //JazzFunction.RankPanel.ClickConfirmHiearchyButton();

            JazzFunction.UnitKPIPanel.SelectHierarchy(hPath);
            TimeManager.MediumPause();

            JazzFunction.EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            //JazzFunction.EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            //JazzFunction.UnitKPIPanel.SelectHierarchy(hPath);
            TimeManager.LongPause();

            

            
            string[] commodities = { "电", "汽油" };
            //JazzFunction.UnitKPIPanel.SelectCommodityUnitCost(commodities);
            //JazzFunction.CarbonUsagePanel.SelectCommodity(commodities);
            JazzFunction.UnitKPIPanel.SelectCommodityUnitCarbon();
            //JazzFunction.UnitKPIPanel.ClickCarbonTotal();
            //JazzFunction.RankPanel.SelectCommodity(commodities[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            

            /*
            string[] hPath = { "NancyCustomer1", "GreenieSite" };
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.Rank);
            JazzFunction.RankPanel.CheckHierarchyNode(hPath);
            TimeManager.MediumPause();
            JazzFunction.RankPanel.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            JazzFunction.RankPanel.SelectCommodity("电");
            */
        }
    }
}

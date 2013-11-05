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
using Mento.Utility;

namespace Mento.Script.EnergyView.CorporateRanking
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101"), CreateTime("2013-10-17"), Owner("Greenie")]
    public class SelectHierarchyNodesForRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCustomer1");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static UnitKPIPanel UnitIndicator = JazzFunction.UnitKPIPanel;
        private static  RatioPanel RatioIndicator= JazzFunction.RatioPanel;

        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        public void SelectHierarchyNodesForCoperateRanking(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector.
            //•  Popup the hierarchy tree.
            //•  In default, no hierarchy node is checked. And all checkboxes are enabled.
            //•  ‘清空’ button is unavailable since no any nodes selected.    @@@@@@@@@
            //•  Customer node is disabled for selection.                             @@@@@@@@@
            //•  Check the hierarchy node in checkbox.Uncheck one hierarchy node.
            //•  Uncheck the hierarchy node in checkbox.
            //Repeat above steps.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.CheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.UnCheckHierarchyNode(input.ExpectedData.Hierarchies);

            //Click '确定' button.
            CorporateRanking.ClickConfirmHiearchyButton();

            //•  The hierarchy tree is hidden.
            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            Assert.IsTrue(CorporateRanking.AreCommoditiesOnTheGrid(input.InputData.commodityNames));

            //Click Hierarchy Node Selector again.
            //•  Checkboxes of selected hierarchy nodes are displayed as checked.
            //•  Other checkboxes are displayed as are unchecked.
            CorporateRanking.ClickClearHiearchyButton();
            Assert.IsTrue(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies.Last()));

            //Click '清空' button.
            CorporateRanking.ClickClearHiearchyButton();

            //•  All hierarchy nodes are unchecked.The popup of hierarchy tree is still displayed.
            Assert.IsFalse(CorporateRanking.IsHierarchyNodeChecked(input.InputData.Hierarchies.Last()));

            //Click '确定' button.
            //•  The hierarchy tree is hidden.
            //•  NO Total Consumption option and NO Commodities options displayed.
            CorporateRanking.ClickConfirmHiearchyButton();
            //CorporateRanking
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-2")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-2")]
        public void SelectFunctionType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit  (单位能耗指标) module.
            //Click Function Type button.
            UnitIndicator.NavigateToUnitIndicator();
            EnergyViewToolbar.ClickFuncModeConvertTarget();

            //Options 'Energy Consumption','Carbon Emission' and 'Cost' are displayed in dropdown list.
            //Selected option is Highlighted. 'Energy Consumption' is selected by default.   


            //Select one option. Dropdown list is hidden.   Set Function type as selected.
            // Chart is not redrawn when switching the function type option.


            //Select ‘Energy Consumption’ option.•  Display Hierarchy Mode button (SingleHierarchyNode is selected by default).
            //Display Hierarchy Tree Selector.•  Display tag selector which support tags under hierarchy node, system node, and area node.


            //Select ‘Carbon Emission’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node.


            //Select ‘Cost’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which support commodity under hierarchy node, system node, and area node.


            //Navigate to Energy Ratio Indicator (时段能耗比) module.


            //•  No function type dropdown list.•  Display Hierarchy Mode button (SingleHierarchyNode is selected by default).
            //•  Display Hierarchy Tree Selector.
            //•  Display tag selector which support commodity under hierarchy node, system node, and area node.


            //Navigate to Corporate Ranking (集团排名) module.•  Successfully navigate to the module.


            //Click Function Type button.
            //•  Options 'Energy Consumption', 'Carbon Emission' and 'Cost' are displayed in dropdown list.
            //•  Selected option is Highlighted.
            //•  'Energy Consumption' is selected by default.


            //Select ‘Energy Consumption’ option.•  Display Hierarchy Tree Selector.
            //Display Commodity selector which support commodity under hierarchy node, system node, and area node..

            //Select ‘Carbon Emission’ option.
            //•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node.
            //•  Display Carbon Emission Type selector.

            //Select ‘Cost’ option.•  Display Hierarchy Tree Selector.
            //•  Display Commodity selector which only support commodity under hierarchy node and system node (without area node).
        
        
        
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-3")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-3")]
        public void SelectCarbonEmissionType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit Indicator(单位能耗指标) module.•  Successfully navigate to the module.
            

            //Select ‘Carbon Emission’ option from 'Function Type'.


            //Click Carbon Consumption Type dropdown list.
            //•  Display options as 'Standard Coal Consumption', 'CO2 Emission' and 'Tree Consumption' in dropdown list.
            //•  'Standard Coal Consumption' option is selected by default.
            //•  Current selected option should be highlighted.


            //Select one option.•  Set consumption type as selected option.


            //Navigate to Corporate Ranking (集团排名) module.•  Successfully navigate to the module.

            //Repeat steps as above.•  Carbon Consumption Type can be selected correctly.


        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-4")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-4")]
        public void SelectUnitIndicatorType(CorporateRankingData input)
        {
            //Navigate to Energy Consumption Unit Indicator(单位能耗指标) module.•  Successfully navigate to the module.

            //Click Indicator Type dropdown list.

            //•  Display options as Unit Person, Unit Total Area, Unit Cooling Area, and Unit Heating Area in dropdown list.
            //•  ‘Unit Person’ option is selected by default.

            //Select one option.•  Set indicator type as selected option.
            //•  Current selected option should be highlighted.

        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-5")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-5")]
        public void SelectRatioIndicatorType(CorporateRankingData input)
        {
            //Navigate to Energy Ratio Indicator(时段能耗比) module.

            //Click Ratio Type dropdown list.
            //•  Display options as Day/Night Ratio and Workday/NonWorkDay Ratio in dropdown list.
            //•  ‘Day/Night Ratio’ option is selected by default.

            //Select one option.•  Set ratio type as selected option.
            //•  Current selected option should be highlighted.
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-6")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-6")]
        public void SelectRankingType(CorporateRankingData input)
        {
            //Navigate to Corporate Ranking (集团排名) module.

            //Click Ranking Type dropdown list.

            //•  Display options as Total Ranking, Unit Person Ranking, Unit Area Ranking, Unit Cooling Area Ranking and Unit Heating Area Ranking.
            //•  ‘Total Ranking’ option is selected by default.

            //Select one option.Set Ranking type as selected option.Current selected option should be highlighted.
        }

    }
}

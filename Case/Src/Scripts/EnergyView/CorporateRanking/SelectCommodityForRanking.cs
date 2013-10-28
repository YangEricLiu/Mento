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
    [ManualCaseID("TC-J1-FVT-SelectCommodityForRanking-101"), CreateTime("2013-10-21"), Owner("Greenie")]
    public class SelectCommodityForRanking : TestSuiteBase
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
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SelectCommodityForRanking-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectCommodityForRanking-101-1")]
        public void SelectHierarchyNodesForCoperateRanking(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector to select multiple hierarchy nodes, click 确定.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
            CorporateRanking.CheckHierarchyNode(input.ExpectedData.Hierarchies);
            CorporateRanking.ClickConfirmHiearchyButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Take Cost function type for example to verify below steps.
            //Select 'Cost'  from function type dropdown list.
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //•  Display Total Consumption and all available Commodities under all selected hierarchy nodes with Radio Button.
            //•  In default, No any option is selected.          @@@@@@@@@@ 
            Assert.IsTrue(CorporateRanking.AreCommoditiesOnTheGrid(input.InputData.commodityNames));
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));

            //Select Total Consumption option.•  Total Consumption option is checked.Commodity option is unchecked.
            CorporateRanking.SelectCommodity("介质总览");
            Assert.IsTrue(CorporateRanking.IsCommoditySelected("介质总览"));

            //Select Commodity option. This Commodity option is checked. Total Consumption option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[0]);
            Assert.IsFalse(CorporateRanking.IsCommoditySelected("介质总览"));
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[0]));

            //Click System Dimension tab.Click System Dimension Node Selector.
            CorporateRanking.SwitchSystemDimensionTab();
            TimeManager.ShortPause();
            CorporateRanking.ClickSelectSystemDimensionButton();
            //•  Popup a system dimension tree which contains all available system dimension nodes under all selected hierarchy nodes.
            //•  In default, No any system dimension node is selected.@@@@@@@@@@@
            //•  Root node of System Dimension tree cannot be selected.
            Assert.IsTrue(CorporateRanking.IsNodeDisabled(input.InputData.Hierarchies.First()));

            //Select one system dimension node.
            CorporateRanking.SelectSystemDimensionNode(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //•  Hide system dimension tree.Display selected node info in System Dimension Node Selector.
            //•  Display Total Consumption and all available commodities under all selected hierarchy nodes with same dimension node with radio button.
            //•  In default, No any option is selected.@@@@@@@@@@@
            CorporateRanking.AreCommoditiesOnTheGrid(input.ExpectedData.commodityNames);

            //Select Total Consumption option.
            CorporateRanking.SelectCommodity("介质总览");

            //•  Total Consumption option is checked.•  Commodity option is unchecked.
            Assert.IsTrue(CorporateRanking.IsCommoditySelected("介质总览"));
            Assert.IsFalse(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));

            //Select Commodity option.This Commodity option is checked.•  Total Consumption option is unchecked.
            CorporateRanking.SelectCommodity(input.InputData.commodityNames[1]);
            Assert.IsFalse(CorporateRanking.IsCommoditySelected("介质总览"));
            Assert.IsTrue(CorporateRanking.IsCommoditySelected(input.InputData.commodityNames[1]));

            //Repeat above verifications for EnergyConsumption function type.
            //•  Hierarchy tab and System tab are available. (no area)•  No Total Consumption option.@@@@@@@@
            //•  Only have Commodities option.
            Assert.IsFalse(CorporateRanking.IsCommodityExist(input.InputData.commodityNames[2]));

            //Repeat above verifications for Carbon Emission function type.
            //•  Only hierarchy tab is available. (no system and no area)@@@
            //•  Total Consumption option and Commodities option are both available with radio button.

        }

    }
}

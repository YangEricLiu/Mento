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


namespace Mento.Script.EnergyView.UnitIndicator
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SelectIndustryBenchmark-101"), CreateTime("2014-10-15"), Owner("Pearl")]
    public class SelectIndustryBenchmarkSuite : TestSuiteBase
    {
        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;
        private static MenuButton LabellingIndustryConvertButton = JazzButton.LabellingIndustryConvertMenuButton;
        //private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();
        private static MenuButton UnitTypeConvertTargetButton = JazzButton.UnitTypeConvertMenuButton;
        private static MenuButton IndustryConvertTargetButton = JazzButton.IndustryConvertMenuButton;

        [SetUp]
        public void CaseSetUp()
        {
            UnitKPIPanel.NavigateToUnitIndicator();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryBenchmark-101-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-101-1")]
        public void SelectIndustyBenchmark01(UnitIndicatorData input)
        {

            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Labellingtag2 from BuildingLabellingtag2 and Labellingtag3 from BuildingLabellingtag3
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Energy"));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }
        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-2")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-101-2")]
        public void SelectIndustyBenchmark02(UnitIndicatorData input)
        {

            //Select 园区测试多层级", "楼宇XX", tagXX
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Energy"));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-3")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-101-3")]
        public void SelectIndustyBenchmark03(UnitIndicatorData input)
        {

            //Select 园区测试多层级", "楼宇XX", tagXX
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-4")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-101-4")]
        public void SelectIndustyBenchmark04(UnitIndicatorData input)
        {

            //Select 园区测试多层级", "楼宇XX", tagXX
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Carbon);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            UnitKPIPanel.SelectSingleCommodityUnitCarbon(input.InputData.Commodity[0]);
            TimeManager.ShortPause();

            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Carbon"));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-5")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-101-5")]
        public void SelectIndustyBenchmark05(UnitIndicatorData input)
        {

            //Select 园区测试多层级", "楼宇XX", tagXX
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.LongPause();
            TimeManager.ShortPause();

            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Cost"));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-001-1")]
        [MultipleTestDataSource(typeof(UnitIndicatorData[]), typeof(SelectIndustryBenchmarkSuite), "TC-J1-FVT-SelectIndustryBenchmarkSuite-001-1")]
        public void SelectIndustyBenchmark06(UnitIndicatorData input)
        {
            //select Carbon/Cost 总览   
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.LongPause();
            //行业基准值 button is disale
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Unit indicator chart display without benchmark chart
            Assert.IsFalse(UnitKPIPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].BenchmarkValue));
            //select Cost, not select any commodity
            UnitKPIPanel.UnSelectSingleCommodityUnitCost();
            Assert.AreEqual(true, IndustryConvertTargetButton.IsEnabled());
            TimeManager.MediumPause();
            //园区节点
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //总览
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(UnitKPIPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].BenchmarkValue));
            //介质单项
            UnitKPIPanel.SelectSingleCommodityUnitCost(input.InputData.Commodity[0]);
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            TimeManager.MediumPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(UnitKPIPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].BenchmarkValue));
            //区域数据点
            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Cost);
            UnitKPIPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.SelectCommodityUnitCost();
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            TimeManager.LongPause();

            EnergyViewToolbar.SelectFuncModeConvertTarget(FuncModeConvertTarget.Energy);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            UnitKPIPanel.SwitchTagTab(TagTabs.HierarchyTag);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[0]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[1]);
            UnitKPIPanel.CheckTag(input.InputData.tagNames[2]);
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[2]));
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());

            UnitKPIPanel.UncheckTag(input.InputData.tagNames[0]);
            Assert.AreEqual(true, IndustryConvertTargetButton.IsEnabled());
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(UnitKPIPanel.IsLegendItemExists(input.InputData.UnitIndicatorLegend[0].BenchmarkValue));

            UnitKPIPanel.CloseLegendItem(input.InputData.UnitIndicatorLegend[0].BenchmarkValue);
            TimeManager.ShortPause();
            Assert.AreEqual("$@Setting.Benchmark.Label.IndustryBaseLineValue", IndustryConvertTargetButton.GetText());
            UnitKPIPanel.UncheckTag(input.InputData.tagNames[1]);
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Energy"));
            TimeManager.MediumPause();
            UnitKPIPanel.UncheckTag(input.InputData.tagNames[2]);
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetBenchmarkMenulist("Energy"));
            TimeManager.MediumPause();

            UnitKPIPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.AreEqual(true, IndustryConvertTargetButton.IsEnabled());
            TimeManager.LongPause();

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();
            //Select multiple tags Labellingtag2 from BuildingLabellingtag2
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();
            Assert.AreEqual(true, IndustryConvertTargetButton.IsEnabled());

            UnitKPIPanel.ClickMultipleHierarchyAddTagsButton();
            //TimeManager.MediumPause();
            //MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickDeleteXButton(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.tagNames[4]);
            TimeManager.ShortPause();

            //选择系统数据点
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[2].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.tagNames[3]);
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();
            Assert.AreEqual(true, IndustryConvertTargetButton.IsEnabled());
            //Assert.AreEqual(input.ExpectedData.Industries[0], EnergyViewToolbar.GetBenchmarkMenulist("Energy"));

            UnitKPIPanel.ClickMultipleHierarchyAddTagsButton();
            TimeManager.LongPause();
            MultiHieCompareWindow.ClickDeleteXButton(input.InputData.MultiSelectedHiearchyPath[1], input.InputData.tagNames[3]);
            TimeManager.LongPause();
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();
            //Go to Multiple hierarchy node comparation mode. check Labellingtag2 from Buildinglabelling2. Select 1 Labellingtag3 tag from Buildinglabelling3 and 确定.
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();
            EnergyViewToolbar.SelectIndustryConvertTarget(input.InputData.Industries[2]);
            TimeManager.LongPause();
            //Click "删除所有" and 确定
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            TimeManager.LongPause();

            //验证多层级不同介质
            UnitKPIPanel.ClickMultipleHierarchyAddTagsButton();
            TimeManager.LongPause();
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[3].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[3].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();
            Assert.AreEqual(false, IndustryConvertTargetButton.IsEnabled());
            TimeManager.LongPause();

            //切换到Ratio验证ConvertTargetButton status
            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.IndustryValue, IndustryConvertTargetButton.GetText());
            TimeManager.LongPause();
        }
    }
}

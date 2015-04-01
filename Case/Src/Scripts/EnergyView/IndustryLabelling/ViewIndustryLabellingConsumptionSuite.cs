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

namespace Mento.Script.EnergyView.IndustryLabelling
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101"), CreateTime("2014-02-28"), Owner("Emma")]
    public class ViewIndustryLabellingConsumptionSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            IndustryLabellingPanel.LabellingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            IndustryLabellingPanel.LabellingCaseTearDown();
        }

        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingConsumptionSuite), "TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-1")]
        public void ViewConsumptIndustryLabelling01(IndustryLabellingData input)
        {
            //Go to Function Labelling view. Select NancyCustomer1. Go to Unit=单位人口,  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select BuildingBC, select V(1), select a 行业区域=寒冷地区全行业 option to view chart. 
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();         

            //time 2014-12
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Labelling chart display with v(1).
            Assert.AreEqual(input.ExpectedData.UnitTypeValue, EnergyViewToolbar.GetUnitTypeButtonText());

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.ExpectedData.IndustryValue, input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Go to 多层级 select BuildingBC+BuildingBAD and 确定.(待定) 

            //Change select non-building node 园区测试多层.
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            //Select the BuildingBC from Hierarchy Tree.time range="2012 全年", 行业区域=寒冷地区全行业. Select multiple tag V（1）+V(2) +V(3) with the same commodity to display Labelling chart view.
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[2]));
            Assert.AreEqual(input.ExpectedData.IndustryValue, EnergyViewToolbar.GetLabellingIndustryButtonText());

            IndustryLabellingPanel.SetYearAndMonth(input.InputData.YearAndMonth[1].year, input.InputData.YearAndMonth[1].month);
            EnergyViewToolbar.ClickViewButton();
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[1], input.ExpectedData.IndustryValue, input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingConsumptionSuite), "TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-2")]
        public void ViewConsumptIndustryLabelling02(IndustryLabellingData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags V(1) and V(2) from BuildingBC node and Dimension node
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            //Switch to "system dimension" and pick V2_BuildingBC
            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[1]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            //寒冷地区全行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            //time 2014-12
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            string labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            Assert.IsTrue(EnergyViewToolbar.IsMoreMenuItemDisabled(input.ExpectedData.texts[0]));
            Assert.IsTrue(EnergyViewToolbar.IsMoreMenuItemDisabled(input.ExpectedData.texts[1]));

            //Change Unit=单位人口. Click “+数据点” to select multiple tags from hierarchy node BuildingBAD and Dimension node, 
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.MediumPause(); ;

            //time 2014-10
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[2].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[2].month);

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            //Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));

            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[1][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);


            //Click "Save to dashboard"（保存到仪表盘）to save the  chart to dashboard. 
            var dashboard = input.InputData.DashboardInfo;
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.LongPause();

            IndustryLabellingPanel.SetYearAndMonth(input.InputData.YearAndMonth[1].year, input.InputData.YearAndMonth[1].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[1], input.InputData.Industries[1][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[3], labellingInfo1);

            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.MediumPause();

            //· Display blank chart.
            Assert.IsTrue(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());

            /*no value
            //Select 1 tag V(12) from hierarchy node BuildingBAD, Unit=单位供冷面积 to display Labelling chart view.
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[1]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //time 2014-12
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            //夏热冬暖地区全行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);

            //Unit=单位供冷面积
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[1][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[2], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
            
            //Go to widget maximize view. Change time range to 2012 全年.
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetName);
            TimeManager.LongPause();

            Widget.SetYearAndMonth(input.InputData.YearAndMonth[1].year, input.InputData.YearAndMonth[1].month);
            Widget.ClickViewLabellingDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Assert.AreEqual(7, Widget.GetLabellingNumber());
            Widget.CompareMaxWidgetStringData(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3], IndustryLabellingPanel.IndustryLabellingPath);

            Widget.ClickCloseMaxDialogButton();    
            */
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-3")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingConsumptionSuite), "TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-3")]
        public void ViewConsumptIndustryLabelling03(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.LongPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            //Select the BuildingCostYearToDay from Hierarchy Tree.Commodity=V2_YearToDay,  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //夏热冬冷地区轨道交通行业, 
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            //time 2014-12
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());
            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], null);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select a not lighten tag WorkNotworkPNotlighten under BuildingWorkNonwork, 
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //WorkNotworkPNotlighten
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //严寒地区B区地区办公建筑
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);

            //time 2013-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(4, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[1][1], null);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //WorkNotworkP
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(4, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], null, null);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[2], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Go to 多层级. Select a StandardUOMTon from BuildingConvertStandardUOM and BuildingNotConvertStandardUOM from NotStandardUOMkg to view Labelling chart.(2014-01)
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //温和地区超市
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[2]);

            //time 2014-12
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[2][1], null);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[3], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-4")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingConsumptionSuite), "TC-J1-FVT-ConsumptionUnitIndicatorIndustryLabelling-View-101-4")]
        public void ViewConsumptIndustryLabelling04(IndustryLabellingData input)
        {
            //Go to Function Labelling view. Select NancyOtherCustomer3.  
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            //Select BuildingLabelling1, select Labellingtag1, 
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //Go to Unit=单位面积,  select 行业区域=夏热冬暖酒店三星级行业;time range=2012/10 to view chart. 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(6, IndustryLabellingPanel.GetLabellingNumber());
            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            // Select time range=2010/10 to view chart.
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(6, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[1], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Select time range=2012/09 to view chart. 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[2].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[2].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.messages[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.LongPause();

            Assert.IsTrue(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());

            //Select Labellingtag2, select 行业区域=夏热冬暖酒店三星级行业;time range=2013/10 to view chart.
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            // Select time range=2013/10 to view chart.
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[3].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[3].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(6, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[1], input.InputData.YearAndMonth[3], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[2], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //time range=2012/09 to view chart. 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[4].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[4].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.messages[0]));
            JazzMessageBox.MessageBox.OK();
            TimeManager.LongPause();

            Assert.IsTrue(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());

            //Change to NancyCostCustomer2, select 楼宇B-> system dimension=空调 to select BBV1KT(Or area dimension=一层 to select BBV1A1)select a 行业区域=严寒地区B区机场行业 option to view chart. 
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            TimeManager.MediumPause();

            IndustryLabellingPanel.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //BBV1KT
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            //2014-12, 严寒地区B区全行业
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[5].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[5].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[2], input.InputData.YearAndMonth[5], input.InputData.Industries[1][1], null);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[3], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Uncheck BBV1KT to view labelling chart again.
            IndustryLabellingPanel.UncheckTag(input.InputData.tagNames[2]);
            TimeManager.ShortPause();

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());
        }
    }
}

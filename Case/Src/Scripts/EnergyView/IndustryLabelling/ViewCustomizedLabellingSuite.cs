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
    [ManualCaseID("TC-J1-FVT-CustomizedLabelling-View-101"), CreateTime("2014-09-29"), Owner("Nancy")]
    public class ViewCustomizedLabellingSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            //Go to NancyOtherCustomer3. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.LongPause();
            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
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
        [CaseID("TC-J1-FVT-CustomizedLabelling-View-101")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewCustomizedLabellingSuite), "TC-J1-FVT-CustomizedLabellingView-101")]
        public void ViewUnitIndicatorCustomizedLabelling(IndustryLabellingData input)
        {

            //Go to Function Labelling view.  Go to Unit=单位人口,  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select BuildingLabelling1, select Labellingtag2, select a 自定义能效标识 option to view chart. 
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //time 2013-10
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            TimeManager.MediumPause();
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //·Labelling chart display with Labellingtag2.
            Assert.AreEqual(input.ExpectedData.UnitTypeValues[0], EnergyViewToolbar.GetUnitTypeButtonText());
            //Assert.AreEqual(6, IndustryLabellingPanel.GetLabellingNumber());

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.ExpectedData.IndustryValue, input.ExpectedData.UnitTypeValues[0]);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);


            //Select select another LabellingtagWithoutNull to view chart of 自定义能效标识 again. 
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
        
            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[1], input.ExpectedData.IndustryValue, input.ExpectedData.UnitTypeValues[1]);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
          
        }

        [Test]
        [CaseID("TC-J1-FVT-CustomizedLabellingView-102")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewCustomizedLabellingSuite), "TC-J1-FVT-CustomizedLabellingView-102")]
        public void ViewWorkNonworkCustomizedLabelling(IndustryLabellingData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Labellingtag1 and LabellingtagAreadimension from BuildingLabelling1 node and Dimension node
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            //Switch to "system dimension" and pick LabellingtagSystemdimension
            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[2]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(10, IndustryLabellingPanel.GetLabellingNumber());

            string labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);


            //Change Unit=公休比. Click “+数据点” to select multiple tags from hierarchy node BuildingBAD and Dimension node, 
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

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
            Widget.CompareMaxWidgetStringData(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3], IndustryLabellingPanel.IndustryLabellingPath);
            Widget.ClickCloseMaxDialogButton();
        }

        [Test]
        [CaseID("TC-J1-FVT-CustomizedLabellingView-103")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewCustomizedLabellingSuite), "TC-J1-FVT-CustomizedLabellingView-103")]
        public void ViewDayNightCustomizedLabelling(IndustryLabellingData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Labellingtag1 and LabellingtagAreadimension from BuildingLabelling1 node and Dimension node
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            //Switch to "system dimension" and pick LabellingtagSystemdimension
            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[2]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());

            string labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);


            //Change Unit=昼夜比. Click “+数据点” to select multiple tags from hierarchy node BuildingLabelling2, 
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(8, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[1][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
          
        }

        [Test]
        [CaseID("TC-J1-FVT-CustomizedLabellingView-104")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewCustomizedLabellingSuite), "TC-J1-FVT-CustomizedLabellingView-104")]
        public void ViewOriginalValueCustomizedLabelling(IndustryLabellingData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select multiple tags Labellingtag1 and LabellingtagAreadimension from BuildingLabelling1 node and Dimension node
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            //Switch to "system dimension" and pick LabellingtagSystemdimension
            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[2]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.LongPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());

            string labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            //IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);


            //Change Unit=原始值. Click “+数据点” to select multiple tags from hierarchy node BuildingLabelling2, 
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(11, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[0], input.InputData.Industries[1][1], input.ExpectedData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

        }
    }
}
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
    [ManualCaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101"), CreateTime("2014-03-04"), Owner("Emma")]
    public class ViewIndustryLabellingDayNightSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();

            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-1")]
        public void ViewDayNightIndustryLabelling01(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
            
            //Select the BuildingDayNight from Hierarchy Tree
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //select DayNightP, select 昼夜比 option. select a 行业区域=严寒地区B区数据中心 option to view chart. 
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();         

            //time 2013年 全年
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(7, IndustryLabellingPanel.GetLabellingNumber());

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change different time range 年=2012，月=10月 to view chart.
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(8, IndustryLabellingPanel.GetLabellingNumber());

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[1], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Click "Save to dashboard"（保存到仪表盘）to save the  chart to dashboard. 
            var dashboard = input.InputData.DashboardInfo;
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetName, dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, dashboard[0].DashboardName);
            TimeManager.LongPause();

            IndustryLabellingPanel.SetYearAndMonth(input.InputData.YearAndMonth[2].year, input.InputData.YearAndMonth[2].month);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[2], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
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

            Widget.SetYearAndMonth(input.InputData.YearAndMonth[2].year, input.InputData.YearAndMonth[2].month);
            Widget.ClickViewLabellingDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Assert.AreEqual(8, Widget.GetLabellingNumber());
            Widget.CompareMaxWidgetStringData(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3], IndustryLabellingPanel.IndustryLabellingPath);

            Widget.ClickCloseMaxDialogButton(); 
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-2")]
        public void ViewDayNightIndustryLabelling02(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view. 
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select the BuildingMultipleSteps from Hierarchy Tree, select 昼夜比 option
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            
            //Select multiple VH_SiteS1+VD_SiteS1+VM_SiteS1 to view chart.
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[1]);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[2]);
            TimeManager.ShortPause();
            //对比数据点已选满
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsTrue(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //PH_SiteS1 change to disable to check.(PH_SiteS1 enable to check when uncheck V(H)_SiteS1)
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            Assert.IsTrue(MultiHieCompareWindow.IsAllEnabledCheckbox());

            //Uncheck 1 tag and select 1 more the BuildingNoTag from Hierarchy Tree. 
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            //对比数据点已选满
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            Assert.IsTrue(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //Select 公休比 to view data, 2014.1
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-3")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(ViewIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-View-101-3")]
        public void ViewDayNightIndustryLabelling03(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view.  
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

            //select a 行业区域=夏热冬暖酒店三星级行业; Go to 昼夜比 option, time range=2012/10 to view chart.
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(6, IndustryLabellingPanel.GetLabellingNumber());
            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select time range=2010/10 to view chart.
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

            //Select Labellingtag2, select  行业区域=夏热冬暖酒店三星级行业;time range=2012/09 to view chart. 
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

            //2014-1, 严寒地区B区全行业
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[5].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[5].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Assert.AreEqual(5, IndustryLabellingPanel.GetLabellingNumber());
            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[2], input.InputData.YearAndMonth[5], input.InputData.Industries[1][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[3], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

            //Select tag BBV1Root, and “全部区域全行业" Click "查看数据".2014-1
            IndustryLabellingPanel.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            IndustryLabellingPanel.UncheckTag(input.InputData.tagNames[2]);
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[3]);
            TimeManager.MediumPause();

            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[2]);
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[5].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[5].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsFalse(IndustryLabellingPanel.EntirelyNoLabellingChartDrawn());
        }
    }
}

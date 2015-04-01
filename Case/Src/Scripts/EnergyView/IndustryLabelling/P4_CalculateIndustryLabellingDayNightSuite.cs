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
    [ManualCaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101"), CreateTime("2014-03-05"), Owner("Emma")]
    public class P4_CalculateIndustryLabellingDayNightSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(P4_CalculateIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-1")]
        public void CalculateDayNightIndustryLabelling01(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view.  
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
            
            //Go to Labeling. Labellingtag1, select Unit=昼夜比 行业&区域=夏热冬暖酒店三星级行业;time range=2012/10 to view chart.  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select BuildingLabelling1, select Labellingtag1, select a 行业区域=热冬暖酒店三星级行业 option to view chart. 
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();         

            //time 2012-10
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select BuildingLabelling21, select 行业&区域=全行业全区域;time range=2012/10 to view chart. 
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //全部区域全行业（夏热冬暖地区酒店（三星级））
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[2]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2012-10
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[2].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[2].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[1], input.InputData.YearAndMonth[2], input.InputData.Industries[2][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Go to SP1. Go to Function Labelling.
            //Select 多层级. BuildingConvertStandardUOM->StandardUOMTon,and select BuildingNotConvertStandardUOM->NotStandardUOMkg, 行业&区域=温和地区超市行业.;time range=2013/1 to view chart. 
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            TimeManager.ShortPause(); 
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            TimeManager.ShortPause(); 
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //温和地区超市
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2013-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetMultiLabellingInfo(input.InputData.MultipleHierarchyAndtags, input.InputData.YearAndMonth[1], input.InputData.Industries[1][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[2], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);
        }

        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(P4_CalculateIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-2")]
        public void SP2_CalculateDayNightIndustryLabelling02(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view.  
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            //Go to SP2. Select Labellingtag11 select  行业&区域=夏热冬暖酒店三星级行业;time range=2012/10 to view chart. 
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause(); 

            //夏热冬暖酒店三星级行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2012/10 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select SP2-> Rankingtag1 from BuildingRanking1, select 行业&区域=夏热冬暖酒店行业; time range=2013/1 to view chart.  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause(); 

            //严寒地区A区酒店四星级行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2013/01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[1], input.InputData.YearAndMonth[1], input.InputData.Industries[1][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }

        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-3")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(P4_CalculateIndustryLabellingDayNightSuite), "TC-J1-FVT-ConsumptionDayNightRatioIndustryLabelling-Calculate-101-3")]
        public void SP3_CalculateDayNightIndustryLabelling03(IndustryLabellingData input)
        {
            //Go to NancyOtherCustomer3. Go to Function Labelling view.  
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.ShortPause();

            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();

            //Select Labellingtag19/OR Labellingtag20 select  行业&区域=夏热冬暖酒店三星级行业;time range=2012/10 to view chart. 
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause(); 

            //夏热冬暖酒店三星级行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2012/10 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            string labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[0], input.InputData.YearAndMonth[0], input.InputData.Industries[0][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[0], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Select SP3->Rankingtag3 from BuildingRanking3（UOM=KW）, select 行业&区域=夏热冬暖酒店行业;time range=2013/1 to view chart.  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause(); 

            //夏热冬暖酒店五星级行业
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            EnergyViewToolbar.SelectLabellingUnitTypeConvertTarget(input.InputData.UnitTypeValue);

            //time 2012/10 
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[1].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[1].month);

            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            labellingInfo1 = IndustryLabellingPanel.GetSingleLabellingInfo(input.InputData.Hierarchies[1], input.InputData.YearAndMonth[1], input.InputData.Industries[1][1], input.InputData.UnitTypeValue);
            IndustryLabellingPanel.ExportExpectedStringToExcel(input.ExpectedData.expectedFileName[1], labellingInfo1);
            TimeManager.MediumPause();
            IndustryLabellingPanel.CompareStringsOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}

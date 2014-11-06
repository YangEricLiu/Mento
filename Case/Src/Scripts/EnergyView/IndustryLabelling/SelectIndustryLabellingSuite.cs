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
    [ManualCaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101"), CreateTime("2014-09-15"), Owner("Pearl")]
    public class SelectIndustryLabellingSuite : TestSuiteBase
    {
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
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

        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SelectIndustryLabellingSuite), "TC-J1-FVT-SelectIndustryLabellingSuite-101-1")]
        public void SelectIndustyLabelling01(IndustryLabellingData input)
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

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            //打开能效标示menu，选择行业labelling
            //EnergyViewToolbar.OpenIndustryConvertButton();
            //EnergyViewToolbar.FloatIndustyLabellinglist();
            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetIndustryLabellingMenuListItems(input.InputData.Industries[0][0]));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }
        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-101-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SelectIndustryLabellingSuite), "TC-J1-FVT-SelectIndustryLabellingSuite-101-2")]
        public void SelectIndustyLabelling02(IndustryLabellingData input)
        {

            //Select 园区测试多层级", "楼宇XX", tagXX
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            TimeManager.ShortPause();

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            //打开能效标示menu，选择行业labelling
            //EnergyViewToolbar.OpenIndustryConvertButton();
            //EnergyViewToolbar.FloatIndustyLabellinglist();
            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetIndustryLabellingMenuListItems(input.InputData.Industries[0][0]));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }
        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-001-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SelectIndustryLabellingSuite), "TC-J1-FVT-SelectIndustryLabellingSuite-001-1")]
        public void SelectIndustyLabelling03(IndustryLabellingData input)
        {

            //Select "园区测试多层级", 非楼宇节点
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            TimeManager.LongPause();
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());
            TimeManager.LongPause();
            //Select Nancycustomer1,非楼宇节点
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());
            TimeManager.LongPause();

            //'所选数据点不是同一介质，请重新选择'
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));
            TimeManager.LongPause();
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());
            TimeManager.LongPause();
            //系统区域数据点，'所选数据点不是同一介质，请重新选择'
            IndustryLabellingPanel.UncheckTag(input.InputData.tagNames[1]);
            IndustryLabellingPanel.SwitchTagTab(TagTabs.SystemDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            IndustryLabellingPanel.SelectSystemDimension(input.InputData.SystemDimensionPath[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[2]);
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[1]));
            TimeManager.LongPause();
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());
            TimeManager.LongPause();
            //Uncheck Labellingtag12,
            IndustryLabellingPanel.SwitchTagTab(TagTabs.HierarchyTag);
            IndustryLabellingPanel.UncheckTag(input.InputData.tagNames[0]);
            // Assert.AreEqual("寒冷地区酒店", LabellingIndustryConvertButton.GetText());
            Assert.AreEqual(input.ExpectedData.IndustryValues[2], LabellingIndustryConvertButton.GetText());
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetIndustryLabellingMenuListItems(input.InputData.Industries[0][0]));
            TimeManager.LongPause();
            TimeManager.MediumPause();
            //选择BuildingLabelling2，
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[3]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.AreEqual(true, LabellingIndustryConvertButton.IsEnabled());
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[4]);

            //Click "删除所有" and 确定
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.LongPause();
            //Assert.AreEqual("$@Zone_Extreme_Cold_Region_A$@Industry_Hotel_Five_stat", LabellingIndustryConvertButton.GetText());
            TimeManager.LongPause();

            //验证多层级不同介质
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
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
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());
            TimeManager.LongPause();
            //切换到Ratio indicator，验证ConvertTargetButton status状态
            RadioPanel.NavigateToRatio();
            TimeManager.MediumPause();
            Assert.AreEqual(input.ExpectedData.IndustryValues[0], IndustryConvertTargetButton.GetText());
            TimeManager.LongPause();
            //切换到Labelling，验证行业labelling为空，自定义不为空
            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[4]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[3]);
            TimeManager.ShortPause();
            Assert.AreEqual(input.ExpectedData.IndustryValues[1], LabellingIndustryConvertButton.GetText());
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            Assert.AreEqual("SelectIndustryLabelling", LabellingIndustryConvertButton.GetText());
        }
        [Test]
        [CaseID("TC-J1-FVT-SelectIndustryLabellingSuite-001-2")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SelectIndustryLabellingSuite), "TC-J1-FVT-SelectIndustryLabellingSuite-001-2")]
        public void SelectIndustyLabelling04(IndustryLabellingData input)
        {

            //Select "园区测试多层级", 非楼宇节点
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[0]);
            Assert.AreEqual(input.ExpectedData.UnitTypeValues, EnergyViewToolbar.GetUnitTypeMenulist());
        }  
    }
}

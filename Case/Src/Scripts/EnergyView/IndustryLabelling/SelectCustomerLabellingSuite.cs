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
    [ManualCaseID("TC-J1-FVT-SelectCustomerLabellingSuite-101"), CreateTime("2014-09-15"), Owner("Pearl")]
    public class SelectCustomerLabellingSuite : TestSuiteBase
    {
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static Widget Widget = JazzFunction.Widget;
        private static MenuButton LabellingIndustryConvertButton = JazzButton.LabellingIndustryConvertMenuButton;
        //private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();
        private static MenuButton UnitTypeConvertTargetButton = JazzButton.UnitTypeConvertMenuButton;

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

        [Test]
        [CaseID("TC-J1-FVT-SelectCustomerLabellingSuite-101-1")]
        [MultipleTestDataSource(typeof(IndustryLabellingData[]), typeof(SelectCustomerLabellingSuite), "TC-J1-FVT-SelectCustomerLabellingSuite-101-1")]
        public void SelectCustomerLabelling01(IndustryLabellingData input)
        {
            //Go to Function Labelling view. Select NancyCustomer1, select 园区测试多层级,  
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.popupNotes[0]));
            //check Industry labelling button is grey out. 
            Assert.AreEqual(false, LabellingIndustryConvertButton.IsEnabled());

            //Select 园区测试多层级", "楼宇BAD", tag V12_BuildingBC
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            //verify text
            Assert.AreEqual(input.ExpectedData.Industries[0], LabellingIndustryConvertButton.GetText());

            //选择自定义能效标识10
            TimeManager.LongPause();
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[0]);
            TimeManager.LongPause();
            Assert.AreEqual(false, UnitTypeConvertTargetButton.IsEnabled());
            TimeManager.LongPause();
            //
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //选择自定义能效标识8
            TimeManager.LongPause();
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[1]);
            TimeManager.LongPause();
            Assert.AreEqual(false, UnitTypeConvertTargetButton.IsEnabled());
            TimeManager.LongPause();
            //
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Select 园区测试多层级", "楼宇BC"
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[2]);
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //verify text
            //Assert.AreEqual("寒冷地区全行业", LabellingIndustryConvertButton.GetText());
            Assert.AreEqual(input.ExpectedData.Industries[1], LabellingIndustryConvertButton.GetText());

            //Select 园区测试多层级", "楼宇BAD", tag V12_BuildingBC
            TimeManager.LongPause();
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //verify text
            //Assert.AreEqual("夏热冬暖地区全行业", LabellingIndustryConvertButton.GetText());
            Assert.AreEqual(input.ExpectedData.Industries[0], LabellingIndustryConvertButton.GetText());
            TimeManager.LongPause();

            //Select “SOHO，“GalaxySOHO"
            HomePagePanel.SelectCustomer("SOHO");
            TimeManager.LongPause();
            IndustryLabellingPanel.NavigateToIndustryLabelling();
            TimeManager.MediumPause();
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[3]);
            TimeManager.LongPause();
            
            //选择自定义能效标无
            TimeManager.LongPause();
            EnergyViewToolbar.SelectLabellingIndustryConvertTarget(input.InputData.Industries[2]);

            //View button is enable, and KPI button is ready only
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.AreEqual(false, UnitTypeConvertTargetButton.IsEnabled());
        }
    }
}

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
          
            //Select 园区测试多层级", "楼宇BAD", tag V12_BuildingBC
            IndustryLabellingPanel.SelectHierarchy(input.InputData.Hierarchies[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            IndustryLabellingPanel.CheckTag(input.InputData.tagNames[1]);
            TimeManager.ShortPause();

            //time 2014-01
            IndustryLabellingPanel.SetYear(input.InputData.YearAndMonth[0].year);
            IndustryLabellingPanel.SetMonth(input.InputData.YearAndMonth[0].month);

            //打开能效标示menu，选择行业labelling
            TimeManager.LongPause();
            //EnergyViewToolbar.OpenIndustryConvertButton();
            //EnergyViewToolbar.FloatIndustyLabellinglist();
            TimeManager.LongPause();
            //与期望结果对比
            TimeManager.LongPause();
            Assert.AreEqual(input.ExpectedData.Industries, EnergyViewToolbar.GetIndustryLabellingMenuListItems(input.InputData.Industries[0][0]));
            TimeManager.LongPause();
            TimeManager.MediumPause();
        }
    }
}

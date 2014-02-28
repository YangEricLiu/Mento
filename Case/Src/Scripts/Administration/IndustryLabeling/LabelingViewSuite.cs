using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.IndustryLabeling
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2014-2-27")]
    public class LabelingViewSuite : TestSuiteBase
    {
        private static IndustryLabelingSetting IndustryLabelingSetting = JazzFunction.IndustryLabelingSetting;
        [SetUp]
        public void CaseSetUp()
        {
            IndustryLabelingSetting.NavigatorToLabelingSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 ViewMapAndLocation
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-View-101")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-View-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingViewSuite), "TC-J1-FVT-IndustrylabelingSetting-View-101")]
        public void ViewMapAndLocation(IndustryLabelingData input)
        {
            //Click one Labeling from Labeling List.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industrys[0]);
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.ClimaticRegion);

            //Display properties行业，气候分区， 能耗标识级别 and 数据来源 start&end year of selected Labeling in View mode. 
            Assert.AreEqual(input.InputData.Industry,IndustryLabelingSetting.GetSelectedIndustry());
            Assert.AreEqual(input.InputData.ClimaticRegion, IndustryLabelingSetting.GetSelectedClimateRegion());
            Assert.AreEqual(input.InputData.EnergyEfficiencyLabellingLevel, IndustryLabelingSetting.GetSelectedEnergyEfficiencyLabelingLevel());
            Assert.AreEqual(input.InputData.StartYear, IndustryLabelingSetting.GetSelectedStartYear());
            Assert.AreEqual(input.InputData.EndYear, IndustryLabelingSetting.GetSelectedEndYear());

            //Switch from labeling list.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industrys[1]);
            
            //Display properties行业，气候分区， 能耗标识级别 and 数据来源 start&end year of selected Labeling in View mode. 
            Assert.AreEqual(input.InputData.Industrys[1], IndustryLabelingSetting.GetSelectedIndustry());
            Assert.AreEqual(input.InputData.ClimaticRegion, IndustryLabelingSetting.GetSelectedClimateRegion());
            Assert.AreEqual(input.InputData.EnergyEfficiencyLabellingLevel, IndustryLabelingSetting.GetSelectedEnergyEfficiencyLabelingLevel());
            Assert.AreEqual(input.InputData.StartYear, IndustryLabelingSetting.GetSelectedStartYear());
            Assert.AreEqual(input.InputData.EndYear, IndustryLabelingSetting.GetSelectedEndYear());


        }
        #endregion

    }
}

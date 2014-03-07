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
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industrys[0], input.InputData.ClimateRegion);

           //Display properties行业，气候分区， 能耗标识级别 and 数据来源 start&end year of selected Labeling in View mode. 
            Assert.AreEqual(input.ExpectedData.Industrys[0],IndustryLabelingSetting.GetSelectedIndustry());
            Assert.AreEqual(input.ExpectedData.ClimateRegion, IndustryLabelingSetting.GetSelectedClimateRegion());
            Assert.AreEqual(input.ExpectedData.EnergyEfficiencyLabellingLevels[0], IndustryLabelingSetting.GetSelectedEnergyEfficiencyLabelingLevel());
            Assert.AreEqual(input.ExpectedData.StartYears[0], IndustryLabelingSetting.GetSelectedStartYear());
            Assert.AreEqual(input.ExpectedData.EndYears[0], IndustryLabelingSetting.GetSelectedEndYear());

            //Switch from labeling list.
            //IndustryLabelingSetting.FocusOnLabelingIndustry(input.InputData.Industrys[1]);
            
            //Display properties行业，气候分区， 能耗标识级别 and 数据来源 start&end year of selected Labeling in View mode. 
            Assert.AreEqual(input.ExpectedData.Industrys[1], IndustryLabelingSetting.GetSelectedIndustry());
            Assert.AreEqual(input.ExpectedData.ClimateRegion, IndustryLabelingSetting.GetSelectedClimateRegion());
            Assert.AreEqual(input.ExpectedData.EnergyEfficiencyLabellingLevels[1], IndustryLabelingSetting.GetSelectedEnergyEfficiencyLabelingLevel());
            Assert.AreEqual(input.ExpectedData.StartYears[1], IndustryLabelingSetting.GetSelectedStartYear());
            Assert.AreEqual(input.ExpectedData.EndYears[1], IndustryLabelingSetting.GetSelectedEndYear());


        }
        #endregion

    }
}

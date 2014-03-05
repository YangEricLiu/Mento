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
    [CreateTime("20Industry4-2-26")]
    public class LabelingModifyValidSuite : TestSuiteBase
    {
        private static IndustryLabelingSetting IndustryLabelingSetting = JazzFunction.IndustryLabelingSetting;
        [SetUp]
        public void CaseSetUp()
        {
            IndustryLabelingSetting.NavigatorToLabelingSetting();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase ViewMapAndLocation
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-101")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingModifyValidSuite), "TC-J1-FVT-IndustrylabelingSetting-Modify-101")]
        public void ModifyIndustryLabelingValid(IndustryLabelingData input)
        {
            //Click a Labeling(行业=酒店（三星级）; 气候分区=严寒地区A区 ) from list and click 修改 button.
            IndustryLabelingSetting.FocusOnLabelingIndustry(input.InputData.Industry);
            IndustryLabelingSetting.FocusOnLabelingClimateRegion(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            TimeManager.ShortPause();

            //The Labeling combox is gray and can't not be modified.
            Assert.IsFalse(IndustryLabelingSetting.IsIndustryComboxEnabled());
            Assert.IsFalse(IndustryLabelingSetting.IsClimateRegionComboxEnabled());

            //labeling save to labeling list successfully 
            //Display old view status.
            IndustryLabelingSetting.ClickSaveLabeling();
            IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry);
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevel);
            IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYear);
            IndustryLabelingSetting.IsEndYearInDropdownList(input.InputData.EndYear);


            //Click 修改 button
            //Select 气候分区=温和地区；Select a labeling level=5 from dropdown list;Selct 数据来源 2008-2009 from dropdown list.
            IndustryLabelingSetting.ClickModifyLabeling();
            Assert.IsFalse(IndustryLabelingSetting.IsClimateRegionComboxEnabled());
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevels[2]);
            IndustryLabelingSetting.SelectStartYearCombox(input.InputData.StartYear);
            IndustryLabelingSetting.SelectEndYearCombox(input.InputData.EndYear);

            // Click Save button,and the modified labeling save to labeling list successfully.
            IndustryLabelingSetting.ClickSaveLabeling();
            TimeManager.ShortPause();

            //Click the modified labeling from list.
            //Go to view status . 
            IndustryLabelingSetting.FocusOnLabelingIndustry(input.InputData.Industry);
            IndustryLabelingSetting.FocusOnLabelingClimateRegion(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry);
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevel);
            IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYear);
            IndustryLabelingSetting.IsEndYearInDropdownList(input.InputData.EndYear);

            //· The 行业=酒店（三星级） and  气候分区=严寒地区A区  display  and not editable.
            Assert.IsFalse(IndustryLabelingSetting.IsIndustryComboxEnabled());
            Assert.IsFalse(IndustryLabelingSetting.IsClimateRegionComboxEnabled());

            //Click +能效标识 buttons.
            IndustryLabelingSetting.ClickAddLabeling();
            TimeManager.LongPause();

            //· There is 行业=酒店（三星级） can be selected from dropdown list. 
            Assert.IsTrue(IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry));

            //Select 行业=酒店（三星级）, then select 气候分区.
            //There isn't 气候分区=严寒地区A区 can be selected from dropdown list.
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
            Assert.IsFalse(IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion));

        }
        #endregion

    }
}

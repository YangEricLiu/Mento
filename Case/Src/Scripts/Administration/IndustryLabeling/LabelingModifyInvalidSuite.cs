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
    public class LabelingModifyInvalidSuite : TestSuiteBase
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

        #region TestCase1 ModifyIndustryLabelingCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-001")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-001")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingModifyInvalidSuite), "TC-J1-FVT-IndustrylabelingSetting-Modify-001")]
        public void ModifyIndustryLabelingCancelled(IndustryLabelingData input)
        {
            //Click a labeling(气候分区=严寒地区A区 ) from list and click 修改 button.
            IndustryLabelingSetting.FocusOnLabelingClimateRegion(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            TimeManager.LongPause();
            
            //Click Cancel button directly.
            IndustryLabelingSetting.ClickCancelLabeling();

            //·Modify canceled and the labeling display old view status.
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevel);
            IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYear);

            //Click a labeling from list and click 修改 button. 
            // Change 级别 or 数据来源. Click Cancel button.
            IndustryLabelingSetting.FocusOnLabelingClimateRegion(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevel);
            //IndustryLabelingSetting.SelectStartYearCombox(input.InputData.StartYear);
            IndustryLabelingSetting.ClickCancelLabeling();

            //·Modify canceled and the labeling display old view status before modify.
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevel);
            //IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYear);


       }
        #endregion
        #region TestCase1 ModifyIndustryLabelingInvalid
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-002")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Modify-002")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingModifyInvalidSuite), "TC-J1-FVT-IndustrylabelingSetting-Modify-002")]
        public void ModifyIndustryLabelingInvalid(IndustryLabelingData input)
        {
            //Click a Labeling(行业=酒店; 气候分区=严寒地区A区) from list and click 修改 button.
            IndustryLabelingSetting.FocusOnLabelingIndustry(input.InputData.Industry);
            IndustryLabelingSetting.FocusOnLabelingClimateRegion(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            TimeManager.LongPause();

            //·The 行业 & 气候分区 is gray out and can't be modified.
            IndustryLabelingSetting.IsIndustryComboxEnabled();
            IndustryLabelingSetting.IsClimateRegionComboxEnabled();

            // Click Save button.
            IndustryLabelingSetting.ClickSaveLabeling();
            TimeManager.ShortPause();

            //The modified Labeling save to Labeling list successfully
            //The labeling display old view status.
            IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry);
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion);
        }
        #endregion

    }
}

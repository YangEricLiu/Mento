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
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Click a labeling(行业=全行业，气候分区=严寒地区A区 ) from list and click 修改 button.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry,input.InputData.ClimateRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            TimeManager.LongPause();
            
            //Click Cancel button directly.
            IndustryLabelingSetting.ClickCancelLabeling();

            //·Modify canceled and the labeling display old view status.
            IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry);
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimateRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevels[0]);
            IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYears[0]);
            IndustryLabelingSetting.IsEndYearInDropdownList(input.InputData.EndYear);

            //Click a labeling from list and click 修改 button. 
            // Change 级别 or 数据来源. Click Cancel button.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry, input.InputData.ClimateRegion);
            IndustryLabelingSetting.ClickModifyLabeling();
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevels[1]);
            //IndustryLabelingSetting.SelectStartYearCombox(input.InputData.StartYears[1]);
            IndustryLabelingSetting.ClickCancelLabeling();

            //·Modify canceled and the labeling display old view status before modify.
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimateRegion);
            IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevels[0]);
            //IndustryLabelingSetting.IsStartYearInDropdownList(input.InputData.StartYears[0]);


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
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Click a Labeling(行业=全行业; 气候分区=严寒地区B区) from list and click 修改 button.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry, input.InputData.ClimateRegion);
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
            IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimateRegion);
        }
        #endregion

    }
}

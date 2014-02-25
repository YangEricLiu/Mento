﻿using System;
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
    [CreateTime("2014-2-19")]
    public class LabelingAddInvalidSuite : TestSuiteBase
    {
        private static IndustryLabelingSetting IndustryLabelingSetting = JazzFunction.IndustryLabelingSetting;
        [SetUp]
        public void CaseSetUp()
        {
            IndustryLabelingSetting.NavigatorToLabelingSetting();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 AddIndustryLabelingCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryLabelingSetting-Add-001")]
        [CaseID("TC-J1-FVT-IndustryLabelingSetting-Add-001")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingAddInvalidSuite), "TC-J1-FVT-IndustryLabelingSetting-Add-001")]
        public void AddIndustryLabelingCancelled(IndustryLabelingData input)
        {

            //Click +能效标识 buttons.
            IndustryLabelingSetting.ClickAddLabeling();
            TimeManager.LongPause();

            //Click Cancel button before select any 行业 and 区域.
            IndustryLabelingSetting.ClickCancelLabeling();
            TimeManager.LongPause();
    
            //·Cancel and there isn't any labeling added to list.
            int i = 0;
            while (i < input.InputData.Industrys.Length)
            {
                Assert.IsFalse(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.Industrys[i]));
                i++;
            }

            int j = 0;
            while (j < input.InputData.ClimaticRegions.Length)
            {
                Assert.IsFalse(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.ClimaticRegions[j]));
                j++;
            }

            //Click +能效标识 buttons. click Save button directly not input any field. 
            IndustryLabelingSetting.ClickAddLabeling();
            TimeManager.LongPause();
            IndustryLabelingSetting.ClickSaveLabeling();
            TimeManager.LongPause();
                        
            //Red line display at 行业 & 气候分区 &  能效标识级别
            //After note show "必输项",
            Assert.IsTrue(IndustryLabelingSetting.IsIndustrysAddMessageDisplayed());
            Assert.IsTrue(IndustryLabelingSetting.IsClimateRegionAddMessageDisplayed());
            Assert.IsTrue(IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelAddMessageDisplayed());

            // Click Cancel button,Click +能效标识 buttons
            IndustryLabelingSetting.ClickCancelLabeling();
            TimeManager.LongPause();
            IndustryLabelingSetting.ClickAddLabeling();

            //Select 行业=酒店五星级  and check one 气候分区=严寒地区B区. 
            //Click Cancel button.
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryLabelingSetting.SelectClimateRegionCombox(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickCancelLabeling();

            //Then click +能效标识 buttons.
            //·Cancel and there isn't any beachmark added to list.
            //· The dropdown list can still select 行业=酒店五星级  and there isn't any 气候分区 is checked.
            IndustryLabelingSetting.ClickAddLabeling();
            Assert.IsTrue(IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry));
            Assert.IsTrue(IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimaticRegion));
            Assert.IsTrue(IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelInDropdownList(input.InputData.EnergyEfficiencyLabellingLevel));
            IndustryLabelingSetting.ClickCancelLabeling();
            Assert.IsFalse(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.Industry));

        }
        #endregion

        #region TestCase2 AddIndustryLabelingInvalid
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Add-001")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Add-002")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingAddInvalidSuite), "TC-J1-FVT-IndustrylabelingSetting-Add-002")]
        public void AddIndustryLabelingInvalid(IndustryLabelingData input)
        {

            //Click  +能效标识 buttons.
            IndustryLabelingSetting.ClickAddLabeling();
            TimeManager.LongPause();

            //Click Save button before select any 行业 & 气候分区 &  能效标识级别
            IndustryLabelingSetting.ClickSaveLabeling();
            TimeManager.LongPause();
 

            //Red line display at 行业 & 气候分区 &  能效标识级别
            //After note show "必输项"
            Assert.IsTrue(IndustryLabelingSetting.IsIndustrysAddMessageDisplayed());
            Assert.IsTrue(IndustryLabelingSetting.IsClimateRegionAddMessageDisplayed());
            Assert.IsTrue(IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelAddMessageDisplayed());

            //Select 行业=酒店五星级 and Click Save button.
            //Save failed with pop up note at 气候分区 & 能效标识级别，show "请至少选择一项。"
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryLabelingSetting.ClickSaveLabeling();
            Assert.IsTrue(IndustryLabelingSetting.IsClimateRegionAddMessageDisplayed());
            Assert.IsTrue(IndustryLabelingSetting.IsEnergyEfficiencyLabelingLevelAddMessageDisplayed());

            //Select 气候分区=严寒地区B区 , 能耗标识级别=3级.
            //Click Save button.
            IndustryLabelingSetting.SelectClimateRegionCombox(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevel);
            IndustryLabelingSetting.ClickSaveLabeling();

            }
        #endregion

        }
      

      

   
}

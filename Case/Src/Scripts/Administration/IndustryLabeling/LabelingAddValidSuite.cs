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
    [CreateTime("20Industry4-2-25")]
    public class LabelingAddValidSuite : TestSuiteBase
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
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Add-101")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Add-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingAddValidSuite), "TC-J1-FVT-IndustrylabelingSetting-Add-101")]
        public void AddIndustryLabelingValid(IndustryLabelingData input)
        {
     
            //Click +能效标识 buttons.
            IndustryLabelingSetting.ClickAddLabeling();

            //Select 行业=酒店 from dropdown list.
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);

            //Display properties of selected Labeling in add mode. 
            Assert.AreEqual(input.InputData.Industry, IndustryLabelingSetting.GetSelectedIndustry());

            //Select 气候分区=严寒地区A区 from dropdown list.
            IndustryLabelingSetting.SelectClimateRegionCombox(input.InputData.ClimateRegion);

            //Display properties of selected Labeling in add mode. 
            Assert.AreEqual(input.InputData.ClimateRegion, IndustryLabelingSetting.GetSelectedClimateRegion());

            //Select 能效标识级别=3级 from dropdown list.
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevel);

            //Display properties of selected Labeling in add mode. 
            Assert.AreEqual(input.InputData.EnergyEfficiencyLabellingLevel, IndustryLabelingSetting.GetSelectedEnergyEfficiencyLabelingLevel());

            //·Default display recent 3 years. (20Industry2-20Industry4);The Year range from Industry950-2049.
            IndustryLabelingSetting.DisplayStartYearItems();
            IndustryLabelingSetting.DisplayEndYearItems();
            
            //Select  数据来源  from dropdown list.
            //Try to select 数据来源 start>end time from dropdown list.
            //The time auto round up/down to start=end time
            IndustryLabelingSetting.SelectStartYearCombox(input.InputData.StartYears[1]);
            IndustryLabelingSetting.SelectEndYearCombox(input.InputData.EndYears[1]);
            string aaa=IndustryLabelingSetting.GetSelectedStartYear();
            string bbb=IndustryLabelingSetting.GetSelectedEndYear();
            if (Convert.ToInt32(aaa) > Convert.ToInt32(bbb))
            {
                aaa = bbb;
            }
                
            //Click the saved Labeling from list.
            IndustryLabelingSetting.ClickSaveLabeling();
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry, input.InputData.ClimateRegion);

            //Click +能效标识 buttons. Go to 行业 dropdown list to check.
            IndustryLabelingSetting.ClickAddLabeling();
            IndustryLabelingSetting.DisplayIndustryItems();

            //·The saved labeling  行业 will not display in the dropdown list.
            Assert.IsFalse(IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry));

            //Click +能效标识 buttons. 
            //Select 行业=酒店 from dropdown list, Select all 气候分区=全部区域，能耗标识级别=3级，数据来源=2013 -2013
            //.Click Save button.
            int i = 0;
            while (i < input.InputData.ClimateRegions.Length)
            {
                IndustryLabelingSetting.ClickAddLabeling();
                IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
                TimeManager.ShortPause();
                IndustryLabelingSetting.SelectClimateRegionCombox(input.InputData.ClimateRegions[i]);
                TimeManager.ShortPause();
                IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevel);
                TimeManager.ShortPause();
                IndustryLabelingSetting.SelectStartYearCombox(input.InputData.StartYears[0]);
                TimeManager.ShortPause();
                IndustryLabelingSetting.SelectEndYearCombox(input.InputData.EndYears[0]);
                TimeManager.ShortPause();
                IndustryLabelingSetting.ClickSaveLabeling();
                TimeManager.ShortPause();
                i++;
            }

            //The Labeling with all 区域 save to Labeling list successfully.
            Assert.IsFalse(IndustryLabelingSetting.IsClimateRegionInDropdownList(input.InputData.ClimateRegion));

            //· There isn't any 行业 item can be selected from dropdown list.
            //· 行业=全部；区域=全部区域 can be selected and save successfully.@@@@
            IndustryLabelingSetting.ClickAddLabeling();
            Assert.IsFalse(IndustryLabelingSetting.IsIndustryInDropdownList(input.InputData.Industry));
        }
        #endregion

    }
}

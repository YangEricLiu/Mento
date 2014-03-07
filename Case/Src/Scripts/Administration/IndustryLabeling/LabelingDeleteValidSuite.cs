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
    public class LabelingDeleteValidSuite : TestSuiteBase
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

        #region TestCase DeleteIndustryLabelingValid
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustryLabelingSetting-Delete-101")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Delete-101")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingDeleteValidSuite), "TC-J1-FVT-IndustrylabelingSetting-Delete-101")]
        public void DeleteIndustryLabelingValid(IndustryLabelingData input)
        {
            //Click a Labeling(行业=学校; 气候分区=温和地区 ) from list and click 删除 button.
            //·Pop up window show 是否删除.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry, input.InputData.ClimateRegion);
            IndustryLabelingSetting.ClickDeleteLabeling();

            //After click confirmation 确定 button.Delete Labeling successfully.
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Deleted Labeling can't display in Labeling list correctly,display in IndustryLabeling list correctly
            Assert.IsFalse(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.Industry, input.InputData.ClimateRegion));
            //Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListIndustry(input.InputData.Industry));
           // Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListClimateRegion(input.InputData.ClimateRegion));

            //Click +能效标识 buttons.
            IndustryLabelingSetting.ClickAddLabeling();
            TimeManager.LongPause();

            //Select 行业=酒店 and  气候分区=严寒地区A区. Click Save button.
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryLabelingSetting.SelectClimateRegionCombox(input.InputData.ClimateRegion);
            IndustryLabelingSetting.SelectEnergyEfficiencyLabelingLevelCombox(input.InputData.EnergyEfficiencyLabellingLevel);
            IndustryLabelingSetting.ClickSaveLabeling();

            //The Labeling the same as deleted one save to labeling list successfully.
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListIndustry(input.InputData.Industry));
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListClimateRegion(input.InputData.ClimateRegion));
            TimeManager.LongPause();

            //Delete all labeling settings whose industry is 学校.
            int i =IndustryLabelingSetting.LabelingList.GetCurrentRowsNumber();
            while (i >=0)
            {
                if (IndustryLabelingSetting.IsRowExistLabelingListIndustry(input.InputData.Industry))
                {
                    IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry);
                    IndustryLabelingSetting.ClickDeleteLabeling();
                    JazzMessageBox.MessageBox.Confirm();
                    JazzMessageBox.LoadingMask.WaitLoading();
                    TimeManager.ShortPause();
                    i--;
                }
                else    { break; }
            }

            //学校 will become available and can be selected when addition;
            //All zones will become available and can be selected for 学校.
            IndustryLabelingSetting.ClickAddLabeling();
            IndustryLabelingSetting.SelectIndustryCombox(input.InputData.Industry);
            IndustryLabelingSetting.ClimateRegionComboBox.DisplayItems();

        }
        #endregion

    }
}

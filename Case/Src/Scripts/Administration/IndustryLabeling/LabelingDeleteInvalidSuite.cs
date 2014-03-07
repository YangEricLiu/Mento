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
    public class LabelingDeleteInvalidSuite : TestSuiteBase
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

        #region TestCase DeleteIndustryLabelingCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-IndustrylabelingSetting-Delete-001")]
        [CaseID("TC-J1-FVT-IndustrylabelingSetting-Delete-001")]
        [Priority("4")]
        [MultipleTestDataSource(typeof(IndustryLabelingData[]), typeof(LabelingDeleteInvalidSuite), "TC-J1-FVT-IndustrylabelingSetting-Delete-001")]
        public void DeleteIndustryLabelingCancelled(IndustryLabelingData input)
        {
            //Click a Labeling(行业=学校，气候分区=温和地区 ) from list and click 删除 button.
            //·Pop up window show 是否删除.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.Industry,input.InputData.ClimateRegion);
            TimeManager.LongPause();
            IndustryLabelingSetting.ClickDeleteLabeling();

            //After click confirmation Cancel button.
            JazzMessageBox.MessageBox.Cancel();
            TimeManager.LongPause();

            //The Labeling still display in Labeling list.
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListIndustry(input.InputData.Industry));
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListClimateRegion(input.InputData.ClimateRegion));
            TimeManager.LongPause();

            //After click confirmation "X" button.
            IndustryLabelingSetting.ClickDeleteLabeling();
            JazzMessageBox.MessageBox.Close();
            TimeManager.LongPause();

            //The Labeling still display in Labeling list.
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListIndustry(input.InputData.Industry));
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingListClimateRegion(input.InputData.ClimateRegion));
            TimeManager.LongPause();
        }
        #endregion

    }
}

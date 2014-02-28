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
    [CreateTime("2014-2-26")]
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
            //Click a Labeling(气候分区=严寒地区A区 ) from list and click 删除 button.
            //·Pop up window show 是否删除.
            IndustryLabelingSetting.FocusOnLabeling(input.InputData.ClimaticRegion);
            IndustryLabelingSetting.ClickDeleteLabeling();

            //After click confirmation Cancel button.
            JazzMessageBox.MessageBox.Cancel();

            //The Labeling still display in menchmark list.
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.ClimaticRegion));

            //After click confirmation "X" button.
            IndustryLabelingSetting.ClickDeleteLabeling();
            JazzMessageBox.MessageBox.Close();

            //The Labeling still display in menchmark list.
            Assert.IsTrue(IndustryLabelingSetting.IsRowExistLabelingList(input.InputData.ClimaticRegion));
        }
        #endregion

    }
}

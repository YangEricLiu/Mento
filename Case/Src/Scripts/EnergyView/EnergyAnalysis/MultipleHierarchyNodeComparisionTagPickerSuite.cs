using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.TestApi.TestData;
using System.Data;
using Mento.Utility;

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-TagPicker"), CreateTime("2013-08-12"), Owner("Emma")]
    public class MultipleHierarchyNodeComparisionTagPickerSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        //private static 

        [Test]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-TagPicker-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MultipleHierarchyNodeComparisionTagPickerSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-TagPicker-1")]
        public void MultiCheckOneTagAndVerify(EnergyViewOptionData input)
        {
            //Before switch to "多层级数据点", pick one tag on "单层数据点"
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);

            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //"Confirm" button is disabled when no tags checked
            Assert.IsFalse(MultiHieCompareWindow.IsConfirmButtonEnable());

            //"Confirm" button is enabled when there is tag checked
            //Pick V2_BuildingBC, verify if the tag on list
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            Assert.IsTrue(MultiHieCompareWindow.IsConfirmButtonEnable());
            Assert.IsTrue(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.TagNames[0]));

            //Click "放弃" and back to "单层数据点"
            MultiHieCompareWindow.ClickGiveUpButton();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyViewToolbar.GetCurrentTagModeButtonValue().Contains("单层级数据点"));
            Assert.IsTrue(EnergyAnalysis.IsTagChecked(input.InputData.TagNames[0]));

            //Switch to "多层级数据点" and check the same tag again, verify that after confirm the tag is checked on left
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.TagNames[0]));

            //Open "+数据点" again, click "X" of the tag then check it's unchecked on left tag list
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.LongPause();
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.ClickDeleteXButton(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.TagNames[0]);
            Assert.IsFalse(MultiHieCompareWindow.IsTagChecked(input.InputData.TagNames[0]));

            //Click "放弃" and back to "单层数据点"
            MultiHieCompareWindow.ClickGiveUpButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-TagPicker-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MultipleHierarchyNodeComparisionTagPickerSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-TagPicker-2")]
        public void MultiCheckMultipleTagsAndVerify(EnergyViewOptionData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[0]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            Assert.IsTrue(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.TagNames[0]));

        }
    }
}

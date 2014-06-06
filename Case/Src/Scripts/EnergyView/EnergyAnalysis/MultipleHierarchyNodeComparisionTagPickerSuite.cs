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
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

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
            Assert.IsTrue(EnergyViewToolbar.GetCurrentTagModeButtonValue().Contains(input.InputData.HierarchyTexts[0]));
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
            //Switch to "多层级数据点" and pick up 10 tags then verify its on the correct position
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[0]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);

            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            MultiHieCompareWindow.SelectAreaDimension(input.InputData.MultipleHiearchyPath[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[1]);

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[2]);

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[3]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[3]);

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[4]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[4]);

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[5]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[5]);

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[6]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[6]);

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[7]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[7]);

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[8]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[8]);

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[9]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[9]);

            for (int i = 0; i < 10; i++)
            {
               Assert.IsTrue(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[i], input.InputData.TagNames[i]));
            }

            //Confirm and draw line chart
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.MediumPause();
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2012, 4, 7));
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            //Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //back to "多层级数据点", the hierarchy button is display "请选择层级结构"
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();
            Assert.IsTrue(MultiHieCompareWindow.GetHierarchyButtonValue().Contains(input.InputData.HierarchyTexts[0]));

            //The tags are still on the right part list
            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[i], input.InputData.TagNames[i]));
            }

            //Uncheck one tag, the tag will not display from right part
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[0]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.TagNames[0]);
            Assert.IsFalse(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[0], input.InputData.TagNames[0]));
            

            //uncheck one tag on area/system dimension and the tag will not display from right part
            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            MultiHieCompareWindow.SelectAreaDimension(input.InputData.MultipleHiearchyPath[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.TagNames[1]);
            Assert.IsFalse(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[1], input.InputData.TagNames[1]));

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.MultipleHiearchyPath[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.TagNames[2]);
            Assert.IsFalse(MultiHieCompareWindow.IsTagExistedOnSpecialContainer(input.InputData.MultiSelectedHiearchyPath[2], input.InputData.TagNames[2]));

            MultiHieCompareWindow.ClickGiveUpButton();
            TimeManager.MediumPause();

            //Switch to "单层级数据点" and cancel/confirm
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.SingleHierarchyTag);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.QuitMultipleMessage));
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyViewToolbar.GetCurrentTagModeButtonValue().Contains(input.InputData.HierarchyTexts[1]));

            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.SingleHierarchyTag);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.QuitMultipleMessage));
            JazzMessageBox.MessageBox.Quit();
            TimeManager.MediumPause();

            //"单层级数据点" display and  "+数据点" not displayed
            Assert.IsTrue(EnergyViewToolbar.GetCurrentTagModeButtonValue().Contains(input.InputData.HierarchyTexts[2]));
            Assert.IsFalse(EnergyAnalysis.IsMultipleHierarchyAddTagsButtonDisplayed());

            //Pick up one tag from "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHiearchyPath[0]);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.MediumPause();
            EnergyViewToolbar.SetDateRange(new DateTime(2012, 4, 1), new DateTime(2013, 4, 7));
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            //Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Delete all from "more" then cancel
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.GiveUp();
            TimeManager.MediumPause();
            //Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

            //Delete all from "more" then confirm
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.MediumPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.MediumPause();
            //Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());
            Assert.IsTrue(EnergyViewToolbar.GetCurrentTagModeButtonValue().Contains(input.InputData.HierarchyTexts[1]));
            Assert.IsTrue(EnergyAnalysis.IsMultipleHierarchyAddTagsButtonDisplayed());
            Assert.IsTrue(EnergyAnalysis.IsEmptyMultiHierarchyTagsPanel());
        }
    }
}

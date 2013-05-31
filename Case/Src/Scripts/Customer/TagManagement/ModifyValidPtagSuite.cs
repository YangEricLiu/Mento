using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-05-30")]
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Modify-101")]
    public class ModifyValidPtagSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {   
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-101-1")]
        public void ModifyWithoutChange(PtagData input)
        {
            //Click "Modify" button and input nothing to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag keep the same successfully
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            Assert.AreEqual(input.ExpectedData.CommonName, PTagSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(input.ExpectedData.Meter, PTagSettings.GetMetercodeValue());
            Assert.AreEqual(input.ExpectedData.Channel, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.ExpectedData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.ExpectedData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(input.ExpectedData.CalculationType), PTagSettings.GetCalculationTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, PTagSettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-101-2")]
        public void ModifyAndEmptyItemNotDisplay(PtagData input)
        {
            //Click "Modify" button and input value to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);

            //Verify comments not hidden
            Assert.IsFalse(PTagSettings.IsCommentHidden());

            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag keep the same successfully
            PTagSettings.FocusOnPTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, PTagSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(input.ExpectedData.Meter, PTagSettings.GetMetercodeValue());
            Assert.AreEqual(input.ExpectedData.Channel, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.ExpectedData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.ExpectedData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(input.ExpectedData.CalculationType), PTagSettings.GetCalculationTypeValue());
            //Verify comments is hidden
            Assert.IsTrue(PTagSettings.IsCommentHidden());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-101-3")]
        public void ModifyCodeAndCheckOnFormula(PtagData input)
        {
            string vtagName = "VtagForCheckPtagAll";
            string updatedFormula = "{ptag|PtagForCodeUpdate_M}+1";

            //Click "Modify" button and input new code to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());
            PTagSettings.FocusOnPTagByCode(input.ExpectedData.Code);

            //Verify that ptag code is updated on vtag formula
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            Assert.AreEqual(updatedFormula, JazzFunction.VTagSettings.GetFormulaValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-101-4")]
        public void ModifyAndVerify(PtagData input)
        {
            string vtagName = "VtagForCheckPtagAll";

            //Click "Modify" button and input new value to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());
            PTagSettings.FocusOnPTagByName(input.ExpectedData.CommonName);

            //1. Verify that ptag is updated on vtag formula tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.ExpectedData.CommonName));

            //2. Verify that ptag is updated on associated tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName);

            //3. Verify that ptag is updated on energy view tag list and  its legend name
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName);
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.ExpectedData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("PtagForModifyCheckAl...");
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(ModifyValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Modify-101-5")]
        public void ModifyUomCommoditAndVerify(PtagData input)
        {
            //Click "Modify" button and input new value for uom&commodity to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());
            PTagSettings.FocusOnPTagByName(input.ExpectedData.CommonName);

            //3. Verify that ptag Commodity is updated on energy view tag list and  UOm updated on its chart view y-axis
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            //Commodity updated
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.ExpectedData.CommonName);
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.ExpectedData.Commodity), JazzFunction.EnergyAnalysisPanel.GetSelectedRowData(3));

            //Uom updated
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.ExpectedData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.ExpectedData.Uom), JazzFunction.EnergyAnalysisPanel.GetUomValue());
        }
    }
}

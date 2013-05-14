using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.SmokeTest;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-KPItagConfiguration-004")]
    [CreateTime("2013-01-16")]
    [Owner("Alice")]
    public class ModifyKPITagSuite : TestSuiteBase
    {
        private KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {

            KPITagSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-004")]
        [Priority("1")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(ModifyKPITagSuite), "TC-J1-FVT-KPItagConfiguration-004-ModifytoValid")]
        public void ModifyKPItagtoValid(KPIData input)
        {
            KPITagSettings.FocusOnKPITagCode("KPI4");
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickModifyKPITagButton();
            TimeManager.LongPause();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }
        public void ModifyKPItagtoValidResultView(KPIData testdata)
        {

            KPITagSettings.FocusOnKPITagCode(testdata.InputData.Code);
            Assert.AreEqual(testdata.InputData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.InputData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(testdata.InputData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.InputData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.InputData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, KPITagSettings.GetKPITagCommentValue());
        }

        
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-003")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(ModifyKPITagSuite), "TC-J1-FVT-KPItagConfiguration-004-ModifytoInvalid-001")]

        public void ModifyKPItagtoInvalid002(KPIData input)
        {
            KPITagSettings.FocusOnKPITagCode("KPI");
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickModifyKPITagButton();
            TimeManager.LongPause();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void ModifyKPItagtoInvalidResultView002(KPIData testdata)
        {
            Assert.AreEqual(testdata.ExpectedData.Name, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.Code, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.Uom, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.ExpectedData.Steps), KPITagSettings.GetStepErrorMessageValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.ExpectedData.CalculationType), KPITagSettings.GetTypeErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.Comment, KPITagSettings.GetCommentErrorMessageValue());
            Assert.IsFalse(KPITagSettings.KPITagIsExist(testdata.InputData.Code));
        }

        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-004")]
        [Priority("1")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(ModifyKPITagSuite), "TC-J1-FVT-KPItagConfiguration-004-ModifytoInvalid-002")]
        public void ModifyKPItagtoInvalid001(KPIData input)
        {
            KPITagSettings.FocusOnKPITagCode("KPI");
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickModifyKPITagButton();
            TimeManager.LongPause();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickCancelButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }
        public void ModifyKPItagtoInvalidResultView001(KPIData testdata)
        {
            Assert.IsTrue(KPITagSettings.KPITagIsExist("KPI"));

            KPITagSettings.FocusOnKPITagCode("KPI");
            Assert.AreEqual(testdata.ExpectedData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.ExpectedData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(testdata.ExpectedData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.ExpectedData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.ExpectedData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.ExpectedData.Comment, KPITagSettings.GetKPITagCommentValue());

        }
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-004")]
        [Priority("1")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(ModifyKPITagSuite), "TC-J1-FVT-KPItagConfiguration-004-ModifybutCancel")]
        public void ModifyKPItagtoValidbutCancel(KPIData input)
        {
            KPITagSettings.FocusOnKPITagCode("KPI");
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            KPITagSettings.ClickModifyKPITagButton();
            TimeManager.LongPause();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickCancelButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();

        }
        public void ModifyKPItagtoValidbutCancelResultView(KPIData testdata)
        {
            Assert.IsTrue(KPITagSettings.KPITagIsExist("KPI"));
            KPITagSettings.FocusOnKPITagCode("KPI");
            Assert.AreEqual(testdata.ExpectedData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.ExpectedData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(testdata.ExpectedData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.ExpectedData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.ExpectedData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.ExpectedData.Comment, KPITagSettings.GetKPITagCommentValue());
        }
    }
}
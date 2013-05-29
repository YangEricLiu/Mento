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
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-KPItagConfiguration-003")]
    [CreateTime("2013-02-04")]
    [Owner("Alice")]
    public class AddKPITagSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-KPItagConfiguration-003")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AddKPIData[]), typeof(AddKPITagSuite), "TC-J1-FVT-KPItagConfiguration-003-AddValid")]
        public void AddValidKPItag(AddKPIData input)
        {
            KPITagSettings.ClickAddKPITagButton();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }


        public void AddKPItagResultView(AddKPIData testdata)
        {

            KPITagSettings.FocusOnKPITagcode(testdata.InputData.code);
            Assert.AreEqual(testdata.InputData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.InputData.code, KPITagSettings.GetKPITagcodeValue());
            Assert.AreEqual(testdata.InputData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.InputData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.InputData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, KPITagSettings.GetKPITagCommentValue());
          
        }
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-003")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AddKPIData[]), typeof(AddKPITagSuite), "TC-J1-FVT-KPItagConfiguration-003-AddInvalid")]

        public void AddInvalidKPItag(AddKPIData input)
        {
            KPITagSettings.ClickAddKPITagButton();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);


            JazzMessageBox.LoadingMask.WaitLoading();

            TimeManager.MediumPause();
        }

        public void AddInvalidKPItagResultView(AddKPIData testdata)
        {
            Assert.IsFalse(KPITagSettings.KPITagIsExist(testdata.InputData.code));
            Assert.AreEqual(testdata.ExpectedData.Name, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.code, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.Uom, KPITagSettings.GetNameErrorMessageValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.ExpectedData.Steps), KPITagSettings.GetStepErrorMessageValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.ExpectedData.CalculationType), KPITagSettings.GetTypeErrorMessageValue());
            Assert.AreEqual(testdata.ExpectedData.Comment, KPITagSettings.GetCommentErrorMessageValue());
            Assert.IsFalse(KPITagSettings.KPITagIsExist(testdata.InputData.code));
        }
   
        [Test]
        [CaseID("TC-J1-FVT-KPItagConfiguration-003")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(AddKPIData[]), typeof(AddKPITagSuite), "TC-J1-FVT-KPItagConfiguration-003-AddValidbutCancel")]
        public void AddValidbutCancel(AddKPIData input)
        {
            KPITagSettings.ClickAddKPITagButton();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickCancelButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
            Assert.IsFalse(KPITagSettings.KPITagIsExist("AliceKPI"));
        }
      
    }
}
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
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-07-09")]
    [ManualCaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101")]
    public class ModifyValidFormula : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.NavigatorToVTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }
        /// <summary>
        /// Prepare Data:  1. make sure the vtags have been added "PtagForCheckVtagFormula"
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-0")]
        [Type("BFT")]
        public void NotSupportFormula(VtagData input)
        {
            // Navigate to the ptag configuration page
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            // Select a  ptag
            JazzFunction.PTagSettings.FocusOnPTagByName("PtagForCheckVtagFormula");
            TimeManager.MediumPause();
            Assert.IsFalse(VTagSettings.IsSwitchToFormulaTabExist());
        }

      
        [Test]
        [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-1")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(VtagData[]))]
        public void AddValidFormula(VtagData input)
        {
            //Click "+" button and fill vtag field with invalid input
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);
            TimeManager.MediumPause();
            //Click "Save" button
            VTagSettings.ClickSaveButton();
            TimeManager.LongPause();

            //verify add successful
            Assert.IsTrue(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(VTagSettings.IsCancelButtonDisplayed());
            //problem here
            //Verify that the error message popup and the input field is invalid
            Assert.IsTrue(VTagSettings.IsNameInvalid());
            Assert.IsTrue(VTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(VTagSettings.IscodeInvalid());
            Assert.IsTrue(VTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
            //Assert.IsTrue(VTagSettings.IsCommodityInvalid());
            //Assert.IsTrue(VTagSettings.IsCommodityInvalidMsgCorrect(input.ExpectedData));
           // Assert.IsTrue(VTagSettings.IsCalculationTypeInvalid());
            //Assert.IsTrue(VTagSettings.IsCalculationTypeInvalidMsgCorrect(input.ExpectedData));
            //Assert.IsTrue(VTagSettings.IsUomInvalid());
            //Assert.IsTrue(VTagSettings.IsUomInvalidMsgCorrect(input.ExpectedData));
            //Assert.IsTrue(VTagSettings.IsStepInvalid());
            //Assert.IsTrue(VTagSettings.IsStepInvalidMsgCorrect(input.ExpectedData));
            Assert.IsTrue(VTagSettings.IsCommentsInvalid());
            Assert.IsTrue(VTagSettings.IsCommentsInvalidMsgCorrect(input.ExpectedData));
        }
       
      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-2")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-2")]
      public void AllFieldsEmpty(VtagData input)
      {
          //Click "+" button and fill nothing
          VTagSettings.ClickAddVTagButton();

          //Click "Save" button
          VTagSettings.ClickSaveButton();
          TimeManager.MediumPause();

          //verify add successful
          Assert.IsTrue(VTagSettings.IsSaveButtonDisplayed());
          Assert.IsTrue(VTagSettings.IsCancelButtonDisplayed());

          //Verify that the error message popup and the input field is invalid
          
          Assert.IsTrue(VTagSettings.IsNameInvalid());
          Assert.IsTrue(VTagSettings.IsNameInvalidMsgCorrect(input.ExpectedData));
          Assert.IsTrue(VTagSettings.IscodeInvalid());
          Assert.IsTrue(VTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
          Assert.IsTrue(VTagSettings.IsCommodityInvalid());
          Assert.IsTrue(VTagSettings.IsCommodityInvalidMsgCorrect(input.ExpectedData));
          Assert.IsTrue(VTagSettings.IsUomInvalid());
          Assert.IsTrue(VTagSettings.IsUomInvalidMsgCorrect(input.ExpectedData));
          Assert.IsTrue(VTagSettings.IsCalculationTypeInvalid());
          Assert.IsTrue(VTagSettings.IsCalculationTypeInvalidMsgCorrect(input.ExpectedData));
          Assert.IsFalse(VTagSettings.IsCommentsInvalid());
           
      }

      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-3")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-3")]
      public void ModifyTagCode(VtagData input)
      {
          //Click "+" button and fill Vtag field with same code
          VTagSettings.ClickAddVTagButton();
          VTagSettings.FillInAddVTagData(input.InputData);
          TimeManager.ShortPause();
          //Click "Save" button
          VTagSettings.ClickSaveButton();
          TimeManager.MediumPause();
          //Verify that the error message popup and the input field is invalid
          Assert.IsTrue(VTagSettings.IscodeInvalid());
          Assert.IsTrue(VTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
          //verify add successful
          Assert.IsTrue(VTagSettings.IsSaveButtonDisplayed());
          Assert.IsTrue(VTagSettings.IsCancelButtonDisplayed());


      }

      [Test]
      [CaseID("TC-J1-FVT-VtagFormulaConfiguration-Modify-101-4")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagFormulaConfiguration-Modify-101-4")]
      public void FormulaCaseInsensive(VtagData input)
      {

          //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
          JazzFunction.VTagSettings.FocusOnVTagByCode(input.InputData.Code);
          TimeManager.MediumPause();
          JazzFunction.VTagSettings.SwitchToFormulaTab();
          TimeManager.LongPause();
          JazzFunction.VTagSettings.ClickModifyFormulaButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();

          //  Clear formula content
          JazzFunction.VTagSettings.FillInFormulaField("  ");
          TimeManager.ShortPause();
          JazzFunction.VTagSettings.ClickSaveFormulaButton();
          TimeManager.ShortPause();
          Assert.IsTrue(VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData));

          
      }
       
       
    }
}

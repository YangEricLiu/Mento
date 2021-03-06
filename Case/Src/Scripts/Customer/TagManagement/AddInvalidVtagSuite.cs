﻿using System;
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
    [CreateTime("2013-06-06")]
    [ManualCaseID("TC-J1-FVT-VtagConfiguration-Add-001")]
    public class AddInvalidVtagSuite : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.VTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            VTagSettings.VTagSettingCaseTearDown();
        }

        /// <summary>
        /// Prepare Data:  1. make sure the vtags have been added "VtagForInvalidSameCode","VtagForInvalidFormula" had formula "PtagByFormula";
        /// </summary> 
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-001-1")]
        public void AddVtagAndCancel(VtagData input)
        {
            //Click "+" button and fill vtag field with valid input
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click cancel button 
            VTagSettings.ClickCancelButton();


            //verify add unsuccessful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //verify vtag not add successful
            Assert.IsFalse(VTagSettings.FocusOnVTagByName(input.InputData.CommonName));
        }
    
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-001-2")]
        [Type("BFT")]
        [IllegalInputValidation(typeof(VtagData[]))]
        public void AddInvalidVtag(VtagData input)
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
            Assert.IsFalse(VTagSettings.IsCommentsInvalid());
        }
       
      [Test]
      [Category("P4_Emma")]
      [CaseID("TC-J1-FVT-VtagConfiguration-Add-001-3")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-001-3")]
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
      [Category("P4_Emma")]
      [CaseID("TC-J1-FVT-VtagConfiguration-Add-001-4")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-001-4")]
      public void AddSameCode(VtagData input)
      {
          //Click "+" button and fill Vtag field with same code
          VTagSettings.ClickAddVTagButton();
          VTagSettings.FillInAddVTagData(input.InputData);
          TimeManager.ShortPause();
          //Click "Save" button
          VTagSettings.ClickSaveButton();
          TimeManager.MediumPause();
          //Verify that the error message popup and the input field is invalid
          //Assert.IsTrue(VTagSettings.IscodeInvalid());
          Assert.IsTrue(VTagSettings.IscodeInvalidMsgCorrect(input.ExpectedData));
          //verify add successful
          Assert.IsTrue(VTagSettings.IsSaveButtonDisplayed());
          Assert.IsTrue(VTagSettings.IsCancelButtonDisplayed());


      }

      [Test]
      [Category("P4_Emma")]
      [CaseID("TC-J1-FVT-VtagConfiguration-Add-001-5")]
      [Type("BFT")]
      [MultipleTestDataSource(typeof(VtagData[]), typeof(AddInvalidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-001-5")]
      public void ModifyVtagFormulaToBlank(VtagData input)
      {

          //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
          JazzFunction.VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
          TimeManager.MediumPause();
          JazzFunction.VTagSettings.SwitchToFormulaTab();
          TimeManager.LongPause();
          JazzFunction.VTagSettings.ClickModifyFormulaButton();
          JazzMessageBox.LoadingMask.WaitSubMaskLoading();
          TimeManager.MediumPause();

          //  Clear formula content
          JazzFunction.VTagSettings.FillInFormulaField("");
          TimeManager.ShortPause();
          JazzFunction.VTagSettings.ClickSaveFormulaButton();
          TimeManager.ShortPause();
          Assert.IsTrue(VTagSettings.IsFormulaInvalidMsgCorrect(input.ExpectedData.FormulaMessage));

      }    
    }
}

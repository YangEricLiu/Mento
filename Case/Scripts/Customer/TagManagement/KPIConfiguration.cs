﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    //[ManualCaseID("TA-KPIConfigue")]
    [CreateTime("2013-01-04")]
    [Owner("Alice")]
    public class KPIConfiguration : TestSuiteBase
    {
        private KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            //ElementLocator.OpenJazz();
            //FunctionWrapper.Login.Login();

            //NavigatorIns.NavigateToTarget(NavigationTarget.TagSettingsKPI);

        }
        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.CloseJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            //FunctionWrapper.KPItag.NavigatorToKPItagSetting();
            //ElementLocator.Pause(2000);   
            KPITagSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-KPIConfigue-001"), CreateTime("2013-01-04"), Owner("Alice"), ManualCaseID("TA-KPItag-T001")]
        [MultipleTestDataSource(typeof(AddKPIData[]), typeof(KPIConfiguration), "TA-KPIConfigue-001")]
        public void AddKPItag(AddKPIData input)
        {
            KPITagSettings.ClickAddKPITagButton();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }


        public void AddKPItagResultView(AddKPIData testdata)
        {

            string AddedKPItagName = "AliceKPItag";
            KPITagSettings.FocusOnKPITag(AddedKPItagName);
            Assert.AreEqual(testdata.InputData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.InputData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(testdata.InputData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.InputData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.InputData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, KPITagSettings.GetKPITagCommentValue());
        }

    }
}
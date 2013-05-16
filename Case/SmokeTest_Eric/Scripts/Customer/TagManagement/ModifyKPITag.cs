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
    [ManualCaseID("TC-J1-SmokeTest-004")]
    [CreateTime("2013-01-16")]
    [Owner("Alice")]
    public class ModifyKPITag : TestSuiteBase
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
        [CaseID("TA-ModifyKPITag-001")]
        [Priority("1")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(ModifyKPITag), "TA-ModifyKPITag-001")]
        public void ModifyKPItag(KPIData input)
        {
            KPITagSettings.FocusOnKPITag("KPI4");
            TimeManager.LongPause();
            KPITagSettings.ClickModifyKPITagButton();
            TimeManager.LongPause();
            KPITagSettings.FillInAddKPItagData(input.InputData);
            KPITagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }
        public void ModifyKPItagResultView(KPIData testdata)
        {
            KPITagSettings.FocusOnKPITag(testdata.InputData.Name);
            Assert.AreEqual(testdata.InputData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.InputData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(testdata.InputData.Uom, KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.InputData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.InputData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, KPITagSettings.GetKPITagCommentValue());
        }

    }
}
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

namespace Mento.Script.TestScript.TagManagement
{
    [TestFixture]
    [ManualCaseID("TA-Smoke-Tag-003")]
    [CreateTime("2013-05-13")]
    [Owner("Eric")]
    public class AddKPITagSuite : TestSuiteBase
    {
        
        private KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "Auto_Customer");


            KPITagSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TA-Smoke-Tag-003-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPIData[]), typeof(AddKPITagSuite), "TA-Smoke-Tag-003-001")]
        public void AddValidKPItag(KPIData testdata)
        {
            KPITagSettings.ClickAddKPITagButton();
            KPITagSettings.FillInAddKPItagData(testdata.InputData);
            KPITagSettings.ClickSaveButton();
            
            JazzMessageBox.LoadingMask.WaitLoading();

            KPITagSettings.FocusOnKPITagCode(testdata.InputData.Code);
            Assert.AreEqual(testdata.InputData.Name, KPITagSettings.GetKPITagNameValue());
            Assert.AreEqual(testdata.InputData.Code, KPITagSettings.GetKPITagCodeValue());
            Assert.AreEqual(KPITagSettings.GetKPITagUOMExpectedValue(testdata.InputData.Uom), KPITagSettings.GetKPITagUOMValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationStepExpectedValue(testdata.InputData.Steps), KPITagSettings.GetKPITagCalculationStepValue());
            Assert.AreEqual(KPITagSettings.GetKPITagCalculationTypeExpectedValue(testdata.InputData.CalculationType), KPITagSettings.GetKPITagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, KPITagSettings.GetKPITagCommentValue());
        }

        [Test]
        [CaseID("TA-Smoke-Tag-003-002")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPITagSuite), "TA-Smoke-Tag-003-002")]
        public void AddValidFormulaToDayNightKPItag(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(testdata.InputData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());

        }
    }
}
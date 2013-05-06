using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Alice")]
    [CreateTime("2013-02-05")]
    [ManualCaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
    public class AddKPIFormulaSuite : TestSuiteBase
    {
        private static KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            KPITagSettings.NavigatorToKPITagSetting();
            //ElementLocator.Pause(2000);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForDayNightKPI-Valid")]
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
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForNonDayNightKPI-Valid")]
        public void AddValidFormulaToNonDayNightKPItag(KPITagFormulaData testdata)
        {
            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(testdata.InputData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsFalse(KPITagSettings.DayNightIsChecked());
        }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForDayNightKPI-Invalid-redline")]
        public void AddInvalidFormulaToDayNightKPItagRedline(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            string msgText = KPITagSettings.GetFormulaErrorMessageValue();
            TimeManager.LongPause();
            Assert.IsTrue(msgText.Contains(testdata.ExpectedData.Formula));
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());
         }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForDayNightKPI-Invalid-messagebox")]
        public void AddInvalidFormulaToDayNightKPItagMessagebox(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            string msgText = KPITagSettings.GetMessageText();
            TimeManager.LongPause();
            Assert.IsTrue(msgText.Contains("无法保存"));
            KPITagSettings.ConfirmMagBox();
            KPITagSettings.ClickCancelFormula();
            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(testdata.ExpectedData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());

        }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForNonDayNightKPI-Invalid-redline")]
        public void AddInvalidFormulaToNonDayNightKPItag(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            string msgText = KPITagSettings.GetFormulaErrorMessageValue();
            TimeManager.LongPause();
            Assert.IsTrue(msgText.Contains(testdata.ExpectedData.Formula));
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());
         }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForNonDayNightKPI-Invalid-messagebox")]
        public void AddInvalidFormulaToNonDayNightKPItagMessagebox(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickSaveFormulaButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            string msgText = KPITagSettings.GetMessageText();
            TimeManager.LongPause();
            Assert.IsTrue(msgText.Contains("无法保存"));
            KPITagSettings.ConfirmMagBox();
            KPITagSettings.ClickCancelFormula();
            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(testdata.ExpectedData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsFalse(KPITagSettings.DayNightIsChecked());

        }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForDayNightKPIbutCancel-Invalid")]
        public void AddFormulaToDayNightKPItagbutCancel(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickCancelFormula();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            KPITagSettings.FocusOnKPITag(testdata.InputData.Name);
            Assert.AreEqual(testdata.ExpectedData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());

        }
        [Test]
        [CaseID("TC-J1-FVT-KPIFormulaConfiguration-001")]
        [Priority("20")]
        [Type("FVT")]
        [MultipleTestDataSource(typeof(KPITagFormulaData[]), typeof(AddKPIFormulaSuite), "AddFormulaForNonDayNightKPIbutCancel-Invalid")]
        public void AddFormulaToNonDayNightKPItagbutCancel(KPITagFormulaData testdata)
        {

            KPITagSettings.PrepareToAddFormula(testdata.InputData.Name);

            KPITagSettings.FillInFormulaField(testdata.InputData.Formula);

            KPITagSettings.ClickCancelFormula();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            KPITagSettings.FocusOnKPITag(testdata.InputData.Name);
            Assert.AreEqual(testdata.ExpectedData.Formula, KPITagSettings.GetFormulaValue());
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());

        } 
    }
}
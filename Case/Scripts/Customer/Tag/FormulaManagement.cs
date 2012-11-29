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
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.Tag
{
    public class FormulaManagement : TestSuiteBase
    {
        private static VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            //ElementLocator.OpenJazz();
            //FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.NavigatorToVTagSetting();
            //ElementLocator.Pause(2000);
            TimeManager.PauseMedium();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-Formula-001"), ManualCaseID("TJ-Formula-001"), CreateTime("2012-11-08"), Owner("Emma")]
        public void AddFormulaToVtag()
        {
            string vtagName = "AutoVtag001";
            string expectedFormula = "{vtag.AZuoDian}+{vtag.AZuoKongtiaoDian}";

            VTagSettings.PrepareToAddFormula(vtagName);

            VTagSettings.FillInFormulaField("{vtag.AZuoDian}");
            VTagSettings.AppendFormulaField("+");
            VTagSettings.DragTagToFormula("A座空调用电");

            VTagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.PauseShort();

            Assert.AreEqual(VTagSettings.GetFormulaValue(), expectedFormula);

        }
    }
}

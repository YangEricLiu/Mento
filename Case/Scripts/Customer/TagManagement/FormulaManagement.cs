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

namespace Mento.Script.Customer.TagManagement
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
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-Formula-001"), ManualCaseID("TJ-Formula-001"), CreateTime("2012-11-08"), Owner("Emma")]
        public void AddFormulaToVtag()
        {
            //string vtagName = "Add_V1";
            //string expectedFormula = "{vtag.AZuoDian}+{vtag.AZuoKongtiaoDian}";
            string vtagName = "Add_V1";
            string expectedFormula = "{ptag.Add_P1}+{ptag.Amy_c_P1}";
            
            VTagSettings.PrepareToAddFormula(vtagName);

            VTagSettings.FillInFormulaField("{ptag.Add_P1}");
            VTagSettings.AppendFormulaField("+");
            VTagSettings.DragTagToFormula("Amy_c_P1电_分散空调");

            VTagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(VTagSettings.GetFormulaValue(), expectedFormula);

        }
    }
}

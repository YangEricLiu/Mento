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

namespace Mento.Script.Administration.Tag
{
    public class FormulaManagement : TestSuiteBase
    {
        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            ElementLocator.OpenJazz();
            FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            FunctionWrapper.Tag.NavigatorToVtagSetting();
            ElementLocator.Pause(2000);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-Formula-001"), CreateTime("2012-11-08"), Owner("Emma")]
        public void AddFormulaToVtag()
        {
            string vtagName = "AutoVtag001";
            string expectedFormula = "{vtag.AZuoKongtiaoDian}+{vtag.AZuoDian}";

            FunctionWrapper.Tag.PrepareToAddFormula(vtagName);

            FunctionWrapper.Tag.AppendFormulaField("{vtag.AZuoDian}");
            FunctionWrapper.Tag.AppendFormulaField("+");
            FunctionWrapper.Tag.DragTagToFormula("A座空调用电");

            FunctionWrapper.Tag.ClickSaveFormulaButton();

            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(500);

            Assert.AreEqual(FunctionWrapper.Tag.GetFormulaValue(), expectedFormula);

        }
    }
}

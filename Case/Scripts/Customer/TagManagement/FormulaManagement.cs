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
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-11-08")]
    [ManualCaseID("TC-J1-SmokeTest-005")]
    public class FormulaManagement : TestSuiteBase
    {
        private static VTagSettings VTagSettings = JazzFunction.VTagSettings;

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

        [Test]
        [CaseID("TC-J1-SmokeTest-005-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddFormulaToVtag()
        {
            string vtagName = "Add_V1";
            string expectedFormula = "{ptag.Add_P1}+{ptag.Amy_c_P1}";
            
            VTagSettings.PrepareToAddFormula(vtagName);

            VTagSettings.FillInFormulaField("{ptag.Add_P1}");
            VTagSettings.AppendFormulaField("+");
            VTagSettings.DragTagToFormula("Amy_c_P1电_分散空调");

            VTagSettings.ClickSaveFormulaButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(VTagSettings.GetFormulaValue(), expectedFormula);

        }
    }
}

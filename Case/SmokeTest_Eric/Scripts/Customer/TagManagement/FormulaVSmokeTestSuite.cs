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
    public class FormulaVSmokeTestSuite : TestSuiteBase
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
        [Priority("19")]
        [Type("BVT")]
        public void SmokeTestAddFormulaToVtag()
        {
            /// <summary>
            /// Precondition: 1. make sure there is vtag "Formula_V1" for adding formula
            ///               2. make sure there are one ptag named "ptag.Formula_P1" code is "ptag.Formula_P1"
            ///                  one ptag named "ptag.Formula_P2", code is "ptag.Formula_P2"
            /// </summary>  
            ///
            string vtagName = "Formula_V1";
            string expectedFormula = "{ptag.Formula_P1}+{ptag.Formula_P2}";

            //Focus on vtag "Add_V1" and click "计算公式" tab, 
            VTagSettings.PrepareToAddFormula(vtagName);

            //Fill formula "{ptag.Add_P1}+{ptag.Amy_c_P1}", and save
            VTagSettings.FillInFormulaField("{ptag.Formula_P1}");
            VTagSettings.AppendFormulaField("+");
            VTagSettings.DragTagToFormula("ptag.Formula_P2");

            VTagSettings.ClickSaveFormulaButton();
            TimeManager.ShortPause();

            //Verify the formula is added and display correct
            Assert.AreEqual(VTagSettings.GetFormulaValue(), expectedFormula);
        }
    }
}

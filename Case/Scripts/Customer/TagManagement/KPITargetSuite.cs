using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-11")]
    [ManualCaseID("TC-J1-SmokeTest")]
    public class KPITargetSuite:TestSuiteBase
    {
        private static KPITargetBaselineSettings KPITargetBaselineSettings = JazzFunction.KPITargetBaselineSettings;
        [SetUp]
        public void CaseSetUp()
        {
            KPITargetBaselineSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-022")]
        [MultipleTestDataSource(typeof(KPITargetData[]), typeof(KPITargetSuite), "TC-J1-SmokeTest-022")]
        public void AddKPITarget(KPITargetData testData)
        {
            KPITargetBaselineSettings.FocusOnKPITag("KPITagForTargetBaseline");
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SwitchToTargetPropertyTab();
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SelectYear("2010");

            TimeManager.LongPause();

            //KPITargetBaselineSettings.ViewCalculationRule();

            //KPITargetBaselineSettings.CreateCalculationRule();

            //Input 'Effective Year' and 'Factor Value' for the record(s) based on the input data file
                   
            
        }       
    }
}

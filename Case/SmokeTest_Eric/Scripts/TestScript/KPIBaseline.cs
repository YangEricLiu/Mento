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

namespace Mento.Script.TestScript.TagManagement
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-14")]
    [ManualCaseID("TA-Smoke-TargetBaseline-001")]
    public class KPIBaselineSuite:TestSuiteBase
    {
        private static KPITargetBaselineSettings KPITargetBaselineSettings = JazzFunction.KPITargetBaselineSettings;
        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            KPITargetBaselineSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }
           
        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-TargetBaseline-001-001")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(KPIBaselineSuite), "TA-Smoke-TargetBaseline-001-001")]
        public void KPIBaselineConfigurationCalculationRevision(KPITargetBaselineData testData)
        {
            KPITargetBaselineSettings.FocusOnKPITag("Auto_Kpi_Target");
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SwitchToBaselinePropertyTab();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectYear(testData.InputData.Year);
            TimeManager.ShortPause();

            #region Edit calculate values
            KPITargetBaselineSettings.ClickViewCalculationRuleButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            for (int elementPosition = 1; elementPosition <= testData.InputData.WorkdayRuleRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectWorkdayRuleEndTime(testData.InputData.WorkdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInWorkdayRuleValue(testData.InputData.WorkdayRuleValue[inputDataArrayPosition], elementPosition);
            }
           
            for (int elementPosition = 1; elementPosition <= testData.InputData.NonworkdayRuleRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectNonworkdayRuleEndTime(testData.InputData.NonworkdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInNonworkdayRuleValue(testData.InputData.NonworkdayRuleValue[inputDataArrayPosition], elementPosition);
            }

            for (int elementPosition = 1; elementPosition <= testData.InputData.SpecialdayRuleRecordNumber; elementPosition++)
            {
                KPITargetBaselineSettings.ClickAddSpecialDatesButton();
                TimeManager.ShortPause();

                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectSpecialdayRuleStartDate(testData.InputData.SpecialdayRuleStartDate[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleStartTime(testData.InputData.SpecialdayRuleStartTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleEndDate(testData.InputData.SpecialdayRuleEndDate[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleEndTime(testData.InputData.SpecialdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInSpecialdayRuleValue(testData.InputData.SpecialdayRuleValue[inputDataArrayPosition], elementPosition);
            }

            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickBackFromCalculationRuleButton();
            TimeManager.ShortPause();
            #endregion


            #region Calculate values
            KPITargetBaselineSettings.ClickCalculateBaselineButton();
            TimeManager.LongPause();

            Assert.AreEqual(testData.ExpectedData.AnnualCalculatedValue, KPITargetBaselineSettings.GetAnnualValue());
            TimeManager.LongPause();
            #endregion

            #region Revise calculation values
            KPITargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInAnnualRevisedValue(testData.InputData.AnnualRevisedValue);
            KPITargetBaselineSettings.FillInJanuaryRevisedValue(testData.InputData.JanuaryRevisedValue);
            KPITargetBaselineSettings.FillInFebruaryRevisedValue(testData.InputData.FebruaryRevisedValue);
            KPITargetBaselineSettings.FillInMarchRevisedValue(testData.InputData.MarchRevisedValue);
            KPITargetBaselineSettings.FillInAprilRevisedValue(testData.InputData.AprilRevisedValue);
            KPITargetBaselineSettings.FillInMayRevisedValue(testData.InputData.MayRevisedValue);
            KPITargetBaselineSettings.FillInJuneRevisedValue(testData.InputData.JuneRevisedValue);
            KPITargetBaselineSettings.FillInJulyRevisedValue(testData.InputData.JulyRevisedValue);
            KPITargetBaselineSettings.FillInAugustRevisedValue(testData.InputData.AugustRevisedValue);
            KPITargetBaselineSettings.FillInSeptemberRevisedValue(testData.InputData.SeptemberRevisedValue);
            KPITargetBaselineSettings.FillInOctoberRevisedValue(testData.InputData.OctoberRevisedValue);
            KPITargetBaselineSettings.FillInNovemberRevisedValue(testData.InputData.NovemberRevisedValue);
            KPITargetBaselineSettings.FillInDecemberRevisedValue(testData.InputData.DecemberRevisedValue);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            Assert.AreEqual(testData.InputData.AnnualRevisedValue, KPITargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(testData.InputData.JanuaryRevisedValue, KPITargetBaselineSettings.GetJanuaryValue());
            TimeManager.ShortPause();
            #endregion
        }       
    }
}

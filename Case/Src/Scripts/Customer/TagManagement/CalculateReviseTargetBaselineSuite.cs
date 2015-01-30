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
    [Owner("Emma")]
    [CreateTime("2013-07-30")]
    [ManualCaseID("TC-J1-FVT-TargetCalculateRevise-101")]
    public class CalculateReviseTargetBaselineSuite : TestSuiteBase
    {
        private static TagTargetBaselineSettings PVtagTargetBaselineSettings = JazzFunction.TagTargetBaselineSettings;
        private static PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseTearDown();
        }

        private void PickupPtagOrVtag(KPITargetBaselineData input)
        {
            if (String.Equals(input.InputData.TagType, "Ptag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
                PVtagTargetBaselineSettings.FocusOnPTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            }

            if (String.Equals(input.InputData.TagType, "Vtag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
                PVtagTargetBaselineSettings.FocusOnVTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            } 
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-1")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-1")]
        public void CalculateTargetWorkday(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-2")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-2")]
        public void CalculateTargetNonWorkday(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateBaselineButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-3")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-3")]
        public void CalculateTargetNegative(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateBaselineButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-4")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-4")]
        public void CalculateTargetWithOtherFormat(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-5")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-5")]
        public void RevisionCancel(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.MediumPause();

            //Click "Revise" button and input nothing then save
            PVtagTargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());

            //Click "Revise" button and revise some then cancel
            PVtagTargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.FillInAnnualRevisedValue(input.InputData.AnnualRevisedValue);
            PVtagTargetBaselineSettings.FillInFebruaryRevisedValue(input.InputData.FebruaryRevisedValue);

            PVtagTargetBaselineSettings.ClickCancelButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-6")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-6")]
        public void RevisionSaveAndCheck(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.MediumPause();

            //Click "Revise" button and revise some then save
            PVtagTargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.FillInAnnualRevisedValue(input.InputData.AnnualRevisedValue);
            PVtagTargetBaselineSettings.FillInFebruaryRevisedValue(input.InputData.FebruaryRevisedValue);

            PVtagTargetBaselineSettings.ClickSaveButton();
            TimeManager.MediumPause();

            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-7")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-7")]
        public void CalculationFailed(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.LongPause();

            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.CalculationErrorMessages[0]));
            JazzMessageBox.MessageBox.OK();
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-8")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-8")]
        public void CalculationNoValue(KPITargetBaselineData input)
        {
            string blankValue = "";
            
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.MediumPause();

            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(blankValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-3913")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-3913")]
        public void CheckRevisionWord3913(KPITargetBaselineData input)
        {
            //Get a vtag/ptag which have "修正值" word, navigate to "基准值" tab
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //"修正值" word display correctly on "六月"
            Assert.IsTrue(PVtagTargetBaselineSettings.IsReviseTextDisplay("June"));

            //Switch between '目标值''基准值''基础属性' tabs, when back to "基准值" tab 
            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //"修正值" word still display correctly on "六月"
            Assert.IsTrue(PVtagTargetBaselineSettings.IsReviseTextDisplay("June"));
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetCalculateRevise-101-4012")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(CalculateReviseTargetBaselineSuite), "TC-J1-FVT-TargetCalculateRevise-101-4012")]
        public void CheckRevisionWord4012(KPITargetBaselineData input)
        {
            //Get a vtag/ptag which have associate calendar
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //then config calculation rule 
            PVtagTargetBaselineSettings.ClickViewCalculationRuleButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.FillInWorkdayRuleValue("1", 1);
            PVtagTargetBaselineSettings.FillInNonworkdayRuleValue("1", 1);

            PVtagTargetBaselineSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            PVtagTargetBaselineSettings.ClickBackFromCalculationRuleButton();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.ClickCalculateBaselineButton();
            TimeManager.LongPause();

            //"目标值" calculated correctly
            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());

            //Switch between '目标值''基准值''基础属性' tabs, when back to "基准值" tab 
            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //"目标值" calculated value still display
            Assert.AreEqual(input.ExpectedData.AnnualCalculatedValue, PVtagTargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(input.ExpectedData.JanuaryCalculatedValue, PVtagTargetBaselineSettings.GetJanuaryValue());
            Assert.AreEqual(input.ExpectedData.FebruaryCalculatedValue, PVtagTargetBaselineSettings.GetFebruaryValue());
            Assert.AreEqual(input.ExpectedData.MarchCalculatedValue, PVtagTargetBaselineSettings.GetMarchValue());
            Assert.AreEqual(input.ExpectedData.AprilCalculatedValue, PVtagTargetBaselineSettings.GetAprilValue());
            Assert.AreEqual(input.ExpectedData.MayCalculatedValue, PVtagTargetBaselineSettings.GetMayValue());
            Assert.AreEqual(input.ExpectedData.JulyCalculatedValue, PVtagTargetBaselineSettings.GetJulyValue());
            Assert.AreEqual(input.ExpectedData.JuneCalculatedValue, PVtagTargetBaselineSettings.GetJuneValue());
            Assert.AreEqual(input.ExpectedData.AugustCalculatedValue, PVtagTargetBaselineSettings.GetAugustValue());
            Assert.AreEqual(input.ExpectedData.SeptemberCalculatedValue, PVtagTargetBaselineSettings.GetSeptemberValue());
            Assert.AreEqual(input.ExpectedData.OctoberCalculatedValue, PVtagTargetBaselineSettings.GetOctoberValue());
            Assert.AreEqual(input.ExpectedData.NovemberCalculatedValue, PVtagTargetBaselineSettings.GetNovemberValue());
            Assert.AreEqual(input.ExpectedData.DecemberCalculatedValue, PVtagTargetBaselineSettings.GetDecemberValue());
        }
    }
}

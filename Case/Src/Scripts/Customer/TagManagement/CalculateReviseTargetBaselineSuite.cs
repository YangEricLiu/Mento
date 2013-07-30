﻿using System;
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
        private string CalculationMessage = "本次操作时间较长，您确定要继续吗";

        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.NavigatorToTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
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
    }
}

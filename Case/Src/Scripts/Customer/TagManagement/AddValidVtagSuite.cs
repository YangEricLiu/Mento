using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-06-04")]
    [ManualCaseID("TC-J1-FVT-VtagConfiguration-Add-101")]
    public class AddValidVtagSuite : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            VTagSettings.VTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            VTagSettings.VTagSettingCaseTearDown();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  ["自动化测试", "CheckOnESSite001"] and ["自动化测试","AutoSite_Vtag","CheckModifyVtag"]
        ///                      2. make sure the AreaDimensionNode has been added  ["CheckModifyVtag","FirstFloor"]
        /// Prepare Data:  1. make sure the vtags have been added "VtagForCheckNotSameCode","VtagForTestFormula"
        ///                        2. make sure the vtags have been added "PtagUseredByVtagFormula"
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-1")]
        public void AddValidVtag(VtagData input)
        {

            //Click "+" button and fill vtag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            //waiting for "quanjuzhezhao" disappear
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();


            //Verify that vtag added successfully
            //VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.InputData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.InputData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.InputData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationStepExpectedValue(input.InputData.Step), VTagSettings.GetVTagCalculationStepValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-2")]
        public void AddVtagAndCheckOnEA(VtagData input)
        {

             //Click "+" button and fill vtag field
             VTagSettings.ClickAddVTagButton();
             VTagSettings.FillInAddVTagData(input.InputData);

             //Click "Save" button
             VTagSettings.ClickSaveButton();
             //waiting for "quanjuzhezhao" disappear
             JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.MediumPause();

             //Verify that vtag added successfully
             //VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
             Assert.AreEqual(input.InputData.CommonName, VTagSettings.GetVTagNameValue());
             Assert.AreEqual(input.InputData.Code, VTagSettings.GetVTagcodeValue());
             Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.InputData.Commodity), VTagSettings.GetVTagCommodityValue());
             Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.InputData.UOM), VTagSettings.GetVTagUOMValue());
             Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.InputData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
             Assert.AreEqual(VTagSettings.GetVTagCalculationStepExpectedValue(input.InputData.Step), VTagSettings.GetVTagCalculationStepValue());

             // verify on data association tag list
             JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
             JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
             JazzFunction.AssociateSettings.ClickAssociateTagButton();
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();
             TimeManager.LongPause();
             JazzFunction.AssociateSettings.CheckedTag(input.InputData.CommonName);
             TimeManager.MediumPause();
             JazzFunction.AssociateSettings.ClickAssociateButton();
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();
             Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName));
             TimeManager.MediumPause();
            //verify the trend chart is drawn 
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.CommonName);
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.InputData.CommonName);
            TimeManager.MediumPause();
            JazzFunction.EnergyViewToolbarViewSplitButton.ClickView();
            TimeManager.MediumPause();
            // Verify is there  any trend chart display (temp method)
            
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTrendChartDrawn());
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists(input.InputData.CommonName));
        }


        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-3")]
        public void AddVtagAndCheckOnFormula(VtagData input)
        {

            string PtagName = "PtagByFormula";
            //Click "+" button and fill vtag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //verify add successful
            TimeManager.MediumPause();
            Assert.IsTrue(VTagSettings.IsModifyButtonDisplayed());

            //1. verify on area node
            // Prepare for testing the formula
            VTagSettings.SwitchToFormulaTab();
            VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            // For find the vtag
            //VTagSettings.GotoPageOnFormulaTaglist(3);
            //VTagSettings.ScrollToViewTagByCode("PtagWater001");
            VTagSettings.DragTagToFormula(PtagName);
            VTagSettings.ClickSaveFormulaButton();
            TimeManager.MediumPause();
           
            // 2 Assosiate the vtag to Area node
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSettings);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.ClickAssociateTagButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            JazzFunction.AssociateSettings.CheckedTag(input.InputData.Code);
            JazzFunction.AssociateSettings.ClickAssociateButton();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName);
            //JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.ExpectedData.CommonName);
            TimeManager.MediumPause();

            //3. verify on formula tag list

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettings);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            JazzFunction.VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            TimeManager.ShortPause();
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //JazzFunction.VTagSettings.GotoPageOnFormulaTaglist(5);
            //TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.MediumPause();
            JazzFunction.VTagSettings.DragTagToFormula(input.InputData.CommonName);
            TimeManager.MediumPause();
            JazzFunction.VTagSettings.ClickSaveFormulaButton();
            // Verify the tag in the formula field
            JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.InputData.CommonName);
            TimeManager.MediumPause();
        }


        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-4")]
        public void AddSameNameVtag(VtagData input) 
        {
            
            //Click "+" button and fill vtag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            TimeManager.MediumPause();
            //Click "Save" button
            VTagSettings.ClickSaveButton();

            //Verify that vtag added successfully
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());

        }   
        
    }
}

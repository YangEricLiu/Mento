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
/*
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
            VTagSettings.NavigatorToVTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

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

            //verify add successful
            //Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            //Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //Verify that vtag added successfully
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
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
             
             //verify add successful
             //Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
             //Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

             //Verify that vtag added successfully
             VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
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
             TimeManager.LongPause();

             //！ can't check the vtags that need to drag the scroll bar
             JazzFunction.AssociateSettings.CheckedTag(input.InputData.CommonName);
             //JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.MediumPause();
             JazzFunction.AssociateSettings.ClickAssociateButton();
             //JazzMessageBox.LoadingMask.WaitLoading();
             TimeManager.LongPause();
             Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName));
             

            //verify the trend chart is emtpy
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.CommonName);
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.InputData.CommonName);
            TimeManager.MediumPause();
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            TimeManager.MediumPause();
            // Verify is there  any trend chart display (temp method)
            
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTrendChartDrawn());
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists(input.InputData.CommonName));


            // prepare this vtag for test the formula
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            TimeManager.MediumPause();
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            TimeManager.LongPause();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            JazzFunction.VTagSettings.GotoPageOnFormulaTaglist(3);
            TimeManager.LongPause();
            TimeManager.LongPause();

            JazzFunction.VTagSettings.DragTagToFormula(input.ExpectedData.CommonName);
            TimeManager.LongPause();
            JazzFunction.VTagSettings.ClickSaveFormulaButton();
            // Verify the tag in the formula field
            TimeManager.LongPause();
            JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.ExpectedData.CommonName);



        }

        

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-3")]
        public void AddVtagAndCheckOnFormula(VtagData input)
        {

           
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
            
            // Add hierarchy for verify the added vtag
           
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            TimeManager.MediumPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            //Click "子区域" button to add Area node.	
            JazzFunction.AreaDimensionSettings.ClickCreateAreaDimensionButton();
            //"Input  area name: "一层", comment ,Click ""save"" button"	
            JazzFunction.AreaDimensionSettings.FillAreaDimensionData(input.InputData.Message, input.InputData.Comment);
            JazzFunction.AreaDimensionSettings.ClickSaveButton();
           

            // Assosiate the vtag to Area node
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNode(input.InputData.Message);
          
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.ClickAssociateTagButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.AssociateSettings.CheckedTag(input.InputData.Code);
            JazzFunction.AssociateSettings.ClickAssociateButton();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName);
            //JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.ExpectedData.CommonName);


            //1. verify on formula tag list




            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            TimeManager.LongPause();
            TimeManager.LongPause();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Assert.IsTrue(JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.InputData.CommonName));


            //2. verify whether tag on the formula tag list
            //    A problem here :  those tags should drag scroll bar to diplay can't drag into the formula textarea

            // Drag the vtag to the formula
            // Should modify the page to the vtag you find
            JazzFunction.VTagSettings.GotoPageOnFormulaTaglist(5);
            TimeManager.MediumPause();
            TimeManager.LongPause();
            TimeManager.MediumPause();
            JazzFunction.VTagSettings.DragTagToFormula(input.ExpectedData.CommonName);
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

            //Click "Save" button
            VTagSettings.ClickSaveButton();

            //Verify that vtag added successfully
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());

        }   
        
    }
}

*/
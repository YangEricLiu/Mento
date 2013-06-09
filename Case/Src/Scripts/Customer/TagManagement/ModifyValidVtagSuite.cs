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
    [CreateTime("2013-06-06")]
    [ManualCaseID("TC-J1-FVT-VtagConfiguration-Modify-101")]
    public class ModifyValidVtagSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-1")]
        public void ModifyWithoutChange(VtagData input)
        {
            //Click "Modify" button and input nothing to vtag field
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            VTagSettings.ClickModifyButton();

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            //Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //Verify that vtag keep the same successfully
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.ExpectedData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(input.ExpectedData.Comment, VTagSettings.GetVTagCommentValue());
        }


        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-2")]
        public void ModifyCodeAndCheckFormula(VtagData input)
        {
            string vtagName = "VtagForCheckAll";
            string updatedFormula = "{vtag|VtagForCheckOnFormula}";

            //Click "Modify" button and input new code to vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            VTagSettings.FocusOnVTagByCode(input.ExpectedData.Code);

            //Verify that ptag code is updated on vtag formula
            JazzFunction.Navigator.NavigateHome();
            VTagSettings.NavigatorToVTagSetting();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            Assert.AreEqual(updatedFormula, JazzFunction.VTagSettings.GetFormulaValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-3")]
        public void ModifyNameAndCommodity(VtagData input)
        {
            
            
            //Click "Modify" button and input new value to Vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            
            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            

                       
             //1. Verify that vtag is updated on associated tag list
             JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
             JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName));
           
            //2. Verify that vtag is updated on energy view tag list and  its legend name
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            
            //Commodity updated
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.InputData.CommonName);
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.InputData.Commodity), JazzFunction.EnergyAnalysisPanel.GetSelectedRowData(3));
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.CommonName);

            JazzFunction.EnergyAnalysisPanel.CheckTag(input.InputData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("VtagForCheckOnESSite001"));
            
        }
      
        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-4")]
        public void ModifyUomAndCheck(VtagData input)
        {
 
            //Click "Modify" button and input new value to Vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
          
            //Verify that vtag Uom is updated on energy view tag list and  Uom updated on its chart view y-axis
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            //TimeManager.LongPause();

            //Uom updated
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.InputData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

           // Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), JazzFunction.EnergyAnalysisPanel.GetUomValue());
        }



        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-5")]
        public void ModifyStepAndCheck(VtagData input)
        {
            //string vtagName = "VtagForCheckPtagAll";
            
            //Click "Modify" button and input new value to Vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();


            TimeManager.LongPause();
            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            VTagSettings.FocusOnVTagByName(input.InputData.CommonName);
            
            //Verify that vtag Step is updated on energy view tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);

          
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName));

            //Step updated
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.ExpectedData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            //JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            
            //problem here 
            TimeManager.MediumPause();
            //Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Equals("所选数据点不支持"));
            //Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("VtagForCheckAll"));
            TimeManager.MediumPause();
            //Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("小时"));
            //Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.Step), JazzFunction.EnergyAnalysisPanel.GetUomValue());

        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-6")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-6")]
        public void ModifyCompAndCheck(VtagData input)
        {

            //Click "Modify" button and input new value to Vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), VTagSettings.GetVTagUOMValue());

            //Verify that not lighten vtag Uom is updated dimension node
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            JazzFunction.AreaDimensionSettings.ShowHierarchyTree();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.ExpectedData.CommonName);
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.UOM), JazzFunction.EnergyAnalysisPanel.GetSelectedRowData(6));
        }

    }
}

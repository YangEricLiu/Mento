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
            VTagSettings.VTagSettingCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            VTagSettings.VTagSettingCaseTearDown();
        }

        /// <summary>
        /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"/"AutoSite_Vtag"/"CheckModifyVtag"
        /// Prepare Data: 1. add area dimension "一层" and system dimension "空调" for associate tag and lightened in either dimension Node
        ///                       2. add vtag "VtagForCheckFormula" used by formula   "VtagModify001" ,
        ///                       3. add vtag "VtagModify002"(formula:ptag"PtagByFormula"), "VtagFormula2"
        ///                       4. add vtag "VtagModify003"  assosiated under ["自动化测试","AutoSite_Vtag","CheckModifyVtag"]  Need data here
        ///                       5. add vtag "VtagModify004"  assosiated under ["自动化测试","AutoSite_Vtag","CheckModifyVtag"]  Need data here
        ///                       6. add vtag "VtagModify005"  assosiated under ["自动化测试","AutoSite_Vtag","CheckModifyVtag"]  Need data here
        ///                       7. add vtag "VtagModify006"  assosiated under  CheckModifyVtag,空调 (Lightend) and CheckModifyVtag,FirstFloor
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-1")]
        public void ModifyWithoutChange(VtagData input)
        {

            //Click "Modify" button and input nothing to vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            
            VTagSettings.ClickModifyButton();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //Verify that vtag keep the same successfully
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.ExpectedData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, VTagSettings.GetVTagCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-2")]
        public void ModifyCodeAndCheckFormula(VtagData input)
        {
            string vtagName = "VtagFormula2";
            string updatedFormula = "{vtag|VtagCodeModified}";

            //Click "Modify" button and input new code to vtag field
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            TimeManager.LongPause();

            //VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
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
            TimeManager.ShortPause();
            VTagSettings.GotoPageOnVTagList(1);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //Verify that ptag code is updated on vtag formula

            JazzFunction.VTagSettings.FocusOnVTagByName(vtagName);
            TimeManager.MediumPause();
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            TimeManager.LongPause();
            Assert.AreEqual(updatedFormula, JazzFunction.VTagSettings.GetFormulaValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-3")]
        public void ModifyNameAndCommodity(VtagData input)
        {

            //Click "Modify" button and input new value to Vtag field


            int i = 2;

            bool flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);

            if ((!flag) & (i < 5))
            {

                VTagSettings.GotoPageOnVTagList(i);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
                i = i + 1;
            }
            //VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            TimeManager.MediumPause();
            VTagSettings.ClickModifyButton();
            TimeManager.LongPause();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            
            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());
            //VTagSettings.FocusOnVTagByName(input.InputData.CommonName);

            TimeManager.MediumPause();
                       
             //1. Verify that vtag is updated on associated tag list
             JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
             JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
             JazzMessageBox.LoadingMask.WaitSubMaskLoading();
             TimeManager.LongPause();
             Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName));

            //2. Verify that vtag is updated on energy view tag list and  its legend name
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            //Commodity updated
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.InputData.CommonName);
            
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.InputData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.ClickView();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading(30);
            TimeManager.MediumPause();
            // No data here  
            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("VtagNameModified"));            
        }
      
        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-4")]
        public void ModifyUomAndCheck(VtagData input)
        {

            //VTagSettings.ScrollToViewTagByName(input.ExpectedData.CommonName);
            //Click "Modify" button and input new value to Vtag field
            int i = 2;

            bool flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);

            if ((!flag) & (i < 5))
            {

                VTagSettings.GotoPageOnVTagList(i);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
                i = i + 1;
            }

            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //Verify that vtag keep the same successfully
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.ExpectedData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());

             //Verify that vtag Uom is updated on energy view tag list and  Uom updated on its chart view y-axis
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);

            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            //Uom updated
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.ExpectedData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.ClickView();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
           //Need data here
            //Assert.AreEqual(input.InputData.UOM, JazzFunction.EnergyAnalysisPanel.GetUomValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-5")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-5")]
        public void ModifyStepAndCheck(VtagData input)
        {

            int i = 2;
            //Click "Modify" button and input new value to Vtag field
            bool flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            // Temp method for find the next page vtags
            if ((!flag)&(i<5))
            {
                
                VTagSettings.GotoPageOnVTagList(i);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
                i = i + 1;
            }

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

            //Verify that vtag Step is updated on energy view tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.IsTrue(JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName));
            //Step updated
            JazzFunction.EnergyAnalysisPanel.CheckTag(input.ExpectedData.CommonName);
            /*
            JazzFunction.EnergyViewToolbarViewSplitButton.ClickView();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.AreEqual(JazzMessageBox.MessageBox.GetMessage(),input.ExpectedData.Message);
            //JazzMessageBox.MessageBox.Equals(input.ExpectedData.Message);
            TimeManager.LongPause();
            JazzMessageBox.MessageBox.Cancel();
            TimeManager.MediumPause();
            //Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsLegendItemExists("小时"));
            //Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.Step), JazzFunction.EnergyAnalysisPanel.GetUomValue());
            */
        }

        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-101-6")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-101-6")]
        public void ModifyCompAndCheck(VtagData input)
        {
            
            int i = 2;

            bool flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);

            if ((!flag) & (i < 5))
            {

                VTagSettings.GotoPageOnVTagList(i);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();
                flag = VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.LongPause();
                i = i + 1;
            }

            //VTagSettings.FocusOnVTagByName(input.ExpectedData.Code);
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
            TimeManager.LongPause();
            JazzFunction.AreaDimensionSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.AreaDimensionSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            TimeManager.MediumPause();
            //JazzFunction.AssociateSettings.CheckedTag(input.ExpectedData.CommonName);
            JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName);
            Assert.IsTrue(JazzFunction.AssociateSettings.FocusOnVTagByName(input.ExpectedData.CommonName));
            TimeManager.MediumPause();
            //JazzFunction.AssociateSettings.GetSelectedRowData(5);
            //Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.UOM), JazzFunction.AssociateSettings.GetSelectedRowData(6));
            Assert.IsTrue(JazzFunction.AssociateSettings.FocusOnVTagByName(input.ExpectedData.CommonName));
            //Problem here @@@@@@@@@@@@@@@@@@@@@@@@@@2222
            //Assert.AreEqual(JazzFunction.AssociateSettings.GetSelectedRowData(6),input.ExpectedData.UOM);
            //VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.UOM).Equals(JazzFunction.AssociateSettings.GetSelectedRowData(5));
        }
    }
}

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
    [Owner("Amy")]
    [CreateTime("2012-11-12")]
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
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
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
            JazzFunction.AssociateSettings.CheckedTag(input.ExpectedData.CommonName);
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();
            JazzFunction.AssociateSettings.ClickAssociateButton();
            //JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.ExpectedData.CommonName));
            TimeManager.ShortPause();

            
            //verify the trend chart is emtpy
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.ExpectedData.HierarchyNodePath);
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.IsTagOnListByName(input.ExpectedData.CommonName);
            JazzFunction.EnergyAnalysisPanel.FocusOnRowByName(input.ExpectedData.CommonName);
            JazzFunction.EnergyViewToolbarViewSplitButton.Click();
            // ！ the interface should be update      
            //Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.IsTrendChartDrawn());
        }


        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(AddValidVtagSuite), "TC-J1-FVT-VtagConfiguration-Add-101-4")]
        public void AddSameNameVtag(VtagData input) 
        {
            //Click "+" button and fill ptag field
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Save" button
            VTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

           
            //Verify that ptag added successfully
            //Assert.IsTrue(VTagSettings.FocusOnVTagByName(input.InputData.CommonName));
        }   

    }
}

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
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Add-101")]
    public class AddValidPtagSuite : TestSuiteBase
    {
        private PTagSettings PTagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {   
            PTagSettings.NavigatorToPtagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-101-1")]
        public void AddValidPtag(PtagData input)
        {
            //Click "+" button and fill ptag field
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag added successfully
            PTagSettings.FocusOnPTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, PTagSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(input.ExpectedData.Meter, PTagSettings.GetMetercodeValue());
            Assert.AreEqual(input.ExpectedData.Channel, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.InputData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.InputData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(input.InputData.CalculationType), PTagSettings.GetCalculationTypeValue());
            Assert.AreEqual(input.ExpectedData.Comments, PTagSettings.GetCommentValue());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-101-2")]
        public void EmptyFieldNotDisplay(PtagData input)
        {
            //Click "+" button and fill ptag field
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag added successfully
            PTagSettings.FocusOnPTagByName(input.InputData.CommonName);
            Assert.IsTrue(PTagSettings.IsCommentHidden());
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-101-3")]
        public void AddPtagAndVerify(PtagData input)
        {
            string ptagFormula = "PtagForCheckPtagAll";

            //Click "+" button and fill ptag field
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //1. verify on formula tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            JazzFunction.PTagSettings.FocusOnPTagByName(ptagFormula);
            JazzFunction.VTagSettings.SwitchToFormulaTab();
            JazzFunction.VTagSettings.ClickModifyFormulaButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.VTagSettings.IsTagNameOnFormulaTagList(input.InputData.CommonName));

            //2. verify on data association tag list
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationHierarchy);
            JazzFunction.AssociateSettings.SelectHierarchyNodePath(input.ExpectedData.HierarchyNodePath);
            JazzFunction.AssociateSettings.ClickAssociateButton();
            TimeManager.MediumPause();
            Assert.IsTrue(JazzFunction.AssociateSettings.IsTagOnAssociatedGridView(input.InputData.CommonName));
        }

        [Test]
        [CaseID("TC-J1-FVT-PtagConfiguration-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(AddValidPtagSuite), "TC-J1-FVT-PtagConfiguration-Add-101-4")]
        public void AddSameNamePtag(PtagData input)
        {
            //Click "+" button and fill ptag field
            PTagSettings.ClickAddPtagButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Save" button
            PTagSettings.ClickSaveButton();
            TimeManager.MediumPause();

            //verify add successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag added successfully
            Assert.IsTrue(PTagSettings.FocusOnPTagByCode(input.InputData.Code));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Administration.Tag.VtagManagement;

namespace Mento.Script.Administration.Tag
{
    [TestFixture]
    //[ManualCaseID("TA-VtagConfigue")]
    [CreateTime("2012-11-15")]
    [Owner("Nancy")]
    public class VtagManagement : TestSuiteBase
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        private Navigator NavigatorIns = ControlAccess.GetControl<Navigator>();
       [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            ElementLocator.OpenJazz();
            FunctionWrapper.Login.Login();
            
            NavigatorIns.NavigateToTarget(NavigationTarget.TagSettingsV);

        }
        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            ElementLocator.QuitJazz();
        }
        
        [Test]
        [CaseID("TA-VtagConfigue-001"), CreateTime("2012-11-14"), Owner("Nancy"),ManualCaseID("TA-VTAG-T001")]
        [MultipleTestDataSource(typeof(AddVtagData[]), typeof(VtagManagement), "TA-VtagConfigue-001")]
        public void AddVtag(AddVtagData input)
        {
            FunctionWrapper.Vtag.ClickAddVtagButton();
            FunctionWrapper.Vtag.FillInAddVtagData(input.InputData);
            FunctionWrapper.Vtag.ClickSaveButton();
            FunctionWrapper.WaitForLoadingDisappeared(5000);
        }


        public void AddVtagResultView(AddVtagData testdata)
        {

            string AddedVtagName = "NancyVtag";
            FunctionWrapper.Vtag.FocusOnTag(AddedVtagName);
            Assert.AreEqual(testdata.InputData.Name, FunctionWrapper.Vtag.GetVtagNameValue());
            Assert.AreEqual(testdata.InputData.Code, FunctionWrapper.Vtag.GetVtagCodeValue());
            Assert.AreEqual(testdata.InputData.Commodity, FunctionWrapper.Vtag.GetVtagCommodityValue());
            Assert.AreEqual(testdata.InputData.UOM, FunctionWrapper.Vtag.GetVtagUOMValue());
            Assert.AreEqual(FunctionWrapper.Vtag.GetVtagUOMExpectedValue(testdata.InputData.Commodity), FunctionWrapper.Vtag.GetVtagUOMValue());
            Assert.AreEqual(FunctionWrapper.Vtag.GetVtagCalculationStepExpectedValue(testdata.InputData.Step), FunctionWrapper.Vtag.GetVtagCalculationStepValue());
            Assert.AreEqual(FunctionWrapper.Vtag.GetVtagCalculationTypeExpectedValue(testdata.InputData.CalculationType), FunctionWrapper.Vtag.GetVtagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, FunctionWrapper.Vtag.GetVtagCommentValue());
        }
       
    }
}
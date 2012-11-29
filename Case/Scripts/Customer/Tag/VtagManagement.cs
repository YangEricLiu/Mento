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
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.Tag
{
    [TestFixture]
    //[ManualCaseID("TA-VtagConfigue")]
    [CreateTime("2012-11-15")]
    [Owner("Nancy")]
    public class VTagManagement : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

       [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            //ElementLocator.OpenJazz();
            //FunctionWrapper.Login.Login();
            
            //NavigatorIns.NavigateToTarget(NavigationTarget.TagSettingsV);

        }
        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.CloseJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            //FunctionWrapper.Ptag.NavigatorToPtagSetting();
            //ElementLocator.Pause(2000);   
            VTagSettings.NavigatorToVTagSetting();
            TimeManager.PauseMedium();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            JazzFunction.Navigator.NavigateHome();
        }
        
        [Test]
        [CaseID("TA-VtagConfigue-001"), CreateTime("2012-11-14"), Owner("Nancy"),ManualCaseID("TA-VTAG-T001")]
        [MultipleTestDataSource(typeof(AddVtagData[]), typeof(VTagManagement), "TA-VtagConfigue-001")]
        public void AddVtag(AddVtagData input)
        {
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(input.InputData);
            VTagSettings.ClickSaveButton();
            //FunctionWrapper.WaitForLoadingDisappeared(5000);

            JazzMessageBox.LoadingMask.WaitLoading();
        }


        public void AddVtagResultView(AddVtagData testdata)
        {

            string AddedVtagName = "NancyVtag";
            VTagSettings.FocusOnVTag(AddedVtagName);
            Assert.AreEqual(testdata.InputData.Name, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(testdata.InputData.Code, VTagSettings.GetVTagCodeValue());
            Assert.AreEqual(testdata.InputData.Commodity, VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(testdata.InputData.UOM, VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(testdata.InputData.Commodity), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationStepExpectedValue(testdata.InputData.Step), VTagSettings.GetVTagCalculationStepValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(testdata.InputData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, VTagSettings.GetVTagCommentValue());
        }
       
    }
}
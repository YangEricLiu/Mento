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
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [ManualCaseID("TC-J1-SmokeTest-003")]
    [CreateTime("2012-11-15")]
    [Owner("Nancy")]
    public class VTagManagementSuite : TestSuiteBase
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
        [CaseID("TA-VtagConfigue-001")]
        [Priority("18")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AddVtagData[]), typeof(VTagManagementSuite), "TA-VtagConfigue-001")]
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
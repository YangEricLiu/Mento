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

namespace Mento.Script.TestScript.TagManagement
{
    [TestFixture]
    [ManualCaseID("TA-Smoke-Tag-002")]
    [CreateTime("2013-05-13")]
    [Owner("Eric")]
    public class VTagManagementSuite : TestSuiteBase
    {
        private VTagSettings VTagSettings = JazzFunction.VTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            VTagSettings.NavigatorToVTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }
        
        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-Tag-002-001")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(VTagManagementSuite), "TA-Smoke-Tag-002-001")]
        public void AddVtag(VtagData testdata)
        {
            VTagSettings.ClickAddVTagButton();
            VTagSettings.FillInAddVTagData(testdata.InputData);
            VTagSettings.ClickSaveButton();

            TimeManager.MediumPause();

            VTagSettings.FocusOnVTag(testdata.InputData.Name);
            Assert.AreEqual(testdata.InputData.Name, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(testdata.InputData.Code, VTagSettings.GetVTagCodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(testdata.InputData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(testdata.InputData.UOM), VTagSettings.GetVTagUOMValue());            
            Assert.AreEqual(VTagSettings.GetVTagCalculationStepExpectedValue(testdata.InputData.Step), VTagSettings.GetVTagCalculationStepValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(testdata.InputData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
            Assert.AreEqual(testdata.InputData.Comment, VTagSettings.GetVTagCommentValue());
        }
    }
}
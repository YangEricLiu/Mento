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
    [CreateTime("2013-06-07")]
    [ManualCaseID("TC-J1-FVT-VtagConfiguration-Modify-001")]
    public class ModifyInvalidVtagSuite : TestSuiteBase
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
        /// <summary>
        /// Prepare Data:  1. make sure the vtags have been added "VtagForModifyInvalid"
        /// </summary> 
        [Test]
        [CaseID("TC-J1-FVT-VtagConfiguration-Modify-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(VtagData[]), typeof(ModifyInvalidVtagSuite), "TC-J1-FVT-VtagConfiguration-Modify-001-1")]
        public void ModifyThenCancel(VtagData input)
        {
            //Click "Modify" button and modify the vtag
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            VTagSettings.ClickModifyButton();
            VTagSettings.FillInAddVTagData(input.InputData);

            //Click "Cancel" button
            VTagSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(VTagSettings.IsSaveButtonDisplayed());
            Assert.IsTrue(VTagSettings.IsModifyButtonDisplayed());
            Assert.IsFalse(VTagSettings.IsCancelButtonDisplayed());

            //Verify that vtag not changed
            Assert.IsTrue(VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName));
            Assert.IsFalse(VTagSettings.FocusOnVTagByName(input.InputData.CommonName));

            //Verify the vtag not changed
            VTagSettings.FocusOnVTagByName(input.ExpectedData.CommonName);
            Assert.AreEqual(input.ExpectedData.CommonName, VTagSettings.GetVTagNameValue());
            Assert.AreEqual(input.ExpectedData.Code, VTagSettings.GetVTagcodeValue());
            Assert.AreEqual(VTagSettings.GetVTagCommodityExpectedValue(input.ExpectedData.Commodity), VTagSettings.GetVTagCommodityValue());
            Assert.AreEqual(VTagSettings.GetVTagUOMExpectedValue(input.ExpectedData.UOM), VTagSettings.GetVTagUOMValue());
            Assert.AreEqual(VTagSettings.GetVTagCalculationTypeExpectedValue(input.ExpectedData.CalculationType), VTagSettings.GetVTagCalculationTypeValue());
        }
        
    }
}

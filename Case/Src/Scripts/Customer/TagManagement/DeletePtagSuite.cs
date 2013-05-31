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
    [Owner("Emma")]
    [CreateTime("2013-05-30")]
    [ManualCaseID("TC-J1-FVT-PtagConfiguration-Delete-001")]
    public class DeletePtagSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-PtagConfiguration-Delete-001-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(DeletePtagSuite), "TC-J1-FVT-PtagConfiguration-Delete-001-1")]
        public void DeletePtagThenCancel(PtagData input)
        {
            //Click "Modify" button and input nothing to ptag field
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            PTagSettings.ClickModifyButton();
            PTagSettings.FillInPtag(input.InputData);

            //Click "Cancel" button
            PTagSettings.ClickCancelButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //verify modify successful
            Assert.IsFalse(PTagSettings.IsSaveButtonDisplayed());
            Assert.IsFalse(PTagSettings.IsCancelButtonDisplayed());

            //Verify that ptag not changed
            Assert.IsTrue(PTagSettings.FocusOnPTagByName(input.InputData.OriginalName));
            Assert.IsFalse(PTagSettings.FocusOnPTagByName(input.InputData.CommonName));

            //Verify the ptag not changed
            PTagSettings.FocusOnPTagByName(input.InputData.OriginalName);
            Assert.AreEqual(input.ExpectedData.CommonName, PTagSettings.GetNameValue());
            Assert.AreEqual(input.ExpectedData.Code, PTagSettings.GetCodeValue());
            Assert.AreEqual(input.ExpectedData.Meter, PTagSettings.GetMetercodeValue());
            Assert.AreEqual(input.ExpectedData.Channel, PTagSettings.GetChannelIdValue());
            Assert.AreEqual(PTagSettings.GetCommodityExpectedValue(input.ExpectedData.Commodity), PTagSettings.GetCommodityValue());
            Assert.AreEqual(PTagSettings.GetUomExpectedValue(input.ExpectedData.Uom), PTagSettings.GetUomValue());
            Assert.AreEqual(PTagSettings.GetCalculationTypeExpectedValue(input.ExpectedData.CalculationType), PTagSettings.GetCalculationTypeValue());
        }

    }
}

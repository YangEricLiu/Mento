using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.ScriptCommon.TestData.Administration.Tag.PtagConfiguration;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;

namespace Mento.Script.Administration.Tag
{
    public class PtagConfiguration : TestSuiteBase
    {
        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            ElementLocator.OpenJazz();
            FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            FunctionWrapper.Ptag.NavigatorToPtagSetting();
            ElementLocator.Pause(2000);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-PtagConfiguration-001"), CreateTime("2012-11-12"), Owner("Amy")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(PtagConfiguration), "TA-PtagConfiguration-001")]
        public void AddPtag(PtagData testData)
        {
            FunctionWrapper.Ptag.PrepareToAddPtag();
            FunctionWrapper.Ptag.FillInPtag(testData.InputData);
            FunctionWrapper.Ptag.ClickSaveButton();

            ElementLocator.Pause(500);
            FunctionWrapper.Ptag.FocusOnTag(testData.InputData.Name);
            Assert.AreEqual(testData.ExpectedData.Name, FunctionWrapper.Ptag.GetNameValue());
            Assert.AreEqual(FunctionWrapper.Ptag.GetUomExpectedValue(testData.InputData.UomId), FunctionWrapper.Ptag.GetUomValue());
        }

        [Test]
        [CaseID("TA-PtagConfiguration-002"), CreateTime("2012-11-13"), Owner("Amy")]
        [MultipleTestDataSource(typeof(PtagData[]), typeof(PtagConfiguration), "TA-PtagConfiguration-002")]
        public void ModifyPtag(PtagData testData)
        {
            string tagName = "tagformodification";
            FunctionWrapper.Ptag.PrepareToModifyPtag(tagName);
            FunctionWrapper.Ptag.FillInCode(testData.InputData.Code);
            FunctionWrapper.Ptag.ClickSaveButton();

            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(500);

            FunctionWrapper.Ptag.FocusOnTag(tagName);
            Assert.AreEqual(testData.ExpectedData.Code, FunctionWrapper.Ptag.GetCodeValue());            
        }
    }
}

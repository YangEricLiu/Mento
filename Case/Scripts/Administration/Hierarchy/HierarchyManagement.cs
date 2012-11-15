using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using Mento.Utility;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using System.IO;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration.Hierarchy.HierarchyManagement;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;


namespace Mento.Script.Administration.Hierarchy
{
    [TestFixture]
    public class HierarchyManagement : TestSuiteBase
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
            ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            FunctionWrapper.Hierarchy.NavigatorToHSetting();
            ElementLocator.Pause(2000);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-Hierarchy-001"), CreateTime("2012-10-30"), Owner("Emma"), ManualCaseID("TA-Example")]
        [MultipleTestDataSource(typeof(AddHierarchyData[]), typeof(HierarchyManagement), "TA-Hierarchy-001")]
        public void AddOrgnizationNodeTest(AddHierarchyData input)
        {
            FunctionWrapper.Hierarchy.FillInHierarchyNode("Schneider", input.InputData);
            FunctionWrapper.Hierarchy.ClickSaveButton();
            FunctionWrapper.Hierarchy.WaitForCreateOKDisplay(120);

            ElementLocator.Pause(500);

            FunctionWrapper.Hierarchy.ConfirmCreateOKMagBox();

            Assert.IsTrue(FunctionWrapper.Hierarchy.IsNodesChildParent(input.InputData.Name, "Schneider"));

            FunctionWrapper.Hierarchy.FocusOnHierarchyNode(input.InputData.Name);

            Assert.AreEqual(FunctionWrapper.Hierarchy.GetTypeExpectedValue(input.InputData.Type), FunctionWrapper.Hierarchy.GetTypeValue());
        }

    }
}

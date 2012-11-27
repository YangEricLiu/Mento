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
using Mento.ScriptCommon.TestData.Administration;

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [ManualCaseID("TA-Example")]
    [CreateTime("2012-10-13")]
    [Owner("Aries")]
    public class ExampleSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        { 
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TA-Example-001")]
        public void TestCase1()
        {
            //1. load test data
            //   TestDataType testData = (TestDataType)TestDataAPI.GetCaseData(ServiceConext.CurrentCaseName);

            //2. //test step 1
            //   JazzHierarchyTree hierarchyTree = JazzControlAPI.GetMainHierarchyTree();
            //   hierarchyTree.NavigateTo(testData.ExpectedHierarchyName);
            //   //test step 1 result validation
            //   Assert.AreEqual(hierarchyTree.SelectedName, testData.ExpectedHierarchyName);

            //   test step 2
            //   test step 2 result validation

            //   ...

            //   test step N
            //   test step N result validation

        }

        [Test]
        [CaseID("TA-Example-002")]
        public void TestCase2()
        {
            IWebDriver driverChrome = new ChromeDriver();
            //IWebDriver driverIE = new InternetExplorerDriver();

            driverChrome.Url = "http://www.bing.com";

            IWebElement textbox = driverChrome.FindElement(By.Id("sb_form_q"));

            IWebElement submit = driverChrome.FindElement(By.Id("sb_form_go"));

            textbox.SendKeys("sss");

            submit.Click();

            Assert.IsTrue(driverChrome.PageSource.Contains("sss"));

            driverChrome.Close();
        }

        [Test]
        [CaseID("TA-Example-003")]
        public void TestCase3()
        {
            var a = 1;
            var b = 2;
            Assert.That(a, Is.LessThan(b));
        }

        [Test]
        [CaseID("TA-Example-004")]
        public void TestCase4()
        {
            string Path = ConfigurationManager.AppSettings["path"];
            Assert.That(Path, Is.StringContaining("temp"));
        }

        [TestCase("Round A", "Round A")]
        [TestCase("Round B", "Round B")]
        [TestCase("Round C", "Round D")]
        [CaseID("TA-Example-005")]
        public void TestCase5(string input, string expected)
        {
            Assert.AreEqual(input, expected);
        }

        [Test]
        [Combinatorial]
        [CaseID("TA-Example-006")]
        public void TestCase6([Values(1,2)]int a, [Values("a","b")]string b)
        {
        }

        [Test]
        [Sequential]
        [CaseID("TA-Example-007")]
        public void TestCase7([Values(1, 2, 3)]int a, [Values(3, 2, 1)]int b)
        {
            Assert.AreEqual(4, a + b);
        }

        [Test]
        [CaseID("TA-Example-008")]
        public void TestCase8()
        {
            //LogHelper.LogDebug(TestContext.CurrentContext.Test.FullName);
            Func<int, int, int> function = (int a, int b) => a + b;

            var testData = TestContext.CurrentContext.GetTestData<ExampleData>();

            int actual = function(testData.InputData.Number1, testData.InputData.Number2);

            Assert.AreEqual(testData.ExpectedData.Result, actual);
        }

        [Test]
        [CaseID("TA-Example-009"), CreateTime("2012-10-23")]
        [MultipleTestData(typeof(ExampleData[]), typeof(ExampleSuite), "TA-Example-009", 0)]
        [MultipleTestData(typeof(ExampleData[]), typeof(ExampleSuite), "TA-Example-009", 2)]
        public void TestCase9(ExampleData testData)
        {
            Func<int, int, int> function = (int a, int b) => a + b;
            
            int actual = function(testData.InputData.Number1, testData.InputData.Number2);

            Assert.AreEqual(testData.ExpectedData.Result, actual);
        }
        
        [Test]
        [CaseID("TA-Example-010"), CreateTime("2012-10-24")]
        [MultipleTestDataSource(typeof(ExampleData[]), typeof(ExampleSuite), "TA-Example-010")]
        public void TestCase10(ExampleData testData)
        {
            Func<int, int, int> function = (int a, int b) => a + b;

            int actual = function(testData.InputData.Number1, testData.InputData.Number2);

            Assert.AreEqual(testData.ExpectedData.Result, actual);
        }
    }
}
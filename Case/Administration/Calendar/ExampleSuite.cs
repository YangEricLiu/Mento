using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace Automation.Administration.Calendar
{
    [TestFixture]
    public class Suite1
    {
        //[TestFixtureSetUp]
        //public static void FixtureSetUp(TestContext context)
        //{ 
        //}
        
        //[TestFixtureTearDown]
        //public static void FixtureTearDown()
        //{
        //}

        [SetUp]
        public void CaseSetUp()
        { 
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
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
        public void TestCase3()
        {
            var a = 1;
            var b = 2;
            Assert.That(a, Is.LessThan(b));
        }

        [Test]
        public void TestCase4()
        {
            string Path = ConfigurationManager.AppSettings["path"];
            Assert.That(Path, Is.StringContaining("temp"));
        }

        [TestCase("Round A", "Round A")]
        [TestCase("Round B", "Round B")]
        [TestCase("Round C", "Round D")]
        public void TestCase5(string input, string expected)
        {
            Assert.AreEqual(input, expected);
        }

        [Test]
        [Combinatorial]
        public void TestCase6([Values(1,2)]int a, [Values("a","b")]string b)
        {
        }

        [Test]
        [Sequential]
        public void TestCase7([Values(1, 2, 3)]int a, [Values(3, 2, 1)]int b)
        {
            Assert.AreEqual(4, a + b);
        }

        [Test]
        public void TestCase8()
        { 
            
        }
    }
}

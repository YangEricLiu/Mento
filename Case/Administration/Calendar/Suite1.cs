using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            driverChrome.Url = "http://www.youdao.com";

            IWebElement textbox = driverChrome.FindElement(By.Id("query"));

            IWebElement submit = driverChrome.FindElement(By.ClassName("s-btn"));

            textbox.SendKeys("sss");

            submit.Click();

            Assert.IsTrue(driverChrome.PageSource.Contains("sss"));
        }

        [Test]
        public void TestCase3()
        { }
    }
}

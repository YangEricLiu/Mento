using Mento.Business.Plan.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mento.Business.Plan.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Mento.Business.Plan.Test
{
    
    
    /// <summary>
    ///This is a test class for ExecutionBLTest and is intended
    ///to contain all ExecutionBLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExecutionBLTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetTestSuiteResults
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Mento.Business.Plan.dll")]
        public void GetTestSuiteResultsTest()
        {
            ExecutionBL_Accessor target = new ExecutionBL_Accessor(); // TODO: Initialize to an appropriate value

            string workFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData"); // TODO: Initialize to an appropriate value
            long executionID = 54; // TODO: Initialize to an appropriate value

            List<ResultEntity> actual = target.GetTestSuiteResults(workFolder, executionID);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");

            Assert.AreEqual(12, actual.Count);

            Assert.IsTrue(actual.Where(r => !String.IsNullOrEmpty(r.FailDetail)).Max(r => r.FailDetail.Length) < 8000);
            Assert.IsTrue(actual.Where(r => !String.IsNullOrEmpty(r.FailReason)).Max(r => r.FailReason.Length) < 1024);
            Assert.AreEqual(actual.Where(r => !String.IsNullOrEmpty(r.ImageUrl) && r.ImageUrl.Length > 512).First().ImageUrl, "aa");
            Assert.AreEqual(actual.Where(r => !String.IsNullOrEmpty(r.ImageUrl)).Max(r => r.ImageUrl.Length), 512);
        }
    }
}

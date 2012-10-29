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
using Mento.Script.Calendar.TestData;
using System.IO;
using Mento.Framework.Script;


namespace Mento.Script.Administration.Hierarchy
{
    [TestFixture]
    public class HierarchyManagement : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
        }

        [TearDown]
        public void CaseTearDown()
        {
        }
    }
}

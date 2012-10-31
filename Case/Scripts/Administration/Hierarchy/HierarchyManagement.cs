﻿using System;
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
        [SetUp]
        public void CaseSetUp()
        {
            //OpenJazz()
            //Login()
            //NavigateToHierarchySetting()
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TA-Hierarchy-001"), CreateTime("2012-10-30"), Owner("Emma")]
        [MultipleTestDataSource(typeof(AddHierarchyData[]), typeof(HierarchyManagement), "TA-Hierarchy-001")]
        public void AddOrgnizationNode(HierarchyInputData input, ExpectedTestDataBase expected)
        {
            FunctionWrapper.hierarchy.AddHierarchyNode("Schneider", input);
            FunctionWrapper.hierarchy.ClickSaveButton();
            FunctionWrapper.hierarchy.WaitForCreateOKDisplay(120);

            ElementLocator.pause(500);

            FunctionWrapper.hierarchy.ConfirmCreateOKMagBox();
        }

    }
}
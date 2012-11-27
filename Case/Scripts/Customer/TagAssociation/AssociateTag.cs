using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;

namespace Mento.Script.Customer.TagAssociation
{
    public class AssociateTag : TestSuiteBase
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
            FunctionWrapper.Associate.NavigateToHierarchyAssociate();
            ElementLocator.Pause(2000);
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
        }

        [Test]
        [CaseID("TA-AssociateTag-001"), ManualCaseID("TJ-AssociateTag-001"), CreateTime("2012-11-09"), Owner("Emma")]
        public void AssociateOneTag()
        {
            FunctionWrapper.Hierarchy.FocusOnHierarchyNode("Schneider");
            ElementLocator.Pause(1000);

            FunctionWrapper.Associate.ClickAssociateTagButton();
            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(1000);

            FunctionWrapper.Associate.CheckedTag("test01");
            FunctionWrapper.Associate.ClickAssociateButton();
            FunctionWrapper.WaitForLoadingDisappeared(2000);
            ElementLocator.Pause(1000);

            Assert.IsTrue(FunctionWrapper.Associate.IsTagOnAssociategGridView("test01"));
        }
    }
}

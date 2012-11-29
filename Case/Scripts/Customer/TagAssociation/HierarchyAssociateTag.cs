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
using Mento.ScriptCommon.Library;

namespace Mento.Script.Customer.TagAssociation
{
    public class HierarchyAssociateTag : TestSuiteBase
    {
        private static HierarchyAssociateSettings Association = JazzFunction.HierarchyAssociateSettings;

        [TestFixtureSetUp]
        public void CaseFixtureSetUp()
        {
            //ElementLocator.OpenJazz();
            //FunctionWrapper.Login.Login();
        }

        [TestFixtureTearDown]
        public void CaseFixtureTearDown()
        {
            //ElementLocator.QuitJazz();
        }

        [SetUp]
        public void CaseSetUp()
        {
            //FunctionWrapper.Associate.NavigateToHierarchyAssociate();
            //ElementLocator.Pause(2000);
            Association.NavigateToHierarchyAssociate();
            TimeManager.PauseMedium();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TA-AssociateTag-001"), ManualCaseID("TJ-AssociateTag-001"), CreateTime("2012-11-09"), Owner("Emma")]
        public void AssociateOneTag()
        {
            //FunctionWrapper.Hierarchy.FocusOnHierarchyNode("Schneider");
            //ElementLocator.Pause(1000);
            Association.ExpandHierarchyNodePath(new string[] { "Schneider" });

            Association.ClickAssociateTagButton();
            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(1000);
            TimeManager.PauseShort();

            Association.CheckedTag("test01");
            Association.ClickAssociateButton();
            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(1000);
            TimeManager.PauseShort();

            Assert.IsTrue(Association.IsTagOnAssociategGridView("test01"));
        }
    }
}

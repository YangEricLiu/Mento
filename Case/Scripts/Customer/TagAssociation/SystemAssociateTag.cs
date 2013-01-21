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
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-31")]
    [ManualCaseID("TC-J1-SmokeTest-009")]
    public class SystemAssociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationSystemDimension);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-009-001")]
        [Priority("P1")]
        [Type(ScriptType.BVT)]
        public void AssociateOneTag()
        { 
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.ExpandHierarchyNodePath(new string[] { "自动化测试" });
            SystemSettings.SelectHierarchyNode("systemAssociate");

            SystemSettings.ExpandSystemDimensionNodePath(new string[] { "systemAssociate" });
            SystemSettings.SelectSystemDimensionNode("空调");

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            Association.CheckedTag("Add_V1");
            Association.ClickAssociateButton();
            TimeManager.ShortPause();

            Assert.IsTrue(Association.IsTagOnAssociategGridView("Add_V1"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("Add_V1"));
        }
    }
}

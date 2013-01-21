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

namespace Mento.Script.Customer.TagDisassociation
{
    [TestFixture]
    [Owner("Nancy")]
    [CreateTime("2012-01-06")]
    [ManualCaseID("TC-J1-SmokeTest-012")]
    public class SystemDisassociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static SystemDimensionSettings SystemSettings = JazzFunction.SystemDimensionSettings;
        private static DisassociateSettings Disassociation = JazzFunction.DisassociateSettings;

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
        [CaseID("TC-J1-SmokeTest-012-001")]
        [Priority("P1")]
        [Type(ScriptType.BVT)]
        public void DisassociateOneTag()
        { 
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.ExpandHierarchyNodePath(new string[] { "自动化测试" });
            SystemSettings.SelectHierarchyNode("systemAssociate");

            SystemSettings.ExpandSystemDimensionNodePath(new string[] { "systemAssociate" });
            SystemSettings.SelectSystemDimensionNode("空调");

            Disassociation.FocusOnTag("Add_V1");
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("Add_V1"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView("Add_V1"));
        }
    }
}

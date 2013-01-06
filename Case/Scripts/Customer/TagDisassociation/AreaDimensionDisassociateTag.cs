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
    [CreateTime("2013-01-06")]
    [ManualCaseID("TC-J1-SmokeTest-012")]
    public class AreaDimensionDisassociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private static DisassociateSettings Disassociation = JazzFunction.DisassociateSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-014")]
        public void DisassociateOneTag()
        {
            AreaSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "自动化测试", "systemAssociate" });
            AreaSettings.SelectHierarchyNode("AreaDimension");

            AreaSettings.ExpandAreaDimensionNodePath(new string[] { "AreaDimension" });
            AreaSettings.SelectAreaDimensionNode("FirstFloor");

            Disassociation.FocusOnTag("AddforAreaAssociate");
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

        }
    }
}

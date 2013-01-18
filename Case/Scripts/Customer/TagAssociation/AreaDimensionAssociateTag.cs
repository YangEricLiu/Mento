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
    [ManualCaseID("TC-J1-SmokeTest-010")]
    public class AreaDimensionAssociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-010-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AssociateOneTag()
        {
            AreaSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "自动化测试", "systemAssociate" });
            AreaSettings.SelectHierarchyNode("AreaDimension");

            AreaSettings.ExpandAreaDimensionNodePath(new string[] { "AreaDimension" });
            AreaSettings.SelectAreaDimensionNode("FirstFloor");

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            Association.CheckedTag("AddforAreaAssociate");
            Association.ClickAssociateButton();
            TimeManager.ShortPause();

            Assert.IsTrue(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));
        }
    }
}

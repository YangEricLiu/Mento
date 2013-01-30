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
    [ManualCaseID("TC-J1-SmokeTest-013")]
    public class AreaDimensionDisassociateTagSuite : TestSuiteBase
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-013-001")]
        [Priority("29")]
        [Type("BVT")]
        public void DisassociateOneTag()
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"->"AddCalendarProperty"->"AddPeopleProperty"
            ///                  And "FirstFloor" area dimension added
            ///               2. make sure tag "AddforAreaAssociate" has been added and associate to "FirstFloor"
            /// </summary> 
            ///
            //Select hierarchy node "AddPeopleProperty"
            AreaSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "自动化测试", "systemAssociate" });
            AreaSettings.SelectHierarchyNode("AreaDimension");

            AreaSettings.ExpandAreaDimensionNodePath(new string[] { "AreaDimension" });
            AreaSettings.SelectAreaDimensionNode("FirstFloor");

            //Select area dimension node "FirstFloor" and click associate tag button
            Disassociation.FocusOnTag("AddforAreaAssociate");

            //Verify the tag is not on associated tag list
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

            //Verify the tag is on disassociated tag list
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

        }
    }
}

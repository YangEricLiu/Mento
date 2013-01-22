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
    public class AreaDimensionAssociateTagSuite : TestSuiteBase
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
        [Priority("26")]
        [Type(ScriptType.BVT)]
        public void AssociateOneTag()
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"->"AddCalendarProperty"->"AddPeopleProperty"
            ///                  And "FirstFloor" area dimension added
            ///               2. make sure tag "AddforAreaAssociate" has been added for associate
            /// Prepare Data: 1. associate tag for the case to disassociate tag
            /// </summary> 
            /// 
            //Select hierarchy node "AddPeopleProperty"
            AreaSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "自动化测试", "AddCalendarProperty" });
            AreaSettings.SelectHierarchyNode("AddPeopleProperty");

            //Select area dimension node "FirstFloor" and click associate tag button
            AreaSettings.ExpandAreaDimensionNodePath(new string[] { "AddPeopleProperty" });
            AreaSettings.SelectAreaDimensionNode("FirstFloor");

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            //select tag "AddforAreaAssociate" and click associate button to associate
            Association.CheckedTag("AddforAreaAssociate");
            
            //Verify the tag is  display on associated tag list
            //And not display on disassociate tag list
            Association.ClickAssociateButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("AddforAreaAssociate"));
        }
    }
}

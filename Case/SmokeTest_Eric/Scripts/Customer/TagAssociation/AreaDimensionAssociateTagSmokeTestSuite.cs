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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.TagAssociation
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-31")]
    [ManualCaseID("TC-J1-SmokeTest-010")]
    public class AreaDimensionAssociateTagSmokeTestSuite : TestSuiteBase
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
        [CaseID("TC-J1-SmokeTest-AssociateTag-003")]
        [Priority("26")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(AreaDimensionAssociateTagSmokeTestSuite), "TC-J1-SmokeTest-AssociateTag-003")]
        public void SmokeTestAssociateAreaTag(AssociateTagData input)
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
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Select area dimension node "FirstFloor" and click associate tag button);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaDimensionPath);

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            //select tag "AddforAreaAssociate" and click associate button to associate
            Association.CheckedTag(input.InputData.TagName);
            
            //Verify the tag is  display on associated tag list
            //And not display on disassociate tag list
            Association.ClickAssociateButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView(input.InputData.TagName));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView(input.InputData.TagName));
        }
    }
}

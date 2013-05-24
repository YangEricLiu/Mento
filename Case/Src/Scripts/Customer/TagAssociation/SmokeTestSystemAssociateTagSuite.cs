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
    [ManualCaseID("TC-J1-SmokeTest-009")]
    public class SmokeTestSystemAssociateTagSuite : TestSuiteBase
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
        [CaseID("TC-J1-SmokeTest-AssociateTag-002")]
        [Priority("25")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(SmokeTestSystemAssociateTagSuite), "TC-J1-SmokeTest-AssociateTag-002")]
        public void SmokeTestAssociateSystemTag(AssociateTagData input)
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"->"systemAssociate"
            ///                  And "空调" system dimension checked
            ///               2. make sure tag "Add_V1" has been added for associate
            /// Prepare Data: 1. associate tag for the case to disassociate tag
            /// </summary> 
            /// 
            //Select hierarchy node "自动化测试"->"systemAssociate"
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.SystemDimensionPath);

            //Select system dimension "空调"
            SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);

            //Click associate tag button
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            //select tag "Add_V1" and click associate button to associate
            Association.CheckedTag(input.InputData.TagName);
            Association.ClickAssociateButton();
            TimeManager.ShortPause();

            //Verify the tag is  display on associated tag list
            //And not display on disassociate tag list
            Assert.IsTrue(Association.IsTagOnAssociategGridView(input.InputData.TagName));
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView(input.InputData.TagName));
        }
    }
}

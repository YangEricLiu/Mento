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
    [Owner("Nancy")]
    [CreateTime("2012-01-06")]
    [ManualCaseID("TC-J1-SmokeTest-012")]
    public class SystemDisassociateTagSmokeTestSuite : TestSuiteBase
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
        [CaseID("TC-J1-SmokeTest-DisassociateTag-002")]
        [Priority("28")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(SystemDisassociateTagSmokeTestSuite), "TC-J1-SmokeTest-DisassociateTag-002")]
        public void DisassociateOneTag(AssociateTagData input)
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added "自动化测试"->"systemAssociate"
            ///                  And "空调" system dimension checked
            ///               2. make sure tag "Amy_m_V1_Vtagconst1" has been added and associate to "空调"
            /// </summary> 
            ///
            //Select hierarchy node "自动化测试"->"systemAssociate"
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);

            //Select system dimension "空调"
            SystemSettings.SelectSystemDimensionNodePath(input.InputData.SystemDimensionPath);

            //Select associated tag and click "disassociate" button
            Disassociation.FocusOnTag(input.InputData.TagName);

            //Verify the tag is not on associated tag list
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView(input.InputData.TagName));

            //Verify the tag is on disassociated tag list
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView(input.InputData.TagName));
        }
    }
}

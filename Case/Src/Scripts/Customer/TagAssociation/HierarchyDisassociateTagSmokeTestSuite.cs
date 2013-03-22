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
    [CreateTime("2012-11-09")]
    [ManualCaseID("TC-J1-SmokeTest-011")]
    public class HierarchyDisassociateTagSmokeTestSuite : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;
        private static DisassociateSettings Disassociation = JazzFunction.DisassociateSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Association.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-DisassociateTag-001")]
        [Priority("27")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(HierarchyDisassociateTagSmokeTestSuite), "TC-J1-SmokeTest-DisassociateTag-001")]
        public void DisassociateOneTag(AssociateTagData input)
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"
            ///               2. make sure tag "Amy_m_V1_Vtagconst1" has been added and associate to "自动化测试"
            /// </summary> 
            ///
            //Select hierarchy node 
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            //Select associated tag and click "disassociate" button
            Disassociation.FocusOnTag(input.InputData.TagName);
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();

            //Verify the tag is on disassociated tag list
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView(input.InputData.TagName));

            //Verify the tag is not on associated tag list
            Disassociation.ClickAssociatedCancel();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView(input.InputData.TagName));
        }
    }
}

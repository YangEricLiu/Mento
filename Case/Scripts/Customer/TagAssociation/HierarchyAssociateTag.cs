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
    [CreateTime("2012-11-09")]
    [ManualCaseID("TC-J1-SmokeTest-008")]
    public class HierarchyAssociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;

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
        [CaseID("TC-J1-SmokeTest-008-001")]
        [Priority("P1")]
        [Type(ScriptType.BVT)]
        public void AssociateOneTag()
        {
            Association.SelectHierarchyNode("自动化测试");

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

            Association.CheckedTag("Amy_m_V1_Vtagconst1");
            Association.ClickAssociateButton();
            TimeManager.ShortPause();

            Assert.IsTrue(Association.IsTagOnAssociategGridView("Amy_m_V1_Vtagconst1"));

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("Amy_m_V1_Vtagconst1"));
        }
    }
}

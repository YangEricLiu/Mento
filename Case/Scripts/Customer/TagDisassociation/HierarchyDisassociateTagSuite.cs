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
    [CreateTime("2012-11-09")]
    [ManualCaseID("TC-J1-SmokeTest-011")]
    public class HierarchyDisassociateTagSuite : TestSuiteBase
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
        [CaseID("TA-DisassociateTag-001-001")]
        [Priority("27")]
        [Type(ScriptType.BVT)]
        public void DisassociateOneTag()
        {
            Association.SelectHierarchyNode("自动化测试");
            TimeManager.ShortPause();

            Disassociation.FocusOnTag("Amy_m_V1_Vtagconst1");
            Disassociation.ClickDisassociateButton();
            TimeManager.ShortPause();

            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();
            Assert.IsTrue(Association.IsTagOnAssociategGridView("Amy_m_V1_Vtagconst1"));

            Disassociation.ClickAssociatedCancel();
            TimeManager.ShortPause();
            Assert.IsFalse(Association.IsTagOnAssociategGridView("Amy_m_V1_Vtagconst1"));
        }
    }
}

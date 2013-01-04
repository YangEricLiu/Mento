﻿using System;
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
    [ManualCaseID("TC-J1-SmokeTest-015")]
    public class HierarchyAssociateTag : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;

        [SetUp]
        public void CaseSetUp()
        {
            //FunctionWrapper.Associate.NavigateToHierarchyAssociate();
            //ElementLocator.Pause(2000);
            Association.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-AssociateTag-001")]
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

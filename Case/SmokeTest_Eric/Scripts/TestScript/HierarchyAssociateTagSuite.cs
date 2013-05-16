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
using Mento.ScriptCommon.TestData.SmokeTest;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.TestScript.TagAssociation
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-13")]
    [ManualCaseID("TA-Smoke-TagMap-001")]
    public class HierarchyAssociateTagSuite : TestSuiteBase
    {
        private static AssociateSettings Association = JazzFunction.AssociateSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "Auto_Customer");

            Association.NavigateToHierarchyAssociate();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TA-Smoke-TagMap-001-001")]
        [Priority("24")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(AssociateTagData[]), typeof(HierarchyAssociateTagSuite), "TA-Smoke-TagMap-001-001")]
        public void SmokeTestAssociateHierarchyTag(AssociateTagData input)
        {
            /// <summary>
            /// Precondition: 1. make sure the hiearchy node has been added  "自动化测试"
            ///               2. make sure tag "Amy_m_V1_Vtagconst1" has been added for associate
            /// Prepare Data: 1. associate tag for the case to disassociate tag
            /// </summary> 
            /// 
            //Click hierarchy node and click associate tag button
            Association.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            Association.ClickAssociateTagButton();
            TimeManager.ShortPause();

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
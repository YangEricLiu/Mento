﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Utility;
using Mento.Framework.Attributes;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Aries")]
    [CreateTime("2012-11-19")]
    [ManualCaseID("TC-J1-SmokeTest-015")]
    public class AreaDimensionSuite : TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-015-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void CreateAreaDimension()
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            var randomString = Generate.Random<string>();
            var testArea = new { Name = "AutoArea" + randomString, Comment = "Auto area " + randomString };

            ////Select a Building node.	
            ////The Area dimension is light and enable to select.
            TimeManager.ShortPause();
            
            ////Select a Building node.	
            ////The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "自动化测试", "12345" });
            AreaSettings.SelectHierarchyNode("124");

            //AreaSettings.ExpandAreaDimensionNodePath(new string[] { "124" });
            AreaSettings.SelectAreaDimensionNode("124");


            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: area001, comment: auto test ,Click ""save"" button"	
            //Add Area node successfully.
            AreaSettings.FillAreaDimensionData(testArea.Name, testArea.Comment);
            AreaSettings.ClickSaveButton();

            TimeManager.ShortPause();

            Assert.IsTrue(AreaSettings.IsShownSuccessMessage());

            AreaSettings.CloseSuccessMessage();

            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), testArea.Name);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(), testArea.Comment);
        }
    }
}
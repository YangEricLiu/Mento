using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.Library;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.TestData.SmokeTest;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.TestScript.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-13")]
    [ManualCaseID("TA-Smoke-SystemDimension-001")]
    public class SystemDimensionSmokeTestSuite : TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "Auto_Customer");

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// PrepareData: 1. Associated system dimension for next case 
        /// </summary> 
        [Test]
        [CaseID("TA-Smoke-SystemDimension-001-001")]
        [Priority("14")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(SystemDimensionSmokeTestSuite), "TA-Smoke-SystemDimension-001-001")]
        public void SmokeTestAssoicateSystemDimension(SystemDimensionData input)
        { 
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            //Display hierarchy tree -> click hierarchy node "自动化测试" -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.Associate Level 1 dimension node by select the checkbox: Select ‘空调’ checkbox.
            //The Level 1 dimension node ('空调') is associated.
            //3.Associate Level 2 dimension node by select the checkbox: Select ‘冷热源’ checkbox.
            //The Level 2 dimension node ('冷热源') is associated.
            //4.Associate Level 3 dimension node by select the checkbox: Select ‘供冷主机’ checkbox.
            //The Level 3 dimension node ('供冷主机') is associated.
            SystemSettings.CheckSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.CloseSystemDimensionDialog();

            //Expand system dimension tree and verify
            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }
    }
}

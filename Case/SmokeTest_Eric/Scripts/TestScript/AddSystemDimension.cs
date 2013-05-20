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
using Mento.ScriptCommon.TestData.Customer;
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
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            
        }

        [Test]
        [CaseID("TA-Smoke-SystemDimension-001-001")]  
        [MultipleTestDataSource(typeof(SystemDimensionData[]), typeof(SystemDimensionSmokeTestSuite), "TA-Smoke-SystemDimension-001-001")]
        public void SmokeTestAssoicateSystemDimension(SystemDimensionData input)
        { 
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            SystemSettings.CheckSystemDimensionNodePath(input.InputData.SystemDimensionItemPath);
            SystemSettings.CloseSystemDimensionDialog();

            SystemSettings.SelectSystemDimensionNodePath(input.ExpectedData.SystemDimensionPath);
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed(input.InputData.SystemDimensionItemPath.Last()));
        }
    }
}

using System;
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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.TestScript.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-13")]
    [ManualCaseID("TA-Smoke-AreaDimension-001")]
    public class AreaDimensionSmokeTestSuite : TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            
        }
       
        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-AreaDimension-001-001")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(AreaDimensionSmokeTestSuite), "TA-Smoke-AreaDimension-001-001")]
        public void SmokeTestAddAreaDimension(AreaDimensionData input)
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
        
            TimeManager.ShortPause();
            
            AreaSettings.ShowHierarchyTree();
            AreaSettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);

            AreaSettings.ClickCreateAreaDimensionButton();

            AreaSettings.FillAreaDimensionData(input.InputData.CommonName, input.InputData.Comments);
            AreaSettings.ClickSaveButton();

            TimeManager.ShortPause();

            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), input.InputData.CommonName);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(), input.InputData.Comments);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using OpenQA.Selenium;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Customer.HierarchySettings
{
    [TestFixture]
    public class SystemDimensionSuite : TestSuiteBase
    {
        [SetUp]
        public void ScriptSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        public void UpdateSystemDimension()
        {
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            //1.Select the org/site/building node from hierarchy tree.
            //The system dimension tree for the selected hierarchy node is displayed.
            SystemSettings.ShowHierarchyTree();
            SystemSettings.ExpandHierarchyNodePath(new string[] { "Schneider" });
            SystemSettings.SelectHierarchyNode("12345");

            SystemSettings.ShowSystemDimensionDialog();

            //2.Associate Level 1 dimension node by select the checkbox: Select ‘空调’ checkbox.
            //The Level 1 dimension node ('空调') is associated.
            //3.Associate Level 2 dimension node by select the checkbox: Select ‘冷热源’ checkbox.
            //The Level 2 dimension node ('冷热源') is associated.
            //4.Associate Level 3 dimension node by select the checkbox: Select ‘供冷主机’ checkbox.
            //The Level 3 dimension node ('供冷主机') is associated.

            SystemSettings.CheckSystemDimensionNodePath(new string[] { "空调", "冷热源", "供冷主机" });

            SystemSettings.CloseSystemDimensionDialog();
        }
    }
}

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
using Mento.Framework.Attributes;

namespace Mento.Script.Customer.HierarchySettings
{
    [TestFixture]
    [Owner("Aries")]
    [CreateTime("2012-11-19")]
    [ManualCaseID("TC-J1-SmokeTest-013")]
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
        [CaseID("TC-J1-SmokeTest-013")]
        public void UpdateSystemDimension()
        {
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            //1.Select the org/site/building node from hierarchy tree.
            //The system dimension tree for the selected hierarchy node is displayed.

            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            //SystemSettings.ExpandHierarchyNodePath(new string[] { "自动化测试" });
            SystemSettings.SelectHierarchyNode("自动化测试");

            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

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

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

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Aries")]
    [CreateTime("2012-11-19")]
    [ManualCaseID("TC-J1-SmokeTest-014")]
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
            JazzFunction.Navigator.NavigateHome();
        }

        /// <summary>
        /// PrepareData: 1. Associated system dimension for next case 
        /// </summary> 
        [Test]
        [CaseID("TC-J1-SmokeTest-014-001")]
        [Priority("14")]
        [Type("BVT")]
        public void AssoicateSystemDimension()
        { 
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            //Display hierarchy tree -> click hierarchy node "自动化测试" -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
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

            //Expand system dimension tree and verify
            SystemSettings.ExpandSystemDimensionNodePath(new string[] { "自动化测试", "空调", "冷热源" });
            Assert.IsTrue(SystemSettings.IsSystemDimensionNodeDisplayed("供冷主机"));
        }

        /// <summary>
        /// Precondition: 1. Disssociated system dimension from last case
        /// </summary> 
        [Test]
        [CaseID("TC-J1-SmokeTest-014-002")]
        [Priority("15")]
        [Type("BVT")]
        public void DisassoicateSystemDimension()
        {
            var SystemSettings = JazzFunction.SystemDimensionSettings;

            //Display hierarchy tree -> click hierarchy node "自动化测试" -> open system dimension dialog
            SystemSettings.ShowHierarchyTree();
            TimeManager.ShortPause();
            SystemSettings.SelectHierarchyNode("自动化测试");
            SystemSettings.ShowSystemDimensionDialog();
            TimeManager.MediumPause();

            //2.Disassociate Level 3 dimension node by select the checkbox: Select ‘供冷主机’ checkbox.
            //The Level 3 dimension node ('供冷主机') is Disassociated.
            //3.Disassociate Level 2 dimension node by select the checkbox: Select ‘冷热源’ checkbox.
            //The Level 2 dimension node ('冷热源') is Disassociated.
            //4.Disassociate Level 1 dimension node by select the checkbox: Select ‘空调’ checkbox.
            //The Level 1 dimension node ('空调') is Disassociated.

            SystemSettings.UncheckSystemDimensionNodePath(new string[] { "空调", "冷热源", "供冷主机" });
            SystemSettings.CloseSystemDimensionDialog();

            //Expand system dimension tree and verify
            SystemSettings.ExpandSystemDimensionNodePath(new string[] { "自动化测试" });
            Assert.IsFalse(SystemSettings.IsSystemDimensionNodeDisplayed("空调"));
            Assert.IsFalse(SystemSettings.IsSystemDimensionNodeDisplayed("冷热源"));
            Assert.IsFalse(SystemSettings.IsSystemDimensionNodeDisplayed("供冷主机"));
        }
    }
}

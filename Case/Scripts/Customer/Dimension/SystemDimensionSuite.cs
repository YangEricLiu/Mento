using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library.Functions;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface.NewControls;
using Mento.ScriptCommon.Library.Controls;

namespace Mento.Script.Customer.Dimension
{
    [TestFixture]
    public class SystemDimensionSuite : TestSuiteBase
    {
        private static Navigator Navigator = ControlAccess.GetControl<Navigator>();

        [SetUp]
        public void ScriptSetUp()
        {
            //ElementLocator.OpenJazz();

            FunctionWrapper.Login.Login();

            //Navigator.NavigateHome();
            //Navigator.NavigateToTarget(NavigationTarget.EnergyView);

            Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);           
        }

        [TearDown]
        public void ScriptTearDown()
        {
            Navigator.NavigateToTarget(NavigationTarget.EnergyView);

            LoadingMask.WaitLoading();
        }

        [Test]
        [TestCase]
        [TestCase]
        [TestCase]
        public void AssociateSystemDimension()
        {
            //1.Select the org/site/building node from hierarchy tree.
            //The system dimension tree for the selected hierarchy node is displayed.
            //2.Associate Level 1 dimension node by select the checkbox: Select ‘空调’ checkbox.
            //The Level 1 dimension node ('空调') is associated.
            //3.Associate Level 2 dimension node by select the checkbox: Select ‘冷热源’ checkbox.
            //The Level 2 dimension node ('冷热源') is associated.
            //4.Associate Level 3 dimension node by select the checkbox: Select ‘供冷主机’ checkbox.
            //The Level 3 dimension node ('供冷主机') is associated.
            TimeManager.PauseShort();

            JazzButton selectHierarchyButton = new JazzButton(JazzButtonNames.DimensionSelectHierarchyButton);
            selectHierarchyButton.Click();
                        
            HierarchyTree hierarchy = JazzControl.GetControl<HierarchyTree>();
            hierarchy.WaitForMe(WaitType.ToAppear);

            hierarchy.ClickNode("Schneider");

            TimeManager.PauseShort();

            JazzButton updateSystemDimensionButton = new JazzButton(JazzButtonNames.SystemDimensionUpdateButton);
            //instead of validate system dimension tree, here validates update system dimension button
            Assert.IsTrue(updateSystemDimensionButton.Exists() && updateSystemDimensionButton.IsEnabled());
            updateSystemDimensionButton.Click();

            var systemDimensionTree = new SystemDimensionTree(isInDialog: true);
            systemDimensionTree.WaitForMe(WaitType.ToAppear);
            systemDimensionTree.CheckNodePath(new string[] { "空调", "冷热源", "供冷主机" });

            //return
            ElementLocator.FindElement(new Locator("st-sys-configtree-goback-btnEl", ByType.ID)).Click();
        }
    }
}

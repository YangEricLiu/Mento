using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using OpenQA.Selenium;
using Mento.ScriptCommon.Library.Controls;
using Mento.TestApi.WebUserInterface.NewControls;

namespace Mento.Script.Customer.Dimension
{
    [TestFixture]
    public class AreaDimensionSuite : TestSuiteBase
    {
        private static Navigator Navigator = ControlAccess.GetControl<Navigator>();

        [SetUp]
        public void ScriptSetUp()
        {
            FunctionWrapper.Login.Login();

            Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            Navigator.NavigateToTarget(NavigationTarget.EnergyView);

            LoadingMask.WaitLoading();
        }

        [Test]
        public void CreateAreaDimension()
        {
            ////Select a Building node.	
            ////The Area dimension is light and enable to select.
            TimeManager.PauseShort();

            JazzButton selectHierarchyButton = new JazzButton(JazzButtonNames.DimensionSelectHierarchyButton);
            selectHierarchyButton.Click();
            
            HierarchyTree hierarchy = JazzControl.GetControl<HierarchyTree>();
            hierarchy.WaitForMe(WaitType.ToAppear);

            hierarchy.ExpandNodePath(new string[] { "Schneider", "12345" });

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.


            //"Input  area name: area001, comment: auto test ,Click ""save"" button"	
            //Add Area node successfully.

        }
    }
}

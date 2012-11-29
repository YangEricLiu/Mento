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

namespace Mento.Script.Customer.Dimension
{
    [TestFixture]
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
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        public void CreateAreaDimension()
        {
            var AreaSettings = JazzFunction.AreaDimensionSettings;
            var testArea = new { Name = "area001", Comment = "auto test" };

            ////Select a Building node.	
            ////The Area dimension is light and enable to select.
            TimeManager.PauseShort();
            
            ////Select a Building node.	
            ////The Area dimension is light and enable to select.
            AreaSettings.ShowHierarchyTree();
            AreaSettings.ExpandHierarchyNodePath(new string[] { "Schneider", "12345" });

            //Click "子区域" button to add Area node.	
            //The Area property display and enable to input.
            AreaSettings.ClickCreateAreaDimensionButton();

            //"Input  area name: area001, comment: auto test ,Click ""save"" button"	
            //Add Area node successfully.
            AreaSettings.FillAreaDimensionData(testArea.Name, testArea.Comment);
            AreaSettings.ClickSaveButton();

            Assert.IsTrue(AreaSettings.IsShownSuccessMessage());

            AreaSettings.CloseSuccessMessage();

            Assert.AreEqual(AreaSettings.GetAreaDimensionName(), testArea.Name);
            Assert.AreEqual(AreaSettings.GetAreaDimensionComment(), testArea.Comment);
        }
    }
}

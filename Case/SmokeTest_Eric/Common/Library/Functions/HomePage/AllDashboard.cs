using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;


namespace Mento.ScriptCommon.Library.Functions
{
    public class AllDashboard
    {
        #region Controls
        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.AllDashboardSelectHierarchyButton;
        private static HierarchyTree HierarchyTree = JazzTreeView.AllDashboardHierarchyTree;
              
        #endregion

        private Button GetGridAllDashboardListIcon(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.GridAllDashboardListIcon, positionIndex);
        }
        private Button GetGridAllDashboardListText(int positionIndex)
        {
            return JazzButton.GetOneButton(JazzControlLocatorKey.GridAllDashboardListText, positionIndex);
        }

        #region Hierarchy operations
        public void SelectHierarchy(string[] hierarchyNames)
        {
            SelectHierarchyButton.Click();

            HierarchyTree.SelectNode(hierarchyNames);
        }
        public void ClickDashboardIcon(int positionIndex)
        {
            GetGridAllDashboardListIcon(positionIndex).Click();
        }
        public void ClickDashboardText(int positionIndex)
        {
            GetGridAllDashboardListText(positionIndex).Click();
        }
        #endregion
        #region operations
      
        #endregion
    }
}

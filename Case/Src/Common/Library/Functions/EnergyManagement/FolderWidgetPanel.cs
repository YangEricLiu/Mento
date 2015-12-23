using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.Framework.Exceptions;
using Mento.ScriptCommon.Library.Functions.EnergyManagement;
using System.Collections;
using Mento.Framework.Configuration;
using System.IO;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public class FolderWidgetPanel
    {
        #region New Jazz

        #region New Jazz Controls

        private static HierarchyTree NewJazzFolderTree = JazzTreeView.NewJazzFolderTree;

        #endregion

        public void NewJazz_SelectFolderOrWidget(string[] folderNames)
        {
            NewJazzFolderTree.NewJazz_SelectFolderOrWidget(folderNames);
        }

        #region tree opertion

        public widgetsPath[] GetAllWidgetsPath()
        {
            List<widgetsPath> widgetsPath = new List<widgetsPath>();

            TreeNode[] treeNodes = NewJazzFolderTree.NewJazz_GetAllWidgetsOfTree();

            foreach (TreeNode node in treeNodes)
            {
                List<string> combatStringArray = new List<string>();

                foreach (string path in node.nodePath)
                {                
                    combatStringArray.Add(path);
                }

                foreach (string widget in node.widgets)
                {
                    combatStringArray.Add(widget);

                    widgetsPath oneWidget = new widgetsPath();
                    oneWidget.widgetPath = combatStringArray.ToArray();

                    widgetsPath.Add(oneWidget);

                    combatStringArray.Remove(widget);
                }
            }

            return widgetsPath.ToArray();
        }

        public widgetsPath[] GetWidgetsPathOfFolder(string[] folderPath)
        {
            List<widgetsPath> widgetsPath = new List<widgetsPath>();

            string[] widgets = NewJazzFolderTree.NewJazz_GetChildrenOfFolder(folderPath);


            List<string> combatStringArray = new List<string>();

            foreach (string path in folderPath)
            {
                combatStringArray.Add(path);
            }

            foreach (string widget in widgets)
            {
                combatStringArray.Add(widget);

                widgetsPath oneWidget = new widgetsPath();
                oneWidget.widgetPath = combatStringArray.ToArray();

                widgetsPath.Add(oneWidget);

                combatStringArray.Remove(widget);
            }


            return widgetsPath.ToArray();
        }

        #endregion

        #endregion

    }

    public class widgetsPath
    {
        public  string[] widgetPath;
    }
        
}

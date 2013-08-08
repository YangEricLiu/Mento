using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class SaveToDashboardDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'widgetsavewindow') and contains(@class,'x-window')]", ByType.XPath);
        
        internal SaveToDashboardDialog() : base(Locator) { }

        //Widget name textbox
        private static TextField WidgetNameTextbox = JazzTextField.EnergyViewSaveDashboardWidgetNameTextField;

        //Hierarchy name select
        private static Button WidgetSaveHierarchy = JazzButton.WidgetSaveHierarchyButton;

        private static HierarchyTree WidgetSaveHierarchyTree = JazzTreeView.WidgetSaveHierarchyTree;

        //Dashboard select
        private static ComboBox DashboardComboBox = JazzComboBox.EnergyViewSaveDashboardDashboardComboBox;

        //Create dashboard link
        private static Button CreateDashboardButton = JazzButton.CreateNewDashboardButton;

        //Dashboard name textbox
        private static TextField DashboardNameTextbox = JazzTextField.EnergyViewSaveDashboardDashboardNameTextField;

        public void Save(string widgetName, string[] hierarchyNamePath, bool isCreateDashboard, string dashboardName)
        {
            WidgetNameTextbox.Fill(widgetName);
            WidgetSaveHierarchy.Click();
            WidgetSaveHierarchyTree.SelectNode(hierarchyNamePath);
            TimeManager.LongPause();
            if (isCreateDashboard)
            {
                CreateDashboardButton.Click();
                DashboardNameTextbox.Fill(dashboardName);
            }
            else
            {
                DashboardComboBox.SelectItem(dashboardName);
            }

            base.Confirm();
        }
    }
}

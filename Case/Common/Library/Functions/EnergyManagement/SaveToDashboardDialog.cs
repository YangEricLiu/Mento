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
        private static ComboBox HierarchyComboBox = JazzComboBox.EnergyViewSaveDashboardHierarchyComboBox;

        //Dashboard select
        private static ComboBox DashboardComboBox = JazzComboBox.EnergyViewSaveDashboardDashboardComboBox;

        //Create dashboard link
        private static LinkButton CreateDashboardButton = JazzButton.EnergyViewSaveDashboardCreateDashboardButton;

        //Dashboard name textbox
        private static TextField DashboardNameTextbox = JazzTextField.EnergyViewSaveDashboardDashboardNameTextField;

        public void Save(string widgetName, string hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            WidgetNameTextbox.Fill(widgetName);
            HierarchyComboBox.SelectItem(hierarchyName);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class SaveToDashboardDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'widgetsavewindow') and contains(@class,'x-window')]", ByType.XPath);
        
        public SaveToDashboardDialog() : base(Locator) { }

        //Widget name textbox
        private static TextField WidgetNameTextbox = JazzTextField.EnergyViewSaveDashboardWidgetNameTextField;

        //Hierarchy name select
        private static Button WidgetSaveHierarchy = JazzButton.WidgetSaveHierarchyButton;

        private static HierarchyTree WidgetSaveHierarchyTree = JazzTreeView.WidgetSaveHierarchyTree;

        //Dashboard select
        private static ComboBox DashboardComboBox = JazzComboBox.EnergyViewSaveDashboardDashboardComboBox;

        //Create dashboard link
        private static RadioButton CreateDashboardButton = JazzButton.CreateNewDashboardButton;

        //Existed dashboard link
        private static RadioButton ExistedDashboardButton = JazzButton.ExistedDashboardButton;

        //Dashboard name textbox
        private static TextField DashboardNameTextbox = JazzTextField.EnergyViewSaveDashboardDashboardNameTextField;

        //Widget annotation
        private static TextField WidgetAnnotationTextArea = JazzTextField.WidgetAnnotationTextField;

        //no hierarchy selected txt
        private static Label SaveDashboardDialogHierarchy = JazzLabel.SaveDashboardDialogHierarchyLabel;

        public void Save(string widgetName, string[] hierarchyNamePath, bool isCreateDashboard, string dashboardName)
        {
            WidgetNameTextbox.Fill(widgetName);
            WidgetSaveHierarchy.Click();
            if (hierarchyNamePath != null)
            {
                WidgetSaveHierarchyTree.SelectNode(hierarchyNamePath); 
            }   
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

        public void SaveThenCancel(string widgetName, string[] hierarchyNamePath, bool isCreateDashboard, string dashboardName)
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

            base.Cancel();
        }

        public void SaveWithAnnotation(string widgetName, string[] hierarchyNamePath, bool isCreateDashboard, string dashboardName, string comment)
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

            WidgetAnnotationTextArea.Fill(comment);
            TimeManager.ShortPause();

            base.Confirm();
        }

        public void FillWidgetName(string widgetName)
        {
            WidgetNameTextbox.Fill(widgetName);
        }

        public bool IsWidgetNameInvalid()
        {
            return WidgetNameTextbox.IsTextFieldValueInvalid();
        }

        public string GetWidgetNameInvalidMsg()
        {
            return WidgetNameTextbox.GetInvalidTips();
        }

        public void SelectSaveHierarhcyNode(string[] hierarchyNamePath)
        {
            WidgetSaveHierarchy.Click();
            WidgetSaveHierarchyTree.SelectNode(hierarchyNamePath);
            TimeManager.LongPause();
        }

        public void ClickCreateNewDashboardButton()
        {
            CreateDashboardButton.Click();
        }

        public void FillDashboard(string dashboardName)
        {
            DashboardNameTextbox.Fill(dashboardName);
        }

        public string GetNewDashboardMsg()
        {
            return DashboardNameTextbox.GetInvalidTips();
        }

        public void SelectDashboard(string dashboardName)
        {
            DashboardComboBox.SelectItem(dashboardName);
        }

        public string GetExistedDashboardMsg()
        {
            return DashboardComboBox.GetInvalidTips();
        }

        public void ClickSaveButton()
        {
            base.Confirm();
        }

        public void ClickCancelButton()
        {
            base.Cancel();
        }

        public bool IsCreateNewDashboardButtonDisabled()
        {
            return CreateDashboardButton.IsRadioButtonDisabled();
        }

        public bool IsExistedDashboardButtonChecked()
        {
            return ExistedDashboardButton.IsRadioButtonChecked();
        }

        public string GetCreateNewDashboardText()
        {
            return CreateDashboardButton.GetRadioButtonLabel();
        }

        public string GetUnselectHierarchyMsg()
        {
            return SaveDashboardDialogHierarchy.GetLabelTextValue();
        }
    }
}

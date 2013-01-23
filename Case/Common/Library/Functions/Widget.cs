using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.EnergyView;

namespace Mento.ScriptCommon.Library.Functions
{
    public class Widget
    {
        internal Widget()
        {
        }

        private static LinkButton DashboardHierarchyNameButton = JazzButton.DashboardHierarchyNameButton;
        private static Button ModifyWidgetNameButton = JazzButton.ButtonModifyWidgetName;
        private static Button ModifyWidgetNameSaveButton = JazzButton.ModifyWidgetNameSaveButton;
        private static Button ModifyWidgetNameCancelButton = JazzButton.ModifyWidgetNameCancelButton;
        private static Button DeleteWidgetButton = JazzButton.ButtonDeleteWidget;
        private static Button DeleteWidgetCancelButton = JazzButton.DeleteWidgetCancelButton;
        private static Button DeleteWidgetConfirmButton = JazzButton.DeleteWidgetConfirmButton;
     
        private static TextField ModifyWidgetNameTextField = JazzTextField.TextFieldModifyWidgetName;


        /// <summary>
        /// check a widget is or no exist
        /// </summary>
        /// <returns></returns>
         public bool CheckWidgetIsExist()
        {
            return ElementHandler.Exists(JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.WidgetName));
        }
        
        /// <summary>
        /// click the dashboard hierarchy name linkbutton to midify the widget
        /// </summary>
         public void ClickDashboardHierarchyNameButton()
         {
             DashboardHierarchyNameButton.ClickLink();
         }

        
        /// <summary>
        /// modify widget name and save it,expected is the new widget name
        /// </summary>
        /// <param name="expected"></param>
        public void SaveModifyWidgetName(string expected)
         {
             ModifyWidgetNameButton.Click();
             ModifyWidgetNameTextField.Fill(expected);
             TimeManager.LongPause();
             ModifyWidgetNameSaveButton.Click();
         }
        
        /// <summary>
        /// modify widget name but cancel it
        /// </summary>
         public void CancelModifyWidgetName()
         {
             ModifyWidgetNameButton.Click();
             ModifyWidgetNameCancelButton.Click();
         }
        /// <summary>
        /// delete widget
        /// </summary>
         public void DeleteWidget()
         {
             DeleteWidgetButton.Click();
         }
        /// <summary>
        /// Cancel delete widget
        /// </summary>
         public void CancelDeleteWidget()
         {
             DeleteWidgetCancelButton.Click();
         }
        /// <summary>
        /// confirm delete widget
        /// </summary>
         public void ConfirmDeleteWidget()
         {
             DeleteWidgetConfirmButton.Click();
         }

    }
}
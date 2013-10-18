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

        #region controls
        
        private static Button DashboardHierarchyNameButton = JazzButton.DashboardHierarchyNameButton;
        private static Button ModifyWidgetNameSaveButton = JazzButton.ModifyWidgetNameSaveButton;
        private static Button ModifyWidgetNameCancelButton = JazzButton.ModifyWidgetNameCancelButton;
        private static Button DeleteWidgetCancelButton = JazzButton.DeleteWidgetCancelButton;
        private static Button DeleteWidgetConfirmButton = JazzButton.DeleteWidgetConfirmButton;
     
        private static TextField ModifyWidgetNameTextField = JazzTextField.TextFieldModifyWidgetName;

        private static ComboBox WidgetMaxDialogDefaultTime = JazzComboBox.WidgetMaxDialogDefaultTimeComboBox;
        private static ComboBox WidgetMaxDialogStartTime = JazzComboBox.WidgetMaxDialogStartTimeComboBox;
        private static ComboBox WidgetMaxDialogEndTime = JazzComboBox.WidgetMaxDialogEndTimeComboBox;

        private static DatePicker WidgetMaxDialogStartDate = JazzDatePicker.WidgetMaxDialogStartDatePicker;
        private static DatePicker WidgetMaxDialogEndDate = JazzDatePicker.WidgetMaxDialogEndDatePicker;

        private static Button WidgetMaxDialogViewButton = JazzButton.WidgetMaxDialogViewButton;
        private static Button WidgetMaxDialogCloseButton = JazzButton.WidgetMaxDialogCloseButton;
        private static Button WidgetMaxDialogPrevButton = JazzButton.WidgetMaxDialogPrevButton;
        private static Button WidgetMaxDialogNextButton = JazzButton.WidgetMaxDialogNextButton;

        private static Label WidgetMaxDialogName = JazzLabel.WidgetNameMaxLabel;
        private static Label WidgetShareResourceCommon = JazzLabel.WidgetShareResourceCommonLabel;
        private static Label WidgetShareResourceTime = JazzLabel.WidgetShareResourceTimeLabel;
        private static Label WidgetShareResourceUser = JazzLabel.WidgetShareResourceUserLabel;
        private static Tooltip ShareUserInfo = JazzTooltip.ShareUserTooltip;

        #endregion

        #region common

        /// <summary>
        /// Navigate To AllDashboard
        /// </summary>
        /// <returns></returns>
        public void NavigateToAllDashboard()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
        }

        /// <summary>
        /// Navigate To MyFavorite
        /// </summary>
        /// <returns></returns>
        public void NavigateToMyFavorite()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.MyFavirate);
        }

        /// <summary>
        /// Navigate To Energy View
        /// </summary>
        /// <returns></returns>
        public void NavigateToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
        }
        #endregion

        #region min widget operation

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
             DashboardHierarchyNameButton.Click();
         }

        /// <summary>
        /// modify widget name and save it,expected is the new widget name
        /// </summary>
        /// <param name="expected"></param>
        public void FillNewWidgetName(string name)
         {
             ModifyWidgetNameTextField.Fill(name);
         }

        /// <summary>
        /// Judge if the name field invalid
        /// </summary>
        /// <param name="expected"></param>
        public bool IsWidgetNameFieldInvalid()
        {
            return ModifyWidgetNameTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Get name field invalid message
        /// </summary>
        public string GetWidgetNameFieldInvalidMsg()
        {
            return ModifyWidgetNameTextField.GetInvalidTips();
        }

        /// <summary>
        /// click save
        /// </summary>
        public void ClickSaveWidgetNameButton()
        {
            ModifyWidgetNameSaveButton.Click();
        }

        /// <summary>
        /// modify widget name but cancel it
        /// </summary>
         public void CancelModifyWidgetName()
         {
             ModifyWidgetNameCancelButton.Click();
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
        #endregion

        #region max widget operation

        public void SelectStartDate(string startDate)
        {
            WidgetMaxDialogStartDate.SelectDateItem(startDate);
        }

        public string GetStartDate()
        {
            return WidgetMaxDialogStartDate.GetValue();
        }

        public void SelectEndDate(string endDate)
        {
            WidgetMaxDialogEndDate.SelectDateItem(endDate);
        }

        public string GetEndDate()
        {
            return WidgetMaxDialogEndDate.GetValue();
        }

        public void SelectStartTime(string startTime)
        {
            WidgetMaxDialogStartTime.SelectItem(startTime);
        }

        public void SelectEndTime(string endTime)
        {
            WidgetMaxDialogEndTime.SelectItem(endTime);
        }

        public void ClickViewDataButton()
        {
            WidgetMaxDialogViewButton.Click();
        }

        public void ClickPrevButton()
        {
            WidgetMaxDialogPrevButton.Click();
        }

        public void ClickNextButton()
        {
            WidgetMaxDialogNextButton.Click();
        }

        public void ClickCloseMaxDialogButton()
        {
            WidgetMaxDialogCloseButton.Click();
        }

        public string GetMaxWidgetName()
        {
            return WidgetMaxDialogName.GetLabelTextValue();
        }

        public bool IsPrevButtonEnable()
        {
            return WidgetMaxDialogPrevButton.IsEnabled();
        }

        public bool IsNextButtonEnable()
        {
            return WidgetMaxDialogNextButton.IsEnabled();
        }

        public bool IsShareResoureCommonExisted()
        {
            return WidgetShareResourceCommon.IsLabelExisted();
        }

        public bool IsShareResoureTimeExisted()
        {
            return WidgetShareResourceTime.IsLabelExisted();
        }

        public bool IsShareResoureUserExisted()
        {
            return WidgetShareResourceUser.IsLabelExisted();
        }

        public string GetShareResoureUser()
        {
            return WidgetShareResourceUser.GetLabelTextValue();
        }

        public string GetShareResoureTooltipTexts()
        {
            return ShareUserInfo.GetTooltipTexts();
        }

        public bool IsTextsExisted(string[] texts)
        {
            return ShareUserInfo.IsTooltipTextsExisted(texts);
        }

        public void FloatOnShareResoureUser()
        {
            WidgetShareResourceUser.Float();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
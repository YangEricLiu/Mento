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


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of time management.
    /// </summary>
    public class TimeManagement
    {
        internal TimeManagement()
        {
        }

        //private static Grid PTagList = JazzGrid.PTagSettingsPTagList;

        private static Button CreateWorkdayCalendarButton = JazzButton.WorkdayCalendarCreateButton;

        private static Button ModifyButton = JazzButton.WorkdayCalendarModifyButton;
        private static Button SaveButton = JazzButton.WorkdayCalendarSaveButton;
        private static Button CancelButton = JazzButton.WorkdayCalendarCancelButton;
        private static Button DeleteButton = JazzButton.WorkdayCalendarDeleteButton;

        private static TextField NameTextField = JazzTextField.WorkdayCalendarNameTextField;
        private static ComboBox SpecialDateTypeComboBox = JazzComboBox.WorkdayCalendarSpecialDateTypeComboBox;
        
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToWorkdayCalendarSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.ShortPause();
        }

        /// <summary>
        /// Click "add workday" button to add one workday calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddWorkdayCalendar()
        {
            CreateWorkdayCalendarButton.Click();
        }

        /// <summary>
        /// Click save button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Input name, special date type, start month, start date, end month and end date of the special date range
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInWorkdayCalendar(WorkdayCalendarInputData input)
        {
            NameTextField.Fill(input.Name);            
        }
             
        /// <summary>
        /// Get the tag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Commodity actual value
        /// </summary>
        /// <returns></returns>
        //public string GetCommodityValue()
        //{
        //    return CommodityComboBox.GetValue();
        //}

        /// <summary>
        /// Get the tag Commodity expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Commodity key</param>
        /// <returns>Key value</returns>
        //public string GetCommodityExpectedValue(string itemKey)
        //{
        //    return CommodityComboBox.GetActualValue(itemKey);
        //}

        public void FocusOnWorkdayCalendar(string workdayCalendarName)
        {
            //PTagList.FocusOnRow(1, workdayCalendarName);
        }
    }
}

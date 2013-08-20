using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class WidgetMaxChartDialog : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'widgetmaxwindow') and contains(@class,'x-window')]", ByType.XPath);

        #region controls

        private static DatePicker WidgetMaxDialogStartDatePicker = JazzDatePicker.WidgetMaxDialogStartDatePicker;
        private static DatePicker WidgetMaxDialogEndDatePicker = JazzDatePicker.WidgetMaxDialogEndDatePicker;
        private static ComboBox WidgetMaxDialogDefaultTimeComboBox = JazzComboBox.WidgetMaxDialogDefaultTimeComboBox;
        private static ComboBox WidgetMaxDialogStartTimeComboBox = JazzComboBox.WidgetMaxDialogStartTimeComboBox;
        private static ComboBox WidgetMaxDialogEndTimeComboBox = JazzComboBox.WidgetMaxDialogEndTimeComboBox;
        private static Button WidgetMaxDialogViewButton = JazzButton.WidgetMaxDialogViewButton;
        private static Button WidgetMaxDialogCloseButton = JazzButton.WidgetMaxDialogCloseButton;
        private static Button WidgetMaxDialogPrevButton = JazzButton.WidgetMaxDialogPrevButton;
        private static Button WidgetMaxDialogNextButton = JazzButton.WidgetMaxDialogNextButton;

        #endregion

        public WidgetMaxChartDialog() : base(Locator) { }

        #region common       

        public void ClickPrevButton()
        {
            WidgetMaxDialogPrevButton.Click();
        }

        public void ClickNextButton()
        {
            WidgetMaxDialogNextButton.Click();
        }

        public void ClickViewButton()
        {
            WidgetMaxDialogViewButton.Click();
        }

        public void ClickCloseButton()
        {
            WidgetMaxDialogCloseButton.Click();
        }

        #endregion

        #region set time range
        
        public void InputStartDate(string startDate)
        {
            WidgetMaxDialogStartDatePicker.SelectDateItem(startDate);
        }

        public void InputStartDate(DateTime startDate)
        {
            WidgetMaxDialogStartDatePicker.SelectDateItem(startDate);
        }

        public void InputEndDate(string endDate)
        {
            WidgetMaxDialogEndDatePicker.SelectDateItem(endDate);
        }

        public void InputEndDate(DateTime endDate)
        {
            WidgetMaxDialogEndDatePicker.SelectDateItem(endDate);
        }

        public void SelectDefaultTime(string defaultTime)
        {
            WidgetMaxDialogDefaultTimeComboBox.SelectItem(defaultTime);
        }

        public void SelectStartTime(string startTime)
        {
            WidgetMaxDialogStartTimeComboBox.SelectItem(startTime);
        }

        public void SelectedEndTime(string endTime)
        {
            WidgetMaxDialogEndTimeComboBox.SelectItem(endTime);
        }
        #endregion

        #region get value

        

        #endregion
    }
}

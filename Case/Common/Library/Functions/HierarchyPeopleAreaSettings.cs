using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Hierarchy PeopleArea Settings.
    /// </summary>
    public class HierarchyPeopleAreaSettings
    {
        internal HierarchyPeopleAreaSettings()
        {
        }

        #region Controls
        private static TabButton PeopleAreaTab = JazzButton.PeopleAreaPropertyTabButton;
        private static Button PeopleAreaCreate = JazzButton.PeopleAreaCreateButton;
        private static Button PeopleAreaUpdate = JazzButton.PeopleAreaUpdateButton;
        private static Button PeopleAreaSave = JazzButton.PeopleAreaSaveButton;
        private static TextField TotalAreaValue = JazzTextField.TotalAreaValueTextField;
        private static TextField HeatingAreaValue = JazzTextField.HeatingAreaValueTextField;
        private static TextField CoolingAreaValue = JazzTextField.CoolingAreaValueTextField;
        private static TextField PeopleNumber = JazzTextField.PeopleNumberTextField;

        private static Button PeopleCreate = JazzButton.PeopleCreateButton;
        private static MonthPicker PeopleEffectiveDate = JazzMonthPicker.PeopleEffectiveDateMonthPicker;
        #endregion

        #region Peoplae Area
        public void ClickPeopleAreaTab()
        {
            PeopleAreaTab.Click();
        }

        public void ClickPeopleAreaCreateButton()
        {
            if (PeopleAreaCreate.IsDisplayed())
            {
                PeopleAreaCreate.Click();
            }
            else if (PeopleAreaUpdate.IsDisplayed())
            {
                PeopleAreaUpdate.Click();
            }
        }

        public void ClickSaveButton()
        {
            PeopleAreaSave.Click();
            JazzMessageBox.LoadingMask.WaitLoading(maxtime: 2);
        }        
        #endregion

        #region Area
        public void InputTotalAreaValue(string value)
        {
            TotalAreaValue.Fill(value);
        }

        public void InputHeatingAreaValue(string value)
        {
            HeatingAreaValue.Fill(value);
        }

        public void InputCoolingAreaValue(string value)
        {
            CoolingAreaValue.Fill(value);
        }

        public string GetTotalAreaValue()
        {
            return TotalAreaValue.GetValue();
        }

        public string GetHeatingAreaValue()
        {
            return HeatingAreaValue.GetValue();
        }

        public string GetCoolingAreaValue()
        {
            return CoolingAreaValue.GetValue();
        }
        #endregion

        #region People

        public void  ClickPeopleCreateButton()
        {
            PeopleCreate.Click();
        }

        public void SelectEffectiveDate(DateTime date)
        {
            PeopleEffectiveDate.SelectYearMonthItem(date);
        }

        public void InputPeopleNumber(string number)
        {
            PeopleNumber.Append(number);
        }

        public string GetEffectiveDateValue()
        {
            return PeopleEffectiveDate.GetValue();
        }

        public string GetPeopleNumberValue()
        {
            return PeopleNumber.GetValue();
        }
        #endregion
    }
}

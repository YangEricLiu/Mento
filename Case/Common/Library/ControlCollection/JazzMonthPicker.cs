using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzMonthPicker : JazzControlCollection
    {
        #region Get Position MonthPicker Method
        public static MonthPicker GetOneMonthPicker(string key, int positionIndex)
        {
            return GetControl<MonthPicker>(key, positionIndex);
        }
        #endregion

        #region customer setting
        #region hierarchy people area property
        public static MonthPicker PeopleEffectiveDateMonthPicker = GetControl<MonthPicker>(JazzControlLocatorKey.MonthPickerPeopleEffectiveDate, 1);
        #endregion
        #endregion
    }
}

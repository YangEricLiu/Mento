using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public sealed class JazzCheckBox : JazzControlCollection
    {
        #region CheckBox of DayNightKPITag 
        public static CheckBoxField CheckBoxFieldDayNightKPITag = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldDayNightKPITag);
        #endregion

        #region CheckBox of UserTypePermission
        public static CheckBoxField CheckBoxFieldUserTypeCost = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypeCost);
        public static CheckBoxField CheckBoxFieldUserTypeEnergyUse = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypeEnergyUse);

        public static CheckBoxField UserTypePermissionCheckBoxField = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypePermission);
        public static CheckBoxField UserDataAllHierarchyNodeCheckBoxField = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserAllHierarchyNode);
        public static CheckBoxField UserAllDataScopeCheckBoxField = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserAllDataScope);
        public static CheckBoxField CustomerMapPropertyCheckBoxField = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldCustomerMapProperty);

        
        #endregion

        #region CheckBox of BenchMark
        public static CheckBoxField CheckBoxBenchMark = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxBenchMark);
        #endregion

    }
}

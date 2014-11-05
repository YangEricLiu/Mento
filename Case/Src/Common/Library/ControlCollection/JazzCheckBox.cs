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
        public static CheckBoxField CheckBoxFieldDayNightKPITag{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldDayNightKPITag);}}
        #endregion

        #region CheckBox of UserTypePermission
        public static CheckBoxField CheckBoxFieldUserTypeCost{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypeCost);}}
        public static CheckBoxField CheckBoxFieldUserTypeEnergyUse{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypeEnergyUse);}}

        public static CheckBoxField UserTypePermissionCheckBoxField{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserTypePermission);}}
        public static CheckBoxField UserDataAllHierarchyNodeCheckBoxField{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserAllHierarchyNode);}}
        public static CheckBoxField UserAllDataScopeCheckBoxField{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldUserAllDataScope);}}
        public static CheckBoxField CustomerMapPropertyCheckBoxField{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxFieldCustomerMapProperty);}}

        
        #endregion

        #region CheckBox of BenchMark
        public static CheckBoxField CheckBoxBenchMark{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxBenchMark);}}
        #endregion

        #region CheckBox of Labeling
        #endregion
        #region CheckBox of Ptag

        public static CheckBoxField PtagIsAccumulatedCheckBox{ get { return GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxPtagIsAccumulated);}}

        #endregion

        #region CheckBox of Widget template

        public static CheckBoxField WidgetTemplateTableCheckBox = GetControl<CheckBoxField>(JazzControlLocatorKey.CheckBoxWidgetTemplateTable);    

        #endregion


    }
}

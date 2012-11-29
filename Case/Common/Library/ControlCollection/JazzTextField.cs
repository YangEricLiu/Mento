using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public class JazzTextField : JazzControlCollection
    {
        #region Login
        public static TextField LoginUserNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginUserName);
        public static TextField LoginPasswordTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldLoginPassword);
        #endregion

        #region Customer settings
        #region Hierarchy settings
        public static TextField HierarchySettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsName);
        public static TextField HierarchySettingsCodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsCode);
        public static TextField HierarchySettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldHierarchySettingsComment);
        #endregion

        #region PTag settings
        public static TextField PTagSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsName);
        public static TextField PTagSettingsCodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsCode);
        public static TextField PTagSettingsMeterCodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsMeterCode);
        public static TextField PTagSettingsChannelTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsChannel);
        public static TextField PTagSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldPTagSettingsComment);
        #endregion

        #region VTag settings
        public static TextField VTagSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsName);
        public static TextField VTagSettingsCodeTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsCode);
        public static TextField VTagSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldVTagSettingsComment);
        public static FormulaField FormulaField = GetControl<FormulaField>(null);
        #endregion

        #region Area dimension settings
        public static TextField AreaDimensionSettingsNameTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsName);
        public static TextField AreaDimensionSettingsCommentTextField = GetControl<TextField>(JazzControlLocatorKey.TextFieldAreaDimensionSettingsComment);
        #endregion
        #endregion
    }
}

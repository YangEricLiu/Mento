﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    internal static class ControlLocatorKey
    {
        #region Old Jazz     

        #region Common locators
        public static string LoadingMask = "LoadingMask";
        public static string SubMaskLoadingLocator = "SubMaskLoadingLocator";
        public static string ChartMaskerLoadingLocator = "ChartMaskerLoadingLocator";
        public static string DashboardHeaderLoadingLocator = "DashboardHeaderLoadingLocator";
        public static string WidgetsContainerLoadingLocator = "WidgetsContainerLoadingLocator";
        public static string CalendarLoadingLocator = "CalendarLoadingLocator";
        public static string JumpLoadingLocator = "JumpLoadingLocator";
        public static string PopNotesLocator = "PopNotesLocator";
        public static string MyShareLocator = "MyShareLocator";
        //public static string CreateSuccessMessageBox = "CreateSuccessMessageBox";
        //public static string CreateSuccessMessageBoxOkButton = "CreateSuccessMessageBoxOkButton";

        public static string MessageBox = "MessageBox";
        public static string MessageBoxOkButton = "MessageBoxOkButton";
        public static string MessageBoxConfirmButton = "MessageBoxConfirmButton";
        public static string MessageBoxYesButton = "MessageBoxYesButton";
        public static string MessageBoxNoButton = "MessageBoxNoButton";
        public static string MessageBoxCancelButton = "MessageBoxCancelButton";
        public static string MessageBoxCancelShareButton = "MessageBoxCancelShareButton";
        public static string MessageBoxDeleteButton = "MessageBoxDeleteButton";
        public static string MessageBoxCloseButton = "MessageBoxCloseButton";
        public static string MessageBoxClearButton = "MessageBoxClearButton";
        public static string MessageBoxGiveUpButton = "MessageBoxGiveUpButton";
        public static string MessageBoxQuitButton = "MessageBoxQuitButton";

        public static string ContainerNotHiddenItems = "ContainerNotHiddenItems";
        
        #endregion

        #region TreeView locators
        public static string TreeNode = "TreeNode";
        public static string TreeNodeImage = "TreeNodeImage";
        public static string TreeNodeCheckbox = "TreeNodeCheckbox";
        #endregion

        #region Pop TreeView locators
        public static string PopTreeNode = "PopTreeNode";

        #endregion

        #region Alarm ReactJS TreeView locators

        public static string AlarmTreeNode = "AlarmTreeNode";
        public static string NewJazzTreeNode = "NewJazzTreeNode";

        #endregion

        #region TextField locators
        public static string FormulaTextBox = "FormulaTextBox";
        public static string FormulaTextArea = "FormulaTextArea";
        public static string TextFieldHiddenTable = "TextFieldHiddenTable";

        #endregion

        #region Button locators
        public static string ButtonInput = "ButtonInput";
        public static string AscendingCustomizedLabellingButton = "AscendingCustomizedLabellingButton";
        #endregion

        #region MenuButton locators
        public static string MenuButtonTrigger = "MenuButtonTrigger";
        public static string MenuButtonInput = "MenuButtonInput";
        public static string MenuButtonItem = "MenuButtonItem";
        public static string MenuButtonDropdownListItems = "MenuButtonDropdownListItems";
        public static string MenuButtonIndustryLabellingIndustry = "MenuButtonIndustryLabellingIndustry";
        #endregion

        #region ComboBox locators

        #region Pop ComboBox

        public static string PopComboBoxTrigger = "PopComboBoxTrigger";
        public static string PopComboBoxItem = "PopComboBoxItem";

        #endregion

        public static string ComboBoxTrigger = "ComboBoxTrigger";
        public static string ComboBoxInput = "ComboBoxInput";
        public static string ComboBoxItem = "ComboBoxItem";
        public static string ComboBoxDropdownListItems = "ComboBoxDropdownListItems";
        #endregion

        #region Grid locators
        public static string GridRows = "GridRows";
        public static string GridRow = "GridRow";
        public static string GridOneRow = "GridOneRow";
        public static string GridRowSelected = "GridRowSelected";
        public static string GridRowChecker = "GridRowChecker";
        //public static string GridRowSelector = "GridRowSelector";
        public static string GridRowLight = "GridRowLight";
        public static string GridAllRows = "GridAllRows";
        public static string GridCellText = "GridCellText";
        public static string GridCellIndex = "GridCellIndex";
        public static string GridRowIndex = "GridRowIndex";

        public static string GridPagingToolbar = "GridPagingToolbar";
        public static string GridPagingPreviousPageButton = "GridPagingPreviousPageButton";
        public static string GridPagingNextPageButton = "GridPagingNextPageButton";
        public static string GridPagingCurrentPageTextBox = "GridPagingCurrentPageTextBox";
        public static string GridPagingTotalPageLabel = "GridPagingTotalPageLabel";
        public static string GridPagingTotalRecordLabel = "GridPagingTotalRecordLabel";

        public static string GridRowDataPermissionChecker = "GridRowDataPermissionChecker";
        public static string GridRowDataPermissionCheckerTextRow = "GridRowDataPermissionCheckerTextRow";
        public static string GridRowDeleteX = "GridRowDeleteX";
        public static string GridRowHeaderShare = "GridRowHeaderShare";

        public static string GridRowLabelling = "GridRowLabelling";
        public static string GridRowQuitSubscriber = "GridRowQuitSubscriber";

        public static string GridHeaderShowValueType = "GridHeaderShowValueType";

        public static string GridCellIndex5 = "GridCellIndex5";
        #endregion

        #region MonthPicker locators
        public static string MonthPickerTrigger = "MonthPickerTrigger";
        public static string MonthPickerInput = "MonthPickerInput";
        public static string MonthPickerYearItem = "MonthPickerYearItem";
        public static string MonthPickerMonthItem = "MonthPickerMonthItem";
        public static string MonthPickerPreviousNavigator = "MonthPickerPreviousNavigator";
        public static string MonthPickerNextNavigator = "MonthPickerNextNavigator";
        public static string MonthPickerConfirm = "MonthPickerConfirm";
        public static string MonthPickerCancel = "MonthPickerCancel";
        #endregion

        #region Window locators
        public static string WindowTitleLabel = "WindowTitle";
        public static string WindowCloseButton = "WindowCloseButton";
        public static string WindowConfirmButton = "WindowConfirmButton";
        public static string WindowCancelButton = "WindowCancelButton";
        public static string WindowQuitButton = "WindowQuitButton";
        #endregion

        #region DatePicker locators
        public static string DatePickerTrigger = "DatePickerTrigger";
        public static string DatePickerInput = "DatePickerInput";
        public static string DatePickerPreviousMonth = "DatePickerPreviousMonth";
        public static string DatePickerNextMonth = "DatePickerNextMonth";
        public static string InnerMonthPickerButton = "InnerMonthPickerButton";
        public static string InnerMonthPickerPreviousNavigator = "InnerMonthPickerPreviousNavigator";
        public static string InnerMonthPickerNextNavigator = "InnerMonthPickerNextNavigator";
        public static string InnerMonthPickerConfirm = "InnerMonthPickerConfirm";
        public static string InnerMonthPickerCancel = "InnerMonthPickerCancel";
        public static string InnerMonthPickerYearItem = "InnerMonthPickerYearItem";
        public static string InnerMonthPickerMonthItem = "InnerMonthPickerMonthItem";
        public static string DatePickerDayItem = "DatePickerDayItem";
        #endregion

        #region CheckBoxField locators

        #region pop

        public static string PopCheckBoxInput = "PopCheckBoxInput";

        #endregion

        #region Alarm ReactJS Checkbox locators

        public static string Alarm_CheckBoxInput = "Alarm_CheckBoxInput";

        #endregion

        public static string PermissionCheckBoxTable = "PermissionCheckBoxTable";
        public static string CheckBoxTable = "CheckBoxTable";
        public static string CheckBoxInput = "CheckBoxInput";

        public static string CheckBoxWidgetTemplateInput = "CheckBoxWidgetTemplateInput"; 
        public static string CheckBoxWidgetTemplateTable = "CheckBoxWidgetTemplateTable";
        #endregion

        #region Container locators
        public static string CustomerManageMapInfo = "CustomerMapInfoSetMesaage";
        #endregion

        #region Grade locators
        public static string GradeItems = "GradeItems";
        #endregion

        #region MenuCheckItem locators

        public static string MenuCheckItemItem = "MenuCheckItemItem";
        public static string MenuCheckSearching = "MenuCheckSearching";
        public static string MenuCheckExtraComp = "MenuCheckExtraComp";
        public static string MenuAssociateStatusItem = "MenuAssociateStatusItem";

        #endregion

        #endregion

        #region New Jazz

        #region New Jazz DatePickerLocators

        public static string NewReactJSjazzDatePickerTrigger = "NewReactJSjazzDatePickerTrigger";
        public static string NewReactJSjazzTimePickerTrigger = "NewReactJSjazzTimePickerTrigger";
        public static string NewReactJSjazzInnerMonthPickerMonth = "NewReactJSjazzInnerMonthPickerMonth";
        public static string NewReactJSjazzInnerMonthPickerYear = "NewReactJSjazzInnerMonthPickerYear";
        public static string NewReactJSjazzDatePickerPreviousMonth = "NewReactJSjazzDatePickerPreviousMonth";
        public static string NewReactJSjazzDatePickerNextMonth = "NewReactJSjazzDatePickerNextMonth";
        public static string NewReactJSjazzDatePickerDayItem = "NewReactJSjazzDatePickerDayItem";
        public static string NewReactJSjazzDatePickerTimeItem = "NewReactJSjazzDatePickerTimeItem";
        
        #endregion

        #region New Jazz Tree View

        public static string NewReactJSjazzTreeNode = "NewReactJSjazzTreeNode";
        public static string NewReactJSjazzTreeNodeImage = "NewReactJSjazzTreeNodeImage";

        public static string NewReactJSjazzFolderTreeNode = "NewReactJSjazzFolderTreeNode";
        public static string NewReactJSjazzFolderTreeNodeImage = "NewReactJSjazzFolderTreeNodeImage";

        public static string NewReactJSjazzFolderTreeNodeAgain = "NewReactJSjazzFolderTreeNodeAgain";

        #endregion

        #region New Jazz Grid

        public static string NewReactJSjazzGridPagingToolbar = "NewReactJSjazzGridPagingToolbar";
        public static string NewReactJSjazzGridPagingCurrentPageTextBox = "NewReactJSjazzGridPagingCurrentPageTextBox";
        public static string NewReactJSjazzGridPagingTotalPage = "NewReactJSjazzGridPagingTotalPage";
        public static string NewReactJSjazzGridPagingJumpButton = "NewReactJSjazzGridPagingJumpButton";
        public static string NewReactJSjazzGridPagingJumpButtonOnFloat = "NewReactJSjazzGridPagingJumpButtonOnFloat";
        public static string NewReactJSjazzGridPagingTextBox = "NewReactJSjazzGridPagingTextBox";
        public static string NewReactJSjazzGridRowChecker = "NewReactJSjazzGridRowChecker";
        public static string NewReactJSjazzGridRow = "NewReactJSjazzGridRow";
        public static string NewReactJSjazzGridRowCheckerStatus = "NewReactJSjazzGridRowCheckerStatus";
        public static string NewReactJSjazzGridPagingPreviousPageButton = "NewReactJSjazzGridPagingPreviousPageButton";
        public static string NewReactJSjazzGridPagingNextPageButton = "NewReactJSjazzGridPagingNextPageButton";
        public static string NewReactJSjazzBaselineGridRows = "NewReactJSjazzBaselineGridRows";

        #endregion

        #region New Jazz Loading Mask

        public static string NewReactJSjazzChartMaskerLoadingLocator = "NewReactJSjazzChartMaskerLoadingLocator";

        #endregion

        #endregion
    } 
}

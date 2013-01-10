using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    internal static class ControlLocatorKey
    {
        #region Common locators
        public static string LoadingMask = "LoadingMask";
        //public static string CreateSuccessMessageBox = "CreateSuccessMessageBox";
        //public static string CreateSuccessMessageBoxOkButton = "CreateSuccessMessageBoxOkButton";

        public static string MessageBox = "MessageBox";
        public static string MessageBoxOkButton = "MessageBoxOkButton";
        public static string MessageBoxConfirmButton = "MessageBoxConfirmButton";
        public static string MessageBoxNoButton = "MessageBoxNoButton";
        public static string MessageBoxCancelButton = "MessageBoxCancelButton";
        #endregion

        #region TreeView locators
        public static string TreeNode = "TreeNode";
        public static string TreeNodeImage = "TreeNodeImage";
        #endregion

        #region TextField locators
        public static string FormulaTextBox = "FormulaTextBox";
        public static string FormulaTextArea = "FormulaTextArea";
        
        #endregion

        #region Button locators
        public static string ButtonInput = "ButtonInput";
        #endregion

        #region ComboBox locators
        public static string ComboBoxTrigger = "ComboBoxTrigger";
        public static string ComboBoxInput = "ComboBoxInput";
        public static string ComboBoxItem = "ComboBoxItem";
        
        #endregion

        #region Grid locators 
        public static string GridRows = "GridRows";
        public static string GridRow = "GridRow";
        public static string GridRowChecker = "GridRowChecker";
        public static string GridPagingToolbar = "GridPagingToolbar";   
        public static string GridPagingPreviousPageButton = "GridPagingPreviousPageButton";
        public static string GridPagingNextPageButton = "GridPagingNextPageButton";
        public static string GridPagingCurrentPageTextBox = "GridPagingCurrentPageTextBox";
        public static string GridPagingTotalPageLabel = "GridPagingTotalPageLabel";
        public static string GridPagingTotalRecordLabel = "GridPagingTotalRecordLabel";
        
            
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.Framework.Exceptions;
using Mento.ScriptCommon.Library.Functions.EnergyManagement;
using System.Collections;
using Mento.Framework.Configuration;
using System.IO;
using System.Data;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyViewToolbar
    {
        #region Old Jazz
     
        #region Controls
        //StartDatePicker
        private static DatePicker StartDatePicker = JazzDatePicker.EnergyUsageStartDateDatePicker;
        //StartTimeComboBox
        private static ComboBox StartTimeComboBox = JazzComboBox.EnergyViewStartTimeComboBox;

        private static MenuButton IndustyLabellinglist = JazzButton.IndustryLabellingIndustryMenuButton;
        private static MenuButton CustomerIndustyLabellinglist = JazzButton.CustomerLabellingIndustryMenuButton;
        //EndDatePicker
        private static DatePicker EndDatePicker = JazzDatePicker.EnergyUsageEndDateDatePicker;
        //EndTimeComboBox
        private static ComboBox EndTimeComboBox = JazzComboBox.EnergyViewEndTimeComboBox;

        //ViewButton
        private static EnergyViewToolbarViewSplitButton ViewButton = new EnergyViewToolbarViewSplitButton();

        //ConvertTargetSplitButton
        private static EnergyViewToolbarConvertTargetMenu ConvertTargetButton = new EnergyViewToolbarConvertTargetMenu();

        //PeakValleyButton
        private static Button PeakValleyButton = JazzButton.EnergyViewPeakValleyButton;

        //AddTimeSpanButton and add time span dialog
        //private static Button AddTimeSpanButton = JazzButton.EnergyViewAddTimeSpanButton;//em-chartgrid-topbar-addInterval

        //RemoveAllTagButton
        private static Button RemoveAllButton = JazzButton.EnergyViewRemoveAllButton; //em-chartgrid-topbar-del

        //MoreMenu and more dialog
        private static EnergyViewToolbarMoreMenu MoreMenu = new EnergyViewToolbarMoreMenu();
        private static SaveToDashboardDialog DashboardDialog = new SaveToDashboardDialog();
        private static TimeSpanDialog TimeSpanDialog = new TimeSpanDialog();

        #endregion

        internal EnergyViewToolbar()
        {
        }

        public string GetStartDate()
        {
            return StartDatePicker.GetValue();
        }

        public string GetEndDate()
        {
            return EndDatePicker.GetValue();
        }

        public string GetStartTime()
        {
            return StartTimeComboBox.GetValue();
        }

        public string GetEndTime()
        {
            return EndTimeComboBox.GetValue();
        }

        public void SetDateRange(DateTime startTime, DateTime endTime)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute, endHour = endTime.Hour, endMinute = endTime.Minute;

            /*
            if (startMinute != 0 || startMinute != 30 || endMinute != 0 || endMinute != 30)
            {
                throw new ApiException("Start time and end time must be multiple of half hour.");
            }
            */

            StartDatePicker.SelectDateItem(startTime);
            //StartTimeComboBox.SelectItem(String.Format("{0}:{1}", startHour, startMinute));

            EndDatePicker.SelectDateItem(endTime);
            //EndTimeComboBox.SelectItem(String.Format("{0}:{1}", endHour, endMinute));
        }

        public void SetDateRange(string startTime, string endTime)
        {
            StartDatePicker.SelectDateItem(startTime);

            EndDatePicker.SelectDateItem(endTime);

            if (EndTimeComboBox.Exists() && EndTimeComboBox.IsDisplayed())
            {
                EndTimeComboBox.SelectItem("24:00");
            }

            TimeManager.ShortPause();
        }

        public void SetTimeRange(string startTime, string endTime)
        {
            StartTimeComboBox.SelectItem(startTime);

            EndTimeComboBox.SelectItem(endTime);
        }

        public bool View(EnergyViewType viewType)
        {
            try
            {
                ViewButton.SwitchViewType(viewType);
                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }

        public void ClickViewButton()
        {
            ViewButton.ClickView();

            TimeManager.LongPause();
        }

        public bool IsTimeSpanButtonEnable()
        {
            return !ViewButton.IsTimeSpanButtonDisabled();
        }

        public bool IsTimeSpanMenuItemDisabled(string text)
        {
            return ViewButton.IsMenuItemDisabled(text);
        }

        public void ClickTimeSpanButton()
        {
            ViewButton.ClickTimeSpan();

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public bool IsMoreMenuItemDisabled(string text)
        {
            return MoreMenu.IsMoreMenuItemDisabled(text);
        }

        public void TimeSpan(TimeSpans span)
        {
            ViewButton.SwitchTimeSpans(span);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void ClickFuncModeConvertTarget()
        {
            ConvertTargetButton.ClickFuncModeConvertTargetButton();
        }

        public string GetFuncModeConvertTargetText()
        {
            return ConvertTargetButton.GetFuncModeConvertTargetButtonText();
        }

        public void ClickRankTypeConvertTarget()
        {
            ConvertTargetButton.ClickRankTypeConvertTargetButton();
        }

        public void SelectIndustryConvertTarget(string industry)
        {
            ConvertTargetButton.SwitchIndustryMenuItem(industry);
        }

        public ArrayList GetBenchmarkMenulist(string buttonType)
        {
                return MoreMenu.GetBenchmarkMenuItemsList(buttonType);
        }

        public ArrayList GetUnitTypeMenulist()
        {
            return MoreMenu.GetUnitTypeMenuItemsList();
        }

        public void SelectIndustryOrCustomerLabellingConvertTarget(int LabellingType, string Labelling)
        {
            if (1 == LabellingType)
                ConvertTargetButton.SwitchLabellingIndustryMenuItem(Labelling);
            else
                ConvertTargetButton.SwitchCustomerLabellingIndustryMenuItem(Labelling);
        }

        public ArrayList GetIndustryLabellingMenuListItems(string industry)
        {
            return MoreMenu.GetLabellingSecondLevelMenuItem(industry);
        }

        public void SelectRatioIndustryConvertTarget(string industry)
        {
            ConvertTargetButton.SwitchRatioIndustryMenuItem(industry);
            TimeManager.ShortPause();
        }

        public void SelectLabellingIndustryConvertTarget(string[] industry)
        {
            MoreMenu.SwitchLabellingIndustryMenuItem(industry);
        }

        public ArrayList GetIndustryLabellingDropdownListItems()
        {
            return null;
            //return IndustyLabellinglist.GetCurrentDropdownListItems();
        }

        public string GetLabellingIndustryButtonText()
        {
            return MoreMenu.GetLabellingIndustryValue();
        }

        public string GetIndustryButtonText()
        {
            return ConvertTargetButton.GetIndustryButtonText();
        }
        /* 
         * can be deleted
        public string GetIndustryLabellingButtonText()
        {
            return ConvertTargetButton.GetIndustryLabellingButtonText();
        }
        */
        public void SelectCarbonConvertTarget(CarbonConvertTarget target)
        {
            ConvertTargetButton.SwitchCarbonMenuItem(target);
        }

        public void SelectCarbonConvertTarget(string target)
        {
            ConvertTargetButton.SwitchCarbonMenuItem(target);
        }

        public void SelectFuncModeConvertTarget(FuncModeConvertTarget target)
        {
            ConvertTargetButton.SwitchFuncModeMenuItem(target);
        }

        public void SelectTagModeConvertTarget(TagModeConvertTarget target)
        {
            ConvertTargetButton.SwitchTagModeMenuItem(target);
        }

        public void SelectUnitTypeConvertTarget(UnitTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchUnitTypeMenuItem(target);
        }

        public void SelectUnitTypeConvertTarget(string target)
        {
            ConvertTargetButton.SwitchUnitTypeMenuItem(target);
        }

        public void SelectLabellingUnitTypeConvertTarget(string target)
        {
            ConvertTargetButton.SwitchLabellingUnitTypeMenuItem(target);
        }

        public string GetUnitTypeButtonText()
        {
            return ConvertTargetButton.GetUnitTypeButtonText();
        }

        public void SelectRadioTypeConvertTarget(RadioTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRadioTypeMenuItem(target);
        }

        public void SelectRankTypeConvertTarget(RankTypeConvertTarget target)
        {
            ConvertTargetButton.SwitchRankTypeMenuItem(target);
        }

        public string GetCurrentTagModeButtonValue()
        {
            return ConvertTargetButton.GetCurrentTagModeButtonValue();
        }

        public void RemoveAllTags()
        {
            RemoveAllButton.Click();
        }

        public void ShowPeakValley()
        {
            PeakValleyButton.Click();
        }

        public bool IsPeakValleyButtonEnable()
        {
            return PeakValleyButton.IsEnabled();
        }

        public bool IsPeakValleyButtonPressed()
        {
            return PeakValleyButton.IsPressed();
        }

        public void SelectMoreOption(EnergyViewMoreOption moreOption)
        {
            MoreMenu.SwitchMenuItem(moreOption);

            JazzMessageBox.LoadingMask.WaitLoading();
        }

        public void OpenMoreButton()
        {
            MoreMenu.OpenMoreButton();
        }

        public void OpenIndustryConvertButton()
        {
            MoreMenu.OpenIndustryConvertButton();
        }

        #region Dashboard

        public void SaveToDashboard(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();

            DashboardDialog.Save(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }

        public void SaveToDashboardThenCancel(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();

            DashboardDialog.SaveThenCancel(widgetName, hierarchyName, isCreateDashboard, dashboardName);
        }

        public void SaveToDashboardwithAnnotation(string widgetName, string[] hierarchyName, bool isCreateDashboard, string dashboardName, string comment)
        {
            MoreMenu.SwitchMenuItem(EnergyViewMoreOption.ToDashboard);
            TimeManager.MediumPause();

            DashboardDialog.SaveWithAnnotation(widgetName, hierarchyName, isCreateDashboard, dashboardName, comment);
        }

        public bool IsWidgetNameInvalid()
        {
            return DashboardDialog.IsWidgetNameInvalid();
        }

        public string GetWidgetNameInvalidMsg()
        {
            return DashboardDialog.GetWidgetNameInvalidMsg();
        }

        public void ClickCloseDashboardDialog()
        {
            DashboardDialog.Close();
        }

        public string GetExistedDashboardInvalidMsg()
        {
            return DashboardDialog.GetNewDashboardMsg();
        }

        #endregion

        #endregion

        #region New Jazz

        #region New Jazz Controls
        //StartDatePicker
        private static DatePicker NewJazz_StartDatePicker = JazzDatePicker.NewReactJSJazzDatePickerStartDate;

        //EndDatePicker
        private static DatePicker NewJazz_EndDatePicker = JazzDatePicker.NewReactJSJazzDatePickerEndDate;

        private static Button NewJazz_BaselineCalReviseButton = JazzButton.NewReactJSjazzBaselineCalValueReviseButton;
        private static Label NewJazz_BaselineTimeOverlap = JazzLabel.NewReactJSJazzBaselineTimeOverlap;

        //基准值修正值
        private static TextField Annual = JazzTextField.NewReactJSJazzBaselineAnnualCalculationValue;
        private static TextField January = JazzTextField.NewReactJSJazzBaselineJanuaryCalculationValue;
        private static TextField February = JazzTextField.NewReactJSJazzBaselineFebruaryCalculationValue;
        private static TextField March = JazzTextField.NewReactJSJazzBaselineMarchCalculationValue;
        private static TextField April = JazzTextField.NewReactJSJazzBaselineAprilCalculationValue;
        private static TextField May = JazzTextField.NewReactJSJazzBaselineMayCalculationValue;
        private static TextField June = JazzTextField.NewReactJSJazzBaselineJuneCalculationValue;
        private static TextField July = JazzTextField.NewReactJSJazzBaselineJulyCalculationValue;
        private static TextField August = JazzTextField.NewReactJSJazzBaselineAugustCalculationValue;
        private static TextField September = JazzTextField.NewReactJSJazzBaselineSeptemberCalculationValue;
        private static TextField October = JazzTextField.NewReactJSJazzBaselineOctoberCalculationValue;
        private static TextField November = JazzTextField.NewReactJSJazzBaselineNovemberCalculationValue;
        private static TextField December = JazzTextField.NewReactJSJazzBaselineDecemberCalculationValue;
        #endregion

        #region New Jazz Date Picker
        
        public string NewJazz_GetStartDate()
        {
            return NewJazz_StartDatePicker.GetValue();
        }

        public string NewJazz_GetEndDate()
        {
            return NewJazz_EndDatePicker.GetValue();
        }

        public void NewJazz_SetDateRange(DateTime startTime, DateTime endTime)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute, endHour = endTime.Hour, endMinute = endTime.Minute;

            NewJazz_StartDatePicker.NewJazz_SelectDateItem(startTime);

            NewJazz_EndDatePicker.NewJazz_SelectDateItem(endTime);
        }

        public void NewJazz_SetDateRange(string startTime, string endTime)
        {
            NewJazz_StartDatePicker.NewJazz_SelectDateItem(startTime);

            NewJazz_EndDatePicker.NewJazz_SelectDateItem(endTime);
        }

        public void NewJazz_SetDateRange(DateTime startTime, DateTime endTime, string time)
        {
            int startHour = startTime.Hour, startMinute = startTime.Minute, endHour = endTime.Hour, endMinute = endTime.Minute;

            NewJazz_StartDatePicker.NewJazz_SelectDateItem(startTime, time);

            NewJazz_EndDatePicker.NewJazz_SelectDateItem(endTime, time);
        }

        public void NewJazz_SetDateRange(string startTime, string endTime, string time)
        {
            NewJazz_StartDatePicker.NewJazz_SelectDateItem(startTime, time);

            NewJazz_EndDatePicker.NewJazz_SelectDateItem(endTime, time);
        }    

        #endregion

        #region New Jazz Other

        #region New Jazz Controls

        private static MenuButton NewJazzEnergyViewPredefinedTimeButton = JazzButton.NewReactJSJazzEnergyViewPredefinedTimeButton;
        private static MenuButton NewJazzEnergyViewAssistButton = JazzButton.NewReactJSJazzEnergyViewAssistButton;
        private static Button NewJazzEnergyViewCheckDataButton = JazzButton.NewReactJSJazzEnergyViewCheckDataButton;
        private static MenuButton NewJazzBaselineSelectYearButton = JazzButton.NewReactJSJazzBaselineSelectYearButton;
        private static Button NewJazzBaselineEditButton = JazzButton.NewReactJSJazzBaselineEditButton;
        private static Button NewJazzBaselineSaveButton = JazzButton.NewReactJSJazzBaselineSaveButton;
        private static Button NewJazzBaselineCancelButton = JazzButton.NewReactJSJazzBaselineCancelButton;
        private static Button NewJazzBaselineAddTimeSettingButton = JazzButton.NewReactJSJazzBaselineAddTimeSettingButton;


        private static Dictionary<NewJazzEnergyViewToolbarOption, string> NewwJazzMenuItems = new Dictionary<NewJazzEnergyViewToolbarOption, string>()
        {
            {NewJazzEnergyViewToolbarOption.Last7Days,"$@Common.DateRange.Last7Day"},
            {NewJazzEnergyViewToolbarOption.Last30Day,"$@Common.DateRange.Last30Day"},
            {NewJazzEnergyViewToolbarOption.Last12Month,"$@Common.DateRange.Last12Month"},
            {NewJazzEnergyViewToolbarOption.Today,"$@Common.DateRange.Today"},
            {NewJazzEnergyViewToolbarOption.Yesterday,"$@Common.DateRange.Yesterday"},
            {NewJazzEnergyViewToolbarOption.ThisWeek,"$@Common.DateRange.ThisWeek"},
            {NewJazzEnergyViewToolbarOption.LastWeek,"$@Common.DateRange.LastWeek"},
            {NewJazzEnergyViewToolbarOption.ThisMonth,"$@Common.DateRange.ThisMonth"},
            {NewJazzEnergyViewToolbarOption.LastMonth,"$@Common.DateRange.LastMonth"},
            {NewJazzEnergyViewToolbarOption.ThisYear,"$@Common.DateRange.ThisYear"},
            {NewJazzEnergyViewToolbarOption.LastYear,"$@Common.DateRange.LastYear"},

            {NewJazzEnergyViewToolbarOption.TimeInterval, "历史对比"},
            {NewJazzEnergyViewToolbarOption.BaselineConfigration, "基准值设置"},
            {NewJazzEnergyViewToolbarOption.DataSum, "数据求和"},
            {NewJazzEnergyViewToolbarOption.WeatherInfomation, "天气信息"},
        };

        #endregion


        public void NewJazz_SelectPredfinedTimeMenuItem(NewJazzEnergyViewToolbarOption itemName)
        {
            NewJazzEnergyViewPredefinedTimeButton.NewJazzSelectPredefinedTimeItem(NewwJazzMenuItems[itemName]);
            TimeManager.ShortPause();
        }

        public void NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption itemName)
        {
            NewJazzEnergyViewAssistButton.NewJazzSelectAssistItem(NewwJazzMenuItems[itemName]);
            TimeManager.ShortPause();
        }

        public void NewJazz_ClickView()
        {
            NewJazzEnergyViewCheckDataButton.Click();
            JazzMessageBox.LoadingMask.NewJazz_WaitChartMaskerLoading();
            TimeManager.LongPause();
        }

        #endregion

        #region New Jazz Baseline Configration

        private string BSPath = "Baseline";

        #region Baseline config page
        
        public void NewJazz_BaselineSetDateRange(DateTime startTime, DateTime endTime, int position)
        {
            DatePicker baselineStartDatePicker = JazzDatePicker.NewJazz_GetOneDatePicker(JazzControlLocatorKey.NewReactJSJazzBaselineDatePickerStartDate, position);
            baselineStartDatePicker.NewJazz_SelectDateItem(startTime);

            DatePicker baselineEndDatePicker = JazzDatePicker.NewJazz_GetOneDatePicker(JazzControlLocatorKey.NewReactJSJazzBaselineDatePickerEndDate, position);
            baselineEndDatePicker.NewJazz_SelectDateItem(endTime);
        }

        public void NewJazz_BaselineSetDateRange(string startTime, string endTime, int position)
        {
            DatePicker baselineStartDatePicker = JazzDatePicker.NewJazz_GetOneDatePicker(JazzControlLocatorKey.NewReactJSJazzBaselineDatePickerStartDate, position);
            baselineStartDatePicker.NewJazz_SelectDateItem(startTime);

            DatePicker baselineEndDatePicker = JazzDatePicker.NewJazz_GetOneDatePicker(JazzControlLocatorKey.NewReactJSJazzBaselineDatePickerEndDate, position);
            baselineEndDatePicker.NewJazz_SelectDateItem(endTime);
        }

        public void NewJazz_BaselineClickAutoCal(int position)
        {
            Button BaselineAutoCalRatioButton = JazzButton.NewJazz_GetOneButton(JazzControlLocatorKey.NewReactJSJazzBaselineAutoCalRadioButton, position);
            BaselineAutoCalRatioButton.Click();
            TimeManager.Pause(3000);
        }

        public void NewJazz_BaselineClickReCal(int position)
        {
            Button BaselineAutoReCalLinkButton = JazzButton.NewJazz_GetOneButton(JazzControlLocatorKey.NewReactJSJazzBaselineAutoReCalLinkButton, position);
            BaselineAutoReCalLinkButton.Click();
            TimeManager.Pause(5000);
        }
            

        public void NewJazz_SelectBaselineYearMenuItem(string itemName)
        {
            NewJazzBaselineSelectYearButton.NewJazzSelectBaselineYearItem(itemName);
            TimeManager.ShortPause();
        }

        public void NewJazz_ClickBaselineEditButton()
        {
            NewJazzBaselineEditButton.Click();
            TimeManager.LongPause();
        }

        public bool NewJazz_IsConfigEditButtonDisabled()
        {
            return NewJazzBaselineEditButton.NewJazz_IsDisabled();
        }

        public void NewJazz_ClickBaselineSaveButton()
        {
            NewJazzBaselineSaveButton.Click();
            TimeManager.LongPause();
        }

        public bool NewJazz_IsConfigSaveButtonDisabled()
        {
            return NewJazzBaselineSaveButton.NewJazz_IsDisabled();
        }

        public void NewJazz_ClickBaselineCancelButton()
        {
            NewJazzBaselineCancelButton.Click();
            TimeManager.LongPause();
        }

        public void NewJazz_ClickBaselineAddTimeSettingButton()
        {
            NewJazzBaselineAddTimeSettingButton.Click();
            TimeManager.LongPause();
        }

        public void NewJazz_ExportBaselineDataTableToExcel(string fileName, int position)
        {
            if (ExecutionConfig.isCreateExpectedDataViewExcelFile)
            {
                Grid baselineGrid = JazzGrid.NewJazz_GetOneGrid(JazzControlLocatorKey.NewReactJSjazzBaselineAutoCalGrid, position);

                DataTable data = baselineGrid.NewJazz_BaselineGetAllData();

                //Export to excel
                string actualFileName = Path.Combine(BSPath, fileName);
                JazzFunction.DataViewOperation.NewJazz_MoveBaselineDataSheetToExcel(data, actualFileName, "自动计算平均值");
            }
        }

        public bool NewJazz_CompareAutoConfigBaseline(string expectedFileName, string failedFileName, int position)
        {
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(BSPath, expectedFileName); ;

                Grid baselineGrid = JazzGrid.NewJazz_GetOneGrid(JazzControlLocatorKey.NewReactJSjazzBaselineAutoCalGrid, position);

                DataTable actualData = baselineGrid.NewJazz_BaselineGetAllData();
                DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, "自动计算平均值");

                return JazzFunction.DataViewOperation.NewJazz_CompareDataTables(expectedDataTable, actualData, failedFileName);
            }
            else
            {
                return true;
            }
        }

        public void NewJazz_ReviseAutoCalValue(int row, int column, string value, int position)
        {
            Grid baselineGrid = JazzGrid.NewJazz_GetOneGrid(JazzControlLocatorKey.NewReactJSjazzBaselineAutoCalGrid, position);

            baselineGrid.NewJazz_ReviseBaselineAutoCalValue(row, column, value);
        }

        #region Error Message

        public string NewJazz_GetTimeOverlapMessage()
        {
            return NewJazz_BaselineTimeOverlap.GetLabelTextValue(); 
        }

        #endregion

        #endregion

        #region Baseline Revise

        public void NewJazz_BaselineClickCalReviseTab()
        {
            NewJazz_BaselineCalReviseButton.Click();
        }

        public string NewJazz_GetMonthValue(int month)
        {
            switch (month)
            { 
                case (int)AllMonth.Annual:
                    return Annual.GetValue();
                case (int)AllMonth.January:
                    return January.GetValue();
                case (int)AllMonth.February:
                    return February.GetValue();
                case (int)AllMonth.March:
                    return March.GetValue();
                case (int)AllMonth.April:
                    return April.GetValue();
                case (int)AllMonth.May:
                    return May.GetValue();
                case (int)AllMonth.June:
                    return June.GetValue();
                case (int)AllMonth.July:
                    return July.GetValue();
                case (int)AllMonth.August:
                    return August.GetValue();
                case (int)AllMonth.September:
                    return September.GetValue();
                case (int)AllMonth.October:
                    return October.GetValue();
                case (int)AllMonth.November:
                    return November.GetValue();
                case (int)AllMonth.December:
                    return December.GetValue();
                default:
                    return Annual.GetValue();
            }
        }

        public void NewJazz_SetMonthValue(int month, string value)
        {
            switch (month)
            {
                case (int)AllMonth.Annual:
                    Annual.Fill(value);
                    break;
                case (int)AllMonth.January:
                    January.Fill(value);
                    break;
                case (int)AllMonth.February:
                    February.Fill(value);
                    break;
                case (int)AllMonth.March:
                    March.Fill(value);
                    break;
                case (int)AllMonth.April:
                    April.Fill(value);
                    break;
                case (int)AllMonth.May:
                    May.Fill(value);
                    break;
                case (int)AllMonth.June:
                    June.Fill(value);
                    break;
                case (int)AllMonth.July:
                    July.Fill(value);
                    break;
                case (int)AllMonth.August:
                    August.Fill(value);
                    break;
                case (int)AllMonth.September:
                    September.Fill(value);
                    break;
                case (int)AllMonth.October:
                    October.Fill(value);
                    break;
                case (int)AllMonth.November:
                    November.Fill(value);
                    break;
                case (int)AllMonth.December:
                    December.Fill(value);
                    break;
                default:
                    Annual.Fill(value);
                    break;
            }
        }

        public bool NewJazz_CompareReviseValue(string[] actualReviseValue)
        {
            bool isEqual = true;
            string sourceValue;
            string actulValue;

            for (int i = 0; i < 13; i++)
            { 
                sourceValue = actualReviseValue[i].Trim();
                actulValue = NewJazz_GetMonthValue(i).Trim();

                if (!String.Equals(sourceValue, actulValue))
                    isEqual = false;
            }
                return isEqual;
        }

        #endregion

        #endregion

        #endregion

        #region TXT File Operation

        public void OpenTXTFile(string fileName, string failedData)
        {
            string filePath = Path.Combine(ExecutionConfig.failedDataViewExcelFileDirectory, BSPath);

            string actualFileName = Path.Combine(filePath, fileName);

            if (!File.Exists(actualFileName))
            {

                FileStream fs1 = new FileStream("F:\\TestTxt.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(failedData);//开始写入值

                sw.Close();
                fs1.Close();

            }
            else
            {
                FileStream fs = new FileStream("actualFileName", FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(failedData);//开始写入值
                sr.Close();
                fs.Close();
            }
        }

        #endregion

    }

        public enum NewJazzEnergyViewToolbarOption
        {
            Last7Days,
            Last30Day,
            Last12Month,
            Today,
            Yesterday,
            ThisWeek,
            LastWeek,
            ThisMonth,
            LastMonth,
            ThisYear,
            LastYear,

            TimeInterval,
            BaselineConfigration,
            DataSum,
            WeatherInfomation,
        }

        public enum AllMonth
        {
            Annual = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
        }
}

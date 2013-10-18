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
    /// The business logic implement of Industry BenchmarkSetting.
    /// </summary>
    public class IndustryBenchmarkSetting
    {
        internal IndustryBenchmarkSetting()
        {
        }

        #region Controls
        public static Button AddBenchMarkButton = JazzButton.AddBenchMarkButton;
        public static Button ModifyBenchMarkButton = JazzButton.ModifyBenchMarkButton;
        public static Button SaveBenchMarkButton = JazzButton.SaveBenchMarkButton;
        public static Button CancelBenchMarkButton = JazzButton.CancelBenchMarkButton;
        public static Button DeleteBenchMarkButton = JazzButton.DeleteBenchMarkButton;

        public static Grid BenchMarkList = JazzGrid.BenchMarkList;
        public static ComboBox BenchMarkComboBox = JazzComboBox.BenchmarkComboBox;

        public static CheckBoxField ClimateRegionsCheckBox = JazzCheckBox.CheckBoxBenchMark;

        public static Label AtLeastSelectLabel = JazzLabel.PlatformBenchMarkLabel;

        #endregion

        #region common action
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToBenchMarkSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.BenchMarkSettings);
            //TimeManager.ShortPause();
            //BenchMarkcom.SelectItem();
        }

        /// <summary>
        /// Click Add button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddBenchMark()
        {
            AddBenchMarkButton.Click();
        }

        /// <summary>
        /// Click Modify button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyBenchMark()
        {
            ModifyBenchMarkButton.Click();
        }
        /// <summary>
        /// Click Delete button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteBenchMark()
        {
            DeleteBenchMarkButton.Click();
        }

        /// <summary>
        /// Click Save button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveBenchMark()
        {
            SaveBenchMarkButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click Cancel button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelBenchMark()
        {
            CancelBenchMarkButton.Click();
        }

        /// <summary>
        /// Select industry combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectIndustryCombox(string itemName)
        {
            BenchMarkComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Check climatic region checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckClimateRegion(string itemName)
        {
            ClimateRegionsCheckBox.CommonCheck(itemName);
        }

        /// <summary>
        /// Check climatic regions checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckClimateRegions(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                ClimateRegionsCheckBox.CommonCheck(itemName[i]);
                i++;
            }
        }

        /// <summary>
        /// Click Industry combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayIndustryItems()
        {
            BenchMarkComboBox.DisplayItems();
        }

        /// <summary>
        /// UnCheck climatic region checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void UnCheckClimateRegion(string itemName)
        {
            ClimateRegionsCheckBox.CommonUnCheck(itemName);
        }

        /// <summary>
        /// UnCheck climatic regions checkbox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void UnCheckClimateRegions(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                ClimateRegionsCheckBox.CommonUnCheck(itemName[i]);
                i++;
            }
        }

        /// <summary>
        /// Focus benchmark
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnBenchMark(string benchMarkName)
        {
            BenchMarkList.FocusOnRow(1, benchMarkName);
        }

         /// <summary>
        /// Verify Is Climate regions Message Displayed
        /// </summary>
        public Boolean IsCliamteRegionsMessageDisplayed()
        {
            return AtLeastSelectLabel.IsLabelDisplayed();
            
        }

        /// <summary>
        /// Verify Is Industry Add Message Displayed
        /// </summary>
        public Boolean IsIndustrysAddMessageDisplayed()
        {
            return BenchMarkComboBox.GetInvalidTips().Contains("必填项。");

        }

        #endregion

        #region verification
        /// <summary>
        /// verify whether Add button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsAddButtonDisplay()
        {
            return AddBenchMarkButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Save button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplay()
        {
            return SaveBenchMarkButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Cancel button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplay()
        {
            return CancelBenchMarkButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Delete button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplay()
        {
            return DeleteBenchMarkButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Modify button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplay()
        {
            return ModifyBenchMarkButton.IsDisplayed();
        }


        #endregion

        #region Get value
        /// <summary>
        /// Get message in the pop up message box. 
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            JazzMessageBox.LoadingMask.WaitLoading();
            return JazzMessageBox.MessageBox.GetMessage();
        }

        /// <summary>
        /// Get message in the industry combox. 
        /// </summary>
        /// <returns></returns>
        public string GetSelectedIndustry()
        {
            return BenchMarkComboBox.GetValue();
        }

        /// <summary>
        /// Get industrys in the industry combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetIndustryLists()
        {
            return string.Join(",", BenchMarkComboBox.GetCurrentDropdownListItems());
        }

        /// <summary>
        /// Verify whether combox list exist dropdown items 
        /// </summary>
        /// <returns></returns>
        public Boolean IsDropdownItemExist(string item)
        {
            return BenchMarkComboBox.GetCurrentDropdownListItems().Contains(item);
        }


        /// <summary>
        /// Check whether the the climate region display. 
        /// </summary>
        /// <returns></returns>
        public Boolean IsClimateRegionNotDisplay(string regionName)
        {
            return ClimateRegionsCheckBox.IsCommonNotDisplayed(regionName);
        }

        /// <summary>
        /// Check whether the the climate regions display. 
        /// </summary>
        /// <returns></returns>
        public Boolean AreClimateRegionsDisplay(string[] climaticRegions)
        {
            int i = 0;
            while (i < climaticRegions.Length)
            {
                if (ClimateRegionsCheckBox.IsCommonNotDisplayed(climaticRegions[i]))
                    return false;
                i++;
            }
            return !(ClimateRegionsCheckBox.IsCommonNotDisplayed(climaticRegions[i-1]));
        }

        /// <summary>
        /// Check whether the the climate regions Not display. 
        /// </summary>
        /// <returns></returns>
        public Boolean AreClimateRegionsNotDisplay(string[] climaticRegions)
        {
            int i = 0;
            while (i < climaticRegions.Length)
            {
                if (!(ClimateRegionsCheckBox.IsCommonNotDisplayed(climaticRegions[i])))
                    return false;
                i++;
            }
            return ClimateRegionsCheckBox.IsCommonNotDisplayed(climaticRegions[i - 1]);
        }

        /// <summary>
        /// Check whether the industry list include the industry.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsIndustryInDropdownList(string regionName)
        {
            return BenchMarkComboBox.GetCurrentDropdownListItems().Contains(regionName);
        }

        /// <summary>
        /// Check whether the industrys list include the industry.  
        /// </summary>
        /// <returns></returns>
        public Boolean AreIndustrysInDropdownList(string[] industryNames)
        {
            int i = 0;
            while (i < industryNames.Length)
            {
                if (!(BenchMarkComboBox.GetCurrentDropdownListItems().Contains(industryNames[i])))
                    return false;
                i++;
            }
            return BenchMarkComboBox.GetCurrentDropdownListItems().Contains(industryNames[i - 1]);
        }

        /// <summary>
        /// Check whether the benchmark list in the BenchMark List.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsRowExistBenchMarkList(string regionName)
        {
            return BenchMarkList.IsRowExist(1,regionName);
        }

        /// <summary>
        /// Check whether the benchmark combox could not be modified.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsIndustryComboxEnabled()
        {
            return BenchMarkComboBox.IsComboBoxTextEnabled();
        }

        /// <summary>
        /// Verify whether  climatic regions checkbox unchecked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean AreClimateRegionsUnChecked(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                if (ClimateRegionsCheckBox.IsCommonChecked(itemName[i]))
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Verify whether  climatic region checkbox checked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsClimateRegionUnChecked(string itemName)
        {
            
            return ClimateRegionsCheckBox.IsCommonChecked(itemName);
        }

        /// <summary>
        /// Verify whether  climatic regions checkbox checked.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean AreClimateRegionsChecked(string[] itemName)
        {
            int i = 0;
            while (i < itemName.Length)
            {
                if (ClimateRegionsCheckBox.IsCommonUnChecked(itemName[i]))
                    return false;
                i++;
            }
            return true;
        }

        #endregion
    }
}

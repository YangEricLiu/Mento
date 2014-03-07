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
    /// The business logic implement of Industry LabelingSetting.
    /// </summary>
    public class IndustryLabelingSetting
    {
        internal IndustryLabelingSetting()
        {
        }

        #region Controls
        public static Button AddLabelingButton = JazzButton.AddLabelingButton;
        public static Button CancelLabelingButton = JazzButton.CancelLabelingButton;
        public static Button SaveLabelingButton = JazzButton.SaveLabelingButton;
        public static Button ModifyLabelingButton = JazzButton.ModifyLabelingButton;
        public static Button DeleteLabelingButton = JazzButton.DeleteLabelingButton;
        

        public static Grid LabelingList = JazzGrid.LabelingList;
        public static ComboBox IndustryComboBox = JazzComboBox.IndustryComboBox;
        public static ComboBox ClimateRegionComboBox = JazzComboBox.ClimateRegionComboBox;
        public static ComboBox EnergyEfficiencyLabelingLevelComboBox = JazzComboBox.EnergyEfficiencyLabelingLevelComboBox;
        public static ComboBox StartYearComboBox = JazzComboBox.StartYearComboBox;
        public static ComboBox EndYearComboBox = JazzComboBox.EndYearComboBox;

        //public static CheckBoxField ClimateRegionCheckBox = JazzCheckBox.CheckBoxLabeling;
        
        #endregion

        #region common action
        /// <summary>
        /// Navigate to Workday Calendar Setting Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToLabelingSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.IndustryLabelingSettings);
            //TimeManager.ShortPause();
            //Labeling.SelectItem();
        }

        /// <summary>
        /// Click Add button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickAddLabeling()
        {
            AddLabelingButton.Click();
        }

        /// <summary>
        /// Click Cancel button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelLabeling()
        {
            CancelLabelingButton.Click();
        }
     
        /// <summary>
        /// Click Save button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveLabeling()
        {
            SaveLabelingButton.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Click Modify button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyLabeling()
        {
            ModifyLabelingButton.Click();
        }

        /// <summary>
        /// Click Delete button
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickDeleteLabeling()
        {
            DeleteLabelingButton.Click();
        }
       
        /// <summary>
        /// Select industry combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectIndustryCombox(string itemName)
        {
            IndustryComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Select climatic region combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectClimateRegionCombox(string itemName)
        {
            ClimateRegionComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Select EnergyEfficiencyLabelingLevel combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEnergyEfficiencyLabelingLevelCombox(string itemName)
        {
            EnergyEfficiencyLabelingLevelComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Select StartYear  combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectStartYearCombox(string itemName)
        {
            StartYearComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Select EndYear combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectEndYearCombox(string itemName)
        {
            EndYearComboBox.SelectItem(itemName);
        }

        /// <summary>
        /// Click Industry combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayIndustryItems()
        {
            IndustryComboBox.DisplayItems();
        }

        /// <summary>
        /// Click ClimateRegion combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayClimateRegionItems()
        {
            ClimateRegionComboBox.DisplayItems();
        }

        /// <summary>
        /// Click EnergyEfficiencyLabelingLevel combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayEnergyEfficiencyLabelingLevelItems()
        {
            EnergyEfficiencyLabelingLevelComboBox.DisplayItems();
        }
        /// <summary>
        /// Click StartYear combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayStartYearItems()
        {
            StartYearComboBox.DisplayItems();
        }  
        
        /// <summary>
        /// Click EndYear combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void DisplayEndYearItems()
        {
            EndYearComboBox.DisplayItems();
        }

        /// <summary>
        /// Focus Labeling
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnLabeling(string labelingName,string climateregion)
        {
            LabelingList.FocusOnRow(labelingName, climateregion);
        }

        /// <summary>
        /// Focus Labeling
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnLabeling(string labelingName)
        {
            LabelingList.FocusOnRow(1, labelingName);
        }

        /// <summary>
        /// Verify Is Industry Add Message Displayed
        /// </summary>
        public Boolean IsIndustrysAddMessageDisplayed()
        {
            return IndustryComboBox.GetInvalidTips().Contains("必填项。");

        }

        /// <summary>
        /// Verify Is ClimateRegion Add Message Displayed
        /// </summary>
        public Boolean IsClimateRegionAddMessageDisplayed()
        {
            return ClimateRegionComboBox.GetInvalidTips().Contains("必填项。");

        }

        /// <summary>
        /// Verify Is EnergyEfficiencyLabelingLevel Add Message Displayed
        /// </summary>
        public Boolean IsEnergyEfficiencyLabelingLevelAddMessageDisplayed()
        {
            return EnergyEfficiencyLabelingLevelComboBox.GetInvalidTips().Contains("必填项。");

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
            return AddLabelingButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Save button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsSaveButtonDisplay()
        {
            return SaveLabelingButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Cancel button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsCancelButtonDisplay()
        {
            return CancelLabelingButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Delete button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsDeleteButtonDisplay()
        {
            return DeleteLabelingButton.IsDisplayed();
        }

        /// <summary>
        /// verify whether Modify button display.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean IsModifyButtonDisplay()
        {
            return ModifyLabelingButton.IsDisplayed();
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
            return IndustryComboBox.GetValue();
        }

        /// <summary>
        /// Get industrys in the industry combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetIndustryLists()
        {
            return string.Join(",", IndustryComboBox.GetCurrentDropdownListItems());
        }
       
        /// <summary>
        /// Get message in the ClimateRegion combox. 
        /// </summary>
        /// <returns></returns>
        public string GetSelectedClimateRegion()
        {
            return ClimateRegionComboBox.GetValue();
        }

        /// <summary>
        /// Get ClimateRegions in the industry combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetClimateRegionLists()
        {
            return string.Join(",", ClimateRegionComboBox.GetCurrentDropdownListItems());
        }


        /// <summary>
        /// Get message in the EnergyEfficiencyLabelingLevel combox. 
        /// </summary>
        /// <returns></returns>
        public string GetSelectedEnergyEfficiencyLabelingLevel()
        {
            return EnergyEfficiencyLabelingLevelComboBox.GetValue();
        }

        /// <summary>
        /// Get EnergyEfficiencyLabelingLevels in the industry combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetEnergyEfficiencyLabelingLevelLists()
        {
            return string.Join(",", EnergyEfficiencyLabelingLevelComboBox.GetCurrentDropdownListItems());
        }
        
        /// <summary>
        /// Get message in the StartYear combox. 
        /// </summary>
        /// <returns></returns>
        public string GetSelectedStartYear()
        {
            return StartYearComboBox.GetValue();
        }

        /// <summary>
        /// Get StartYears in the StartYear combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetStartYearLists()
        {
            return string.Join(",", StartYearComboBox.GetCurrentDropdownListItems());
        }       
        
        /// <summary>
        /// Get message in the EndYear combox. 
        /// </summary>
        /// <returns></returns>
        public string GetSelectedEndYear()
        {
            return EndYearComboBox.GetValue();
        }

        /// <summary>
        /// Get EndYears in the EndYear combox lists. 
        /// </summary>
        /// <returns></returns>
        public string GetEndYearLists()
        {
            return string.Join(",", EndYearComboBox.GetCurrentDropdownListItems());
        }


        /// <summary>
        /// Check whether the labelingIndustry list in the labeling List.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsRowExistLabelingListIndustry(string regionName)
        {
            return LabelingList.IsRowExist(1, regionName);
        }

        /// <summary>
        /// Check whether the labelingClimateRegion list in the labeling List.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsRowExistLabelingListClimateRegion(string regionName)
        {
            return LabelingList.IsRowExist(2, regionName);
        }

        /// <summary>
        /// Check whether the labeling list in the labeling List.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsRowExistLabelingList(string labelingName, string climateregion)
        {
            try
            {
                LabelingList.FocusOnRow(labelingName, climateregion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Check whether the industry list include the industry.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsIndustryInDropdownList(string regionName)
        {
            return IndustryComboBox.GetCurrentDropdownListItems().Contains(regionName);
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
                if (!(IndustryComboBox.GetCurrentDropdownListItems().Contains(industryNames[i])))
                    return false;
                i++;
            }
            return IndustryComboBox.GetCurrentDropdownListItems().Contains(industryNames[i - 1]);
        }

        /// <summary>
        /// Check whether the ClimateRegion list include the ClimateRegion.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsClimateRegionInDropdownList(string regionName)
        {
            return ClimateRegionComboBox.GetCurrentDropdownListItems().Contains(regionName);
        }

        /// <summary>
        /// Check whether the ClimateRegions list include the industry.  
        /// </summary>
        /// <returns></returns>
        public Boolean AreClimateRegionsInDropdownList(string[] ClimateRegionNames)
        {
            int j = 0;
            while (j < ClimateRegionNames.Length)
            {
                if (!(ClimateRegionComboBox.GetCurrentDropdownListItems().Contains(ClimateRegionNames[j])))
                    return false;
                j++;
            }
            return ClimateRegionComboBox.GetCurrentDropdownListItems().Contains(ClimateRegionNames[j - 1]);
        }

        /// <summary>
        /// Check whether the EnergyEfficiencyLabelingLevel list include the EnergyEfficiencyLabelingLevel.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsEnergyEfficiencyLabelingLevelInDropdownList(string regionName)
        {
            return EnergyEfficiencyLabelingLevelComboBox.GetCurrentDropdownListItems().Contains(regionName);
        }

        /// <summary>
        /// Check whether the EnergyEfficiencyLabelingLevels list include the industry.  
        /// </summary>
        /// <returns></returns>
        public Boolean AreEnergyEfficiencyLabelingLevelsInDropdownList(string[] EnergyEfficiencyLabelingLevelNames)
        {
            int k = 0;
            while (k < EnergyEfficiencyLabelingLevelNames.Length)
            {
                if (!(EnergyEfficiencyLabelingLevelComboBox.GetCurrentDropdownListItems().Contains(EnergyEfficiencyLabelingLevelNames[k])))
                    return false;
                k++;
            }
            return EnergyEfficiencyLabelingLevelComboBox.GetCurrentDropdownListItems().Contains(EnergyEfficiencyLabelingLevelNames[k - 1]);
        }
        
        /// <summary>
        /// Check whether the StartYear list include the StartYear.  
        /// </summary>
        /// <returns></returns>
        public Boolean IsStartYearInDropdownList(string regionName)
        {
            return StartYearComboBox.GetCurrentDropdownListItems().Contains(regionName);
        }

        /// <summary>
        /// Check whether the StartYears list include the StartYear.  
        /// </summary>
        /// <returns></returns>
        public Boolean AreStartYearsInDropdownList(string[] StartYearNames)
        {
            int x = 0;
            while (x < StartYearNames.Length)
            {
                if (!(StartYearComboBox.GetCurrentDropdownListItems().Contains(StartYearNames[x])))
                    return false;
                x++;
            }
            return ClimateRegionComboBox.GetCurrentDropdownListItems().Contains(StartYearNames[x - 1]);
        }

        public Boolean IsEndYearInDropdownList(string regionName)
        {
            return EndYearComboBox.GetCurrentDropdownListItems().Contains(regionName);
        }

        /// <summary>
        /// Check whether the EndYears list include the EndYear.  
        /// </summary>
        /// <returns></returns>
        public Boolean AreEndYearsInDropdownList(string[] EndYearNames)
        {
            int y = 0;
            while (y < EndYearNames.Length)
            {
                if (!(EndYearComboBox.GetCurrentDropdownListItems().Contains(EndYearNames[y])))
                    return false;
                y++;
            }
            return EndYearComboBox.GetCurrentDropdownListItems().Contains(EndYearNames[y - 1]);
        }

       /// <summary>
        /// Check whether the industry combox could not be modified.  
        /// </summary>
        /// <returns></returns>
         public Boolean IsIndustryComboxEnabled()
        {
            return IndustryComboBox.IsComboBoxTextEnabled();
        }

         /// <summary>
         /// Check whether the ClimateRegion combox could not be modified.  
         /// </summary>
         /// <returns></returns>
        public Boolean IsClimateRegionComboxEnabled()
        {
            return ClimateRegionComboBox.IsComboBoxTextEnabled();
        }

      #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using System.Collections;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of customer management.
    /// </summary>
    public class CommodifyUomSetting
    {
        internal CommodifyUomSetting()
        {

        }

        #region Controls

        private Grid PTagList = JazzGrid.PTagSettingsPTagList;
        private Grid VTagList = JazzGrid.VTagSettingsVTagList;
        private Grid CustomizedLabellingList = JazzGrid.CustomizedLabellingListGrid;

        private static Button PtagModifyButton = JazzButton.PTagSettingsModifyButton;
        private static Button VtagModifyButton = JazzButton.VTagSettingsModifyButton;
        private static Button CusLabelingModifyButton = JazzButton.ModifyCustomizedLabellingButton;

        private static ComboBox PCommodityComboBox = JazzComboBox.PTagSettingsCommodityComboBox;
        private static ComboBox PUomComboBox = JazzComboBox.PTagSettingsUomComboBox;

        private static ComboBox VCommodityComboBox = JazzComboBox.VTagSettingsCommodityComboBox;
        private static ComboBox VUomComboBox = JazzComboBox.VTagSettingsUomComboBox;

        private static ComboBox CCommodityComboBox = JazzComboBox.CustomizedLabellingCommodityComboBox;
        private static ComboBox CUomComboBox = JazzComboBox.CustomizedLabellingUomComboBox;


        #endregion

        #region Common
        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToPtagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Navigate to VTag settings
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToVTagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Navigate to CustomizedLabelling Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToCustomizedLabelling()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomizedLabelling);
            TimeManager.ShortPause();
        }

        // <summary>
        /// Focus ptag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnPTagByName(string ptagName)
        {
            PTagList.FocusOnRow(2, ptagName);
        }

        // <summary>
        /// Focus vtag by name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnVTagByName(string vtagName)
        {
            VTagList.FocusOnRow(2, vtagName);
        }

        /// <summary>
        /// Focus Labeling
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void FocusOnCustomizedLabelling(string labelingName)
        {
            CustomizedLabellingList.FocusOnRow(1, labelingName);
        }

        /// <summary>
        /// Click "ptagmodify" button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickPModifyButton()
        {
            PtagModifyButton.Click();
        }

        /// <summary>
        /// Click "Vtagmodify" button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickVModifyButton()
        {
            VtagModifyButton.Click();
        }

        /// <summary>
        /// Click "CusLabelingmodify" button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickCusLabelingModifyButton()
        {
            CusLabelingModifyButton.Click();
        }

        /// <summary>
        /// Click "P-Commodity" Combox button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickPCommodityComboxButton()
        {
            PCommodityComboBox.DisplayItems();
        }

        /// <summary>
        /// Select p commodity combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectPCommodityComboBox(string ItemName)
        {
            PCommodityComboBox.SelectItem(ItemName);
        }
        /// <summary>
        /// Return P Commodity ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetPCommodityComboBoxList()
        {
            return PCommodityComboBox.GetCurrentDropdownListItems();
        }
        /// <summary>
        /// Return P uoms ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetPUOMsComboBoxList()
        {
            return PUomComboBox.GetCurrentDropdownListItems();
        }

        /// <summary>
        /// Click "V-Commodity" Combox button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickVCommodityComboxButton()
        {
            VCommodityComboBox.DisplayItems();
        }

        /// <summary>
        /// Select "V-Commodity"
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectVCommodityComboBox(string ItemName)
        {
            VCommodityComboBox.SelectItem(ItemName);
        }
        /// <summary>
        /// Return V-Commodity ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetVCommodityComboBoxList()
        {
            return VCommodityComboBox.GetCurrentDropdownListItems();
        }
        /// <summary>
        /// Return v uoms ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetVUOMsComboBoxList()
        {
            return VUomComboBox.GetCurrentDropdownListItems();
        }
        /// <summary>
        /// Click "CustomizedLabellingCommodity" Combox button 
        /// </summary>
        /// <param>Tag name</param>
        /// <returns></returns>
        public void ClickCCommodityComboxButton()
        {
            CCommodityComboBox.DisplayItems();
        }

        /// <summary>
        /// Change CustomizedLabellingCommodity combox
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void SelectCCommodityComboBox(string ItemName)
        {
            CCommodityComboBox.SelectItem(ItemName);
        }
        /// <summary>
        /// Return CustomizedLabellingCommodity ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetCCommodityComboBoxList()
        {
            return CCommodityComboBox.GetCurrentDropdownListItems();
        }
        /// <summary>
        /// Return P uoms ComboBox value
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public ArrayList GetCUOMsComboBoxList()
        {
            return CUomComboBox.GetCurrentDropdownListItems();
        }
        #endregion
    }
}

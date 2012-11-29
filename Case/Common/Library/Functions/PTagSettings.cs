using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of physical tag configuration.
    /// </summary>
    public class PTagSettings
    {
        internal PTagSettings()
        {
        }

        private static Grid PTagList;

        private static Button CreatePTagButton;

        private static Button ModifyButton;
        private static Button SaveButton;
        private static Button CancelButton;
        private static Button DeleteButton;

        private static TextField NameTextField;
        private static TextField CodeTextField;
        private static TextField MeterCodeTextField;
        private static TextField ChannelTextField;
        private static ComboBox CommodityComboBox;
        private static ComboBox UomComboBox;
        private static ComboBox CalculationTypeComboBox;
        private static TextField CommentTextField;
        
        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToPtagSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            TimeManager.PauseShort();
        }

        /// <summary>
        /// Click "add ptag" button to add one ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddPtag()
        {
            CreatePTagButton.Click();
        }

        /// <summary>
        /// Click save button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Input name, code, metercode, channelid, commodityid, uomid, calculationtype and comment of the ptag
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInPtag(PtagInputData input)
        {
            NameTextField.Fill(input.Name);
            CodeTextField.Fill(input.Code);
            MeterCodeTextField.Fill(input.MeterCode);
            ChannelTextField.Fill(input.ChannelId);
            CommodityComboBox.SelectItem(input.Commodity);
            UomComboBox.SelectItem(input.Uom);
            CalculationTypeComboBox.SelectItem(input.CalculationType);
            CommentTextField.Fill(input.Comment);
        }

        public void FillInCode(string code)
        {
            CodeTextField.Fill(code);
        }

        /// <summary>
        /// Click "modify" button to modify one ptag
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns></returns>
        public void PrepareToModifyPtag(string tagName)
        {
            PTagList.FocusOnRow(1,tagName);
            ModifyButton.Click();
        }

        /// <summary>
        /// Get the tag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return NameTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Code actual value
        /// </summary>
        /// <returns></returns>
        public string GetCodeValue()
        {
            return CodeTextField.GetValue();
        }

        /// <summary>
        /// Get the tag MeterCode actual value
        /// </summary>
        /// <returns></returns>
        public string GetMeterCodeValue()
        {
            return MeterCodeTextField.GetValue();
        }

        /// <summary>
        /// Get the tag ChannelId actual value
        /// </summary>
        /// <returns></returns>
        public string GetChannelIdValue()
        {
            return ChannelTextField.GetValue();
        }

        /// <summary>
        /// Get the tag Commodity actual value
        /// </summary>
        /// <returns></returns>
        public string GetCommodityValue()
        {
            return CommodityComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag Commodity expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Commodity key</param>
        /// <returns>Key value</returns>
        public string GetCommodityExpectedValue(string itemKey)
        {
            return CommodityComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag Uom actual value
        /// </summary>
        /// <returns></returns>
        public string GetUomValue()
        {
            return UomComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag Uom expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Uom key</param>
        /// <returns>Key value</returns>
        public string GetUomExpectedValue(string itemKey)
        {
            return UomComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag CalculationType actual value
        /// </summary>
        /// <returns></returns>
        public string GetCalculationTypeValue()
        {
            return CalculationTypeComboBox.GetValue();
        }

        /// <summary>
        /// Get the tag CalculationType expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">CalculationType key</param>
        /// <returns>Key value</returns>
        public string GetCalculationTypeExpectedValue(string itemKey)
        {
            return CalculationTypeComboBox.GetActualValue(itemKey);
        }

        /// <summary>
        /// Get the tag Comment actual value
        /// </summary>
        /// <returns></returns>
        public string GetCommentValue()
        {
            return CommodityComboBox.GetValue();
        }

        public void FocusOnPTag(string ptagName)
        {
            PTagList.FocusOnRow(1,ptagName);
        }
    }
}

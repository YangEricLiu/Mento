using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration.Tag.PtagConfiguration;


namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of physical tag configuration.
    /// </summary>
    public class Ptag
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        private Navigator navigatorInstance = ControlAccess.GetControl<Navigator>();
        private TextField textFieldInstance = ControlAccess.GetControl<TextField>();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        private Grid tagInstance = ControlAccess.GetControl<Grid>();
        private Button buttonInstance = ControlAccess.GetControl<Button>();
        
        /// <summary>
        /// Navigate to Ptag Configuration Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToPtagSetting()
        {
            navigatorInstance.NavigateToTarget(NavigationTarget.TagSettingsP);
            ElementLocator.Pause(2000);
        }

        /// <summary>
        /// Click "add ptag" button to add one ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void PrepareToAddPtag()
        {
            buttonInstance.ClickButton(ElementDictionary[ElementKey.PtagAddButton]);
        }

        /// <summary>
        /// Click save button for ptag
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            buttonInstance.ClickButton(ElementDictionary[ElementKey.PtagSaveButton]);
        }

        /// <summary>
        /// Input name, code, metercode, channelid, commodityid, uomid, calculationtype and comment of the ptag
        /// </summary>
        /// <param name="input">Test data</param>
        /// <returns></returns>
        public void FillInPtag(PtagInputData input)
        {
            textFieldInstance.FillIn(ElementKey.PtagName, input.Name);
            textFieldInstance.FillIn(ElementKey.PtagCode, input.Code);
            textFieldInstance.FillIn(ElementKey.PtagMeterCode, input.MeterCode);
            textFieldInstance.FillIn(ElementKey.PtagChannelId, input.ChannelId);
            comboBoxInstance.DisplayItems(ElementKey.PtagCommodityId);
            comboBoxInstance.SelectItem(input.CommodityId);
            comboBoxInstance.DisplayItems(ElementKey.PtagUomId);
            comboBoxInstance.SelectItem(input.UomId);
            comboBoxInstance.DisplayItems(ElementKey.PtagCalculationType);
            comboBoxInstance.SelectItem(input.CalculationType);
            textFieldInstance.FillIn(ElementKey.PtagComment, input.Comment);
        }

        /// <summary>
        /// Click "modify" button to modify one ptag
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns></returns>
        public void PrepareToModifyPtag(string tagName)
        {
            FocusOnTag(tagName);
            buttonInstance.ClickButton(ElementDictionary[ElementKey.PtagUpdateButton]);
        }
        
        /// <summary>
        /// Input code of the ptag 
        /// </summary>
        /// <param name="code">Ptag code</param>
        /// <returns></returns>
        public void FillInCode(string code)
        {
            textFieldInstance.FillIn(ElementKey.PtagCode, code);
        }

        /// <summary>
        /// Select one tag
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <returns></returns>
        public void FocusOnTag(string tagName)
        {
            tagInstance.FocusOnRow(tagName);
        }

        /// <summary>
        /// Get the tag Name actual value
        /// </summary>
        /// <returns></returns>
        public string GetNameValue()
        {
            return textFieldInstance.GetValue(ElementKey.PtagName);
        }

        /// <summary>
        /// Get the tag Code actual value
        /// </summary>
        /// <returns></returns>
        public string GetCodeValue()
        {
            return textFieldInstance.GetValue(ElementKey.PtagCode);
        }

        /// <summary>
        /// Get the tag Uom actual value
        /// </summary>
        /// <returns></returns>
        public string GetUomValue()
        {
            return comboBoxInstance.GetValue(ElementKey.PtagUomId);
        }

        /// <summary>
        /// Get the tag Uom expected value, for language sensitive
        /// </summary>
        /// <param name = "itemKey">Uom key</param>
        /// <returns>Key value</returns>
        public string GetUomExpectedValue(string itemKey)
        {
            return comboBoxInstance.GetItemTypeLangValue(itemKey);
        }

    }
}

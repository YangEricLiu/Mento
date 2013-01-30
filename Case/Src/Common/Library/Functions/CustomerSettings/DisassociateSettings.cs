using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class DisassociateSettings
    {
        internal DisassociateSettings()
        {
        }

        private Grid TagList = JazzGrid.AssociationTagList;
        /// <summary>
        /// Click the "associate tags" button
        /// </summary>
        /// <returns></returns>
        public void ClickDisassociateButton()
        {
            JazzButton.AssociationSettingsDisassociate.Click();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        /// <summary>
        /// Click the tag in grid to select the tag
        /// </summary>
        /// <param name = "tagName">the tag name</param>
        /// <returns></returns>
        public void FocusOnTag(String tagName)
        {
            TagList.FocusOnRow(3, tagName);
        }

        public void ClickAssociatedCancel()
        {
            JazzButton.AssociationSettingCancel.Click();
        }
    }
}
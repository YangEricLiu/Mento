using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class ShareWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'receiverwindow') and contains(@class,'x-window-default')]", ByType.XPath);

        internal ShareWindow() : base(Locator) { }

        #region controls

        //window title
        private static Label ShareWindowTitle = JazzLabel.ShareWindowTitleLabel;

        //Close window button
        private static Button ShareWindowClose = JazzButton.ShareWindowCloseButton;

        //Share button
        private static Button ShareButton = JazzButton.ShareWindowShareButton;

        //Giveup button
        private static Button GiveupButton = JazzButton.ShareWindowGiveupButton;

        #endregion

        #region operation

        public string GetShareWindowTitle()
        {
            return ShareWindowTitle.GetLabelTextValue();
        }

        public void ClickShareWindowCloseButton()
        {
            ShareWindowClose.Click();
        }

        public void ClickShareButton()
        {
            ShareButton.Click();
        }

        public void ClickGiveupButton()
        {
            GiveupButton.Click();
        }

        #endregion

    }
}

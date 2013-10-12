using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    internal class ShareInfoWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'window') and contains(@class,'x-window-default')]", ByType.XPath);

        internal ShareInfoWindow() : base(Locator) { }

        #region controls

        //Received Share info tab
        private static TabButton ShareInfoReceived = JazzButton.ShareInfoReceivedTabButton;

        //Sended Share info tab
        private static TabButton ShareInfoSended = JazzButton.ShareInfoSendedTabButton;

        #endregion

        #region operation

        public void ClickShareInfoReceivedButton()
        {
            ShareInfoReceived.Click();
        }

        public void ClickShareInfoSendedButton()
        {
            ShareInfoSended.Click();
        }


        #endregion

    }
}

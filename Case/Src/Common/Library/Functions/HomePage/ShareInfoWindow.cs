using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class ShareInfoWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'window') and contains(@class,'x-window-default')]", ByType.XPath);

        public ShareInfoWindow() : base(Locator) { }

        #region controls

        //Received Share info tab
        private static TabButton ShareInfoReceived = JazzButton.ShareInfoReceivedTabButton;

        //Sended Share info tab
        private static TabButton ShareInfoSended = JazzButton.ShareInfoSendedTabButton;

        //Share info grid
        private static Grid GridShareInfoList = JazzGrid.GridShareInfoList;

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

        public bool IsRowExisted(int cellIndex, string cellString)
        {
            return GridShareInfoList.IsRowExist(cellIndex, cellString);
        }

        public bool IsRowBold(int cellIndex, string cellString)
        {
            return GridShareInfoList.IsGridRowBold(cellIndex, cellString);
        }

        public void ClickRowColumn(int cellIndex, string cellString)
        {
            GridShareInfoList.ClickShareInfoWindowRowColumn(cellIndex, cellString);
        }
        #endregion

    }
}

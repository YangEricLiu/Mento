using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class ShareWindow : Window
    {
        private static Locator Locator = new Locator("//div[contains(@id,'receiverwindow') and contains(@class,'x-window-default')]", ByType.XPath);

        public ShareWindow() : base(Locator) { }

        #region controls

        //window title
        //private static Label ShareWindowTitle = JazzLabel.ShareWindowTitleLabel;

        //Close window button
        //private static Button ShareWindowClose = JazzButton.ShareWindowCloseButton;

        //Share button
        private static Button ShareButton = JazzButton.ShareWindowShareButton;

        //Enjoy button
        private static Button EnjoyButton = JazzButton.ShareWindowEnjoyButton;

        //Giveup button
        private static Button GiveupButton = JazzButton.ShareWindowGiveupButton;

        //Share users contains
        private static Container ShareWindowTo = JazzContainer.ShareWindowToContainer;

        //Share grid
        private static Grid ShareUserList = JazzGrid.ShareUserListGrid;

        #endregion

        #region operation
        /*
        public string GetShareWindowTitle()
        {
            return ShareWindowTitle.GetLabelTextValue();
        }

        public void ClickShareWindowCloseButton()
        {
            ShareWindowClose.Click();
        }
        */
        public void ClickShareButton()
        {
            ShareButton.Click();
        }

        public void ClickEnjoyButton()
        {
            EnjoyButton.Click();
        }

        public bool IsShareButtonEnable()
        {
            return ShareButton.IsEnabled();
        }

        public void ClickGiveupButton()
        {
            GiveupButton.Click();
        }

        public void ClickRemoveShareUserButton(string name)
        {
            Button ShareUser = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonShareToUserRemove, name);

            ShareUser.Click();
        }

        public bool IsShareUserInContainer(string name)
        {
            Button ShareUser = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonShareToUserRemove, name);

            return ShareUser.IsExisted();
        }

        public void CheckShareUser(string userName)
        {
            ShareUserList.CheckShareWindowRowCheckbox(2, userName, false);
        }

        public void UncheckShareUser(string userName)
        {
            ShareUserList.UncheckShareWindowRowCheckbox(2, userName, false);
        }

        public bool IsShareUserExistedOnWindow(string userName)
        {
            return ShareUserList.IsRowExist(2, userName);
        }

        public bool IsShareUserChecked(string userName)
        {
            return ShareUserList.IsShareWindowRowChecked(2, userName, false);
        }

        public void CheckAllShareUsers()
        {
            ShareUserList.CheckShareHeaderCheckbox();    
        }

        public bool IsAllShareUsersChecked()
        {
            return ShareUserList.IsShareWindowRowsAllChecked();
        }

        public void UncheckAllShareUsers()
        {
            if (IsShareHeaderChecked())
            {
                ShareUserList.CheckShareHeaderCheckbox();
            }
        }

        public bool IsShareHeaderChecked()
        {
            return ShareUserList.IsShareHeaderChecked();
        }

        public int GetShareUserNumber()
        {
            return ShareWindowTo.GetElementNumber();
        }
        #endregion

    }
}

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
        private static Button ShareWindowEnjoyButton = JazzButton.ShareWindowEnjoyButton;

        //Giveup button
        private static Button ShareWindowGiveupButton = JazzButton.ShareWindowGiveupButton;

        //Invite Other button
        private static Button InviteOtherButton = JazzButton.InviteOtherButton;

        //close subcriber list window
        private static Button CloseSubcribeWindowButton = JazzButton.CloseSubcribeWindowButton;

        //Share users contains
        //private static Container ShareWindowTo = JazzContainer.ShareWindowToContainer;

        //Share grid
        private static Grid ShareUserList = JazzGrid.ShareUserListGrid;

        //Sended list grid
        private static Grid SendedUserList = JazzGrid.SendedUserListGrid;

        //Enjoy grid
        private static Grid TrueShareUserList = JazzGrid.TrueShareUserListGrid;

        //Enjoy Sended list grid
        private static Grid TrueSendedUserList = JazzGrid.TrueSendedUserListGrid;

        //Subscribe user list grid
        private static Grid SubscribeUserList = JazzGrid.SubscribeUserListGrid;

        //Enjoy window comment
        private static TextField EnjoyWindowComment = JazzTextField.ShareReceiveWindowCommentTextField;

        #endregion

        #region share operation
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

        public bool IsShareButtonEnable()
        {
            return ShareButton.IsEnabled();
        }

        public void ClickGiveupButton()
        {
            ShareWindowGiveupButton.Click();
        }

        public void ClickRemoveShareUserButton(string name)
        {
            SendedUserList.FloatOnRow(1, name, false);

            SendedUserList.GetSendedListRowDeleteX(1, name, false).Click();
        }

        public bool IsShareUserInSendedList(string name)
        {
            return SendedUserList.IsRowExist(1, name);
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
            return SendedUserList.GetCurrentRowsNumber();
        }

        #endregion

        #region Enjoy operation

        public void CloseSubcriberListWindow()
        {
            CloseSubcribeWindowButton.Click();
        }

        public void ClickInviteOtherButton()
        {
            InviteOtherButton.Click();
        }

        public void ClickEnjoyButton()
        {
            ShareWindowEnjoyButton.Click();
        }

        public void ClickGiveUpEnjoyButton()
        {
            ShareWindowGiveupButton.Click();
        }

        public bool IsEnjoyButtonEnable()
        {
            return ShareWindowEnjoyButton.IsEnabled();
        }

        public bool IsEnjoyUserInSendedList(string name)
        {
            return TrueSendedUserList.IsRowExist(1, name);
        }

        public bool IsEnjoyUserInShareList(string name)
        {
            return TrueShareUserList.IsRowExist(2, name);
        }

        public bool IsEnjoyUserInSubscribeUserList(string name)
        {
            return SubscribeUserList.IsRowExist(1, name);
        }

        public void FloatOnSubscriberUser(string name)
        {
            SubscribeUserList.FloatOnRow(1, name, false);
            TimeManager.MediumPause();
        }

        public void FocusOnSubscriberUser(string name)
        {
            SubscribeUserList.FocusOnRow(1, name, false);
            TimeManager.LongPause();
        }

        public string GetRemoveorQuitSubcriberText(string name)
        {
            return SubscribeUserList.GetRowRemoveorQuitText(1, name);
        }

        public void ClickRemoveEnjoyUserButton(string name)
        {
            TrueSendedUserList.FloatOnRow(1, name, false);

            TrueSendedUserList.GetSendedListRowDeleteX(1, name, false).Click();
        }

        public void ClickRemoveorQuitSubcriberButton(string name)
        {
            SubscribeUserList.ClickRemoveorQuitRowButton(1, name);
        }

        public void CheckEnjoyUser(string userName)
        {
            TrueShareUserList.CheckShareWindowRowCheckbox(2, userName, false);
        }

        public void UncheckEnjoyUser(string userName)
        {
            TrueShareUserList.UncheckShareWindowRowCheckbox(2, userName, false);
        }

        public bool IsEnjoyUserExistedOnWindow(string userName)
        {
            return TrueShareUserList.IsRowExist(2, userName);
        }

        public bool IsEnjoyUserChecked(string userName)
        {
            return TrueShareUserList.IsShareWindowRowChecked(2, userName, false);
        }

        public void CheckAllEnjoyUsers()
        {
            TrueShareUserList.CheckShareHeaderCheckbox();
        }

        public bool IsAllEnjoyUsersChecked()
        {
            return TrueShareUserList.IsShareWindowRowsAllChecked();
        }

        public void UncheckAllEnjoyUsers()
        {
            if (IsEnjoyHeaderChecked())
            {
                TrueShareUserList.CheckShareHeaderCheckbox();
            }
        }

        public bool IsEnjoyHeaderChecked()
        {
            return TrueShareUserList.IsShareHeaderChecked();
        }

        public int GetEnjoyUserNumber()
        {
            return TrueSendedUserList.GetCurrentRowsNumber();
        }

        public void FillEnjoyWindowComment(string comment)
        {
            EnjoyWindowComment.Fill(comment);
        }

        public string GetEnjoyWindowComment()
        {
            return EnjoyWindowComment.GetValue();
        }

        #endregion

    }
}

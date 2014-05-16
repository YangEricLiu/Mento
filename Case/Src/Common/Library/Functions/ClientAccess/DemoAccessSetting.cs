using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.TestData;


namespace Mento.ScriptCommon.Library.Functions
{
   public class DemoAccessSetting
    {
        internal DemoAccessSetting()
        {
        }

        #region Controls
        public static Button DemoAccessButton = JazzButton.DemoAccessButton;
        public static Button SendDemoAccessEmailButton = JazzButton.SendDemoAccessEmailButton;
        public static Button ReturnHomepageButton = JazzButton.ReturnHomepageButton;

        private static TextField DemoAccessEmailAddress = JazzTextField.DemoAccessEmailAddressTextField;
        public static Label EmailSendedSuccessTips = JazzLabel.LabelEmailSendedSuccessTips;
        private static Grid GridUserList = JazzGrid.UserListGrid;

        #endregion

        #region Verify
        /// <summary>
        /// Check the DemoAccess could be visiable. 
        /// </summary>
        /// <returns></returns>
        public void DemoAccessButtonIsVisiable()
        {
            DemoAccessButton.IsExisted();
        }

        /// <summary>
        /// Popup  the valid email's sended message. 
        /// </summary>
        /// <returns></returns>
        public string GetEmailSendedMessage()
        {
            return EmailSendedSuccessTips.GetLabelTextValue();
           //return DemoAccessEmailAddress.GetEmailSendedTips();

        }

        /// <summary>
        /// Popup  the invalid email's wrong message. 
        /// </summary>
        /// <returns></returns>
        public string GetEmailInvalidMessage()
        {
            return DemoAccessEmailAddress.GetEmailInvalidTips();
        }
        #endregion


        /// <summary>
        /// Navigate to UserManagement  Page
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToUserManagement ()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
        }

        /// <summary>
        /// Fillin DemoAccessEmailAddress in the DemoAccessEmailAddressTextField. 
        /// </summary>
        /// <returns></returns>
        public void FillInDemoAccessEmailAddressInfo(string itemName)
        {
            DemoAccessEmailAddress.Fill(itemName);
        }

    }
}

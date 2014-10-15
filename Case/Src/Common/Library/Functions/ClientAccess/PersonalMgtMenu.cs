using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of User Profile.
    /// </summary>
    public class PersonalMgtMenu
    {
        
        private static Button MenuButton = JazzButton.UserProfileButton;
        private static Button ViewButton = JazzButton.UserProfileViewMenuButton;
        private static Button ModifyPassword = JazzButton.UserPasswordModifyMenuButton;
        private static Button ExitJazzButton = JazzButton.ExitJazzMenuButton;
        public static UserProfileDialog UserProfileDialog = new UserProfileDialog();
        public static UserPasswordDialog UserPasswordDialog = new UserPasswordDialog();
        
        
        /// <summary>
        /// Navigate to  User Profile
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToUserProfile()
        {
            MenuButton.Click();
        }

        /// <summary>
        /// click "View user profile" button
        /// </summary>
        /// <param>View user profile button</param>
        /// <returns></returns>
        public void ClickViewUserProfile()
        {
            ViewButton.Click();
        }

        /// <summary>
        /// Get name expected value
        /// </summary>
        /// <param name = "name">name key</param>
        /// <returns>Name value</returns>
        public void ModifyUserPassword()
        {
         ModifyPassword.Click();
        }

        public void ExitJazz()
        { 
            ExitJazzButton.Click();
        }
    }
    
}

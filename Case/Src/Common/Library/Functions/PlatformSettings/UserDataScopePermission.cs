﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of User Data scope permission setting.
    /// </summary>
    public class UserDataScopePermission
    {
        internal UserDataScopePermission()
        {
        }

        #region controls
        private static Grid DataPermissonList = JazzGrid.DataPermissonList;
        private static Grid CustomerList = JazzGrid.CustomerList;
        private static Grid DataPermissionCustomerList = JazzGrid.DataPermissionCustomerList;

        private static Button ModifyButton = JazzButton.ModifyUserDataPermissionButton;
        private static Button SaveButton = JazzButton.SaveUserDataPermissionButton;
        private static Button CancelButton = JazzButton.CancelUserDataPermissionButton;
        private static Button CloseTreeViewButton = JazzButton.ClosePermissionTreeWindowButton;
        private static Button UserBasicPropertiesTab = JazzButton.TabButtonUserBasicProperties;
        private static Button UserDataPermissionTab = JazzButton.TabButtonUserDataPermission;
        private static Button TreeWindowSaveButton = JazzButton.TreeWindowSaveButton;
        private static Button TreeWindowCancelButton = JazzButton.TreeWindowCancelButton;
        private static TreeView UserDataPermissionTree = JazzTreeView.DataPermissionHierarchyTree;

        private static Button SelectAllDataPermission = JazzButton.UserSelectAllDataPermissionButton;
        private static Button CustomerNames = JazzButton.UserCustomerNamesButton;
        private static Button CustomerNameViewStatus = JazzButton.CustomerNamesViewStatusButtons;
        
        private static CheckBoxField CheckAllHierarchyNodesCheckBox = JazzCheckBox.UserDataAllHierarchyNodeCheckBoxField;
        private static CheckBoxField CheckAllDataScopeCheckBox = JazzCheckBox.UserAllDataScopeCheckBoxField;

        private static HierarchyTree HierarchyTree
        {
            get;
            set;
        }

        #endregion

        #region common action

        /// <summary>
        /// Navigate to User setting
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void NavigatorToUserSetting()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UserManagement);
        }

        /// <summary>
        /// Click save button to save new user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        /// <summary>
        /// Click Modify button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickModifyButton()
        {
            ModifyButton.Click();
        }

        /// <summary>
        /// Click cancel button to cancel add user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        /// <summary>
        /// Check All Customer Data Permission 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean CheckAllCustomerDatas()
        {
            try
            {
                TimeManager.MediumPause();
                SelectAllDataPermission.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check Customer Name Data Permission 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void CheckAllCumstomerNames()
        {
            TimeManager.MediumPause();
            CustomerNames.Click();
            TimeManager.LongPause();
            //CustomerNameLinkButton.Click();
        }

        /// <summary>
        /// Check Customer Name Data Permission 
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public void CheckCustomer(string customerName)
        {
            Boolean page = true;
            DataPermissonList.CheckDataPermissionRowCheckbox(4,customerName,page);
        }

        /// <summary>
        /// Verify Customer Name Data Permission checked
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public void UnCheckCustomer(string customerName)
        {
            Boolean page = true;
            DataPermissonList.UnCheckDataPermissionRowCheckbox(4, customerName, page);
        }

        /// <summary>
        /// Uncheck all datas
        /// </summary>
        /// <returns></returns>
        public void UnCheckAllData()
        {
            if (CheckAllDataScopeCheckBox.IsAllDataScopeItemChecked())
            {
                SelectAllDataPermission.Click();
            }
        }

        
        /// <summary>
        /// Get customer lists
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public Boolean IsCustomerView(string customerName)
        {
            return DataPermissionCustomerList.GetAllData().ToString().Contains(customerName);

        }
         

        
        /// <summary>
        /// Click Edit Data Permission  scope  link button
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public Boolean ClickEditDataPermission(string customerName)
        {
            try
            {
                Boolean page = true;
                DataPermissonList.ClickDataPermissionRow(4, customerName, page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// No Hierarchy nodes 
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchyNodesExist(string hierarchyNode)
        {
            return CheckAllHierarchyNodesCheckBox.ToString().Contains(hierarchyNode);
        }

        /// <summary>
        /// Click All hierarchy nodes 
        /// </summary>
        /// <returns></returns>
        public void CheckAllHierarchyNode()
        {
            CheckAllHierarchyNodesCheckBox.DataAllHierarchyCheck();
        }

        /// <summary>
        /// Uncheck All hierarchy nodes 
        /// </summary>
        /// <returns></returns>
        public Boolean UnCheckAllHierarchyNode()
        {
            Boolean flag =  true;
            try
            {
                if (CheckAllHierarchyNodesCheckBox.IsDataAllhierarchyBoxChecked())
                {
                    CheckAllHierarchyNodesCheckBox.DataAllHierarchyCheck();
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Check Whether the view and edit link button is enable 
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public Boolean IsCustomerUnchecked(string customerName)
        {
            Boolean page = true;
            return DataPermissonList.IsDataPermissionRowUnChecked(4,customerName,page);
        }
        /*
        /// <summary>
        /// Check Whether the view and edit link button is enable 
        /// </summary>
        /// <param>Cumtomer name</param>
        /// <returns></returns>
        public Boolean IsCustomerDisplayed(string customerName)
        {
            return DataPermissonList.GetAllRowText().Contains(customerName);
        }
        */
        /// <summary>
        /// Click Close hierarchy tree view button
        /// </summary>
        /// <returns></returns>
        public void CloseTreeWindow()
        {
            TimeManager.ShortPause();
            CloseTreeViewButton.Click();
            TimeManager.ShortPause();
        }

        /// <summary>
        /// Check  certain hierarchy node
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchyNode(string[] hierarchNodePaths)
        {
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                UserDataPermissionTree.CheckNode(hierarchNodePaths.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// UnCheck  certain hierarchy node
        /// </summary>
        /// <returns></returns>
        public void UnCheckHierarchyNode(string[] hierarchNodePaths)
        {
            TimeManager.LongPause();
            UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
            UserDataPermissionTree.UncheckNode(hierarchNodePaths.Last());
        }

        /// <summary>
        /// Check  hierarchy building node.
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchyBuildingNode(string[] hierarchNodePaths)
        {
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                UserDataPermissionTree.CheckNode(hierarchNodePaths.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check  hierarchy Site node. 
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchySiteNode(string[] hierarchFullNodePaths)
        {
             string[] sitePath = new string[hierarchFullNodePaths.Length - 1];
             Array.Copy(hierarchFullNodePaths,sitePath,3);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(sitePath);
                UserDataPermissionTree.CheckNode(sitePath.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// UnCheck  hierarchy Site node. 
        /// </summary>
        /// <returns></returns>
        public Boolean UnCheckHierarchySiteNode(string[] hierarchFullNodePaths)
        {
            string[] sitePath = new string[hierarchFullNodePaths.Length];
            Array.Copy(hierarchFullNodePaths, sitePath, 3);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(sitePath);
                UserDataPermissionTree.UncheckNode(sitePath.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check  hierarchy Orz node. 
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchyOrzNode(string[] hierarchFullNodePaths)
        {
            string[] OrzPath = new string[hierarchFullNodePaths.Length];
            Array.Copy(hierarchFullNodePaths, OrzPath, 2);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(OrzPath);
                UserDataPermissionTree.CheckNode(OrzPath.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        ///UnCheck  hierarchy Orz node. 
        /// </summary>
        /// <returns></returns>
        public Boolean UnCheckHierarchyOrzNode(string[] hierarchFullNodePaths)
        {
            string[] OrzPath = new string[hierarchFullNodePaths.Length];
            Array.Copy(hierarchFullNodePaths, OrzPath, 2);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(OrzPath);
                UserDataPermissionTree.UncheckNode(OrzPath.Last());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check  hierarchy customer node. 
        /// </summary>
        /// <returns></returns>
        public Boolean CheckHierarchyCustomerNode(string[] hierarchFullNodePaths)
        {
            string[] CustomerPath = new string[hierarchFullNodePaths.Length];
            Array.Copy(hierarchFullNodePaths, CustomerPath, 1);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(CustomerPath);
                UserDataPermissionTree.CheckNode(CustomerPath[0]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// UnCheck  hierarchy customer node. 
        /// </summary>
        /// <returns></returns>
        public Boolean UnCheckHierarchyCustomerNode(string[] hierarchFullNodePaths)
        {
            string[] CustomerPath = new string[hierarchFullNodePaths.Length];
            Array.Copy(hierarchFullNodePaths, CustomerPath, 1);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(CustomerPath);
                UserDataPermissionTree.UncheckNode(CustomerPath[0]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check  a  hierarchy node
        /// </summary>
        /// <returns></returns>
        public Boolean CheckSingleHierarchyNode(string hierarchNode)
        {
            try
            {
                TimeManager.LongPause();
                //UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                UserDataPermissionTree.CheckNode(hierarchNode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
        /// <summary>
        /// Verify whether the node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean AreAllCustomerListUncheck()
        {
            //Locator ss = new Locator();

            //ElementHandler.Exists();
            int i = 0;
            // string[] Customer = new ;
            Boolean page = true;
            Boolean flag = true;
            int rows = DataPermissonList.GetAllData().Rows.Count;
            while (i < rows && flag)
            {
                flag = DataPermissonList.IsDataPermissionRowUnChecked(4,DataPermissonList.GetRow(i).Text, page);
                DataPermissonList.GetRow(i).
                i++;
            }
            return flag;
        }
        */

        /// <summary>
        /// Verify whether all the linkbutton disabled
        /// </summary>
        /// <returns></returns>
        public Boolean AreAllEditDataPermissionLinkButtonDisable()
        {
            return DataPermissonList.AreDataPermissionEditLinkButtonDisabled();
        }

        /// <summary>
        /// Verify whether the node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchyNodeChecked(string[] hierarchNodePaths)
        {
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                return UserDataPermissionTree.IsNodeChecked(hierarchNodePaths.Last());
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify whether the customer node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchCustomerNodeChecked(string[] hierarchNodePaths)
        {
            string[] customerPath = new string[1];
            Array.Copy(hierarchNodePaths,customerPath,1);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(customerPath);
                return UserDataPermissionTree.IsNodeChecked(customerPath.Last());
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify whether the customer node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchOrzNodeChecked(string[] hierarchNodePaths)
        {
            string[] orzPath = new string[2];
            Array.Copy(hierarchNodePaths, orzPath, 2);
            try
            {
                TimeManager.LongPause();
                //UserDataPermissionTree.ExpandNodePath(orzPath);
                UserDataPermissionTree.ExpandNodePath(hierarchNodePaths);
                return UserDataPermissionTree.IsNodeChecked(orzPath.Last());
                //return UserDataPermissionTree.IsNodeChecked(hierarchNodePaths[hierarchNodePaths.Length - 3]);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify whether the customer node is checked
        /// </summary>
        /// <returns></returns>
        public Boolean IsHierarchSiteNodeChecked(string[] hierarchNodePaths)
        {
            string[] sitePath = new string[3];
            Array.Copy(hierarchNodePaths, sitePath, 3);
            try
            {
                TimeManager.LongPause();
                UserDataPermissionTree.ExpandNodePath(sitePath);
                return UserDataPermissionTree.IsNodeChecked(sitePath.Last());
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Verify whether the all the hierarchy node path is checked
        /// </summary>
        /// <returns></returns>
        public Boolean AreAllHierarchyNodesChecked(string[] hierarchyNodePaths)
        {
            TimeManager.LongPause();
            string[] hierarchyPaths = hierarchyNodePaths;
            //Array.Copy(hierarchyNodePaths,4,hierarchyPaths,1,4);
            int i = 0;
            while (i < hierarchyNodePaths.Length)
            {
                UserDataPermissionTree.ExpandNodePath(hierarchyPaths);
                if (!(UserDataPermissionTree.IsNodeChecked(hierarchyPaths.Last())))
                {
                    return false;
                }
                Array.Copy(hierarchyNodePaths, hierarchyPaths, hierarchyNodePaths.Length - i - 1);
                i = i + 1;
            }
            return true;
        }


        /// <summary>
        /// Verify whether the all the hierarchy node path is checked
        /// </summary>
        /// <returns></returns>
        public Boolean AreAllHierarchyNodesUnChecked(string[] hierarchyNodePaths)
        {
            TimeManager.LongPause();
            string[] hierarchyPaths = hierarchyNodePaths;
            //Array.Copy(hierarchyNodePaths,4,hierarchyPaths,1,4);
            int i = 0;
            while (i < hierarchyNodePaths.Length)
            {
                UserDataPermissionTree.ExpandNodePath(hierarchyPaths);
                if (UserDataPermissionTree.IsNodeChecked(hierarchyPaths.Last()))
                {
                    return false;
                }
                Array.Copy(hierarchyNodePaths, hierarchyPaths, hierarchyNodePaths.Length - i - 1);
                i = i + 1;
            }
            return true;
        }

        /// <summary>
        /// Click tree window save button
        /// </summary>
        /// <returns></returns>
        public void SaveTreeWindow()
        {
            TreeWindowSaveButton.Click();
        }

        /// <summary>
        /// Click tree window  cancel button
        /// </summary>
        /// <returns></returns>
        public void CancelTreeWindow()
        {
            TreeWindowCancelButton.Click();
        }

        /// <summary>
        /// Switch to basic properties tab
        /// </summary>
        /// <returns></returns>
        public void SwitchToBasicPropertiesTab()
        {
            UserBasicPropertiesTab.Click();
        }

        /// <summary>
        /// Switch to  Data Permission  tab
        /// </summary>
        /// <returns></returns>
        public void SwitchToDataPermissionTab()
        {
            UserDataPermissionTab.Click();
        }

        #endregion

        #region get value

        #endregion

        #region verfication
        /// <summary>
        /// Verify whether the cancel button enable
        /// </summary>
        public Boolean IsCancelButtonEnable()
        {
            return CancelButton.IsEnabled();
        }

        /// <summary>
        /// Verify whether the save button enable
        /// </summary>
        public Boolean IsSaveButtonEnable()
        {
            return SaveButton.IsEnabled();
        }

        /// <summary>
        /// Verify whether the Select all Customer names button enable
        /// </summary>
        public Boolean IsSelectAllCustomerNamesButtonEnable()
        {
            //@@@@@@@@@@@ problem here
            return SelectAllDataPermission.IsEnabled();
        }

        /// <summary>
        /// Verify whether the Customer names button enable
        /// </summary>
        public Boolean IsAllCustomerNamesButtonEnable()
        {
            //@@@@@@@@@@@ problem here
            CustomerNameViewStatus.IsEnabled();
            return SelectAllDataPermission.IsEnabled();
        }

        /*
        /// <summary>
        /// Verify whether the All the Customer names display
        /// </summary>
        public Boolean AreAllCustomerNamesListed()
        {
            
            return true;
        }
        */
        /// <summary>
        /// Verify whether the All the Customer names display
        /// </summary>
        public Boolean IsAllDataCheckboxChecked()
        {
            return CheckAllDataScopeCheckBox.IsAllDataScopeItemChecked();
        }

        /// <summary>
        /// Verify  All hierarchy nodes  check box checked 
        /// </summary>
        /// <returns></returns>
        public void IsAllHierarchyNodeCheck()
        {
            CheckAllHierarchyNodesCheckBox.IsDataAllhierarchyBoxChecked();
        }

        /// <summary>
        /// Verify  All hierarchy nodes  check box checked 
        /// </summary>
        /// <returns></returns>
        public Boolean IsAllDataScopeCheckBoxDisabled()
        {
            return CheckAllDataScopeCheckBox.IsAllDataScopeItemDisabled();
        }


        #endregion
    }
}
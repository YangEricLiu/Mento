using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.EnergyView;
using System.Data;
using System.IO;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Operation on home page
    /// </summary>
    public class HomePage
    {
        internal HomePage()

        {
        }

        #region controls

        private static Button AllDashboardsHierarchyTreeButton = JazzButton.AllDashboardsHierarchyTreeButton;
        private static HierarchyTree AllDashboardsTree = JazzTreeView.AllDashboardsTree;
        private static Container WidgetsOnOneDashboard = JazzContainer.ContainerWidgetsToDashboard;
        private static Label DashboardHeaderName = JazzLabel.DashboardHeaderNameLabel;
        private static MenuButton SelectCustmerMenuButton = JazzButton.SelectCustomerMenuButton;
        private static Button RenameDashboardButton = JazzButton.DashboardRenameButton;
        private static Button ShareDashboardButton = JazzButton.DashboardShareButton;
        private static Button DeleteDashboardButton = JazzButton.DashboardDeleteButton;
        private static TextField RenameDashboardTextField = JazzTextField.ModifyDashboardNameTextField;
        private static Button RenameDashboardCancel = JazzButton.RenameDashboardCancelButton;
        private static Button RenameDashboardSave = JazzButton.RenameDashboardSaveButton;
        private static Label PopNotes = JazzLabel.PopNotesLabel;
        private static Label DashboardPanel = JazzLabel.EmptyDashboardLabel;
        private static Label DashboardFavoriteLevelLabel = JazzLabel.DashboardFavoriteLevelLabel;
        private static DashboardButton DashboardFavoriteLevelButton = JazzButton.DashboardFavoriteLevelButton;
        private static DashboardButton DashboardShareInfoButton = JazzButton.DashboardShareInfoButton;
        #endregion

        #region common

        /// <summary>
        /// Navigate To AllDashboard
        /// </summary>
        /// <returns></returns>
        public void NavigateToAllDashboard()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
        }

        /// <summary>
        /// Navigate To MyFavorite
        /// </summary>
        /// <returns></returns>
        public void NavigateToMyFavorite()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.MyFavirate);
        }


        /// <summary>
        /// Select hierarchy node 
        /// </summary>
        /// <param name="treePath"></param>
        /// <returns></returns>
        public bool SelectHierarchyNode(string[] treePath)
        {
            AllDashboardsHierarchyTreeButton.Click();
            TimeManager.ShortPause();

            try
            {
                AllDashboardsTree.SelectNode(treePath);
                TimeManager.Pause(8000);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public void SelectCustomer(string customerName)
        {
            SelectCustmerMenuButton.SelectOneItem(customerName);
        }

        public bool IsTrendDrawnOnWidgetMin()
        {
            return true;
        }

        public void ClickDashboardButton(string dsName)
        {
            Button dsButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHomePageDashboard, dsName);

            dsButton.Click();
        }

        public bool IsDashboardButtonExisted(string dsName)
        {
            Button dsButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHomePageDashboard, dsName);

            return dsButton.IsExisted();
        }

        public int GetWidgetsNumberOfDashboard()
        {
            return WidgetsOnOneDashboard.GetElementNumber();
        }

        public string GetDashboardHeaderName()
        {
            return DashboardHeaderName.GetLabelTextValue();
        }

        public DataTable GetWidgetMinDataViewAllData(string widgetName)
        {
            Grid dataGrid = JazzGrid.GetOneGrid(JazzControlLocatorKey.GridHomepageMinWidgetDataView, widgetName);

            return dataGrid.GetAllData();
        }

          /// <summary>
        /// Exit Jazz
        /// </summary>
        public void ExitJazz()
        {
            JazzFunction.UserProfile.NavigatorToUserProfile();
            JazzFunction.UserProfile.ExitJazz();
            JazzMessageBox.MessageBox.Confirm();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();
        }      

        /// <summary>
        /// Import expected data file and compare to the data view currently, if not equal, export to another file
        /// </summary>
        /// <param name="expectedFileName"></param>
        /// <param name="failedFileName"></param>
        /// /// <param name="basePath"></param>
        /// <param name="widgetName"></param>
        public bool CompareMinWidgetDataView(string basePath, string expectedFileName, string failedFileName, string widgetName)
        {
            string filePath = Path.Combine(basePath, expectedFileName);
            DataTable actualData = GetWidgetMinDataViewAllData(widgetName);

            DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

            return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName);
        }

        public string GetPopNotesValue()
        {
            return PopNotes.GetLabelTextValue();
        }

        public string GetDashboardPanelValue()
        {
            return DashboardPanel.GetLabelTextValue();
        }
        #endregion

        #region all dashboard operation

        public bool IsWidgetExistedOnDashboard(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);
            
            return WidgetNameMin.IsLabelExisted();
        }

        public void FloatOnDashboardNameButton(string name)
        {
            Button dsButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonHomePageDashboard, name);

            dsButton.Float();
            TimeManager.ShortPause();
        }

        public void ClickRenameDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);

            RenameDashboardButton.Click();
        }

        public bool IsRenameDashboardButtonExisted(string name)
        {
            FloatOnDashboardNameButton(name);

            return RenameDashboardButton.IsExisted();
        }

        public bool IsDeleteDashboardButtonExisted(string name)
        {
            FloatOnDashboardNameButton(name);

            return DeleteDashboardButton.IsExisted();
        }

        public string GetCurrentDashboardNameOnWindow()
        {
            return RenameDashboardTextField.GetValue();
        }

        public void FillInNewDashboardName(string name)
        {
            RenameDashboardTextField.Fill(name);  
        }

        /// <summary>
        /// Judge if the name field invalid
        /// </summary>
        /// <param name="expected"></param>
        public bool IsDashboardNameFieldInvalid()
        {
            return RenameDashboardTextField.IsTextFieldValueInvalid();
        }

        /// <summary>
        /// Get name field invalid message
        /// </summary>
        public string GetDashboardNameFieldInvalidMsg()
        {
            return RenameDashboardTextField.GetInvalidTips();
        }

        public void ClickRenameDashboardCancel()
        {
            RenameDashboardCancel.Click();
        }

        public void ClickRenameDashboardSave()
        {
            RenameDashboardSave.Click();
        }
        
        #endregion

        #region favorite

        public void ClickFavoriteDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);

            DashboardButton FavoriteDashboardButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardFavorite, name);

            FavoriteDashboardButton.Click();
        }

        public bool IsDashboardFavorited(string name)
        {
            DashboardButton FavoriteDashboardButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardFavorite, name);

            return FavoriteDashboardButton.IsDashboardFavorited();
        }

        public void ClickFavoriteLevelButton()
        { 
            DashboardFavoriteLevelButton.ClickLink();
        }

        public string GetFavoriteLevelButtonValue()
        {
            return DashboardFavoriteLevelButton.GetFavoriteLevelButtonValue();    
        }

        public string GetGetFavoriteLevelButtonCommonValue()
        {
            return DashboardFavoriteLevelLabel.GetLabelTextValue();
        }
        #endregion

        #region share

        public void ClickShareDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);

            ShareDashboardButton.Click();
        }

        public bool IsShareDashboardButtonExisted(string name)
        {
            FloatOnDashboardNameButton(name);

            return ShareDashboardButton.IsExisted();
        }

        public void ClickDeleteDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);

            DeleteDashboardButton.Click();
        }

        public void ClickShareInfoButton()
        {
            DashboardShareInfoButton.ClickLink();
        }

        public bool IsShareDashboardUnread()
        {
            return DashboardShareInfoButton.IsDashboardUnread();
        }
        #endregion

        #region widget

        public void FloatOnWidget(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);

            WidgetNameMin.Float();
        }


        public void MaximizeWidget(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            Button maxButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetMax, name);

            maxButton.Click();
        }

        public void RenameWidgetOpen(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            Button renameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetRename, name);

            renameButton.Click();
        }

        /// <summary>
        /// delete widget
        /// </summary>
        public void DeleteWidgetOpen(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            Button DeleteWidgetButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetDelete, name);

            DeleteWidgetButton.Click();
        }

        public bool IsRenameButtonDisplayed(string name)
        {
            Button renameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetRename, name);

            return renameButton.IsDisplayed();
        }

        public bool IsEmptyDashboardLabelExisted()
        {
            return JazzLabel.EmptyDashboardLabel.Exists();
        }

        #endregion

        #region private method


        #endregion
    }
}
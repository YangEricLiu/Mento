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
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.EnergyView;
using System.Data;
using System.IO;
using Mento.Framework.Configuration;
using Mento.ScriptCommon.Library;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Operation on home page
    /// </summary>
    public class HomePage
    {
        private static int WAITMYSHARE = 2000;

        internal HomePage()
        {
        }

        #region contant

        public int WAITSHAREWINDOWTIME = 5000;

        #endregion

        #region controls

        private static Button AllDashboardsHierarchyTreeButton = JazzButton.AllDashboardsHierarchyTreeButton;
        private static HierarchyTree AllDashboardsTree = JazzTreeView.AllDashboardsTree;
        private static Container WidgetsOnOneDashboard = JazzContainer.ContainerWidgetsToDashboard;
        private static Container WidgetsToMyShare = JazzContainer.ContainerWidgetsToMyShare;
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
        private static Button DeleteWidgetButton = JazzButton.ButtonDeleteWidget;

        private static Label ShareResoureCommon = JazzLabel.DashboardShareResourceCommonLabel;
        private static Label ShareResoureTime = JazzLabel.DashboardShareResourceTimeLabel;
        private static Label ShareResoureUser = JazzLabel.DashboardShareResourceUserLabel;
        private static Tooltip ShareUserInfo = JazzTooltip.ShareUserTooltip;
        private static Container DashboardsContainer = JazzContainer.DashboardsContainer;
        private static Label WidgetMinComment = JazzLabel.AnnotationTextLabel;
        private static LinkButton AnnotationAddLinkButton = JazzButton.AnnotationAddLinkButton;
        private static LinkButton AnnotationEditLinkButton = JazzButton.AnnotationEditLinkButton;
        private static Button WidgetConfirmCancelShareButton = JazzButton.WidgetConfirmCancelShareButton;
        private static Button CancelShareWidgetButton = JazzButton.CancelShareWidgetButton;
        private static Container WidgetsNamesToMyShareContainer = JazzContainer.WidgetsNamesToMyShareContainer;

        #endregion

        #region common

        public string GetShareCurrentTime()
        {
            DateTime now = DateTime.Now;

            string year = now.Year.ToString();
            string month = now.Month.ToString().PadLeft(2, '0');
            string day = now.Day.ToString().PadLeft(2, '0');

            string time = year + month + day;

            return time;
        }

        public string GetHierarchyText()
        {
            return JazzButton.AllDashboardsHierarchyTreeButton.GetText();
        }

        /// <summary>
        /// Navigate To AllDashboard
        /// </summary>
        /// <returns></returns>
        public void NavigateToAllDashboard()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboards);
        }

        /// <summary>
        /// Navigate To EnergyView
        /// </summary>
        /// <returns></returns>
        public void NavigateToEnergyView()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
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
        /// Navigate To MyShare
        /// </summary>
        /// <returns></returns>
        public void NavigateToMyShare()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.MyShare);
            JazzMessageBox.LoadingMask.WaitMyShareLoading();

            TimeManager.Pause(WAITMYSHARE);
        }


        /// <summary>
        /// Select hierarchy node 
        /// </summary>
        /// <param name="treePath"></param>
        /// <returns></returns>
        public bool SelectHierarchyNode(string[] treePath)
        {
            AllDashboardsHierarchyTreeButton.Click();
            TimeManager.Pause(8000);

            try
            {
                AllDashboardsTree.SelectNode(treePath);
                TimeManager.LongPause();
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
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            if (JazzMessageBox.MessageBox.Exists())
            {
                if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("Google map is unavailable"))
                {
                    JazzMessageBox.MessageBox.OK();
                }
            }

            if (JazzMessageBox.MessageBox.Exists())
            {
                if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                {
                    JazzMessageBox.MessageBox.OK();
                }
            }
        }

        public bool IsCustomerExistedInCustomerSelectionDialog(string customerName)
        {
            return SelectCustmerMenuButton.IsMenuItemExist(customerName);
        }

        public bool IsTrendDrawnOnWidgetMin()
        {
            return true;
        }

        public void ClickDashboardButton(string dsName)
        {
            DashboardButton dsButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonHomePageDashboard, dsName);

            dsButton.Click();
        }

        public void ClickDashboardButtonPosition(int positionIndex)
        {
            DashboardButton oneDSButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardPosition, positionIndex);

            oneDSButton.Click();
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

        public int GetWidgetsNumberOfMyShare()
        {
            return WidgetsToMyShare.GetElementNumber();
        }

        public string GetDashboardHeaderName()
        {
            return DashboardHeaderName.GetLabelTextValue();
        }

          /// <summary>
        /// Exit Jazz
        /// </summary>
        public void ExitJazz()
        {
            JazzFunction.PersonalMgtMenu.NavigatorToUserProfile();
            JazzFunction.PersonalMgtMenu.ExitJazz();
            TimeManager.LongPause();
            JazzMessageBox.MessageBox.Quit();
            JazzMessageBox.LoadingMask.WaitLoading(15);
            TimeManager.LongPause();
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

        public int GetDashboardsNumber()
        {
            return DashboardsContainer.GetElementNumber();
        }

        public bool IsWidgetExistedOnDashboard(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);
            
            return WidgetNameMin.IsLabelExisted();
        }

        public bool IsWidgetExistedOnMyShare(string name)
        {
            Label EnjoyWidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelEnjoyWidgetNameMin, name);

            return EnjoyWidgetNameMin.IsLabelExisted();
        }
        public bool IsWidgetExistedOnQuickCreateWidget(string name)
        {
            Label QuickCreateWidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelQuickCreateWidgetNameMin, name);

            return QuickCreateWidgetNameMin.IsLabelExisted();
        }
        public bool IsShareWidgetUnread(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);

            return WidgetNameMin.IsShareWidgetUnread();
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

        public void ClickDeleteDashboardButton(string name)
        {
            ClickRenameDashboardButton(name);
            TimeManager.MediumPause();

            DeleteDashboardButton.Click();
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

        public void DeleteDashboardsAfterExecution()
        {       
            if (ExecutionConfig.IsDeleteDashboardsAfterExecution)
            {
                int ds = TestAssemblyInitializer.CaseDownDashboardInfos.Count;

                JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
                TimeManager.LongPause();

                for (int oneds = 0; oneds < ds; oneds++)
                {
                    if (TestAssemblyInitializer.CaseDownDashboardInfos[oneds].IsCreateDashboard)
                    {

                        SelectCustomer(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].HierarchyName[0]);
                        TimeManager.MediumPause();

                        NavigateToAllDashboard();
                        TimeManager.LongPause();

                        SelectHierarchyNode(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].HierarchyName);
                        TimeManager.LongPause();

                        //Judge if dashboard existed
                        if (IsDashboardButtonExisted(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].DashboardName))
                        {
                            ClickDashboardButton(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].DashboardName);
                            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
                            TimeManager.LongPause();

                            //Click 'Delete' button on top of the dashboard.
                            ClickDeleteDashboardButton(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].DashboardName);
                            TimeManager.ShortPause();

                            //Click "Delete"
                            JazzMessageBox.MessageBox.Delete();
                            TimeManager.LongPause();
                        }
                    }
                    else
                    {
                        SelectCustomer(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].HierarchyName[0]);
                        TimeManager.MediumPause();

                        NavigateToAllDashboard();
                        TimeManager.MediumPause();

                        SelectHierarchyNode(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].HierarchyName);
                        TimeManager.LongPause();

                        //Judge if dashboard existed
                        if (IsDashboardButtonExisted(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].DashboardName))
                        {
                            ClickDashboardButton(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].DashboardName);
                            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(15);
                            TimeManager.LongPause();

                            //Judge if widget existed
                            if (IsWidgetExistedOnDashboard(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].WigetName))
                            {
                                //From the dashboard, select a widget, click 'Delete' button on the widget title.
                                DeleteWidgetOpen(TestAssemblyInitializer.CaseDownDashboardInfos[oneds].WigetName);
                                TimeManager.ShortPause();

                                //Click "Delete"
                                JazzMessageBox.MessageBox.Delete();
                                TimeManager.LongPause();
                            }
                        }
                    }
                }                 
            }
        }
        #endregion

        #region favorite

        public void ClickFavoriteDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);
            TimeManager.MediumPause();

            if (!IsDashboardFavorited(name))
            { 
                DashboardButton FavoriteDashboardButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardFavorite, name);

                FavoriteDashboardButton.Click();
            }
        }

        public void ClickUnFavoriteDashboardButton(string name)
        {
            FloatOnDashboardNameButton(name);

            if (IsDashboardFavorited(name))
            {
                DashboardButton FavoriteDashboardButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardFavorite, name);

                FavoriteDashboardButton.Click();
            }
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
            TimeManager.Pause(WAITSHAREWINDOWTIME);
        }

        public bool IsShareDashboardButtonExisted(string name)
        {
            FloatOnDashboardNameButton(name);

            return ShareDashboardButton.IsExisted();
        }

        public void ClickShareInfoButton()
        {
            DashboardShareInfoButton.ClickLink();
        }

        public bool IsShareInfoUnread()
        {
            return DashboardShareInfoButton.IsDashboardUnread();
        }

        public bool IsShareDashboardUnread(string dsName)
        {
            DashboardButton dsButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonHomePageDashboard, dsName);

            return dsButton.IsDashboardUnread();
        }

        public bool IsShareDashboardUnreadPosition(int positionIndex)
        {
            DashboardButton oneDSButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardPosition, positionIndex);

            return oneDSButton.IsDashboardUnread();
        }

        public bool IsDashboardButtonPressed(int positionIndex)
        {
            DashboardButton oneDSButton = JazzButton.GetOneDashboardButton(JazzControlLocatorKey.ButtonDashboardPosition, positionIndex);

            return oneDSButton.IsDashboardPressed();
        }

        public bool IsShareResoureCommonExisted()
        {
            return ShareResoureCommon.IsLabelExisted();
        }

        public bool IsShareResoureTimeExisted()
        {
            return ShareResoureTime.IsLabelExisted();
        }

        public bool IsShareResoureUserExisted()
        {
            return ShareResoureUser.IsLabelExisted();
        }

        public string GetShareResoureUser()
        {
            return ShareResoureUser.GetLabelTextValue();
        }

        public string GetShareResoureTooltipTexts()
        {
            return ShareUserInfo.GetTooltipTexts();
        }

        public bool IsTextsExisted(string[] texts)
        {
            return ShareUserInfo.IsTooltipTextsExisted(texts);
        }

        public void FloatOnShareResoureUser()
        {
            ShareResoureUser.Float();
            TimeManager.ShortPause();
        }

       
        #endregion

        #region Enjoy

        public int GetSameWidgetNameNumberofMyShare(string widgetName)
        {
            return WidgetsNamesToMyShareContainer.GetSameItemNumber(widgetName);
        }

        public void FloatOnMyShareWidget(string name)
        {
            Label EnjoyWidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelEnjoyWidgetNameMin, name);

            EnjoyWidgetNameMin.Float();
        }

        public void ClickOnMyShareWidget(string name)
        {
            Label EnjoyWidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelEnjoyWidgetNameMin, name);

            EnjoyWidgetNameMin.Click();
        }

        public void FloatOnMyShareEditCommentButton(string name)
        {
            Label WidgetMinAnnotationIcon = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelMyShareWidgetMinAnnotationIcon, name);

            WidgetMinAnnotationIcon.Float();
        }

        public void RenameMyShareWidgetOpen(string name)
        {
            FloatOnMyShareWidget(name);
            TimeManager.ShortPause();

            Button MyShareRenameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonMyShareWidgetRename, name);

            MyShareRenameButton.Click();
        }

        public bool IsRenameMyShareWidgetButtonExisted(string name)
        {
            FloatOnMyShareWidget(name);
            TimeManager.ShortPause();

            Button MyShareRenameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonMyShareWidgetRename, name);

            return MyShareRenameButton.IsExisted();
        }

        public void MaximizeMyShareWidget(string name)
        {
            FloatOnMyShareWidget(name);
            TimeManager.ShortPause();

            ClickOnMyShareWidget(name);
        }

        public void ClickShareMyShareWidgetButton(string name)
        {
            FloatOnMyShareWidget(name);
            TimeManager.ShortPause();

            Button ShareMyShareWidgetButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonMyShareWidgetShare, name);

            ShareMyShareWidgetButton.Click();
        }

        /// <summary>
        /// cancel share widget
        /// </summary>
        public void CancelMyShareWidgetOpen(string name)
        {
            FloatOnMyShareWidget(name);
            TimeManager.ShortPause();

            Button MyShareWidgetRenameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonMyShareWidgetRename, name);
            MyShareWidgetRenameButton.Click();
            TimeManager.ShortPause();

            CancelShareWidgetButton.Click();
        }

        public string GetMyShareWidgetShareUser(string name)
        {
            Label MyShareWidgetShareUser = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelMyShareWidgetShareUser, name);

            return MyShareWidgetShareUser.GetLabelTextValue();
        }

        #endregion

        #region widget

        public string GetOneWidgetMinName(int positionIndex)
        {
            Label OneWidgetNameMin = JazzLabel.GetOneLabel(JazzControlLocatorKey.LabelWidgetMinTitlePosition, positionIndex);

            return OneWidgetNameMin.GetLabelTextValue();
        }
        public void ClickOnWidgetTemplateField(string name)
        {
            Label WidgetField = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelQuickCreateWidgetField, name);

            WidgetField.Click();
        }
        public void ClickOnBuildingField(string name)
        {
            Label BuildingField = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelBuildingField, name);

            BuildingField.Click();
        }


        public string GetOneDashboardNamePosition(int positionIndex)
        {
            Label OneDashboardName = JazzLabel.GetOneLabel(JazzControlLocatorKey.LabelDashboardTitlePosition, positionIndex);

            return OneDashboardName.GetLabelTextValue();
        }

        public void FloatOnWidget(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);

            WidgetNameMin.Float();
        }

        public void ClickOnWidget(string name)
        {
            Label WidgetNameMin = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetNameMin, name);

            WidgetNameMin.Click();
        }

        public void FloatOnEditCommentButton(string name)
        {
            Label WidgetMinAnnotationIcon = JazzLabel.GetOneLabelByName(JazzControlLocatorKey.LabelWidgetMinAnnotationIcon, name);

            WidgetMinAnnotationIcon.Float();
        }       

        public void ClickAddAnnotationButton()
        {
            AnnotationAddLinkButton.ClickLink();
        }

        public void ClickEditAnnotationButton()
        {
            AnnotationEditLinkButton.ClickLink();
        }

        public string GetExistedCommentMinWdiget()
        {
            return WidgetMinComment.GetLabelTextValue();
        }

        public void MaximizeWidget(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            ClickOnWidget(name);
        }
        //Click widget field in widget template
        public void ClickWidgetTemplateField(string name)
        {
            ClickOnWidgetTemplateField(name);
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

            Button renameButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetRename, name);
            renameButton.Click();
            TimeManager.ShortPause();

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


        public void ClickShareWidgetButton(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            Button shareButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetShare, name);

            shareButton.Click();
            TimeManager.Pause(WAITSHAREWINDOWTIME);
            TimeManager.Pause(WAITSHAREWINDOWTIME);
        }

        public void ClickEnjoyWidgetButton(string name)
        {
            FloatOnWidget(name);
            TimeManager.ShortPause();

            Button EnjoyButton = JazzButton.GetOneButton(JazzControlLocatorKey.ButtonWidgetEnjoy, name);

            EnjoyButton.Click();
        }

        public DataTable GetWidgetMinDataViewAllData(string widgetName)
        {
            Grid dataGrid = JazzGrid.GetOneGrid(JazzControlLocatorKey.GridHomepageMinWidgetDataView, widgetName);

            return dataGrid.GetAllData();
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
            if (ExecutionConfig.isCompareExpectedDataViewExcelFile)
            {
                string filePath = Path.Combine(basePath, expectedFileName);
                DataTable actualData = GetWidgetMinDataViewAllData(widgetName);
                Grid dataGrid = JazzGrid.GetOneGrid(JazzControlLocatorKey.GridHomepageMinWidgetDataView, widgetName);

                DataTable expectedDataTable = JazzFunction.DataViewOperation.ImportExpectedFileToDataTable(filePath, JazzFunction.DataViewOperation.sheetNameExpected);

                return JazzFunction.DataViewOperation.CompareDataTables(expectedDataTable, actualData, failedFileName, dataGrid.GetGridHeader(), true);
            }
            else
            {
                return true;
            }
        }

        public bool IsTrendChartDrawn(string widgetName)
        {
            Chart superWidgetChart = GetOneWidgetChart(widgetName);

            return superWidgetChart.HasDrawnTrend();
        }

        public int GetTrendChartLines(string widgetName)
        {
            Chart superWidgetChart = GetOneWidgetChart(widgetName);

            return superWidgetChart.GetTrendChartLines() + 1;
        }

        public int GetTrendChartLinesMarkers(string widgetName)
        {
            Chart superWidgetChart = GetOneWidgetChart(widgetName);

            return superWidgetChart.GetTrendChartLinesMarkers();
        }

        private Chart GetOneWidgetChart(string widgetName)
        {
            Chart superWidgetChart = JazzChart.GetOneChart(JazzControlLocatorKey.ChartSuperWidget, widgetName);

            return superWidgetChart;
        }

        #endregion

        #region private method


        #endregion
    }
}
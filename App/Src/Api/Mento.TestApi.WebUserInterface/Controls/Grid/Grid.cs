using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Grid : JazzControl
    {
        private static string CELLINDEXVARIABLE = "cellIndex";
        private static string CELLTEXTVARIABLE = "cellText";
        private static Locator IsGridRowCheckedLocator = new Locator("//td/div/div[contains(@class, 'x-grid-checkheader-checked')]", ByType.XPath);
        //private static Locator IsNoDataOnGridLocator = new Locator("div/div/div/div[text()='没有数据']", ByType.XPath);
        private static Locator IsNoRowOnGridLocator = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr[contains(@class,'x-grid-row')]", ByType.XPath);
        private static Locator DataViewLocator = new Locator("div[contains(@id, 'headercontainer') and contains(@class,'x-grid-header-ct')]", ByType.XPath);
        private static Locator IsNoEnabledCheckboxLocator = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr[contains(@class,'x-grid-row')]/td[contains(@class, 'x-grid-cell-checkcolumn')]/div/div[@class='x-grid-checkheader']", ByType.XPath);
        private static Locator IsDataPermissionEnableLocator = new Locator("//div[@id='st-user-datarange-form-innerCt']//div//div[contains(@id,'datapermissiongrid')]/div[2]/div/table/tbody/tr/td[5]/div/a[@type='disableEdit']", ByType.XPath);
        private static Locator IAllEnabledCheckboxLocator = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr[contains(@class,'x-grid-row')]/td[contains(@class, 'x-grid-cell-checkcolumn')]/div/div[contains(@class,'x-grid-checkheader-disabled')]", ByType.XPath);
        private static Locator ShareWindowGridRowChecker = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr[td[$#cellIndex]/div[text()='$#cellText']]/td[contains(@class,'x-grid-cell-actioncolumn')]/div/img", ByType.XPath);
        private static Locator ShareWindowGridRowColumn = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr/td[$#cellIndex]/div[text()='$#cellText']", ByType.XPath);
        private static Locator ShareWindowRowsNotChecker = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr/td[contains(@class,'x-grid-cell-actioncolumn')]/div/img[not(contains(@class,'x-checked'))]", ByType.XPath);
        private static Locator SendedListRemoveButton = new Locator("div/div/table[contains(@class,'x-grid-table')]/tbody/tr/td[contains(@class,'x-grid-cell-actioncolumn')]/div/img[not(contains(@class,'x-checked'))]", ByType.XPath);

        private static Locator IDataScopeCustomerListLocator = new Locator("/tbody/tr/td[4]", ByType.XPath);

        protected IWebElement[] CurrentRows
        {
            get 
            {
                return FindChildren(ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRows));
            }
        }

        protected IWebElement PagingToolbar
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingToolbar));
            }
        }

        protected IWebElement ShareHeaderCheckbox
        {
            get
            {
                return FindChild(ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowHeaderShare));
            }
        }

        public int GetCurrentRowsNumber()
        {
            return CurrentRows.Count();
        }

        public bool IsPageToolBarExisted()
        {
            return this.Exists(ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingToolbar));
        }

        public bool IsAllEnabledCheckbox()
        {
            return !ChildExists(IAllEnabledCheckboxLocator);
        }

        public bool IsNoEnabledCheckbox()
        {
            return !ChildExists(IsNoEnabledCheckboxLocator);
        }

        public bool IsAllGridTagsUnchecked()
        {
            return !ElementHandler.Exists(IsGridRowCheckedLocator);
        }

        public bool IsNoRowOnGrid()
        {
            return !ChildExists(IsNoRowOnGridLocator);
        }

        /// <summary>
        /// Check share info window column name
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public void ClickShareInfoWindowRowColumn(int cellIndex, string cellText, bool Paging = true)
        {
            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            FindChild(Locator.GetVariableLocator(ShareWindowGridRowColumn, variables)).Click();
        }

        /// <summary>
        /// Data permission locator to verify whether the "编辑数据权限" enabled
        /// </summary>
        /// <param name="locator"></param>
        public bool AreDataPermissionEditLinkButtonDisabled()
        {
            //return !ChildExists(IsDataPermissionEnableLocator);
            return ElementHandler.Exists(IsDataPermissionEnableLocator);
        }

        public bool HasDrawnDataView()
        {
            return ElementHandler.Exists(this._RootLocator);
        }

        /// <summary>
        /// locator parameter must be root element of a grid
        /// </summary>
        /// <param name="locator"></param>
        public Grid(Locator locator) : base(locator) { }

        private bool IsPageToolBarDisplayed()
        {
            return PagingToolbar.Displayed;
        }

        /// <summary>
        /// Simulate mouse focus on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FocusOnRow(int cellIndex,string cellText, bool Paging = true)
        {
            this.GetRow(cellIndex, cellText, Paging).Click();
        }

        /// <summary>
        /// Simulate mouse float on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FloatOnRow(int cellIndex, string cellText, bool Paging = true)
        {
            ElementHandler.Float(this.GetRow(cellIndex, cellText, Paging));
        }

        /// <summary>
        /// Check whether the specified row is checked
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsRowChecked(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Split(' ').Contains("x-grid-checkheader-checked");
        }

        /// <summary>
        /// Check whether the specified ranking commodify row is checked
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsRankingCommodityRowChecked(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Split(' ').Contains("x-grid-radioheader-checked");
        }

        /// <summary>
        /// Check whether the specified row is selected
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsRowSelected(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Contains("x-grid-radioheader-checked");
        }

        /// <summary>
        /// Check whether the specified row is checked
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsShareWindowRowChecked(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetShareWindowRowChecker(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Contains("x-checked");
        }


        /// <summary>
        /// Simulate mouse checked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void ClickDeleteRowXButton(int cellIndex, string cellText, bool Paging = true)
        {
            var deleteX = this.GetRowDeleteX(cellIndex, cellText, Paging);
            deleteX.Click();
        }

        /// <summary>
        /// Simulate mouse click the "X" button on the tail of grid row on multiple hierarchy window
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            //Emma add on 2013-12-10
            if (IsPageToolBarExisted()&&(CurrentPage > 1))
            {
                GotoPage(1);
                TimeManager.LongPause();
            }

            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            if (!this.IsRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// Check commodity radio button
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void SelectRowRadioBox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            if (!this.IsRankingCommodityRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// Simulate mouse click the "X" button on the tail of grid row on multiple hierarchy window
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckShareWindowRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetShareWindowRowChecker(cellIndex, cellText, Paging);

            if (!this.IsShareWindowRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
        }

        public void UncheckShareWindowRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetShareWindowRowChecker(cellIndex, cellText, Paging);

            if (this.IsShareWindowRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// Check share window header check box
        /// </summary>
        /// <returns></returns>
        public void CheckShareHeaderCheckbox()
        {
            ShareHeaderCheckbox.Click();
        }

        public bool IsShareWindowRowsAllChecked()
        {
            return FindChildren(ShareWindowRowsNotChecker).Length < 1;
        }

        public bool IsShareHeaderChecked()
        {
            var HeaderCheckedLocator = new Locator("../../../div[contains(@class,'x-receiver-grid-action-header-checked')]", ByType.XPath);

            return ElementHandler.Exists(HeaderCheckedLocator, ShareHeaderCheckbox);
        }

        /// <summary>
        /// Simulate mouse checked Data permission checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckDataPermissionRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetDataPermissionRowChecker(cellIndex, cellText, Paging);

            if (this.IsDataPermissionRowUnChecked(4, cellText, Paging))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// UnCheck the data scope permission item
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void UnCheckDataPermissionRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetDataPermissionRowChecker(cellIndex, cellText, Paging);

            if (!(this.IsDataPermissionRowUnChecked(4, cellText, Paging)))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// Check whether the specified Data permission row is checked
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsDataPermissionRowUnChecked(int cellIndex, string cellText, bool Paging = true)
        {
            //var checker = this.GetDataPermissionRowChecker(cellIndex, cellText, Paging);
            IWebElement checkerText = this.GetDataPermissionRowCheckerText(4,cellText,Paging);
            
            return checkerText.GetAttribute("type").Contains("disableEdit");
        }

        /// <summary>
        /// Click the edit data permisson 
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public void ClickDataPermissionRow(int cellIndex, string cellText, bool Paging = true)
        {
            IWebElement checkerText = this.GetDataPermissionRowCheckerText(4, cellText, Paging);
            checkerText.Click();
        }

        /// <summary>
        /// Simulate mouse unchecked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void UncheckRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            if (this.IsRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
        }

        //Emma add on 2013/10/17
        public bool IsGridRowBold(int cellIndex, string cellText)
        {
            IWebElement row = GetRow(cellIndex, cellText);

            return row.GetAttribute("class").Contains("x-grid-row-bold");
        }

        public bool IsRowExistOnCurrentPage(int cellIndex, string cellText)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };
            try
            {
                FindChild(Locator.GetVariableLocator(rowLocator, variables));
                //return row != null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsRowExistOnCurrentPage(int cellIndex)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowSelected);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex } };
            try
            {
                FindChild(Locator.GetVariableLocator(rowLocator, variables));
                //return row != null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool IsRowExist(int cellIndex, string cellText)
        {
            try
            {
                IWebElement row = GetRow(cellIndex, cellText);
                //return row != null;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public string GetSelectedRowData(int cellIndex)
        {
            return GetRow(cellIndex).Text;
        }

        /*
        public virtual IWebElement GetRow(int cellIndex)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowSelected);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex } };

            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }
         */

        public virtual IWebElement GetRow(int cellIndex, bool Paging = true)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowSelected);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }

        /*
        public virtual IWebElement GetRow(int cellIndex, string cellText)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };
            
            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }
        */

        public virtual IWebElement GetRow(int cellIndex, string cellText, bool Paging = true)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if(IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }
        
        /*
        protected virtual IWebElement GetRowChecker(int cellIndex, string cellText)
        {
            var checkerLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowChecker);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }
        */

        public IWebElement GetSendedListRowDeleteX(int cellIndex, string cellText, bool Paging = true)
        {
            return GetRowDeleteX(cellIndex, cellText, false);
        }

        protected virtual IWebElement GetRowDeleteX(int cellIndex, string cellText, bool Paging = true)
        {
            var deleteXLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowDeleteX);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(deleteXLocator, variables));
        }

        protected virtual IWebElement GetRowChecker(int cellIndex, string cellText, bool Paging = true)
        {
            var checkerLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowChecker);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };
                
            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }

        protected virtual IWebElement GetShareWindowRowChecker(int cellIndex, string cellText, bool Paging = true)
        {
            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(ShareWindowGridRowChecker, variables));
        }

        // Data permission special checker 
        protected virtual IWebElement GetDataPermissionRowChecker(int cellIndex, string cellText, bool Paging = true)
        {
            var checkerLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowDataPermissionChecker);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }

        protected virtual IWebElement GetDataPermissionRowCheckerText(int cellIndex, string cellText, bool Paging = true)
        {
            var checkerLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowDataPermissionCheckerTextRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }


        public int PageCount
        {
            get
            {
                //get page count locator
                Locator pageCountLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingTotalPageLabel);

                IWebElement pageCountElement = ElementHandler.FindElement(pageCountLocator, container: PagingToolbar);

                if (String.IsNullOrEmpty(pageCountElement.Text))
                    return -1;

                return Convert.ToInt32(pageCountElement.Text.Replace("/", "").Trim());
            }
        }

        public int RecordCount
        {
            get
            {
                Locator recordCountLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingTotalRecordLabel);
                IWebElement recordCountElement = ElementHandler.FindElement(recordCountLocator, container: PagingToolbar);

                if (String.IsNullOrEmpty(recordCountElement.Text))
                    return -1;

                Match match = Regex.Match(recordCountElement.Text, @"\d+");

                if (!match.Success)
                    return -1;

                return Convert.ToInt32(match.Value);
            }
        }

        protected int CurrentPage
        {
            get
            {
                Locator currentPageLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingCurrentPageTextBox);
                IWebElement currentPageElement = ElementHandler.FindElement(currentPageLocator, container: PagingToolbar);

                return Convert.ToInt32(currentPageElement.GetAttribute("value"));
            }
        }

        public void NextPage()
        {
            Locator nextPageLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingNextPageButton);
            ElementHandler.FindElement(nextPageLocator, container: PagingToolbar).Click();

            GetControl<LoadingMask>().WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

        public void PreviousPage()
        {
            Locator previousPageLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingPreviousPageButton);
            ElementHandler.FindElement(previousPageLocator, container: PagingToolbar).Click();

            GetControl<LoadingMask>().WaitChartMaskerLoading();
            TimeManager.MediumPause();
        }

        public void GotoPage(int pageIndex)
        {
            Locator currentPageLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingCurrentPageTextBox);
            
            IWebElement currentPageElement = ElementHandler.FindElement(currentPageLocator, container: PagingToolbar);

            currentPageElement.Clear();
            currentPageElement.SendKeys(pageIndex.ToString());

            currentPageElement.SendKeys("\n");
        }

        public DataTable GetCurrentPageData()
        {
            DataTable data = new DataTable();

            var headerLocatorLeft = new Locator("div[contains(@class,'x-grid-header-ct')]/div/div/div[contains(@class,'x-column-header-align-left') and not(contains(@class,'x-group-sub-header'))]", ByType.XPath);
            //var headerLocatorCenter = new Locator("div[contains(@class,'x-grid-header-ct')]/div/div/div[contains(@class,'x-column-header-align-center')]", ByType.XPath);
            var headerLocatorItems = new Locator("div[contains(@class,'x-grid-header-ct')]//div[contains(@class,'x-column-header-align-center')]//div[contains(@class, 'x-column-header-align-left x-group-sub-header')]", ByType.XPath);

            var cellLocator = new Locator("td", ByType.TagName);

            int j = 1;

            if (ElementHandler.Exists(headerLocatorLeft, container: this.RootElement))
            {
                foreach (IWebElement column in FindChildren(headerLocatorLeft))
                {
                    string columnName1 = j + ". " + column.Text;

                    data.Columns.Add(columnName1);

                    j++;
                }
            }

            foreach (IWebElement column in FindChildren(headerLocatorItems))
            {
                string columnName2 = j + ". " + column.Text;

                data.Columns.Add(columnName2);

                j++;
            }

            foreach (IWebElement row in CurrentRows)
            {
                DataRow dataRow = data.NewRow();
                IWebElement[] cells = ElementHandler.FindElements(cellLocator, container: row);

                for (int i = 0; i < cells.Length; i++)
                    dataRow[i] = cells[i].Text;

                data.Rows.Add(dataRow);
            }

            return data;
        }

        public DataTable GetAllData()
        {
            if (CurrentPage != 1)
                GotoPage(1);

            DataTable data = null;

            for (int pageIndex = 1; pageIndex <= PageCount; pageIndex++)
            {
                if(data==null)
                    data = GetCurrentPageData();
                else
                    data.Merge(GetCurrentPageData());

                if (PageCount > 1)
                {
                    NextPage();
                    TimeManager.LongPause();
                }     
            }

            return data;
        }

        // Get row light

        /// <summary>
        /// Check the specified row is not lightened.
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsRowUnLightened(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowLight(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Contains("not-energy-consump-icon");
        }

        /// <summary>
        /// Check whether the specified row is lightened.
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsRowLightened(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowLight(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Split(' ').Contains("is-energy-consump-icon");
        }

        /// <summary>
        /// Check whether the specified row of a building has a light.
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsBuildingLightNull(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowLight(cellIndex, cellText, Paging);

            return checker.GetAttribute("class").Split(' ').Contains("none-energy-consump-icon");
        }

        /// <summary>
        /// Click lighten button
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void ClickLightenButton(int cellIndex, string cellText, bool Paging = true)
        {
            var lighter = this.GetRowLight(cellIndex, cellText, Paging);

            if (this.IsRowUnLightened(cellIndex, cellText))
            {
                lighter.Click();
            }
        }

        // Get the lights row
        protected virtual IWebElement GetRowLight(int cellIndex, string cellText, bool Paging = true)
        {
            var lightLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowLight);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            if (IsPageToolBarExisted() && Paging)
            {
                int i = 0;

                while (i < PageCount)
                {
                    if (IsRowExistOnCurrentPage(cellIndex, cellText))
                    {
                        break;
                    }
                    else
                    {
                        NextPage();
                        TimeManager.LongPause();
                        i++;
                    }
                }
            }

            return FindChild(Locator.GetVariableLocator(lightLocator, variables));
        }

        /// <summary>
        /// Check the specified row is not lightened.
        /// </summary>
        /// <param name="cellIndex">Column index of the identifier cell</param>
        /// <param name="cellText">Text of the identifier cell</param>
        /// <returns></returns>
        public bool IsLightenedNotExist(int cellIndex, string cellText, bool Paging = true)
        {
            var lightLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowLight);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            return FindChild(Locator.GetVariableLocator(lightLocator, variables)).Displayed.Equals(false);

        }


        #region Common
        private bool ChildExists(Locator locator)
        {
            return FindChildren(locator).Count() > 0;
        }
        #endregion
    }
}

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

        public bool IsPageToolBarExisted()
        {
            return this.Exists(ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingToolbar));
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
        /// Simulate mouse checked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckRowCheckbox(int cellIndex, string cellText, bool Paging = true)
        {
            var checker = this.GetRowChecker(cellIndex, cellText, Paging);

            if (!this.IsRowChecked(cellIndex, cellText, Paging))
            {
                checker.Click();
            }
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

            //GetControl<LoadingMask>().WaitLoading();
            GetControl<LoadingMask>().WaitSubMaskLoading();
        }

        public void PreviousPage()
        {
            Locator previousPageLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridPagingPreviousPageButton);
            ElementHandler.FindElement(previousPageLocator, container: PagingToolbar).Click();

            //GetControl<LoadingMask>().WaitLoading();
            GetControl<LoadingMask>().WaitSubMaskLoading();
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

            var headerLocatorLeft = new Locator("div[contains(@class,'x-grid-header-ct')]/div/div/div[contains(@class,'x-column-header-align-left')]", ByType.XPath);
            //var headerLocatorCenter = new Locator("div[contains(@class,'x-grid-header-ct')]/div/div/div[contains(@class,'x-column-header-align-center')]", ByType.XPath);
            var headerLocatorItems = new Locator("div[contains(@class,'x-grid-header-ct')]//div[contains(@class,'x-column-header-first x-column-header-last') and contains(@class, 'x-column-header-align-left')]", ByType.XPath);

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

                NextPage();
                GetControl<LoadingMask>().WaitLoading();
            }

            return data;
        }
    }
}

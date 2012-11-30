using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;
using System.Data;

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

        protected int PageCount
        {
            get { throw new NotImplementedException(); }
        }
        protected int RecordCount
        {
            get { throw new NotImplementedException(); }
        }
        protected int CurrentPage
        {
            get { throw new NotImplementedException(); }
        }
        
        /// <summary>
        /// locator parameter must be root element of a grid
        /// </summary>
        /// <param name="locator"></param>
        public Grid(Locator locator) : base(locator) { }


        /// <summary>
        /// Simulate mouse focus on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FocusOnRow(int cellIndex,string cellText)
        {
            this.GetRow(cellIndex, cellText).Click();
        }

        /// <summary>
        /// Simulate mouse float on the row which "Name" is "cellName"
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void FloatOnRow(int cellIndex, string cellText)
        {
            ElementHandler.Float(this.GetRow(cellIndex, cellText));
        }

        public bool IsRowChecked(int cellIndex, string cellText)
        {
            var checker = this.GetRowChecker(cellIndex, cellText);

            return checker.GetAttribute("class").Split(' ').Contains("x-grid-checkheader-checked");
        }


        /// <summary>
        /// Simulate mouse checked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void CheckRowCheckbox(int cellIndex, string cellText)
        {
            var checker = this.GetRowChecker(cellIndex, cellText);

            if (!this.IsRowChecked(cellIndex, cellText))
            {
                checker.Click();
            }
        }

        /// <summary>
        /// Simulate mouse unchecked checkbox in the front of one grid row
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public void UncheckRowCheckbox(int cellIndex, string cellText)
        {
            var checker = this.GetRowChecker(cellIndex, cellText);

            if (this.IsRowChecked(cellIndex, cellText))
            {
                checker.Click();
            }
        }

        public bool IsRowExist(int cellIndex, string cellText)
        {
            try
            {
                IWebElement row = GetRow(cellIndex, cellText);
                return row != null;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public virtual IWebElement GetRow(int cellIndex, string cellText)
        {
            var rowLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };
            
            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }

        protected virtual IWebElement GetRowChecker(int cellIndex, string cellText)
        {
            var checkerLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.GridRowChecker);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }
    }
}

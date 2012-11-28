using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class Grid : JazzControl
    {
        private static string CELLINDEXVARIABLE = "cellIndex";
        private static string CELLTEXTVARIABLE = "cellText";

        private IWebElement _Header;
        /// <summary>
        /// Header is a collection of divs that lists all data column names
        /// </summary>
        protected IWebElement Header 
        {
            get
            {
                if (this._Header == null)
                    this._Header = FindChild(LocatorRepository.GetLocator(LocatorKey.GridHeader));

                return this._Header;
            }
        }

        private IWebElement _Body;
        /// <summary>
        /// Body is a table that contains all data rows
        /// </summary>
        protected IWebElement Body
        {
            get
            {
                if (this._Body == null)
                    this._Body = FindChild(LocatorRepository.GetLocator(LocatorKey.GridBody));

                return this._Body;
            }
        }

        private IWebElement _Footer;
        /// <summary>
        /// Footer is paging bar
        /// </summary>
        protected IWebElement Footer
        {
            get
            {
                if (this._Footer == null)
                    this._Footer = FindChild(LocatorRepository.GetLocator(LocatorKey.GridFooter));

                return this._Footer;
            }
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

        protected virtual IWebElement GetRow(int cellIndex, string cellText)
        {
            var rowLocator = LocatorRepository.GetLocator(LocatorKey.GridRow);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };
            
            return FindChild(Locator.GetVariableLocator(rowLocator, variables));
        }

        protected virtual IWebElement GetRowChecker(int cellIndex, string cellText)
        {
            var checkerLocator = LocatorRepository.GetLocator(LocatorKey.GridRowChecker);

            Hashtable variables = new Hashtable() { { CELLINDEXVARIABLE, cellIndex }, { CELLTEXTVARIABLE, cellText } };

            return FindChild(Locator.GetVariableLocator(checkerLocator, variables));
        }
    }
}

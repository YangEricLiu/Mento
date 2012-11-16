using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// Reference to Jazz function attitude.
    /// </summary>
    public static class FunctionWrapper
    {
        private static Hierarchy _hierarchy;
        /// <summary>
        /// Hierarchy function property
        /// </summary>
        public static Hierarchy Hierarchy
        {
            get
            {
                if (_hierarchy == null)
                {
                    _hierarchy = new Hierarchy();
                }
                return _hierarchy;
            }
        }

        private static Formula _formula;
        /// <summary>
        /// Formula function property
        /// </summary>
        public static Formula Formula
        {
            get
            {
                if (_formula == null)
                {
                    _formula = new Formula();
                }
                return _formula;
            }
        }

        private static LoginFunction _login;
        /// <summary>
        /// Login function property
        /// </summary>
        public static LoginFunction Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginFunction();
                }
                return _login;
            }
        }

        private static Ptag _ptag;
        /// <summary>
        /// Ptag function property
        /// </summary>
        public static Ptag Ptag
        {
            get
            {
                if (_ptag == null)
                {
                    _ptag = new Ptag();
                }
                return _ptag;
            }
        }

        private static Vtag _vtag;
        /// <summary>
        /// Vtag function property
        /// </summary>
        public static Vtag Vtag
        {
            get
            {
                if (_vtag == null)
                {
                    _vtag = new Vtag();
                }
                return _vtag;
            }
        }

        private static Associate _associate;
        /// <summary>
        /// Associate function property
        /// </summary>
        public static Associate Associate
        {
            get
            {
                if (_associate == null)
                {
                    _associate = new Associate();
                }
                return _associate;
            }
        }

        /// <summary>
        /// After click save button, waiting for add successful message box pop up
        /// </summary>
        /// <param name="timeout">Waiting time</param>
        /// <returns></returns>
        public static void WaitForLoadingDisappeared(int timeOut)
        {
            var locator = new Locator("mainLoadingMask", ByType.ID);

            ElementLocator.WaitForElementToDisappear(locator, timeOut);
        }

    }
}

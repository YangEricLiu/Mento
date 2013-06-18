using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public abstract class JazzControl
    {
        protected Locator _RootLocator;
        protected ISearchContext _ParentContainer;

        public IWebElement RootElement
        {
            get 
            {
                if (_RootLocator == null)
                    return null;

                if (_ParentContainer == null)
                    return ElementHandler.FindElement(_RootLocator);
                else
                    return ElementHandler.FindElement(_RootLocator, _ParentContainer);
            }
        }

        public IWebElement[] RootElements
        {
            get
            {
                if (_RootLocator == null)
                    return null;

                if (_ParentContainer == null)
                    return ElementHandler.FindElements(_RootLocator);
                else
                    return ElementHandler.FindElements(_RootLocator, _ParentContainer);
            }
        }


        public JazzControl(Locator rootLocator, ISearchContext parentContainer=null)
        {
            _RootLocator = rootLocator;
            _ParentContainer = parentContainer;
        }

        protected virtual IWebElement FindChild(Locator locator)
        {
            return ElementHandler.FindElement(locator, container: this.RootElement);
        }

        protected virtual IWebElement[] FindChildren(Locator locator)
        {
            return ElementHandler.FindElements(locator, container: this.RootElement).ToArray();
        }

        public static T GetControl<T>(Locator locator = null) where T : JazzControl
        {
            Type[] EmptyConstructorParameterControls = new Type[] { typeof(LoadingMask), typeof(FormulaField), typeof(MessageBox) };

            if (EmptyConstructorParameterControls.Contains(typeof(T)))
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                if (locator == null)
                    throw new ApiException("Can not get control when locator is null.");

                return (T)Activator.CreateInstance(typeof(T), locator);
            }
        }

        public virtual bool Exists()
        {
            return ElementHandler.Exists(this._RootLocator);
        }

        public virtual bool Exists(Locator locator)
        {
            return ElementHandler.Exists(locator, container: this.RootElement);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">JavaScript</param>
        public virtual object ExecuteJavaScriptOnControl(string script)
        {
            return BrowserHandler.ExecuteJavaScript(script, this.RootElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator">JavaScript</param>
        public virtual object ExecuteJavaScriptOnControl(string script, params object[] args)
        {
            return BrowserHandler.ExecuteJavaScript(script, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param></param>
        public bool WaitControlDisplayed()
        {
            return ElementHandler.Wait(_RootLocator, WaitType.ToAppear, _ParentContainer);        
        }
    }
}

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
                    return _ParentContainer.FindElement(_RootLocator.ToBy());
            }
        }

        public JazzControl(Locator rootLocator, ISearchContext parentContainer=null)
        {
            _RootLocator = rootLocator;
            _ParentContainer = parentContainer;
        }

        protected virtual IWebElement FindChild(Locator locator)
        {
            return RootElement.FindElement(locator.ToBy());
        }

        protected virtual IWebElement[] FindChildren(Locator locator)
        {
            return RootElement.FindElements(locator.ToBy()).ToArray();
        }

        public static T GetControl<T>(Locator locator = null) where T : JazzControl
        {
            Type[] EmptyConstructorParameterControls = new Type[] { typeof(LoadingMask), typeof(FormulaField), };

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
    }
}

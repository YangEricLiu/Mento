using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Mento.TestApi.WebUserInterface.NewControls
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
                    return ElementLocator.FindElement(_RootLocator);
                else
                    return _ParentContainer.FindElement(_RootLocator.ToBy());
            }
        }

        public JazzControl(Locator rootLocator, ISearchContext parentContainer=null)
        {
            _RootLocator = rootLocator;
            _ParentContainer = parentContainer;
        }

        protected virtual IWebElement FindElement(Locator locator)
        {
            return RootElement.FindElement(locator.ToBy());
        }

        protected virtual IWebElement[] FindElements(Locator locator)
        {
            return RootElement.FindElements(locator.ToBy()).ToArray();
        }

        public static T GetControl<T>() where T : JazzControl, new()
        {
            return new T();
        }

        public virtual void WaitForMe(WaitType waitType)
        {
            ElementHandler.Wait(this._RootLocator, waitType);
        }

        public virtual bool Exists()
        {
            return ElementHandler.Exists(this._RootLocator);
        }
    }
}

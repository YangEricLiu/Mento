using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;
using Mento.Utility;

namespace Mento.TestApi.WebUserInterface
{
    public abstract class JazzControlBase
    {
        //
        protected virtual Dictionary<string, Locator> ElementDictionary
        {
            get
            {
                return ResourceManager.GetElementDictionary();
            }
        }

        /// <summary>
        /// Construct the locator value with a variable value
        /// </summary>
        /// <param name="elementKey"></param>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        /// <returns></returns>
        protected virtual Locator GetVariableLocator(string elementKey, string variableName, string variableValue)
        {
            var locator = ElementDictionary[elementKey];

            locator.Value = locator.Value.Replace(variableName, variableValue);

            return locator;
        }
    }
}

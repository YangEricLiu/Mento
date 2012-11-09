using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Get the key&value from element map configuration file
    /// </summary>
    public static class ComboBoxItemListReader
    {
        /// <summary>
        ///     Get the key&value from combox item list XML file
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="moduleName">The module name in XML file</param>
        /// <returns>The item value/returns>
        public static Dictionary<string, string> GetValueXML(string fileName, string moduleName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode xn = doc.SelectSingleNode(moduleName);

            XmlNodeList xnl = xn.ChildNodes;

            Dictionary<string, string> elementMap = new Dictionary<string, string>();

            foreach (XmlNode xn1 in xnl)
            {
                if (xn1 is XmlElement)
                {
                    XmlElement xe = (XmlElement)xn1;

                    string tmp = xe.GetAttribute("value").ToString();
                    elementMap.Add(xe.GetAttribute("key").ToString(), tmp);
                }
            }

            return elementMap;
        }
    }
}

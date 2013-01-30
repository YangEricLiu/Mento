using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;
using Mento.Framework.Constants;
using System.Configuration;
using System.Xml;
using Mento.TestApi.WebUserInterface;
using System.Xml.Linq;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public static class ComboBoxItemRepository
    {

        private static Dictionary<string, string> _ComboBoxItemDictionary;
        private static Dictionary<string, string> ComboBoxItemDictionary
        {
            get
            {
                if (_ComboBoxItemDictionary == null)
                {
                    _ComboBoxItemDictionary = GetComboBoxItemDictionary();
                }
                return _ComboBoxItemDictionary;
            }
        }

        public static string GetComboBoxItemRealValue(string itemKey)
        {
            if (!ComboBoxItemDictionary.ContainsKey(itemKey))
                return itemKey;
                //throw new ApiException(String.Format("The provided key does not exist: '{0}'",itemKey));

            return ComboBoxItemDictionary[itemKey];
        }

        private static Dictionary<string, string> GetComboBoxItemDictionary()
        {
            string itemListPath = PathHelper.GetAppAbsolutePath(ConfigurationManager.AppSettings[ConfigurationKey.COMBOBOX_ITEM_PATH]);

            XDocument xdoc = XDocument.Load(itemListPath);

            var query = from element in xdoc.Element("ItemList").Elements("add")
                        select new KeyValuePair<string, string>(element.Attribute("key").Value, LanguageResourceRepository.ReplaceLanguageVariables(element.Attribute("value").Value));

            return query.ToDictionary(item => item.Key, item => item.Value);
        }


    }
}

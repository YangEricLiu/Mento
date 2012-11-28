using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mento.Framework.Execution;
using Mento.Framework;
using System.Configuration;
using Mento.Framework.Constants;
using Mento.Framework.Exceptions;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Get the key&value from language resource JS file.
    /// </summary>
    public static class LanguageResourceRepository
    {
        private static Dictionary<string, string> _ResourceDictionary;
        public static Dictionary<string, string> ResourceDictionary
        {
            get 
            {
                if (_ResourceDictionary == null)
                {
                    _ResourceDictionary = ParseUiResource().Union(ParseDataResource()).ToDictionary(item => item.Key, item => item.Value);
                }

                return _ResourceDictionary;
            }
        }

        /// <summary>
        /// Get resource value from language variable, which starts with '$@'
        /// </summary>
        /// <param name="variableName">language variable, which starts with '$@'</param>
        /// <returns>resource value</returns>
        public static string GetVariableValue(string variableName)
        {
            return ResourceDictionary[variableName.Replace(Project.LanguagePrefix, String.Empty)];
        }

        /// <summary>
        ///     Get the key&value from language resource JS file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The language key&value dictionary with JS key replaced</returns>
        private static Dictionary<string, string> ParseUiResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), "ui.js");

            Dictionary<string, string> dict = LoadUiResource(filePath);
            Dictionary<string, string> finalDict = new Dictionary<string, string>(0);

            string finalValue = "";
            string signal = "##";

            foreach (string key in dict.Keys)
            {
                finalValue = dict[key];

                if (finalValue.IndexOf(signal) > -1)
                {
                    foreach (string value in dict.Keys)
                    {
                        string replaceKey = signal + value + signal;

                        if (finalValue.IndexOf(replaceKey) > -1)
                        {
                            finalValue = finalValue.Replace(value, dict[value].ToString());
                        }
                    }

                    finalValue = finalValue.Replace(signal, "");
                }

                finalDict.Add(key, finalValue);
            }

            return finalDict;
        }
        /// <summary>
        ///     Get the key&value from language resource JS file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The language key&value dictionary with out JS key replaced</returns>
        private static Dictionary<string, string> LoadUiResource(string filePath)
        {
            StreamReader objReader = new StreamReader(filePath);
            string sLine = "";
            string key = "";
            string value = "";
            Dictionary<string, string> lineList = new Dictionary<string, string>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals("") && (sLine[0] != '/')
                    && (sLine.IndexOf("{}") < 0) && (sLine.IndexOf("=") > -1))
                {
                    string[] tmp = sLine.Split(new char[2] { '=', ';' });
                    key = tmp[0].Replace("I18N.", "").Replace(" ", "");
                    value = tmp[1].Replace(" ", "").Replace("'", "");
                    if (!lineList.ContainsKey(key))
                    {
                        lineList.Add(key, value);
                    }
                }
            }
            objReader.Close();

            return lineList;
        }

        private static Dictionary<string, string> ParseDataResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), "data.js");

            //if there is ui resource variable in data resource, replace it
            throw new NotImplementedException();
        }
        private static Dictionary<string, string> LoadDataResource(string filePath)
        {
            throw new NotImplementedException();
        }

        private static string GetResourceFileDirectory()
        {
            if (ExecutionContext.Language.HasValue)
            {
                string languageDirectoryPath = String.Empty;
                switch (ExecutionContext.Language.Value)
                {
                    case Language.CN:
                        languageDirectoryPath = ConfigurationManager.AppSettings[ConfigurationKey.LANGUAGE_CN_PATH];
                        break;
                    case Language.EN:
                        languageDirectoryPath = ConfigurationManager.AppSettings[ConfigurationKey.LANGUAGE_EN_PATH];
                        break;
                    default:
                        break;
                }
                return languageDirectoryPath;
            }
            else
            {
                throw new ApiException("Execution context was not initialize correctly, parameter 'language' is null.");
            }
        }
    }
}

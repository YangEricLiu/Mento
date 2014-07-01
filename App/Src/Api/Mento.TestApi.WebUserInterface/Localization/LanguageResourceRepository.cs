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
using System.Text.RegularExpressions;
using System.Resources;
using System.Reflection;

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
                    var stringsResource = ParseStringResource();
                    var appResource = ParseAppResource();
                    var databaseResource = ParseDatabaseResource();

                    //_ResourceDictionary = ParseStringResource().Union(ParseDataResource()).ToDictionary(item => item.Key, item => item.Value);

                    _ResourceDictionary = stringsResource.Union(appResource).Union(databaseResource).ToDictionary(item => item.Key, item => item.Value);
                }

                return _ResourceDictionary;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string ReplaceLanguageVariables(string expression)
        {
            if (expression.IndexOf(Project.LanguagePrefix) < 0)
                return expression;

            Regex variableFormat = new Regex(@"\" + Project.LanguagePrefix + @"(\w+(\.{1})?)+");
            Match match = variableFormat.Match(expression);

            if (!match.Success)
                return expression;

            foreach (Group matchGroup in match.Groups)
            {
                var variable = matchGroup.Value;

                expression = expression.Replace(variable, LanguageResourceRepository.GetLanguageVariableValue(variable));
            }

            return expression;
        }

        /// <summary>
        /// Get resource value from language variable, which starts with '$@'
        /// </summary>
        /// <param name="variableName">language variable, which starts with '$@'</param>
        /// <returns>resource value</returns>
        public static string GetLanguageVariableValue(string variableName)
        {
            if (variableName.StartsWith(Project.LanguagePrefix))
            {
                string replacedVariableName = variableName.Replace(Project.LanguagePrefix, String.Empty);
                if (!ResourceDictionary.ContainsKey(replacedVariableName))
                    throw new ApiException(String.Format("The given language variable was not found: '{0}'", variableName));

                return ResourceDictionary[replacedVariableName];
            }
            else
            {
                return variableName;
            }
        }

        /// <summary>
        ///     Get the key&value from language resource JS file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The language key&value dictionary with JS key replaced</returns>
        private static Dictionary<string, string> ParseStringResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), Project.LocalizationStringResourceName);

            Dictionary<string, string> dict = LoadStringResource(filePath);
            Dictionary<string, string> finalDict = new Dictionary<string, string>(0);

            string finalValue = String.Empty;
            string signal = new string(ASCII.OCTOTHORPE, 2);//"##";

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

                    finalValue = finalValue.Replace(signal, String.Empty);
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
        private static Dictionary<string, string> LoadStringResource(string filePath)
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

        private static Dictionary<string, string> ParseDatabaseResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), Project.LocalizationDatabaseResourceName);

            //if there is ui resource variable in data resource, replace it
            return LoadResxResource(filePath);
        }

        private static Dictionary<string, string> ParseAppResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), Project.LocalizationAppResourceName);

            //if there is ui resource variable in data resource, replace it
            return LoadResxResource(filePath);
        }

        private static Dictionary<string, string> LoadResxResource(string filePath)
        {
            Assembly assembly = Assembly.Load("Mento.ScriptHost");

            string resourceName = String.Format("Mento.ScriptHost.{0}",filePath.Replace("\\",".").Replace("resx","resources"));
            
            Dictionary<string, string> lineList = new Dictionary<string, string>();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {

                using (ResourceReader reader = new ResourceReader(stream))
                {
                    var cursor = reader.GetEnumerator();

                    while (cursor.MoveNext())
                    {
                        string key = cursor.Key.ToString().Trim();
                        string value = cursor.Value.ToString().Trim();

                        if (key.Contains(ASCII.SPACE))
                            key = key.Replace(ASCII.SPACE, ASCII.UNDERSCORE);

                        if (!lineList.ContainsKey(key))
                        {
                            lineList.Add(key, value);
                        }
                    }
                }
            }

            return lineList;


            //StreamReader dataReader = new StreamReader(filePath);
            //string dataLine = "";
            //string key = "";
            //string value = "";
            //Dictionary<string, string> lineList = new Dictionary<string, string>();

            //while (!dataReader.EndOfStream)
            //{
            //    dataLine = dataReader.ReadLine();
            //    if (!String.IsNullOrEmpty(dataLine) && dataLine[0] != '/' && !dataLine.Contains("{}") && dataLine.Contains("="))
            //    {
            //        string[] tmp = dataLine.Split(new char[2] { '=', ';' });
            //        key = tmp[0].Replace(" ", "");
            //        value = tmp[1].Replace(" ", "").Replace("'", "");
            //        if (!lineList.ContainsKey(key))
            //        {
            //            lineList.Add(key, value);
            //        }
            //    }
            //}
            //dataReader.Close();

            //return lineList;
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

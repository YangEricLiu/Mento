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
using Mento.Framework.Configuration;

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
                    var extResource = ParseExtResource();

                    _ResourceDictionary = stringsResource.Union(appResource).Union(databaseResource).Union(extResource).ToDictionary(item => item.Key, item => item.Value);
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
                    key = tmp[0].Replace("I18N.", "").Trim();//.Replace(" ", "");
                    value = tmp[1].Replace("'", "").Trim();//;
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
  
                        if (ExecutionConfig.Language == "EN")
                        {
                            //for labelling and ratio english version only
                            value = cursor.Value.ToString();
                        }

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

        private static Dictionary<string, string> ParseExtResource()
        {
            string filePath = Path.Combine(GetResourceFileDirectory(), Project.LocalizationDatabaseResourceName);

            return ExtLanguageResourceLoader.GetExtLanguageResource(filePath);
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

    public static class ExtLanguageResourceLoader
    {
        public static Dictionary<string, string> GetExtLanguageResource(string resourceFullName)
        {
            Dictionary<string, string> langages = new Dictionary<string, string>();

            using (var reader = new StreamReader(resourceFullName))
            {
                Stack<String> stack = new Stack<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim();

                    if (IsIgnoreLine(line))
                        continue;

                    //if a line has a start curly brace, push stack, if a line has an end curly brace pop stack & calculate what's in the package
                    string cleanLine = Regex.Replace(line, "\".+\"", "");

                    PushKey(stack, line, cleanLine);

                    PopKey(stack, cleanLine);

                    if (!cleanLine.Contains("{") && !cleanLine.Contains("}"))
                    {
                        if (stack.Count > 1)
                        {
                            if (IsDropUnneedLine(stack, line))
                                continue;

                            string languageKey = ConstructLanguageKey(stack);

                            KeyValuePair<string, string> property = GetProperty(line);

                            langages.Add(languageKey + property.Key, property.Value);
                        }
                    }
                }

                if (stack.Count > 0)
                {
                    throw new Exception("Stack is not empty!");
                }
            }

            return langages;
        }

        private static bool IsIgnoreLine(string line)
        {
            bool isInBlockComment = false;

            if (String.IsNullOrEmpty(line)) //ignore empty lines
                return true;

            if (line.StartsWith("//")) //ignore simple comments
                return true;

            if (line.StartsWith("/*"))
            { //start of block comments
                isInBlockComment = true;
            }
            if (line.EndsWith("*/"))
            { //end of block comments
                isInBlockComment = false;
                //ignore this line too
                return true;
            }

            if (isInBlockComment) //ignore block comments
                return true;

            return false;
        }

        private static void PushKey(Stack<string> stack, string line, string cleanLine)
        {
            if (cleanLine.Contains("{"))
            {
                string stackKey = line;
                if (line.StartsWith("Ext.onReady"))
                {
                    stackKey = "Root";
                }
                else if (line.StartsWith("if"))
                {
                    stackKey = "if";
                }
                else if (line.StartsWith("Ext.define"))
                {
                    stackKey = line.Split('"')[1];
                }
                else if (line.StartsWith("Ext.apply"))
                {
                    stackKey = stack.Peek() == "if" ? line.Split('(')[1].Split(',')[0] : "{";
                }
                else if (Regex.Match(line, ".+:.?{").Success)
                {
                    stackKey = line.Split(':')[0].Trim();
                }
                else if (Regex.Match(line, ".+=.?{").Success)
                {
                    stackKey = line.Split('=')[0].Trim();
                }

                stack.Push(stackKey);
            }
        }

        private static void PopKey(Stack<string> stack, string cleanLine)
        {
            if (cleanLine.Contains("}"))
            {
                string result = stack.Pop();
            }
        }

        private static bool IsDropUnneedLine(Stack<string> stack, string line)
        {
            return line.StartsWith("override") || stack.Peek().StartsWith("parseCodes") || Regex.Match(stack.Peek(), @"function.?\(.*\)").Success;
        }

        private static string ConstructLanguageKey(Stack<string> stack)
        {
            string languageKey = String.Empty;

            for (int i = 0; i < stack.Count; i++)
            {
                string element = stack.ElementAt<string>(stack.Count - i - 1);
                if (element == "Root" || element == "if" || element == "{")
                    continue;

                languageKey += stack.ElementAt<string>(stack.Count - i - 1) + ".";
            }

            return languageKey.Replace(".locale.zh_CN", "").Replace(".locale.en", "");
        }

        private static KeyValuePair<string, string> GetProperty(string line)
        {
            string propertyName = String.Empty, propertyValue = String.Empty;

            if (line.Contains("=") && line.Contains(";"))
            {
                var equalSignIndex = line.IndexOf('=');
                propertyName = line.Substring(0, equalSignIndex);
                propertyValue = line.Substring(equalSignIndex + 1).Trim().TrimEnd(';');
            }
            else
            {
                var match2 = Regex.Match(line, @"(.+?):(.+)(,)?");
                if (match2.Success)
                {
                    propertyName = match2.Groups[1].Value.Trim();
                    propertyValue = match2.Groups[2].Value.Trim();
                }
            }

            propertyValue = propertyValue.TrimStart('"');
            propertyValue = propertyValue.TrimEnd('"');

            return new KeyValuePair<string, string>(propertyName, propertyValue);
        }

        [Obsolete("Use 'GetExtLanguageResource' instead")]
        public static void ParseLanguageResource()
        {
            using (var reader = new StreamReader("locale/ext-lang-zh_CN.js"))
            {
                int status = 0; // 0: not in block, 1: in block
                string temp = "";
                Dictionary<string, string> langages = new Dictionary<string, string>();
                string className = String.Empty;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim();

                    if (line.StartsWith("Ext.define"))
                    {
                        temp = line;
                        status = 1;
                        continue;
                    }
                    if (status == 1 && line.EndsWith("}"))
                    {
                        Console.WriteLine("");
                        //Console.WriteLine("End of '{0}'", temp);
                        status = 0;
                    }

                    if (status == 1) // in block, starts to record the properties
                    {
                        Match match = Regex.Match(line, @"(.+)\:(.+)(\,)?");
                        if (match.Success)
                        {
                            if (line.StartsWith("override"))
                            {
                                className = line.Split('"')[1];
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(className) && !line.Contains("function ("))
                                {
                                    string propertyName = match.Groups[1].Value.Trim();
                                    string propertyVaue = match.Groups[2].Value.Trim();

                                    Console.WriteLine("{0}.{1}:{2}", className, propertyName, propertyVaue);
                                }
                                else
                                {
                                    Console.WriteLine("WARN:Not a valid property!");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

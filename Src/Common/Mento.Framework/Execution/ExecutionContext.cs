using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Configuration;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Xml.Linq;
using Mento.Utility;

namespace Mento.Framework.Execution
{
    /// <summary>
    /// Execution context 
    /// </summary>
    public static class ExecutionContext
    {
        private const string TEMPFILENAME = @"temp\executioncontext.xml";
        
        private static string[] ContextPropertyList
        {
            get
            {
                return typeof(ExecutionContext).GetProperties(BindingFlags.Public | BindingFlags.Static).Select(p => p.Name.ToLower()).ToArray();
            }
        }

        private static string ContextConfigFileName = Path.Combine(ExecutionConfig.ExecutionDirectory, TEMPFILENAME);
        private static string ConfigRootElementName = "context";

        public static Browser? Browser
        {
            get
            {
                var config = ReadProperty("browser");
                if (String.IsNullOrEmpty(config) || String.Equals(config, "null", StringComparison.OrdinalIgnoreCase))
                    return null;

                return EnumHelper.StringToEnum<Browser>(ReadProperty("browser"), ignoreCase: true);
            }
            set
            {
                SaveProperty("browser", value.HasValue ? value.ToString().ToLower() : String.Empty);
            }
        }

        public static Language? Language
        {
            get
            {
                var config = ReadProperty("language");
                if (String.IsNullOrEmpty(config) || String.Equals(config, "null", StringComparison.OrdinalIgnoreCase))
                    return null;

                return EnumHelper.StringToEnum<Language>(ReadProperty("language"), ignoreCase: true);
            }
            set
            {
                SaveProperty("language", value.HasValue ? value.ToString().ToLower() : String.Empty);
            }
        }

        public static string Url
        {
            get
            {
                return ReadProperty("url");
            }
            set
            {
                SaveProperty("url", String.IsNullOrEmpty(value) ? String.Empty : value);
            }
        }

        public static void Initialize(string url, string browser, string language)
        {
            if (File.Exists(ContextConfigFileName))
                File.Delete(ContextConfigFileName);

            CreateConfigFile();

            SaveProperty("browser", browser.ToLower());
            SaveProperty("language", language.ToLower());
            SaveProperty("url", url.ToLower());
        }

        public static void Destruct()
        {
            if (File.Exists(ContextConfigFileName))
                File.Delete(ContextConfigFileName);
        }
        
        private static void SaveProperty(string propertyName, string value)
        {
            var xdoc = XDocument.Load(ContextConfigFileName);
            var propertyNode = xdoc.Element(ConfigRootElementName).Element(propertyName);
            if (propertyNode == null)
                throw new Exception("Execution context was not successfully initialized.");

            propertyNode.SetValue(value);

            xdoc.Save(ContextConfigFileName);
        }

        private static string ReadProperty(string propertyName)
        {
            var xdoc = XDocument.Load(ContextConfigFileName);
            var propertyNode = xdoc.Element(ConfigRootElementName).Element(propertyName);
            if (propertyNode == null)
                throw new Exception("Execution context was not successfully initialized.");

            return propertyNode.Value.ToLower();
        }

        private static void CreateConfigFile()
        {
            XDocument xdoc = new XDocument();

            XElement rootElement = new XElement(ConfigRootElementName);

            foreach (var propertyName in ContextPropertyList)
            {
                var propertyElement = new XElement(propertyName);
                propertyElement.SetValue(String.Empty);
                rootElement.Add(propertyElement);
            }

            xdoc.Add(rootElement);

            FileInfo xmlFile = new FileInfo(ContextConfigFileName);
            if (!xmlFile.Directory.Exists)
                xmlFile.Directory.Create();

            xdoc.Save(ContextConfigFileName);
        }

    }
}
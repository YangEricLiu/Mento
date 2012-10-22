using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mento.Utility.Utility
{
    public class JSParser
    {
        private static Dictionary<string, string> GetKeyValueFromJS(string filePath)
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

        public static Dictionary<string, string> GetFormatKeyValue(string filePath)
        {
            Dictionary<string, string> dict = GetKeyValueFromJS(filePath);
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
    }
}

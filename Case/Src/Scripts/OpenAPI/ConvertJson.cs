using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Script.OpenAPI
{
    public class ConvertJson
    {
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>json字符串</returns>
        public static string String2Json(String json)
        {
            string result = "";
            int pos = 0;
            int strLen = json.Length;
            string indentStr = "    ";
            string newLine = "\r\n";
            char prevChar = ' ';
            bool outOfQuotes = true;

            for ( int i = 0; i < strLen; i++ ) 
            {
                 // Grab the next character in the string.
                 string cha = json.Substring(i , 1);

                 // Are we inside a quoted string?
                if (cha[0] =='"' && prevChar != '\\') 
                {
                    outOfQuotes = !outOfQuotes;
                  
                    // If this character is the end of an element,
                    // output a new line and indent the next line.

                } else if ((cha[0] == '}' || cha[0] == ']') && outOfQuotes) 
                {
                    result = result + newLine;
                    pos--;

                    for (int j = 0; j < pos; j++) 
                    {
                        result = result + indentStr;
                    }
                }

                // Add the character to the result string.

                result = result + cha[0];

                // If the last character was the beginning of an element,
                // output a new line and indent the next line.

                if ((cha[0] == ',' || cha[0] == '{' || cha[0] == '[') && outOfQuotes) 
                {
                    result = result + newLine;

                    if (cha[0] ==  '{' || cha[0] == '[') 
                    {
                        pos++ ;
                    }

                    for (int k = 0 ; k < pos ; k++) 
                    {
                        result = result + indentStr ;
                    }
                }

                prevChar = cha[0];
            }

            return result.Replace("\\", "");
        }

        public static string GetString(String json)
        {
            string s = json.ToString();

            return s;
        } 
    }
}

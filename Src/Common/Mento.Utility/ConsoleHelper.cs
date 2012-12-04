using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace Mento.Utility
{
    /// <summary>
    /// Color console
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="text">Write text</param>
        /// <param name="textColor">Text color</param>
        /// <returns></returns>
        public static void WriteColor(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = originColor;
        }
        
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator,
        /// to the standard output stream.
        /// </summary>
        /// <param name="text">Write text</param>
        /// <param name="textColor">Text color</param>
        /// <returns></returns>
        public static void WriteColorLine(string text, ConsoleColor textColor)
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = originColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="headers"></param>
        /// <param name="formats"></param>
        public static void PrintDataTable(System.Data.DataTable table, string[] headers, string[] formats)
        {
            string format = String.Join(String.Empty, formats);

            Console.WriteLine(format, headers);
            Console.WriteLine(new String('-', 10));

            foreach (DataRow row in table.Rows)
            {
                List<string> values = new List<string>();
                foreach (string columnName in headers)
                    values.Add(row[columnName].ToString());

                Console.WriteLine(format, values.ToArray());
            }
        }


        public static void PrintSuccessMessage()
        {
            ConsoleHelper.WriteColorLine("Succed.", ConsoleColor.Green);
        }

        private class ColumnNameComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return String.Equals(x, y, StringComparison.OrdinalIgnoreCase);
            }


            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }

    
}

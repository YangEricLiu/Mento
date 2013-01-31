using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mento.Tool.CodeGenerator
{
    class Program
    {
        private const string ROOTELEMENTNAME = "WebElement";
        private const string ADDELEMENTNAME = "add";
        private const string KEYATTRIBUTENAME = "key";

        private const string STATEMENTFORMAT = "{0}public static string {1} = \"{1}\";";
        private const string REGIONBEGINFORMAT = "{0}#region {1}";
        private const string REGIONENDFORMAT = "{0}#endregion\r\n";

        private const string USINGNAMESPACES = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nnamespace Mento.TestApi.WebUserInterface.ControlCollection\r\n{\r\n    public static class JazzControlLocatorKey\r\n    {";
        private const string CLOSEMARKS = "    }\r\n}";

        private static string Spaces = new String(' ', 8);

        static void Main(string[] args)
        {
            if (args == null || args.Length <= 0 || String.IsNullOrEmpty(args[0]))
                return;

            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);

            FileInfo inputFile = new FileInfo(args[0]);//@"E:\works\kara\mento\Trunk\Case\Common\Library\ControlCollection\Resource\JazzControlLocatorMap.xml";
            FileInfo outputFile = new FileInfo(args[1]);//@"result.txt";

            if (inputFile.IsReadOnly)
                return;

            if (outputFile.IsReadOnly)
                CheckoutForEdit(outputFile.FullName);

            StreamWriter writer = new StreamWriter(outputFile.FullName) { AutoFlush = true };

            writer.WriteLine(USINGNAMESPACES);

            using (XmlReader reader = XmlReader.Create(new StreamReader(inputFile.FullName)))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == ADDELEMENTNAME)
                                writer.WriteLine(STATEMENTFORMAT, Spaces, reader.GetAttribute(KEYATTRIBUTENAME));
                            else
                                if (reader.Name != ROOTELEMENTNAME)
                                    writer.WriteLine(REGIONBEGINFORMAT, Spaces, reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == ADDELEMENTNAME)
                                writer.WriteLine(String.Empty);
                            else
                                if (reader.Name != ROOTELEMENTNAME)
                                    writer.WriteLine(REGIONENDFORMAT, Spaces);
                            break;
                        default:
                            Console.WriteLine(reader.Value);
                            //writer.WriteLine(reader.Value);
                            break;
                    }
                }
            }

            writer.WriteLine(CLOSEMARKS);
            writer.Flush();
            writer.Close();
        }

        private static void CheckoutForEdit(string fileName)
        {
            string[] drives = new string[] { "C", "D", "E" };
            string executable = @"{0}:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\tf.exe";
            string command = "checkout";

            foreach (var drive in drives)
            {
                string exeLocation = String.Format(executable, drive);
                string exeParameter = String.Format(" {0} {1}",command,fileName);
                if (File.Exists(exeLocation))
                {
                    ExecuteCommand(exeLocation, exeParameter);
                    break;
                }
            }
        }

        private static void ExecuteCommand(string executable, string command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(executable, command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                procStartInfo.CreateNoWindow = true;

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                string result = proc.StandardOutput.ReadToEnd();

                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }
    }
}

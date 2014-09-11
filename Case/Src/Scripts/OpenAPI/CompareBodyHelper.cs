using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DifferenceEngine;
using System.Collections;
using System.IO;
using Mento.Framework.Configuration;

namespace Mento.Script.OpenAPI
{
    public class CompareBodyHelper
    {
        private static string EnergyAnalysis = "EnergyAnalysis/";
        //private static string Ranking = "Ranking/";
        //private static string Labelling = "Labeling/";
        private static string pathDestination = ExecutionConfig.destinationExpectedResponseBodyDirectory + EnergyAnalysis;
        private static string pathSource = ExecutionConfig.sourceResponseBodyDirectory + EnergyAnalysis;
        //private static string pathFailed = ExecutionConfig.failedResponseBodyDirectory + EnergyAnalysis;

        #region private method which maybe not used on the current openapi framework
        
        private static void ExportTmpTextFiles(string acFileName, string exFileName, string actualResponseBody, string expectedResponseBody)
        {
                string actualFileName = Path.Combine(pathSource, acFileName);
                string expectedFileName = Path.Combine(pathSource, exFileName);

                StreamWriter sw1 = new StreamWriter(actualFileName);
                sw1.WriteLine(actualResponseBody);
                sw1.Close();
                sw1.Dispose();

                StreamWriter sw2 = new StreamWriter(expectedFileName);
                sw2.WriteLine(expectedResponseBody);
                sw2.Close();
                sw2.Dispose();     
        }

        private static string CompareSDTextFiles(string sFile, string dFile, string actualResponseBody)
        {
                string sourceFileName = Path.Combine(pathSource, sFile);

                StreamWriter sw = new StreamWriter(sourceFileName);
                sw.WriteLine(actualResponseBody);
                sw.Close();
                sw.Dispose();

                string destinationFileName = Path.Combine(pathDestination, dFile);

                return CompareTxtFiles.CompareTextFiles(sourceFileName, destinationFileName);
        }

        private static string CompareSDTextFiles(string sFile, string dFile)
        {
            string sourceFileName = Path.Combine(pathSource, sFile);
            string destinationFileName = Path.Combine(pathDestination, dFile);

            return CompareTxtFiles.CompareTextFiles(sourceFileName, destinationFileName);
        }

        #endregion

        public static string CompareResponseBodyByFiles(string actualResponseBody, string expectedResponseBody)
        {
            string sFile = @"ac.txt";
            string dFile = @"ex.txt";

            ExportTmpTextFiles(@"ac.txt", @"ex.txt", actualResponseBody, expectedResponseBody);

            string sourceFileName = Path.Combine(pathSource, sFile);
            string destinationFileName = Path.Combine(pathDestination, dFile);

            return CompareTxtFiles.CompareTextFiles(sourceFileName, destinationFileName);
        }
    }
}

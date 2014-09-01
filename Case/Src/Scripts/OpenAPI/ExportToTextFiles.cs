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
    public class ExportToTextFiles
    {
        private static string EnergyAnalysis = "EnergyAnalysis/";
        private static string Ranking = "Ranking/";
        private static string Labelling = "Labeling/";
        private static string pathDestination = ExecutionConfig.destinationExpectedResponseBodyDirectory + EnergyAnalysis;
        private static string pathSource = ExecutionConfig.sourceResponseBodyDirectory + EnergyAnalysis;
        private static string pathFailed = ExecutionConfig.failedResponseBodyDirectory + EnergyAnalysis;

        public static void ExportDestinationTextFiles(string fileName, string responseBody)
        {
            if (ExecutionConfig.isCreateResponseBodyTextFile)
            {
                string actualFileName = Path.Combine(pathDestination, fileName);

                StreamWriter sw = new StreamWriter(actualFileName);
                sw.WriteLine(responseBody);
                sw.Close();
                sw.Dispose();
            }       
        }

        public static void CompareSDTextFiles(string sFile, string dFile, string failedFileName, string responseBody)
        {
            if (ExecutionConfig.isCompareResponseTextFile)
            {
                string sourceFileName = Path.Combine(pathSource, sFile);

                StreamWriter sw = new StreamWriter(sourceFileName);
                sw.WriteLine(responseBody);
                sw.Close();
                sw.Dispose();

                string destinationFileName = Path.Combine(pathDestination, dFile);

                CompareTxtFiles.CompareTextFiles(sourceFileName, destinationFileName, pathFailed, failedFileName);
            }
        }

    }
}

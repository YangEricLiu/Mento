using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DifferenceEngine;
using System.Collections;
using System.IO;

namespace Mento.Script.OpenAPI
{
    public class CompareTxtFiles
    {
        private static string reportSignals = "\r\n================================================================================\r\n";
        private static string addString = reportSignals + "Lines added at ";
        private static string deleteString = reportSignals + "Lines deleted at ";
        private static string replaceString = reportSignals + "Lines replaced at ";
        private static string titleString = "Difference Report - " + DateTime.Now.ToString() + "\n";

        #region Maybe use this in future for good format of failed text file
        
        private static CompareReport Results(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double time, string failedFileName, out bool result)
		{
			int cnt = 1;
			int i;
            bool tmpResult = true;
            string addStr = "+                ";
            string deleteStr = "-                ";
            CompareReport tmpReports = new CompareReport();
            tmpReports.AddDestinationStrings = new ArrayList();
            tmpReports.DeleteSourceStrings = new ArrayList();
            tmpReports.ReplaceStrings = new ArrayList();

            StreamWriter sw = new StreamWriter(failedFileName);

            sw.WriteLine(titleString);
            sw.WriteLine(reportSignals);

			foreach (DiffResultSpan drs in DiffLines)
			{				
				switch (drs.Status)
				{
					case DiffResultSpanStatus.DeleteSource:
                        tmpResult = false;
                        tmpReports.DeleteSourceStrings.Add(deleteString + cnt.ToString() + reportSignals);
						for (i = 0; i < drs.Length; i++)
						{
                            tmpReports.DeleteSourceStrings.Add(deleteStr + ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line + "\n");
                            cnt++;
						}
                        foreach (object o in tmpReports.DeleteSourceStrings)
                        {
                            sw.WriteLine(o.ToString());
                        }
						break;
					case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            cnt++;
                        }
						break;
					case DiffResultSpanStatus.AddDestination:
                        tmpResult = false;
                        tmpReports.AddDestinationStrings.Add(addString + cnt.ToString() + reportSignals);
						for (i = 0; i < drs.Length; i++)
						{
                            tmpReports.AddDestinationStrings.Add(addStr + ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line + "\n");
							cnt++;
						}
                        foreach (object o in tmpReports.AddDestinationStrings)
                        {
                            sw.WriteLine(o.ToString());
                        }
						break;
					case DiffResultSpanStatus.Replace:
                        tmpResult = false;
                        tmpReports.ReplaceStrings.Add(replaceString + cnt.ToString() + reportSignals);
						for (i = 0; i < drs.Length; i++)
						{
                            tmpReports.ReplaceStrings.Add(deleteStr + ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line + "\n");
                            tmpReports.ReplaceStrings.Add(addStr + ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line + "\n");
                            cnt++;                        
						}
                        foreach (object o in tmpReports.ReplaceStrings)
                        {
                            sw.WriteLine(o.ToString());
                        }
						break;
				}
			}

            sw.Close();
            sw.Dispose();

            result = tmpResult;

            return tmpReports;
		}

        #endregion

        #region Just put failed data to CompareReport structure, but may not good format when export to failed text file
        
        private static CompareReport Results(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double time, out bool result)
        {
            int cnt = 1;
            int i;
            bool tmpResult = true;
            string addStr = "+                ";
            string deleteStr = "-                ";
            CompareReport tmpReports = new CompareReport();
            tmpReports.AddDestinationStrings = new ArrayList();
            tmpReports.DeleteSourceStrings = new ArrayList();
            tmpReports.ReplaceStrings = new ArrayList();

            foreach (DiffResultSpan drs in DiffLines)
            {
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.DeleteSource:
                        tmpResult = false;
                        tmpReports.DeleteSourceStrings.Add(deleteString + cnt.ToString() + reportSignals);
                        for (i = 0; i < drs.Length; i++)
                        {
                            tmpReports.DeleteSourceStrings.Add(deleteStr + ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line + "\n");
                            cnt++;
                        }
                        break;
                    case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            cnt++;
                        }
                        break;
                    case DiffResultSpanStatus.AddDestination:
                        tmpResult = false;
                        tmpReports.AddDestinationStrings.Add(addString + cnt.ToString() + reportSignals);
                        for (i = 0; i < drs.Length; i++)
                        {
                            tmpReports.AddDestinationStrings.Add(addStr + ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line + "\n");
                            cnt++;
                        }
                        break;
                    case DiffResultSpanStatus.Replace:
                        tmpResult = false;
                        tmpReports.ReplaceStrings.Add(replaceString + cnt.ToString() + reportSignals);
                        for (i = 0; i < drs.Length; i++)
                        {
                            tmpReports.ReplaceStrings.Add(deleteStr + ((TextLine)source.GetByIndex(drs.SourceIndex + i)).Line + "\n");
                            tmpReports.ReplaceStrings.Add(addStr + ((TextLine)destination.GetByIndex(drs.DestIndex + i)).Line + "\n");
                            cnt++;
                        }
                        break;
                }
            }

            result = tmpResult;

            return tmpReports;
        }

        #endregion

        #region private method for maybe not used on the current openapi framework
        
        private static void CompareReports(string sFile, string dFile, string failedFileName, CompareReport reports, string path)
        {
            DateTime dt = DateTime.Now;

            string actualFileName = Path.Combine(path, failedFileName);

            StreamWriter sw = new StreamWriter(actualFileName);

            sw.WriteLine(titleString);
            foreach (object o in reports.AddDestinationStrings)
            {
                sw.WriteLine(o.ToString());
            }

            foreach (object o in reports.DeleteSourceStrings)
            {
                sw.WriteLine(o.ToString());
            }

            foreach (object o in reports.ReplaceStrings)
            {
                sw.WriteLine(o.ToString());
            }

            sw.Close();
            sw.Dispose();
        }

        private static string CompareReports(string sFile, string dFile, CompareReport reports)
        {
            DateTime dt = DateTime.Now;

            StringBuilder finalReport = new System.Text.StringBuilder();

            finalReport.Append(titleString);
            finalReport.Append(reportSignals);
            foreach (object o in reports.AddDestinationStrings)
            {
                finalReport.Append(o.ToString());
            }

            foreach (object o in reports.DeleteSourceStrings)
            {
                finalReport.Append(o.ToString());
            }

            foreach (object o in reports.ReplaceStrings)
            {
                finalReport.Append(o.ToString());
            }

            return finalReport.ToString();
        }

        private static bool CompareTextFiles(string sFile, string dFile, string path, string failedFileName)
        {
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            bool IsEqual = true;

            try
            {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, DiffEngineLevel.FastImperfect);

                ArrayList rep = de.DiffReport();
                CompareReport theReports = Results(sLF, dLF, rep, time, out IsEqual);

                if (!IsEqual)
                {
                    CompareReports(sFile, dFile, failedFileName, theReports, path);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return IsEqual;
        }

        #endregion

        public static string CompareTextFiles(string sFile, string dFile)
        {
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            bool IsEqual = true;
            string reportStr = null;

            try
            {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, DiffEngineLevel.FastImperfect);

                ArrayList rep = de.DiffReport();
                CompareReport theReports = Results(sLF, dLF, rep, time, out IsEqual);

                if (!IsEqual)
                {
                    reportStr = CompareReports(sFile, dFile, theReports);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return reportStr;
        }

        public struct CompareReport
        {
            public ArrayList DeleteSourceStrings;
            public ArrayList AddDestinationStrings;
            public ArrayList ReplaceStrings;
        }
    }
}

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
        private static string reportSignals = "\n================================================================================\n";
        private static string addString = reportSignals + "Lines added at ";
        private static string deleteString = reportSignals + "Lines deleted at ";
        private static string replaceString = reportSignals + "Lines replaced at ";

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
                        foreach (object o in tmpReports.DeleteSourceStrings)
                        {
                            Console.Write(o.ToString());
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
                            Console.Write(o.ToString());
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
                            Console.Write(o.ToString());
                        }
						break;
				}
			}

            result = tmpResult;

            return tmpReports;
		}

        private static void CompareReports(string sFile, string dFile, CompareReport reports)
        {
            DateTime dt = DateTime.Now;

            StreamWriter sw = new StreamWriter(@"D:\2.txt");

            sw.WriteLine("Difference Report - " + dt.ToString());
            sw.WriteLine(reportSignals);
            sw.WriteLine(reports.AddDestinationStrings.ToString());
            sw.WriteLine(reports.DeleteSourceStrings.ToString());
            sw.WriteLine(reports.ReplaceStrings.ToString());

            sw.Close();
            sw.Dispose();
        }

        public static bool CompareTextFiles(string sFile, string dFile)
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

                //if (!IsEqual)
                //{
                    CompareReports(sFile, dFile, theReports);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return IsEqual;
        }

        public struct CompareReport
        {
            public ArrayList DeleteSourceStrings;
            public ArrayList AddDestinationStrings;
            public ArrayList ReplaceStrings;
        }
    }
}

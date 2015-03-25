using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Schneider.REM.BL.Energy.DataContract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mento.Script.OpenAPI
{
    public struct EnergyViewDataBody
    {
        public string EnergyViewDatas;
        public string TargetEnergyData;
        public string EnergyData;
        public string Target;
        public string Name;
        public string Type;
        public string TimeSpan;
    }

    public class EnergyViewDataDtoConvertor
    {
        public static EnergyViewDataBody[] GetEnergyViewDataDtoGroups(string sourceOrginal)
        {
            dynamic targetEnergyDataArrays = JsonHelper.Deserialize2Array(sourceOrginal);

            if (targetEnergyDataArrays.Count == 0)
            {
                return null;
            }

            var evd = new List<EnergyViewDataBody>();
            EnergyViewDataBody tmpevd = new EnergyViewDataBody();

            if (targetEnergyDataArrays.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
            {
                if (!sourceOrginal.Contains("TargetEnergyData"))
                {
                    for (int i = 0; i < targetEnergyDataArrays.Count; i++)
                    {
                        JObject data = (JObject)targetEnergyDataArrays[i];

                        tmpevd.EnergyViewDatas = data.ToString();
                    }
                }
                else
                {              
                    for (int i = 0; i < targetEnergyDataArrays.Count; i++)
                    {
                        JObject data = (JObject)targetEnergyDataArrays[i];

                        JArray tedata = (JArray)data["TargetEnergyData"];

                        if (tedata.Count == 0)
                        {
                            return null;
                        }

                        //JObject target = (JObject)tedata[0]["Target"];

                        tmpevd.EnergyViewDatas = data.ToString();

                        tmpevd.TargetEnergyData = tedata.ToString();
                        tmpevd.EnergyData = tedata[0]["EnergyData"].ToString();
                        //tmpevd.Target = target.ToString();
                        //tmpevd.Name = target["Name"].ToString();
                        //tmpevd.Type = target["Type"].ToString();
                        //tmpevd.TimeSpan = target["TimeSpan"].ToString();
                        evd.Add(tmpevd);
                    }
                }
            }
            else if (targetEnergyDataArrays.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
            {
                JObject targetEnergyDataObject = JsonHelper.Deserialize2Object(sourceOrginal);

                tmpevd.EnergyViewDatas = targetEnergyDataObject.ToString();

                JArray tedata2 = (JArray)targetEnergyDataObject["TargetEnergyData"];
                //JObject target2 = (JObject)tedata2[0]["Target"];


                tmpevd.TargetEnergyData = tedata2.ToString();
                tmpevd.EnergyData = tedata2[0]["EnergyData"].ToString();
                //tmpevd.Target = target2.ToString();
                //tmpevd.Name = target2["Name"].ToString();
                //tmpevd.Type = target2["Type"].ToString();
                //tmpevd.TimeSpan = target2["TimeSpan"].ToString();
                evd.Add(tmpevd);
            }
            
            return evd.ToArray();
        }
        
        public static string GetEnergyViewDataWithLocalTime(string sourceOrginal)
        {
            dynamic targetEnergyDataArrays = JsonHelper.Deserialize2Array(sourceOrginal);
            StringBuilder evd = new StringBuilder();
            string datas = "";
    
            if (targetEnergyDataArrays.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
            {
                JObject targetEnergyDataObject = JsonHelper.Deserialize2Object(sourceOrginal);
                evd.Append(targetEnergyDataObject.ToString());
                datas = evd.ToString();
            }
            else if (targetEnergyDataArrays.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
            {
                string other = "," + "\n";
                evd.Append("[" + "\n");

                for (int i = 0; i < targetEnergyDataArrays.Count; i++)
                {
                    JObject data = (JObject)targetEnergyDataArrays[i];
                    if (i != (targetEnergyDataArrays.Count - 1))
                    {
                        evd.Append(data.ToString() + other);
                    }
                    else
                    {
                        evd.Append(data.ToString());
                    }
                }

                evd.Append("\n" + "]");
                datas = evd.ToString();
            }

            return datas;
        }    
    }
}

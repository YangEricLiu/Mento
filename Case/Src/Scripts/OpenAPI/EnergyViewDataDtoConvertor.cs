using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schneider.REM.BL.Energy.DataContract;
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
            JArray targetEnergyDataArrays = JsonHelper.Deserialize2Array(sourceOrginal);

            if (targetEnergyDataArrays.Count == 0)
            {
                return null; 
            }

            var evd = new List<EnergyViewDataBody>();
            EnergyViewDataBody tmpevd = new EnergyViewDataBody();

            for (int i = 0; i < targetEnergyDataArrays.Count; i++)
            {
                JObject data = (JObject)targetEnergyDataArrays[i];

                JArray tedata = (JArray)data["TargetEnergyData"];                  
                JObject target = (JObject)tedata[0]["Target"];

                tmpevd.EnergyViewDatas = data.ToString();
                tmpevd.TargetEnergyData = tedata.ToString();
                tmpevd.EnergyData = tedata[0]["EnergyData"].ToString();
                tmpevd.Target = target.ToString();
                tmpevd.Name = target["Name"].ToString();
                tmpevd.Type = target["Type"].ToString();
                tmpevd.TimeSpan = target["TimeSpan"].ToString();

                evd.Add(tmpevd);
            }

            return evd.ToArray();
        }
    }
}

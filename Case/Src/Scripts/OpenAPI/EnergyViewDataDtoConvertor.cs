using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schneider.REM.BL.Energy.DataContract;

namespace Mento.Script.OpenAPI
{
    public class EnergyViewDataDtoConvertor
    {
        public static TargetEnergyDataDto[] EnergyViewDataGroups(string source)
        {
            return JsonHelper.DeserializeToArray<TargetEnergyDataDto[]>(source);
        }
    }
}

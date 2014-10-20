using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class CommodityAndUomData : TestDataBase<CommodityUOMInputData, CommodityUOMExpectedData>
    {
    }

     public class CommodityUOMInputData : InputTestDataBase
     {
         public string[] Commoditys { get; set; }
         public string[] UOMs { get; set; }

         public CommodityUOMInputData(string[] commoditys, string[] uoms)
        {

            this.Commoditys = commoditys;
            this.UOMs = uoms;
        }
     }

     public class CommodityUOMExpectedData : ExpectedTestDataBase
     {
         public string[] Commoditys { get; set; }
         public string[] UOMs { get; set; }

         public CommodityUOMExpectedData(string[] commoditys, string[] uoms)
        {

            this.Commoditys = commoditys;
            this.UOMs = uoms;
        } 
     }   
}

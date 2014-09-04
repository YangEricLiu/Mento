using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Mento.Script.OpenAPI
{
    public class UnixTimeConvertor
    {
        private static DateTime BaseTime = new DateTime(1970, 1, 1);

        /// <summary>   
        /// 将unixtime转换为.NET的DateTime   
        /// </summary>   
        /// <param name="timeStamp">string类型的秒数</param>   
        /// <returns>转换后的时间</returns>   
        public static DateTime FromUnixTimeToDateTime(string timeStampStr)
        {
            long timeStamp = long.Parse(timeStampStr.Substring(0, 10));

            return FromUnixTime(timeStamp);
        } 
  
        /// <summary>   
        /// 将unixtime转换为.NET的DateTime   
        /// </summary>   
        /// <param name="timeStamp">秒数</param>   
        /// <returns>转换后的时间</returns>   
        public static DateTime FromUnixTime(long timeStamp)   
        {  
            return new DateTime((timeStamp + 8 * 60 * 60) * 10000000 + BaseTime.Ticks);   
        }   
  
        /// <summary>   
        /// 将.NET的DateTime转换为unix time   
        /// </summary>   
        /// <param name="dateTime">待转换的时间</param>   
        /// <returns>转换后的unix time</returns>   
        public static long FromDateTime(DateTime dateTime)   
        {   
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;   
        }   
    }   
}

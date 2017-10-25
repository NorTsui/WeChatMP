using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxMP.Core.Utility
{
    public class TimeStamps
    {
        /// <summary>
        /// 当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long Now()
        {
            return (long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
        }


        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        public static long ToTimeStamp(DateTime dt)
        {
            return (long)((dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
        }

        /// <summary>
        /// 转DateTime
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
        }
        /// <summary>
        /// 转DateTime
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static string ToDateTimeString(long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToString();
        }
        /// <summary>
        /// 转DateTime
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ToDateTimeString(long timestamp, string format)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToString(format);
        }
    }
}

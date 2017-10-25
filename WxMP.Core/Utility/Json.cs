using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WxMP.Core.Utility
{
    /// <summary>
    /// json 序列化
    /// </summary>
    public class Json
    {
        /// <summary>
        /// Json序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ignoreNullValue"></param>
        /// <returns></returns>
        public static string Serialize(object obj, bool ignoreNullValue = false)
        {
            if (obj == null) return "{}";

            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            JsonSerializerSettings settings = new JsonSerializerSettings();
            if (ignoreNullValue)
                settings.NullValueHandling = NullValueHandling.Ignore;
            else
                settings.NullValueHandling = NullValueHandling.Include;
            settings.Converters = new List<JsonConverter> { timeFormat };

            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, settings);
        }

        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Include;
            settings.Converters = new List<JsonConverter> { timeFormat };
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}

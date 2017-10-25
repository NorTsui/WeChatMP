using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WxMP.Core.Model;

namespace WxMP.Core.Utility
{
    /// <summary>
    /// http请求
    /// </summary>
    public class Https
    {
       /// <summary>
        /// Get
       /// </summary>
       /// <param name="url"></param>
       /// <returns></returns>
        public static string Get(string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                return wc.DownloadString(url);
            }
        }
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Post(string url, string data)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                return wc.UploadString(url, data);
            }
        }

        /// <summary>
        /// GET返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetByJson<T>(string url)
        {
            return Json.Deserialize<T>(Https.Get(url));
        }
        /// <summary>
        /// Post返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T PostByJson<T>(string url, string data)
        {
            return Json.Deserialize<T>(Https.Post(url, data));
        }
        /// <summary>
        /// Post返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T PostByJson<T>(string url, IPostEntity data)
        {
            return Json.Deserialize<T>(Https.Post(url, Json.Serialize(data)));
        }
    }
}

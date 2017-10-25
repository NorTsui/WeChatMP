using System;
using Newtonsoft.Json;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 全局唯一票据
    /// </summary>
    [JsonObject]
    public class AccessToken : BaseResultEntity, ITicketEntity
    {
        /// <summary>
        /// 票据
        /// </summary>
        [JsonProperty("access_token")]
        public string Access_Token { get; set; }
        /// <summary>
        /// 超期时间（秒）
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        [JsonIgnore]
        public DateTime Create_In { get;private set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public bool isExpires
        {
            get
            {
                return DateTime.Now > this.Create_In.AddSeconds(this.Expires_In - 120);//提前2分钟过期
            }
        }

        public AccessToken()
        {
            this.Create_In = DateTime.Now;
        }
    }
}

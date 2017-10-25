using System;
using Newtonsoft.Json;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 公众号用于调用微信JS接口的临时票据
    /// </summary>
    [JsonObject]
    public class JsAPITicket : BaseResultEntity, ITicketEntity
    {
        /// <summary>
        /// 票据
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        [JsonIgnore]
        public DateTime Create_In { get; private set; }

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

        public JsAPITicket()
        {
            this.Create_In = DateTime.Now;
        }
    }
}

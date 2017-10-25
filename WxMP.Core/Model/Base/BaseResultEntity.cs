using System;
using Newtonsoft.Json;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 返回结果基类
    /// </summary>
    [JsonObject]
    public abstract class BaseResultEntity
    {
        /// <summary>
        /// 代码
        /// </summary>
        [JsonProperty("errcode")]
        public virtual int ErrorCode { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("errmsg")]
        public virtual string ErrorMessage { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        /// <returns></returns>
        public virtual bool Result()
        {
            if (this.ErrorCode == 0)
                return true;
            else
                return false;
        }
    }
}

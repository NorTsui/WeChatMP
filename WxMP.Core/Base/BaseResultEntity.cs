using System;
using Newtonsoft.Json;

namespace WxMP.Core
{
    [JsonObject]
    public abstract class BaseResultEntity
    {
        [JsonProperty("errcode")]
        public virtual int ErrorCode { get; set; }
        [JsonProperty("errmsg")]
        public virtual string ErrorMessage { get; set; }

        public virtual bool Result()
        {
            if (this.ErrorCode == 0)
                return true;
            else
                return false;
        }
    }
}

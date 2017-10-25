using System;
using Newtonsoft.Json;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 检验授权凭证（access_token）是否有效
    /// </summary>
    [JsonObject]
    public class Oauth2AccessTokenCheck : BaseResultEntity
    {
    }
}

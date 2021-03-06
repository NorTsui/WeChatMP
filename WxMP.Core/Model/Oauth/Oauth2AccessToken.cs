﻿using System;
using Newtonsoft.Json;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 网页授权access_token
    /// </summary>
    public class Oauth2AccessToken :BaseResultEntity
    {
        /// <summary>
        /// 网页授权接口调用凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 超时时间，单位（秒）
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }
        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string Refresh_Token { get; set; }
        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }
        /// <summary>
        /// 当且仅当该公众号已获取用户的userinfo授权，并且该公众号已经绑定到微信开放平台帐号时，才会出现该字段
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}

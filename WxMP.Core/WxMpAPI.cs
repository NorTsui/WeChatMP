using System;

namespace WxMP.Core
{
    /// <summary>
    /// 公众号接口
    /// </summary>
    public class WxMpAPI
    {

        #region 票据
        /// <summary>
        /// 公众号的全局唯一票据
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="secret">公众号的appsecret</param>
        /// <returns></returns>
        public static string AccessToken(string appid, string secret)
        {
            return String.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret);
        }
        /// <summary>
        /// 公众号用于调用微信JS接口的临时票据
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string GetTicket(string access_token)
        {
            return String.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi ", access_token);
        }

        #endregion

        #region OAuth2

        /// <summary>
        /// 微信网页授权OAuth2.0
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="redirect_uri">重定向URL</param>
        /// <param name="snsapi">snsapi_base/snsapi_userinfo</param>
        /// <param name="state">STATE值原样返回</param>
        /// <returns></returns>
        public static string Oauth2_Authorize(string appid, string redirect_uri, string snsapi = "snsapi_userinfo", string state = "STATE")
        {
            return String.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect", appid, redirect_uri, snsapi, state);
        }
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="secret">公众号的appsecret</param>
        /// <param name="code">授权获取的code参数 </param>
        /// <returns></returns>
        public static string Oauth2_Access_Token(string appid, string secret, string code)
        {
            return String.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appid, secret, code);

        }
        /// <summary>
        /// 刷新access_token
        /// </summary>
        /// <param name="appid">公众号的唯一标识</param>
        /// <param name="refresh_token">填写通过access_token获取到的refresh_token参数</param>
        /// <returns></returns>
        public static string Oauth2_Refresh_Token(string appid, string refresh_token)
        {
            return String.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", appid, refresh_token);

        }

        /// <summary>
        /// 拉取用户信息
        /// </summary>
        /// <param name="access_token">网页授权接口调用凭证</param>
        /// <param name="openid">用户的唯一标识</param>
        /// <returns></returns>
        public static string Oauth2_UserInfo(string access_token, string openid)
        {
            return String.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={0}&lang=zh_CN", access_token, openid);

        }

        #endregion

        /// <summary>
        /// 微信服务器IP地址
        /// </summary>
        /// <param name="access_token">公众号的access_token</param>
        /// <returns></returns>
        public static string GetCallbackIP(string access_token)
        {
            return String.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", access_token);
        }
    }
}
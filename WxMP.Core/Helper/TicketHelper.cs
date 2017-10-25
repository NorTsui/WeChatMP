using System;
using WxMP.Core.Utility;
using WxMP.Core.Model;
using WxMP.Core;

namespace WxMP.Core
{
    /// <summary>
    /// 票据使用类
    /// </summary>
    public class TicketHelper
    {
        private TicketHelper()
        {
        }

        /// <summary>
        /// 缓存
        /// </summary>
        private static Cache _cache = new Cache();
        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// 全局唯一票据
        /// </summary>
        public static AccessToken access_token
        {
            get
            {
                var obj = TicketHelper._cache.Get("accesstoken");

                if (obj == null || ((AccessToken)obj).isExpires)
                {
                    lock (_lock)
                    {
                        if (obj == null || ((AccessToken)obj).isExpires)
                        {
                            obj = Https.GetByJson<AccessToken>(WxMpAPI.AccessToken(SysConfigInfos.AppID, SysConfigInfos.AppSecret));
                        }
                    }
                }

                return (AccessToken)obj;
            }
        }
        /// <summary>
        /// 公众号用于调用微信JS接口的临时票据
        /// </summary>
        public static JsAPITicket jsapi_ticket
        {
            get
            {
                var obj = TicketHelper._cache.Get("jsapiticket");

                if (obj == null || ((JsAPITicket)obj).isExpires)
                {
                    lock (_lock)
                    {
                        if (obj == null || ((JsAPITicket)obj).isExpires)
                        {
                            obj = Https.GetByJson<JsAPITicket>(WxMpAPI.GetTicket(TicketHelper.access_token.Access_Token));
                        }
                    }
                }

                return (JsAPITicket)obj;
            }
        }
    }

}

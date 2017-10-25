using System;
using System.Collections;
using System.Collections.Generic;

namespace WxMP.Core.Model
{
    /// <summary>
    /// JsSDKConfig配置
    /// </summary>
    public class JsSDKConfig
    {
        /// <summary>
        /// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印
        /// </summary>
        public bool Debug { get; set; }
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        public string AppId { get; private set; }
        /// <summary>
        /// 生成签名的时间戳
        /// </summary>
        public long TimesTamp { get; private set; }
        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        public string NonceStr { get; private set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; private set; }
        /// <summary>
        /// 需要使用的JS接口列表
        /// </summary>
        private List<JSAPI> _JsApiList { get; set; }
        /// <summary>
        /// 需要使用的JS接口
        /// </summary>
        public string JsApiList
        {
            get
            {
                string res = string.Empty;
                foreach (var i in _JsApiList)
                {
                    res += (string.IsNullOrEmpty(res) ? string.Format("'{0}'", i.ToString()) : string.Format("',{0}'", i.ToString()));
                }
                return res;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">当前网页的URL，不包含#及其后面部分</param>
        /// <param name="jsapis">需要使用的JS接口</param>
        public JsSDKConfig(string url, params JSAPI[] jsapis)
        {
            this._JsApiList = new List<JSAPI>();
            foreach (var i in jsapis)
            {
                if (!this._JsApiList.Exists(a => a.ToString() == i.ToString()))
                    this._JsApiList.Add(i);
            }


            Debug = false;
            AppId = SysConfigInfos.AppID;
            TimesTamp = WxMP.Core.Utility.TimeStamps.Now();
            NonceStr = Guid.NewGuid().ToString("n");

            ArrayList arr = new ArrayList();
            arr.Add(string.Format("noncestr={0}", NonceStr));
            arr.Add(string.Format("jsapi_ticket={0}", TicketHelper.jsapi_ticket));
            arr.Add(string.Format("timestamp={0}", TimesTamp));
            arr.Add(string.Format("url={0}", url));
            arr.Sort();

            Signature = WxMP.Core.Utility.Cryptography.SHA1(string.Join("&", arr));

        }
    }
}

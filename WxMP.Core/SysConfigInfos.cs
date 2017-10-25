using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxMP.Core
{
    /// <summary>
    /// 服务器配置信息
    /// </summary>
    public static class SysConfigInfos
    {
        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        public static readonly string AppID = (System.Configuration.ConfigurationManager.AppSettings["AppID"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["AppID"].ToString());
        /// <summary>
        /// 公众号的密钥
        /// </summary>
        public static readonly string AppSecret = (System.Configuration.ConfigurationManager.AppSettings["AppSecret"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["AppSecret"].ToString());
        /// <summary>
        /// 服务器配置token,用作生成签名
        /// </summary>
        public static readonly string Token = (System.Configuration.ConfigurationManager.AppSettings["Token"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["Token"].ToString());
        /// <summary>
        /// 消息加解密密钥
        /// </summary>
        public static readonly string EncodingAESKey = (System.Configuration.ConfigurationManager.AppSettings["EncodingAESKey"] == null ? "" : System.Configuration.ConfigurationManager.AppSettings["EncodingAESKey"].ToString());
    }
}

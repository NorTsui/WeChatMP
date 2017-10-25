using System;
using System.Xml.Serialization;
namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收文本消息
    /// </summary>
    public class ReceiveMsgText : BaseReceiveMsgEntity
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.text;
            }
            set
            {
            }
        }
    }
}

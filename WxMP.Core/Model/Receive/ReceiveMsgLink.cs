using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class ReceiveMsgLink : BaseReceiveMsgEntity
    {
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.link;
            }
            set
            {
            }
        }
    }
}

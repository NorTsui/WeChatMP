using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收消息基类
    /// </summary>
    public abstract class BaseReceiveMsgEntity : IMessageEntity
    {
        /// <summary>
        /// 接收方帐号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract MessageType MsgType { get; set; }
        /// <summary>
        /// 消息id
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 执行方法
        /// </summary>
        public virtual void Execute()
        { }
    }
}

using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收事件消息基类
    /// </summary>
    public abstract class BaseReceiveEvenMsgEntity : IMessageEntity
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
        public MessageType MsgType
        {
            get
            {
                return MessageType.Event;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        /// <summary>
        /// 事件类型
        /// </summary>
        public abstract EvenType Even { get; set; }
        /// <summary>
        /// 执行方法
        /// </summary>
        public virtual void Execute()
        { }
    }
}

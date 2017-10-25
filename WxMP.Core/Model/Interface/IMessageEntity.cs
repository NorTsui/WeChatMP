using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 消息基础接口
    /// </summary>
    public interface IMessageEntity
    {
        /// <summary>
        /// 接收方帐号
        /// </summary>
        string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号
        /// </summary>
        string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        long CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        MessageType MsgType { get; }
        /// <summary>
        /// 执行方法
        /// </summary>
        void Execute();

    }
}

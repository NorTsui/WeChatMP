using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收取消订阅事件消息
    /// </summary>
    public class ReceiveEvenMsgUnsubscribe : BaseReceiveEvenMsgEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.unsubscribe;
            }
            set
            {
            }
        }
    }
}

using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收订阅事件消息
    /// </summary>
    public class ReceiveEvenMsgSubscribe : BaseReceiveEvenMsgEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.subscribe;
            }
            set
            {
            }
        }
    }
}

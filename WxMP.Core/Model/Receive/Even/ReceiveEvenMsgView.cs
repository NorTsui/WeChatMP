using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收点击菜单跳转链接时的事件推送
    /// </summary>
    public class ReceiveEvenMsgView : BaseReceiveEvenMsgEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.VIEW;
            }
            set
            {
            }
        }
        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }
    }
}

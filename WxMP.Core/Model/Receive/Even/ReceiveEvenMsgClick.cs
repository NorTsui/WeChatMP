using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收点击菜单拉取消息时的事件推送
    /// </summary>
    public class ReceiveEvenMsgClick : BaseReceiveEvenMsgEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.CLICK;
            }
            set
            {
            }
        }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}

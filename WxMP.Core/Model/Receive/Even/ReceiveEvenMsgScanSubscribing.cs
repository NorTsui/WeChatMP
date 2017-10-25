using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收扫码订阅事件消息,用户未关注
    /// </summary>
    public class ReceiveEvenMsgScanSubscribing : ReceiveEvenMsgSubscribe
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
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}

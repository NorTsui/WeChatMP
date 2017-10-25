using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收扫码订阅事件消息,用户已关注
    /// </summary>
    public class ReceiveEvenMsgScanSubscribed : ReceiveEvenMsgSubscribe
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.SCAN;
            }
            set
            {
            }
        }
        /// <summary>
        /// 事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}

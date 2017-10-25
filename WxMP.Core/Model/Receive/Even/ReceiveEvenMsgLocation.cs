using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收地理位置事件消息
    /// </summary>
    public class ReceiveEvenMsgLocation : BaseReceiveEvenMsgEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EvenType Even
        {
            get
            {
                return EvenType.LOCATION;
            }
            set
            {
            }
        }
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public decimal Precision { get; set; }
    }
}

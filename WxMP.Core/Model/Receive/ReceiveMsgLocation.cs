using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收地理位置消息
    /// </summary>
    public class ReceiveMsgLocation : BaseReceiveMsgEntity
    {
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public decimal Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public decimal Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.location;
            }
            set
            {
            }
        }
    }
}

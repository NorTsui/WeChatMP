using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收图片消息
    /// </summary>
    public class ReceiveMsgImage : BaseReceiveMsgEntity
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.image;
            }
            set
            {
            }
        }
    }
}

using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 接收语音消息
    /// </summary>
    public class ReceiveMsgVoice : BaseReceiveMsgEntity
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.voice;
            }
            set
            {
            }
        }
    }
}

using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复语音消息
    /// </summary>
    public class RevertMsgVoice : BaseRevertMsgEntity
    {
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

        /// <summary>
        /// 语音
        /// </summary>
        public Voice Voice { get; set; }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {

        }
    }
}

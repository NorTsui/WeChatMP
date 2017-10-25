using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复视频消息
    /// </summary>
    public class RevertMsgVideo:BaseRevertMsgEntity
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.video;
            }
            set
            {
                
            }
        }
        /// <summary>
        /// 视频
        /// </summary>
        public Video Video { get; set; }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {

        }
    }
}

using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复音乐消息
    /// </summary>
    public class RevertMsgMusic : BaseRevertMsgEntity
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.music;
            }
            set
            {
                
            }
        }
        /// <summary>
        /// 音乐
        /// </summary>
        public Music Music { get; set; }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {

        }
    }
}

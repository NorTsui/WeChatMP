using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    public class RevertMsgText : BaseRevertMsgEntity
    {
        public override MessageType MsgType
        {
            get
            {
                return MessageType.text;
            }
            set
            {
            }
        }

        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）  
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {

        }
    }
}

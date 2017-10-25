using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复图片消息
    /// </summary>
    public class RevertMsgImage : BaseRevertMsgEntity
    {
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
        /// <summary>
        /// 图片
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {

        }
    }
}

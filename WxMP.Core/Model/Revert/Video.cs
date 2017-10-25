using System;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 通过素材管理接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }
    }
}

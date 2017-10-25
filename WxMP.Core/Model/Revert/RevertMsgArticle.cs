using System;
using System.Collections.Generic;

namespace WxMP.Core.Model
{
    /// <summary>
    /// 回复图文消息
    /// </summary>
    public class RevertMsgArticle : BaseRevertMsgEntity
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public override MessageType MsgType
        {
            get
            {
                return MessageType.news;
            }
            set
            { }
        }
        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        [System.Xml.Serialization.XmlElement("Articles")]
        public List<Article> Articles { get; set; }
        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount
        {
            get
            {
                return Articles.Count;
            }
            set 
            { }
        }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            
        }
    }
}

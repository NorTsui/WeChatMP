using System;

namespace WxMP.Core
{
    /// <summary>
    /// 票据接口
    /// </summary>
    public interface ITicketEntity
    {
        /// <summary>
        /// 生成时间
        /// </summary>
        DateTime Create_In { get; }
        /// <summary>
        /// 是否过期
        /// </summary>
        bool isExpires { get; }
    }
}

using System;

namespace WxMP.Core
{
    public enum EvenType
    {
        /// <summary>
        /// 订阅
        /// </summary>
        subscribe,
        /// <summary>
        /// 取消订阅
        /// </summary>
        unsubscribe,
        /// <summary>
        /// 扫码
        /// </summary>
        SCAN,
        /// <summary>
        /// 上报地理位置
        /// </summary>
        LOCATION,
        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        CLICK,
        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        VIEW,
    }
}

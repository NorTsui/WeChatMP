using System;

namespace WxMP.Core
{
    /// <summary>
    /// JSSDK JS接口
    /// </summary>
    public enum JSAPI
    {
        /// <summary>
        /// 分享到朋友圈
        /// </summary>
        onMenuShareTimeline,
        /// <summary>
        /// 分享给朋友
        /// </summary>
        onMenuShareAppMessage,
        /// <summary>
        /// 分享到QQ
        /// </summary>
        onMenuShareQQ,
        /// <summary>
        /// 分享到腾讯微博
        /// </summary>
        onMenuShareWeibo,
        /// <summary>
        /// 分享到QQ空间
        /// </summary>
        onMenuShareQZone,
        /// <summary>
        /// 开始录音接口
        /// </summary>
        startRecord,
        /// <summary>
        /// 停止录音接口
        /// </summary>
        stopRecord,
        /// <summary>
        /// 监听录音自动停止接口
        /// </summary>
        onVoiceRecordEnd,
        /// <summary>
        /// 播放语音
        /// </summary>
        playVoice,
        /// <summary>
        /// 暂停播放语音
        /// </summary>
        pauseVoice,
        /// <summary>
        /// 停止播放语音
        /// </summary>
        stopVoice,
        /// <summary>
        /// 监听语音播放完毕
        /// </summary>
        onVoicePlayEnd,
        /// <summary>
        /// 上传语音
        /// </summary>
        uploadVoice,
        /// <summary>
        /// 下载语音
        /// </summary>
        downloadVoice,
        /// <summary>
        /// 拍照或从手机相册中选图
        /// </summary>
        chooseImage,
        /// <summary>
        /// 预览图片
        /// </summary>
        previewImage,
        /// <summary>
        /// 上传图片
        /// </summary>
        uploadImage,
        /// <summary>
        /// 下载图片
        /// </summary>
        downloadImage,
        /// <summary>
        /// 识别音频并返回识别结果
        /// </summary>
        translateVoice,
        /// <summary>
        /// 获取网络状态接口
        /// </summary>
        getNetworkType,
        /// <summary>
        /// 使用微信内置地图查看位置
        /// </summary>
        openLocation,
        /// <summary>
        /// 获取地理位置
        /// </summary>
        getLocation,
        /// <summary>
        /// 隐藏右上角菜单
        /// </summary>
        hideOptionMenu,
        /// <summary>
        /// 显示右上角菜单
        /// </summary>
        showOptionMenu,
        /// <summary>
        /// 批量隐藏功能按钮
        /// </summary>
        hideMenuItems,
        /// <summary>
        /// 批量显示功能按钮
        /// </summary>
        showMenuItems,
        /// <summary>
        /// 隐藏所有非基础按钮
        /// </summary>
        hideAllNonBaseMenuItem,
        /// <summary>
        /// 显示所有功能按钮
        /// </summary>
        showAllNonBaseMenuItem,
        /// <summary>
        /// 关闭当前网页窗口
        /// </summary>
        closeWindow,
        /// <summary>
        /// 调起微信扫一扫
        /// </summary>
        scanQRCode,
        /// <summary>
        /// 发起一个微信支付
        /// </summary>
        chooseWXPay,
        /// <summary>
        /// 跳转微信商品页
        /// </summary>
        openProductSpecificView,
        /// <summary>
        /// 批量添加卡券
        /// </summary>
        addCard,
        /// <summary>
        /// 拉取适用卡券列表并获取用户选择信息
        /// </summary>
        chooseCard,
        /// <summary>
        /// 查看微信卡包中的卡券
        /// </summary>
        openCard,
    }
}

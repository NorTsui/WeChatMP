using System;
using System.Web;

namespace WxMP.Core.Utility
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
        /// <summary>
        /// 存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return this.Get(key) != null;
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key">key</param>
        public void Remove(string key)
        {
            if (this.Exists(key))
            {
                HttpRuntime.Cache.Remove(key);
            }
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        /// <param name="timeout">超时时间(分)</param>
        public void Set(string key, object value, int timeout = 180)
        {
            if (this.Exists(key))
                this.Remove(key);

            HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes((double)timeout));
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            System.Collections.IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                HttpRuntime.Cache.Remove(enumerator.Key.ToString());
            }
        }

    }

}

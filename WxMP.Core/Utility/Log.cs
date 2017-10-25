using System;
using System.IO;

namespace WxMP.Core.Utility
{
    public class Log
    {
        private static readonly object _lock = new object();

        public static void Add(string msg)
        {
            msg = "\r\n----------------------------- " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + " -----------------------------\r\n" + msg;

            var filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\logs\\";
            var file = filepath + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);

            lock (_lock)
            {
                using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(msg);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}

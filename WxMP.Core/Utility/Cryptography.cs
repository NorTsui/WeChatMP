using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WxMP.Core.Utility
{
    /// <summary>
    /// 加解密
    /// </summary>
    public abstract class Cryptography
    {
        #region base64
        /// <summary>
        /// 转Base64
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string Base64Encode(string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
        /// <summary>
        /// 解码Base64
        /// </summary>
        /// <param name="base64String">字符串</param>
        /// <returns></returns>
        public static string Base64Decode(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion

        #region md5
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string Md5(string value, string salt = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(salt))
            {
                value += salt;
            }
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
            }
        }
        /// <summary>
        /// md5默认盐加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string Md5DefaultSalt(string value)
        {
            return Cryptography.Md5(value, Base64Encode(value));

        }
        /// <summary>
        /// 16位md5加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string Md5_16(string value, string salt = null)
        {
            return Cryptography.Md5(value, salt).Substring(8, 16);
        }
        /// <summary>
        /// 8位md5加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string Md5_8(string value, string salt = null)
        {
            return Cryptography.Md5(value, salt).Substring(8, 8);
        }

        #endregion

        #region SHA1
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string SHA1(string value, string salt = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(salt))
            {
                value += salt;
            }
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
            }
        }

        /// <summary>
        /// SHA1默认盐加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string SHA1DefaultSalt(string value)
        {
            return Cryptography.SHA1(value, Base64Encode(value));
        }

        #endregion

        #region DES
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="value">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充类型</param>
        /// <returns></returns>
        public static string DESEncrypt(string value, string key, string iv = null, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (key.Length != 8)
            {
                throw new CryptographicException("DES密钥必须为8位字符");
            }
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length != 8)
                {
                    throw new CryptographicException("DES向量必须为8位字符");
                }
            }
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key);
            provider.IV = (iv != null ? Encoding.ASCII.GetBytes(iv) : Encoding.ASCII.GetBytes(key));
            provider.Mode = cipherMode;
            provider.Padding = paddingMode;
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    stream2.Write(bytes, 0, bytes.Length);
                    stream2.FlushFinalBlock();
                }
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="value">明文</param>
        /// <returns></returns>
        public static string DESEncrypt(string value)
        {
            return Cryptography.DESEncrypt(value, "31110991");
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="value">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充类型</param>
        /// <returns></returns>
        public static string DESDecrypt(string value, string key, string iv = null, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (key.Length != 8)
            {
                throw new CryptographicException("DES密钥必须为8位字符");
            }
            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length != 8)
                {
                    throw new CryptographicException("DES向量必须为8位字符");
                }
            }
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key);
            provider.IV = (iv != null ? Encoding.ASCII.GetBytes(iv) : Encoding.ASCII.GetBytes(key));
            provider.Mode = cipherMode;
            provider.Padding = paddingMode;
            byte[] bytes = Convert.FromBase64String(value);
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    stream2.Write(bytes, 0, bytes.Length);
                    stream2.FlushFinalBlock();
                }
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="value">密文</param>
        /// <returns></returns>
        public static string DESDecrypt(string value)
        {
            return Cryptography.DESDecrypt(value, "31110991");
        }
        #endregion

        #region AES
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">明文（默认以UTF-8编码）</param>
        /// <param name="key">密钥（默认以ASCII编码）</param>
        /// <param name="cipherMode">块密码模式（默认ECB）</param>
        /// <param name="paddingMode">填充模式（默认PKCS#7）</param>
        /// <returns>密文（默认以Base64编码输出）</returns>
        public static string AESEncrypt(string value, string key, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            //if (key.Length != 32)
            //{
            //    throw new CryptographicException("AES密钥必须为32位字符");
            //}
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = Encoding.ASCII.GetBytes(Md5(key));
            rijndaelManaged.Mode = cipherMode;
            rijndaelManaged.Padding = paddingMode;
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor())
            {
                var encryptData = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                return Convert.ToBase64String(encryptData);
            }
        }
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">明文</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(string value)
        {
            return Cryptography.AESEncrypt(value, "1L0veu");
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">密文（默认以Base64编码解码）</param>
        /// <param name="key">密钥（默认以ASCII编码）</param>
        /// <param name="cipherMode">块密码模式（默认ECB）</param>
        /// <param name="paddingMode">填充模式（默认PKCS#7）</param>
        /// <returns>明文（默认以UTF-8编码）</returns>
        public static string AESDecrypt(string value, string key, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            //if (key.Length != 32)
            //{
            //    throw new CryptographicException("AES密钥必须为32位字符");
            //}
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = Encoding.ASCII.GetBytes(Md5(key));
            rijndaelManaged.Mode = cipherMode;
            rijndaelManaged.Padding = paddingMode;
            byte[] bytes = Convert.FromBase64String(value);

            using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor())
            {
                var encryptData = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(encryptData);
            }
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">密文</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(string value)
        {
            return Cryptography.AESDecrypt(value, "1L0veu");
        }
        #endregion
    }
}

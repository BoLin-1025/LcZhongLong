using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public class BruceClass
    {
        #region 加密

        /// <summary>
        /// HmacSha256加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        public static string HmacSha256(string plainText)
        {
            var hmacSha256 = new HMACSHA256(Encoding.Default.GetBytes("Bruce"));
            byte[] data = hmacSha256.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// HmacSha1加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        public static string HmacSha1(string plainText)
        {
            var hmacSha1 = new HMACSHA1(Encoding.Default.GetBytes("Bruce"));
            byte[] data = hmacSha1.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// HmacMd5加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        public static string HmacMd5(string plainText)
        {
            var hmacMd5 = new HMACMD5(Encoding.Default.GetBytes("Bruce"));
            byte[] data = hmacMd5.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Sha256加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        public static string Sha256(string plainText)
        {
            SHA256 Sha256 = SHA256.Create();
            //获取要加密的字段，并转化为Byte[]数组
            byte[] data = Sha256.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Md5(string plainText,int size=32)
        {
            //获取加密服务
            MD5 md5 = MD5.Create();
            //获取要加密的字段，并转化为Byte[]数组
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            string md5_content= sBuilder.ToString().ToUpper();

            if (size==32)
            {
                return md5_content;
            }
            else
            {
                return md5_content.Substring(7, 16);
            }
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Sha1(string plainText)
        {
            //获取加密服务
            SHA1 sha1 = SHA1.Create();
            //获取要加密的字段，并转化为Byte[]数组
            byte[] data = sha1.ComputeHash(Encoding.Default.GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        #endregion

        #region 时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        public static DateTime StampToDateTime(string timeStamp)
        {
            DateTime dateTimeStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dateTimeStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">DateTime</param>
        /// <returns></returns>
        public static int DateTimeToStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            return (int)(time - startTime).TotalSeconds;
        }

        #endregion

        #region 类型转换
        /// <summary>
        /// 将可能的DBNULL类型转换为Double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double DBNULLDouble(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToDouble(obj);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 将可能的DBNULL类型转换为Decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Decimal DBNULLDecimal(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToDecimal(obj);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 将可能的DBNULL类型转换为DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime DBNULLDateTime(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToDateTime(obj);
                }
                return DateTime.Now;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 将可能的DBNULL类型转换为Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int DBNULLInt(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 将可能的DBNULL类型转换为String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DBNULLStr(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return obj.ToString();
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}

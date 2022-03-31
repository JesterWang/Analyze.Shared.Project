using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common
{
    public static class SecurityMgr
    {
        /// <summary>
        /// MD5加密方法
        /// </summary>
        /// <param name="str">传入许加密的字符</param>
        /// <returns>返回加密后的字符</returns>
        public static string ToMd5(this string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(str+"wangqiang24"));
            var md5Str = BitConverter.ToString(output).Replace("-","");
            return md5Str;
        }
    }
}

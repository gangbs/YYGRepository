using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace YYG.Framework
{
   public class PwdProtectcs
    {
        /// <summary>
        /// 密码加密，基于Rfc2898算法（通过随机盐以及设置迭代次数来计算hash值的算法）
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string Encryption(string pwd)
        {
          return  Crypto.HashPassword(pwd);
        }

        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YYG.Framework.Data;

namespace YYG.Framework
{
   public static class CookieExtension
    {
        /// <summary>
        /// 从一个Cookie中读取值并转成指定的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static T ConverTo<T>(this HttpCookie cookie)
        {
            if (cookie == null)
                return default(T);

            return (T)Convert.ChangeType(cookie.Value, typeof(T));
        }

        /// <summary>
        /// 从一个Cookie中读取【JSON字符串】值并反序列化成一个对象，用于读取复杂对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static T FromJson<T>(this HttpCookie cookie)
        {
            if (cookie == null)
                return default(T);

            return JsonHelper.Parse<T>(cookie.Value);
        }

        /// <summary>
        /// 将一个对象写入到Cookie
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="expries"></param>
        public static void WriteCookie(this object obj, string name, DateTime? expries=null)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");


            HttpCookie cookie = new HttpCookie(name, obj.ToString());

            if (expries.HasValue)
                cookie.Expires = expries.Value;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }


        /// <summary>
        /// 删除指定的Cookie
        /// </summary>
        /// <param name="name"></param>
        public static void DeleteCookie(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            HttpCookie cookie = new HttpCookie(name);

            // 删除Cookie，其实就是设置一个【过期的日期】
            cookie.Expires = new DateTime(1900, 1, 1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}

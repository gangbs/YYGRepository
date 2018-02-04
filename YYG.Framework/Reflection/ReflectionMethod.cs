using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.Reflection
{
    public static class ReflectionMethod
    {
        /// <summary>
        /// 获取枚举值的特性
        /// </summary>
        /// <typeparam name="T">一个枚举类型</typeparam>
        /// <param name="obj">一个枚举值</param>
        /// <returns></returns>
        /// 1.为什么obj.ToString()可以得到字段的名称，2.在方法里传BindingFlags.Public | BindingFlags.Static这种参数表示什么？
        public static T GetFieldInfoAttribute<T>(dynamic obj) where T : Attribute
        {

            Type type = obj.GetType();
            FieldInfo a = type.GetField(obj.ToString(), BindingFlags.Public | BindingFlags.Static);
            var query = from q in a.GetCustomAttributes(typeof(T), false) select ((T)q);
            return query.FirstOrDefault();
        }
    }
}

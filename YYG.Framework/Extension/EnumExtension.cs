using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Framework.Reflection;

namespace YYG.Framework.Extension
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T item)
        {
            var attr = ReflectionMethod.GetFieldInfoAttribute<DescriptionAttribute>(item);
            return attr == null ? string.Empty : attr.Description;
        }
    }
}

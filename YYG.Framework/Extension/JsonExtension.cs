using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Framework.Data;

namespace YYG.Framework.Extension
{
    public static class JsonExtension
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonHelper.Serialize(obj);
        }
    }
}

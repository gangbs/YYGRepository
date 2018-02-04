using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.Data
{
    public class JsonHelper
    {
        public static T Parse<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}

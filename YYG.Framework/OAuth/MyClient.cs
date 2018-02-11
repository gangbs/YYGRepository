using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.OAuth
{
    /// <summary>
    /// 客户端信息，用于在服务端注册
    /// </summary>
   public class MyClient
    {
        public string Id { get; set; }

        public string Secret { get; set; }

        public string RedirectUrl { get; set; }
    }
}

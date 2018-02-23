using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Business;

namespace YYG.Console
{
   public class RedisTest
    {
        readonly RedisBusiness business;
        public RedisTest()
        {
            this.business = new RedisBusiness();
        }

        public void Test()
        {
            this.business.Add();
            this.business.Edit();
            this.business.Delete();
        }



    }
}

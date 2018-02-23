using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Framework.Extension;
using YYG.Framework.Redis;

namespace YYG.Business
{
   public class RedisBusiness
    {
        readonly RedisHelper redis;
        public RedisBusiness()
        {
            this.redis = new RedisHelper(1);
        }




        public void Add()
        {
            string key = "item1";
            string value = (new { a = "rrr", b = 1 }).ToJson();
            TimeSpan ts = new TimeSpan(0, 1, 0);
            this.redis.StringSet(key, value, ts);
        }

        public void Edit()
        {
            string key = "item1";
            string value = "4444";
            TimeSpan ts = new TimeSpan(0, 1, 0);
            this.redis.StringSet(key, value, ts);
        }

        public void Delete()
        {
           bool flag= this.redis.KeyDelete("item1");
        }

        public void Get(string key)
        {
          string strVal=  this.redis.StringGet("item1");
        }
    }
}

using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
    public class RedisHashCache : RedisBase
    {
        public RedisHashCache(int dbnum, string prefix, string connectionString = null) : base(dbnum, prefix, connectionString)
        {
        }

        public void HashSet<T>(string key, T obj, TimeSpan? exp = default(TimeSpan?))
        {
            key = this.GenRealKey(key);
            List<HashEntry> hashFields = new List<HashEntry>();
            var arrPro = typeof(T).GetProperties();
            foreach (var p in arrPro)
            {
                string name = p.Name;
                object val = p.GetValue(obj);
                hashFields.Add(new HashEntry(name,val.ToString()));
            }
            this.db.HashSet(key, hashFields.ToArray());
            this.db.KeyExpire(key, exp);
        }

        public bool HashSet(string key, string field,string val)
        {
            key = this.GenRealKey(key);
           return this.db.HashSet(key, field, val);
        }

        //public T HashGet<T>(string key) where T : new()
        //{
        //    T obj = new T();
        //    var arrhe= this.db.HashGetAll(key);
        //    foreach (var p in typeof(T).GetProperties())
        //    {
        //        var h = arrhe.Where(x => x.Name.ToString() == p.Name);
        //        if (h == null) continue;
        //        p.SetValue(obj,p.PropertyType.pa)
        //    }
        //}

        public string GetFieldValue(string key,string field)
        {
           return this.db.HashGet(key, field);
        }
    }
}

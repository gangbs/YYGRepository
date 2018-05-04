using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
    public abstract class RedisBase
    {
        readonly ConnectionMultiplexer conn = null;
        readonly string prefix = string.Empty;
        readonly int dbNumber = 0;
       protected readonly IDatabase db;

        public RedisBase(int dbnum, string prefix, string connectionString = null)
        {
            this.dbNumber = dbnum;
            this.conn = string.IsNullOrWhiteSpace(connectionString) ? RedisManager.Instance : RedisManager.GetFromCache(connectionString);
            this.prefix = prefix;
            this.db = this.conn.GetDatabase(dbnum);
        }

        #region 数据库操作

        /// <summary>
        /// 生成数据库中真实的key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GenRealKey(string key)
        {
            return prefix + "_" + key;
        }

        /// <summary>
        /// 执行保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected T DoSave<T>(Func<IDatabase, T> func)
        {
            conn.GetDatabase(dbNumber);
            return func(conn.GetDatabase(dbNumber));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            key = GenRealKey(key);
            return conn.GetDatabase(dbNumber).KeyDelete(key);
        }

        /// <summary>
        /// key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            key = GenRealKey(key);
            return conn.GetDatabase(dbNumber).KeyExists(key);
        }

        #endregion

        #region 数据类型转换

        protected string ConvertJson<T>(T val)
        {
            return val is string ? val.ToString() : JsonConvert.SerializeObject(val);
        }

        protected T ConvertObj<T>(RedisValue val)
        {
            return JsonConvert.DeserializeObject<T>(val);
        }

        protected List<T> ConvertList<T>(RedisValue[] val)
        {
            List<T> result = new List<T>();
            foreach (var item in val)
            {
                var model = ConvertObj<T>(item);
                result.Add(model);
            }
            return result;
        }

        protected RedisKey[] ConvertRedisKeys(List<string> val)
        {
            return val.Select(k => (RedisKey)k).ToArray();
        }

        #endregion
    }
}

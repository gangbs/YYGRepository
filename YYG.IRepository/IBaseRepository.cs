﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YYG.Entity;

namespace YYG.IRepository
{
    public interface IBaseRepository<T> where T : DataBaseEntity
    {
        #region 查询

        T Get(params object[] key);

        T Get(Expression<Func<T, bool>> fliter);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetList(string sql, params object[] parameters);

        IEnumerable<TReturn> GetList<TReturn>(string sql, params object[] parameters);

        IEnumerable<T> GetPaging<K>(Expression<Func<T, bool>> filter, Expression<Func<T, K>> orderFiled, int pageSize, int pageNum, out int count, bool isAsc = true);

        IEnumerable<TReturn> GetList<TReturn>(IQueryable<TReturn> linq) where TReturn : DataBaseEntity;

        #endregion

        #region 增加
        int Insert(T entity, bool isSaveChange = true);

        int InsertMany(IEnumerable<T> lst, bool isSaveChange = true);

        int BatchInsert(IEnumerable<T> lst);

        #endregion

        #region 编辑

        int Update(T entity, bool isSaveChange = true);

        int UpdateProperty(Expression<Func<T, bool>> filter, string filedName, object filedValue, bool isSaveChange = true);

        int UpdatePropertys(Expression<Func<T, bool>> filter, Dictionary<string,object> fileds, bool isSaveChange = true);

        #endregion

        #region 删除

        int Delete(bool isSaveChange = true, params object[] key);

        int Delete(T Entity, bool isSaveChange = true);

        int Delete(Expression<Func<T, bool>> filter, bool isSaveChange = true);

        #endregion

        #region 其它

        int ExcuteSqlCommand(string sql, object[] parameters);        

        bool IsExist(Expression<Func<T,bool>> filter);

        int Count(Expression<Func<T, bool>> filter);

        #endregion                
    }
}

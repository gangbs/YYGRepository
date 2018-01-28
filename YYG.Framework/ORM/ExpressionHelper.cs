using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.ORM
{
   public class ExpressionHelper
    {
        /// <summary>
        /// 将查询条件model转换成表达式树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Expression<Func<T,bool>> CreateExpression<T,K>(K model)
        {
            var allProperty = typeof(K).GetProperties();
            var lstValidProperty = new List<Tuple<int,PropertyInfo>>();

            //1.先去除掉忽略项
            foreach (var p in allProperty)
            {
                //如果有Ignore直接忽略
                if (p.GetCustomAttribute<IgnoreAttribute>() != null) continue;

                //如果model中对应的值为null，也直接忽略
                if (p.GetValue(model)==null) continue;

                var compare = p.GetCustomAttribute<CompareAttribute>();

                int order = compare!=null?compare.Order:0 ;
                
                lstValidProperty.Add(new Tuple<int, PropertyInfo>(order,p));
            }

            if(lstValidProperty.Count==0)
            {
                return null;
            }

            lstValidProperty = lstValidProperty.OrderBy(x => x.Item1).ToList();

            ParameterExpression parameter = Expression.Parameter(typeof(T));
            BinaryExpression query = null;
            for (int i=0;i<lstValidProperty.Count;i++)
            {
                var p = lstValidProperty[i].Item2;
                var val = p.GetValue(model);

                string fieldName = p.Name;
                CompareEnum compareType = CompareEnum.Eq;
                var compare = p.GetCustomAttribute<CompareAttribute>();
                if(compare!=null)
                {
                    fieldName = string.IsNullOrWhiteSpace(compare.ColumnName) ? p.Name : compare.ColumnName;
                    compareType = compare.compare;
                }

                ConstantExpression constant = Expression.Constant(val);
                MemberExpression member = Expression.PropertyOrField(parameter, fieldName);
                BinaryExpression bin;
                switch (compareType)
                {
                    case CompareEnum.Eq:
                        bin = Expression.Equal(member, constant);
                        break;
                    case CompareEnum.NotEq:
                        bin = Expression.NotEqual(member, constant);
                        break;
                    case CompareEnum.Gt:
                        bin = Expression.GreaterThan(member, constant);
                        break;
                    case CompareEnum.GtEq:
                        bin = Expression.GreaterThanOrEqual(member, constant);
                        break;
                    case CompareEnum.Lt:
                        bin = Expression.LessThan(member, constant);
                        break;
                    case CompareEnum.LtEq:
                        bin = Expression.LessThanOrEqual(member, constant);
                        break;
                    //case CompareEnum.Like:
                    //     Expression.Call(typeof(string).GetMethod(nameof(string.Contains)), constant);
                    default:
                        bin = Expression.Equal(member, constant);
                        break;
                }


                if(i==0)
                {
                    query = bin;
                }
                else
                {
                    query = Expression.And(query, bin);
                }              
            }
            return Expression.Lambda<Func<T, bool>>(query, parameter);
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.ExpTree
{
   public class QueryExpression
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

                var compare = p.GetCustomAttribute<QueryCompareAttribute>();

                int order = compare!=null?compare.Order:0 ;
                
                lstValidProperty.Add(new Tuple<int, PropertyInfo>(order,p));
            }

            if(lstValidProperty.Count==0)
            {
                return null;
            }

            lstValidProperty = lstValidProperty.OrderBy(x => x.Item1).ToList();

            ParameterExpression parameter = Expression.Parameter(typeof(T));
            Expression query = null;
            for (int i=0;i<lstValidProperty.Count;i++)
            {
                var p = lstValidProperty[i].Item2;
                var val = p.GetValue(model);

                string fieldName = p.Name;
                CompareEnum compareType = CompareEnum.Eq;
                var compare = p.GetCustomAttribute<QueryCompareAttribute>();
                if(compare!=null)
                {
                    fieldName = string.IsNullOrWhiteSpace(compare.FieldName) ? p.Name : compare.FieldName;
                    compareType = compare.compare;
                }

                ConstantExpression constant = Expression.Constant(val);
                MemberExpression member = Expression.PropertyOrField(parameter, fieldName);
                Expression exp;
                switch (compareType)
                {
                    case CompareEnum.Eq:
                        exp = Expression.Equal(member, constant);
                        break;
                    case CompareEnum.NotEq:
                        exp = Expression.NotEqual(member, constant);
                        break;
                    case CompareEnum.Gt:
                        exp = Expression.GreaterThan(member, constant);
                        break;
                    case CompareEnum.GtEq:
                        exp = Expression.GreaterThanOrEqual(member, constant);
                        break;
                    case CompareEnum.Lt:
                        exp = Expression.LessThan(member, constant);
                        break;
                    case CompareEnum.LtEq:
                        exp = Expression.LessThanOrEqual(member, constant);
                        break;
                    case CompareEnum.Like:
                        exp = Expression.Call(member, typeof(string).GetMethod(nameof(string.Contains)), constant);
                        break;
                    case CompareEnum.LeftLike:
                        exp = Expression.Call(member, typeof(string).GetMethod(nameof(string.StartsWith),new Type[] {typeof(string)}), constant);
                        break;
                    case CompareEnum.RightLike:
                        exp = Expression.Call(member, typeof(string).GetMethod(nameof(string.EndsWith)), constant);
                        break;
                    default:
                        exp = Expression.Equal(member, constant);
                        break;
                }


                if(i==0)
                {
                    query = exp;
                }
                else
                {
                    query = Expression.And(query, exp);
                }              
            }
            return Expression.Lambda<Func<T, bool>>(query, parameter);
        }
      
    }
}

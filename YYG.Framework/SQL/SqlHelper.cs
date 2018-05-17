using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.SQL
{
   public class SqlHelper
    {
        public static string MySqlPaging(int pageIndex,int pageSize,string filterSql)
        {
            string sql = $"select * from ({filterSql}) limit {(pageIndex-1)*pageSize},{pageSize}";//(Limit n,m)  =>从第n行开始取m条记录，n从0开始算。
            return sql;
        }

        public static string SqlServerPaging(int pageIndex, int pageSize, string filterSql)
        {
            string innerSql = $"select ROW_NUMBER() OVER (ORDER BY id ASC) RowNumber ,* from {filterSql} a where a.RowNumber>{(pageIndex - 1) * pageSize}";
            string sql = $"select top({pageSize}) from ({innerSql})";
            return sql;
        }

        public static string OraclePaging(int pageIndex, int pageSize, string filterSql)
        {
            string innerSql = $"select *,rownum rn from ({filterSql}) where rownum<={pageIndex*pageSize}";//rownum是从1开始的，row_number()函数也是如此
            string sql = $"select * from ({innerSql}) a where a.rn>{(pageIndex-1)*pageSize}";//rownum只能用< 或者<=
            return sql;
        }
    }
}

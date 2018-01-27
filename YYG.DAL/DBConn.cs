using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.DAL
{
   public class DBConn
    {
        public static DbConnection GetDbConnection(string providerName, string connStr)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);//该方法有什么条件，必须引用这个提供程序类吗？
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = connStr;
            return conn;
        }


        public static bool DBConnTest(string providerName, string connStr, out string errMsg)
        {
            bool flag;
            errMsg = "";
            DbConnection conn = GetDbConnection(providerName, connStr);
            int t = conn.ConnectionTimeout;
            try
            {
                conn.Open();
                flag = true;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    errMsg = e.InnerException.Message;
                }
                else
                {
                    errMsg = e.Message;
                }
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }


    }
}

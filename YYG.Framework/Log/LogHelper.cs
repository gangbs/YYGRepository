using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
    public class LogHelper
    {
        public static readonly ILog loginfo = LogManager.GetLogger("loginfo");

        public static readonly ILog logerror = LogManager.GetLogger("logerror");

        public static void WriteApiFullLog(string httpMethod, string className, string methodName, string requestJson, string responseJson, TimeSpan timeSpan)
        {
            loginfo.InfoFormat("【耗时】 : {0}毫秒<br>【Http方法】 : {1}<br>【控制器名称】 : {2}<br>【操作名称】 : {3}<br>【请求参数】 : {4}<br>【返回结果】 : {5}<br>", timeSpan.TotalMilliseconds, httpMethod, className, methodName, requestJson, responseJson);
        }

        public static void WriteApiRequestLog(string httpMethod, string className, string methodName, string requestJson, TimeSpan timeSpan)
        {
            loginfo.InfoFormat("【耗时】 : {0}毫秒<br>【Http方法】 : {1}<br>【控制器名称】 : {2}<br>【操作名称】 : {3}<br>【请求参数】 : {4}<br>", timeSpan.TotalMilliseconds, httpMethod, className, methodName, requestJson);
        }

        public static void WriteApiErrorLog(string className, string methodName, string requestJson, Exception ex)
        {
            logerror.InfoFormat("【控制器名称】 : {0}<br>【操作名称】 : {1}<br>【请求参数】 : {2}<br>【异常类型】：{3} <br>【异常信息】：{4} <br>【堆栈调用】：{5}", className, methodName, requestJson, ex.GetType().Name, ex.Message, ex.StackTrace);
        }

    }
}

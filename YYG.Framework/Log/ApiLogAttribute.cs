using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using YYG.Framework.Extension;

namespace YYG.Framework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ApiLogAttribute : ActionFilterAttribute
    {
        readonly bool logResponse;
        readonly Stopwatch watch;

        public ApiLogAttribute(bool logResponse = true)
        {
            this.logResponse = logResponse;
            watch = new Stopwatch();
        }


        /// <summary>
        /// 操作前
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuting(HttpActionContext actionExecutedContext)
        {
            this.watch.Start();
        }

        /// <summary>
        /// 操作后
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            this.watch.Stop();
            string httpMethod = actionExecutedContext.Request.Method.Method;
            string requestJson = actionExecutedContext.ActionContext.ActionArguments.ToJson();
            string className = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            string methodName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            if (logResponse)
            {
                string responseJson = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                LogHelper.WriteApiFullLog(httpMethod, className, methodName, requestJson, responseJson, this.watch.Elapsed);
            }
            else
            {
                LogHelper.WriteApiRequestLog(httpMethod, className, methodName, requestJson, this.watch.Elapsed);
            }
        }
    }
}

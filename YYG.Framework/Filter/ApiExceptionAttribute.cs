using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using YYG.Framework.Extension;
using YYG.Framework.Net;

namespace YYG.Framework.Filter
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var back = new HttpBackResult<string> { Status = (int)HttpBackCode.Parameter, Msg = actionExecutedContext.Exception.Message, Data = null };
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
            actionExecutedContext.Response.Content = new StringContent(back.ToJson());
        }
    }
}

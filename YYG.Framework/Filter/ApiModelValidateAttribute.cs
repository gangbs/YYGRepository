using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using YYG.Framework.Extension;
using YYG.Framework.Net;

namespace YYG.Framework.Filter
{
    public class ApiModelValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var back = new HttpBackResult<string> { Status = (int)HttpBackCode.Parameter, Msg = actionContext.ModelState.GetErrorMessage(), Data = null };
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
                actionContext.Response.Content = new StringContent(back.ToJson());
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}

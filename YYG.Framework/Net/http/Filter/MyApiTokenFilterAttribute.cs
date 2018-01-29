using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using YYG.Framework.Extension;

namespace YYG.Framework.Net
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MyApiTokenFilterAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool isValid = false;
            string token = HttpContext.Current.Request["token"];

            //验证token是否有效
            //isValid=fun(token);

            if (!isValid)
            {
                var back = new HttpBackResult<object> { Status = (int)HttpBackCode.UnAuthorized, Msg = "token验证未通过" };
                actionContext.Response.Content = new StringContent(back.ToJson());
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}

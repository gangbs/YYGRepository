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
        readonly bool canModelNull;

        public ApiModelValidateAttribute(bool canModelNull = false)
        {
            this.canModelNull = canModelNull;
        }


        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string modelName;
            if (!canModelNull && IsModelNull(actionContext.ActionArguments, out modelName))
            {
                var back = new HttpBackResult<string> { Status = (int)HttpBackCode.Parameter, Msg = $"参数\"{modelName}\"不可为空", Data = null };
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
                actionContext.Response.Content = new StringContent(back.ToJson());
                return;
            }

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

        /// <summary>
        /// 参数模型是否为null
        /// </summary>
        /// <param name="actionArguments"></param>
        /// <returns></returns>
        private bool IsModelNull(Dictionary<string, object> actionArguments,out string modelName)
        {
            modelName = "";
            bool flag = false;
            if (actionArguments != null)
            {
                foreach (var kv in actionArguments)
                {
                    if (kv.Value == null)
                    {
                        flag = true;
                        modelName = kv.Key;
                        break;
                    }
                }
            }
            return flag;
        }
    }
}

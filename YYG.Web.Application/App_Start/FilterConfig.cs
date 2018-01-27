using System.Web;
using System.Web.Mvc;

namespace YYG.Web.Application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        /// <summary>Invokes the specified action by using the specified controller context.</summary>
        /// <returns>The result of executing the action.</returns>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionName">The name of the action to invoke.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="controllerContext" /> parameter is null.</exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="actionName" /> parameter is null or empty.</exception>
        /// <exception cref="T:System.Threading.ThreadAbortException">The thread was aborted during invocation of the action.</exception>
        /// <exception cref="T:System.Exception">An unspecified error occurred during invocation of the action.</exception>
        //public virtual bool InvokeAction(ControllerContext controllerContext, string actionName)
        //{
        //    if (controllerContext == null)
        //    {
        //        throw new ArgumentNullException("controllerContext");
        //    }
        //    if (string.IsNullOrEmpty(actionName) && !controllerContext.RouteData.HasDirectRouteMatch())
        //    {
        //        throw new ArgumentException(MvcResources.Common_NullOrEmpty, "actionName");
        //    }
        //    ControllerDescriptor controllerDescriptor = this.GetControllerDescriptor(controllerContext);
        //    ActionDescriptor actionDescriptor = this.FindAction(controllerContext, controllerDescriptor, actionName);//根据Controller信息及Action名称获取Action的描述信息
        //    if (actionDescriptor != null)
        //    {
        //        FilterInfo filters = this.GetFilters(controllerContext, actionDescriptor);//获取所有过滤器
        //        try
        //        {
        //            AuthenticationContext authenticationContext = this.InvokeAuthenticationFilters(controllerContext, filters.AuthenticationFilters, actionDescriptor);//调用身份验证过滤器
        //            if (authenticationContext.Result != null)
        //            {
        //                AuthenticationChallengeContext authenticationChallengeContext = this.InvokeAuthenticationFiltersChallenge(controllerContext, filters.AuthenticationFilters, actionDescriptor, authenticationContext.Result);
        //                this.InvokeActionResult(controllerContext, authenticationChallengeContext.Result ?? authenticationContext.Result);
        //            }
        //            else
        //            {
        //                AuthorizationContext authorizationContext = this.InvokeAuthorizationFilters(controllerContext, filters.AuthorizationFilters, actionDescriptor);//调用授权过滤器
        //                if (authorizationContext.Result != null)
        //                {
        //                    AuthenticationChallengeContext authenticationChallengeContext2 = this.InvokeAuthenticationFiltersChallenge(controllerContext, filters.AuthenticationFilters, actionDescriptor, authorizationContext.Result);
        //                    this.InvokeActionResult(controllerContext, authenticationChallengeContext2.Result ?? authorizationContext.Result);
        //                }
        //                else
        //                {
        //                    if (controllerContext.Controller.ValidateRequest)//判断是否需要验证请求，使用ValidateInput特性并设置EnableValidation为False时跳过验证
        //                    {
        //                        ControllerActionInvoker.ValidateRequest(controllerContext);
        //                    }
        //                    IDictionary<string, object> parameterValues = this.GetParameterValues(controllerContext, actionDescriptor);
        //                    ActionExecutedContext actionExecutedContext = this.InvokeActionMethodWithFilters(controllerContext, filters.ActionFilters, actionDescriptor, parameterValues);//执行Action过滤器和Action方法
        //                    AuthenticationChallengeContext authenticationChallengeContext3 = this.InvokeAuthenticationFiltersChallenge(controllerContext, filters.AuthenticationFilters, actionDescriptor, actionExecutedContext.Result);
        //                    this.InvokeActionResultWithFilters(controllerContext, filters.ResultFilters, authenticationChallengeContext3.Result ?? actionExecutedContext.Result);//执行Result过滤器及Result
        //                }
        //            }
        //        }
        //        catch (ThreadAbortException)
        //        {
        //            throw;
        //        }
        //        catch (Exception exception)
        //        {
        //            ExceptionContext exceptionContext = this.InvokeExceptionFilters(controllerContext, filters.ExceptionFilters, exception);//当捕获异常时执行异常过滤器
        //            if (!exceptionContext.ExceptionHandled)//如果异常过滤器并没有对异常进行处理则继续抛出异常
        //            {
        //                throw;
        //            }
        //            this.InvokeActionResult(controllerContext, exceptionContext.Result);
        //        }
        //        return true;
        //    }
        //    return false;
        //}



    }
}

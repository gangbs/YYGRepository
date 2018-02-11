using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(YYG.Web.Auth.Startup))]

namespace YYG.Web.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //为Owin中间件添加一个授权服务器,授权服务器作用：Access Token的发放以及授权
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp=true,
                AuthorizeEndpointPath = new PathString("/oauth2/authorize"),//授权码获取地址
                //AuthorizationCodeProvider=生成授权code的提供器
                //AuthorizationCodeExpireTimeSpan=new TimeSpan()授权code的有效时间
                TokenEndpointPath=new PathString("/oauth2/token"),//accessToken获取地址
                // AccessTokenProvider=生成token的提供器
                 //AccessTokenExpireTimeSpan=token的有效时间
                // Provider=OAuth授权服务
                 
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {

            });
        }
    }
}

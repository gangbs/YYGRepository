using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using YYG.Framework.OAuth;

[assembly: OwinStartupAttribute(typeof(YYG.Web.Application.Startup))]
namespace YYG.Web.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);


            //为Owin中间件添加一个授权服务器,授权服务器作用：Access Token的发放以及授权
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,//?
                AuthorizeEndpointPath = new PathString("/oauth2/authorize"),//授权码获取地址
                AuthorizationCodeProvider=new MyAuthorizationCodeProvider(),//coke生成的提供器
                TokenEndpointPath = new PathString("/oauth2/token"),//accessToken获取地址
                 //AccessTokenProvider=// AccessTokenProvider=生成token的提供器
                 //AccessTokenExpireTimeSpan=//AccessTokenExpireTimeSpan=token的有效时间
                Provider =new MyOAuthAuthorizationServerProvider(), //OAuth授权服务                                                    
                                                                                       


            });

            //使用Access Token来访问受限制的资源
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {

            });
        }
    }
}

using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.OAuth2
{
   public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        #region 获取授权相关

        /// <summary>
        /// 1
        /// 验证请求授权参数中的client_id和redirect_uri,该方法的最后必须调用context.Validated方法，不调用的话后续方法无法执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            var client = OAuth2ClientRepository.Clients.Where(c => c.Id == context.ClientId).FirstOrDefault();
            if (client != null)
            {
                context.Validated(client.RedirectUrl);
            }
            return base.ValidateClientRedirectUri(context);
        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            context.Validated();
            return base.ValidateAuthorizeRequest(context);
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            return base.AuthorizeEndpoint(context);
            //这一步后去生成授权码，并作缓存
        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            return base.AuthorizationEndpointResponse(context);
        }



        #endregion


        #region 获取accesstoken相关

        /// <summary>
        /// 1
        /// 客户端用code换取token时的client_id和client_secret参数验证，该方法的最后必须调用context.Validated方法，不调用的话后续方法无法执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))//从http请求头中获取
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);//从post请求的body体中获取
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }
            if (!string.IsNullOrEmpty(clientSecret))
            {
                context.OwinContext.Set("clientSecret", clientSecret);
            }
            var client = OAuth2ClientRepository.Clients.Where(c => c.Id == clientId).FirstOrDefault();
            if (client != null)
            {
                context.Validated();
            }
            else
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return Task.FromResult<object>(null);
            }
            return Task.FromResult<object>(null);

            //这一步后会去AuthorizationCodeProvider(或者RefreshTokenProvider)中根据授权码(或者refreshtoken)获取用户信息，也就是对授权码有效性的验证(包含其时间的有效性)
        }

        /// <summary>
        /// 2 验证accesstoken请求的参数，此处可添加一些额外的参数验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            context.Validated();
            return base.ValidateTokenRequest(context);
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            //此处可增加额外的用户信息
            return base.GrantAuthorizationCode(context);
        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            return base.TokenEndpoint(context);
            //这一步后去生成accesstoken
        }

        /// <summary>
        /// 5
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            return base.TokenEndpointResponse(context);
        }

        #endregion


        #region 获取refreshtoken相关

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            context.Validated();
            return base.GrantRefreshToken(context);
        }

        #endregion
    }
}

using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.OAuth
{
   public class MyOAuthAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 实现授权服务器对Client的验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {


            return null;
        }

        /// <summary>
        /// 设置该Client的重定向Url
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using YYG.Framework.Extension;

namespace YYG.Framework.Net
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage CreateResponseMessage(string data)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(data);
            return response;
        }

        protected HttpResponseMessage CreateResponseMessage<T>(T data)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(data.ToJson());
            return response;
        }


        protected HttpResponseMessage CreateResponseMessage(HttpBackCode code, string data, string message = null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var back = new HttpBackResult<string> { Status = (int)code, Msg = message == null ? code.GetDescription() : message, Data = data };
            response.Content = new StringContent(back.ToJson());
            return response;
        }

        protected HttpResponseMessage CreateResponseMessage<T>(HttpBackCode code, T data, string message = null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var back = new HttpBackResult<T> { Status = (int)code, Msg = message == null ? code.GetDescription() : message, Data = data };
            response.Content = new StringContent(back.ToJson());
            return response;
        }

    }
}

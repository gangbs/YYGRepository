using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YYG.Framework.Net;

namespace YYG.Web.API.Controllers
{
    public class TestController : BaseApiController
    {

        [HttpGet]
        public HttpResponseMessage Get([FromUri]string name)
        {
            var res = new HttpResponseMessage(HttpStatusCode.Redirect);
            var url=$"http://{HttpContext.Current.Request.Url.Host}:{HttpContext.Current.Request.Url.Port}/api/GetInfo?age=32";
            //var url = $"http://{HttpContext.Current.Request.Url.Host}:{HttpContext.Current.Request.Url.Port}/b.html?name={name}";
            res.Headers.Location = new Uri(url);
            return res;
        }

        //[Route("api/GetInfo")]
        //[HttpGet]
        //public HttpResponseMessage GetInfo([FromUri]int age)
        //{

        //    return this.CreateResponseMessage(HttpBackCode.Success, new { Name = "yyg", Age = age });
        //}

        [Route("api/GetInfo")]
        [HttpGet]
        public HttpBackResult<string> GetInfo([FromUri]int age)
        {
            //return this.CreateResponseMessage(HttpBackCode.Success, new { Name = "yyg", Age = age });

            var back = new HttpBackResult<string> { Status=2, Data="yyg", Msg="成功" };
            return back;
        }


        //[Route("api/Delete")]
        [HttpDelete]
        public HttpBackResult<string> Delete(int id)
        {

            //return this.CreateResponseMessage(HttpBackCode.Success, new { Name = "yyg", Age = age });

            var back = new HttpBackResult<string> { Status = 2, Data = "yyg", Msg = "成功" };
            return back;
        }

        [Route("api/Put")]
        [HttpPut]
        public HttpBackResult<string> Put(int id)
        {

            //return this.CreateResponseMessage(HttpBackCode.Success, new { Name = "yyg", Age = age });

            var back = new HttpBackResult<string> { Status = 2, Data = "yyg", Msg = "成功" };
            return back;
        }


        [Route("api/Patch")]
        [HttpPatch]
        public HttpBackResult<string> Patch(int id)
        {

            //return this.CreateResponseMessage(HttpBackCode.Success, new { Name = "yyg", Age = age });

            var back = new HttpBackResult<string> { Status = 2, Data = "yyg", Msg = "成功" };
            return back;
        }
    }
}

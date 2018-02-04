using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YYG.Web.API.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody]int id)
        {
            var r = new HttpResponseMessage( HttpStatusCode.OK);
            return r;
        }
    }
}

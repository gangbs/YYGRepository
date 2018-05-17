using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YYG.Business;
using YYG.Core;
using YYG.Entity;
using YYG.Framework;
using YYG.Framework.Net;
using YYG.IRepository;
using YYG.Web.Application.Models;

namespace YYG.Web.Application.Controllers
{
    public class TestController : Controller
    {
        //readonly IPoliceRepository myRepository1;

        //public TestController(IPoliceRepository myRepository1)
        //{            
        //    this.myRepository1 = myRepository1;
        //}


        // GET: Test
        public ActionResult Index()
        {
            //var num = myRepository1.Get();11111

            //var bll = new VehicleBusiness();

            //bll.JoinSearch();
            //bll.Search();

            // var model = new VehicleQueryModel { BuyDate=DateTime.Now, EngineNo="111", FrameNo="ttt" };
            //var filter= YYG.Framework.ORM.ExpressionHelper.CreateExpression<VehicleInfoEntity, VehicleQueryModel>(model);
            // bll.Search(filter);


            //bll.Add();


            // bll.ManyTableDynamicCondition();
            CookieExtension.DeleteCookie("age");
            return View();
        }


        public ActionResult ApiTest()
        {
            string url = "http://localhost:13382/api/Test";
            var http = new HttpHelper();
            //var r= Task.Run(async () => await http.Post(url, "8")).Result;

            var r = Task.Run(async () => await http.Post<int>(url, 8)).Result;
            return null;
        }


        public ActionResult CheckCookie()
        {
            //string ads = "hangzhou";
            //ads.WriteCookie("ads");


            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }



            return this.Content("哈哈");
        }
    }
}
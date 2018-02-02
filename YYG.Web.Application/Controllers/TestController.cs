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

            var bll = new VehicleBusiness();

            //bll.JoinSearch();
            //bll.Search();

            // var model = new VehicleQueryModel { BuyDate=DateTime.Now, EngineNo="111", FrameNo="ttt" };
            //var filter= YYG.Framework.ORM.ExpressionHelper.CreateExpression<VehicleInfoEntity, VehicleQueryModel>(model);
            // bll.Search(filter);


            //bll.Add();


            bll.ManyTableDynamicCondition();
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
    }
}
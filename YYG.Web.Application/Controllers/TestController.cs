using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYG.Business;
using YYG.Core;
using YYG.Entity;
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

            var model = new VehicleQueryModel { BuyDate=DateTime.Now, EngineNo="111" };
           var filter= YYG.Framework.ORM.ExpressionHelper.CreateExpression<VehicleInfoEntity, VehicleQueryModel>(model);
            bll.Search(filter);


            //bll.Add();
            return View();
        }
    }
}
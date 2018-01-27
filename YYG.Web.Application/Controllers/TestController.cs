using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYG.Business;
using YYG.Core;
using YYG.IRepository;

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
            //var num = myRepository1.Get();
            var bll = new VehicleBusiness();

            bll.Search();

            //bll.Add();
            return View();
        }
    }
}
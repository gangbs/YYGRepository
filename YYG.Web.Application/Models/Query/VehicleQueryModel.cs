using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YYG.Framework.ORM;

namespace YYG.Web.Application.Models
{
    public class VehicleQueryModel
    {
        [Ignore]
        public int VehicleKind { get; set; }        

        public Int32 BrandID { get; set; }

        public string VehicleModel { get; set; }

      
        public int VehicleType { get; set; }

        public Int32 MainColor { get; set; }
       
        public Int32 SecondaryColor { get; set; }
        
        public String EngineNo { get; set; }

        public String FrameNo { get; set; }
        
        public double Weight { get; set; }
       
        public Int32 SpeedMax { get; set; }


        public decimal BuyPrice { get; set; }

        
        [Compare(CompareEnum.GtEq)]
        public DateTime BuyDate { get; set; }

    }
}
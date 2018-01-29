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

        [Ignore]
        public Int32 BrandID { get; set; }

        [Ignore]
        public string VehicleModel { get; set; }

        [Ignore]
        public int VehicleType { get; set; }

        [Ignore]
        public Int32 MainColor { get; set; }

        [QueryCompare(CompareEnum.LeftLike)]
        public String EngineNo { get; set; }

        [QueryCompare(CompareEnum.Like)]
        public String FrameNo { get; set; }
        
        [QueryCompare(CompareEnum.GtEq)]
        public DateTime BuyDate { get; set; }

    }
}
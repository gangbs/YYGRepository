using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.Framework.ExpTree;

namespace YYG.DTO
{
   public class VehicleQueryDto
    {
        [QueryCompare(CompareEnum.Like)]
        public string CarNo { get; set; }

        [QueryCompare(CompareEnum.Eq)]
        public int? BrandID { get; set; }

        [QueryCompare(CompareEnum.Eq)]
        public int? VehicleType { get; set; }

        [QueryCompare(CompareEnum.LeftLike)]
        public string EngineNo { get; set; }

        [QueryCompare(CompareEnum.RightLike)]
        public string FrameNo { get; set; }

        public string CarRFID { get; set; }

        [QueryCompare(CompareEnum.Eq)]
        public int? ValidFlag { get; set; }

        public string CardID { get; set; }

        [QueryCompare(CompareEnum.GtEq,FieldName ="BuyDate")]
        public DateTime? BuyDateBegin { get; set; }

        [QueryCompare(CompareEnum.LtEq, FieldName = "BuyDate")]
        public DateTime? BuyDateEnd { get; set; }
    }
}

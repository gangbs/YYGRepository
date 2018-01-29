using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.DTO
{
    public class VehicleInfoDto
    {
        public int ElectricID { get; set; }
        public int OwnerID { get; set; }
        public int CreateID { get; set; }
        public DateTime CreateTime { get; set; }
        public string AreaCode { get; set; }


        public int VehicleKind { get; set; }
        public int BrandID { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleType { get; set; }
        public int MainColor { get; set; }
        public int SecondaryColor { get; set; }
        public string EngineNo { get; set; }
        public string FrameNo { get; set; }
        public double Weight { get; set; }
        public int SpeedMax { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }


        public string CarNo { get; set; }
        public string CarRFID { get; set; }
        public string PowerRFID { get; set; }

    }
}

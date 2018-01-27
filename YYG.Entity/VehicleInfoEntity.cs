using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_vehicle_info")]
    public class VehicleInfoEntity: DataBaseEntity
    {

        /// <summary>
        ///  
        /// </summary>
        [Key]
        public Int32 ElectricInfoID { get; set; }

        /// <summary>
        ///  电动车注册ID
        /// </summary>
        public Int32 ElectricID { get; set; }

        /// <summary>
        /// 是否新车：1新车，2旧车
        /// </summary>
        public int VehicleKind { get; set; }

        /// <summary>
        ///  车辆品牌
        /// </summary>

        public Int32 BrandID { get; set; }

        /// <summary>
        ///  车辆型号
        /// </summary>
        [StringLength(20)]
        public string VehicleModel { get; set; }


        /// <summary>
        ///  车辆型号
        /// </summary>

        public int VehicleType { get; set; }


        /// <summary>
        ///  车辆类型
        /// </summary>
        public Int32 MainColor { get; set; }

        /// <summary>
        /// 车辆配色
        /// </summary>
        public Int32 SecondaryColor { get; set; }

        /// <summary>
        ///  电机号
        /// </summary>
        [StringLength(20)]
        public String EngineNo { get; set; }

        /// <summary>
        ///  车架号
        /// </summary>
        [StringLength(20)]
        public String FrameNo { get; set; }

        /// <summary>
        ///  重量
        /// </summary>

        public double Weight { get; set; }

        /// <summary>
        ///  最高速度
        /// </summary>

        public Int32 SpeedMax { get; set; }


        /// <summary>
        ///  购入价格
        /// </summary>

        public decimal BuyPrice { get; set; }

        /// <summary>
        ///  购买时间
        /// </summary>

        public DateTime BuyDate { get; set; }


        /// <summary>
        ///  是否报废(有效:1,报废:2)
        /// </summary>        
        public Int32 ValidFlag { get; set; }

        /// <summary>
        ///  操作人员
        /// </summary>

        public Int32 OperatorID { get; set; }

        /// <summary>
        ///  操作时间
        /// </summary>

        public DateTime OperatorTime { get; set; }


        [ForeignKey("ElectricID")]
        public virtual VehicleRegistEntity Regist { get; set; }
    }
}

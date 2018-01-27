using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_vehicle_transfer")]
   public class VehicleTransferEntity: DataBaseEntity
    {
        /// <summary>
        ///  过户ID
        /// </summary>
        [Key]
        public Int32 TransferID { get; set; }

        /// <summary>
        ///  电动车注册信息ID
        /// </summary>

        public Int32 ElectricID { get; set; }

        /// <summary>
        ///  原拥有者ID
        /// </summary>

        public Int32 OwerOriginID { get; set; }

        /// <summary>
        ///  现拥有者ID
        /// </summary>

        public Int32 OwerCurrID { get; set; }

        /// <summary>
        ///  过户原因
        /// </summary>
        [StringLength(200)]
        public String Reason { get; set; }

        /// <summary>
        ///  操作人员
        /// </summary>

        public Int32 OperatorID { get; set; }

        /// <summary>
        ///  操作时间
        /// </summary>

        public DateTime OperatorTime { get; set; }

        /// <summary>
        /// 过户登记点code
        /// </summary>
        [StringLength(20)]
        public string AreaCode { get; set; }



        [ForeignKey("ElectricID")]
        public virtual VehicleRegistEntity Regist { get; set; }

        [ForeignKey("OwerOriginID")]
        public virtual VehicleOwnerEntity OrignOwner { get; set; }

        [ForeignKey("OwerCurrID")]
        public virtual VehicleOwnerEntity CurrentOwner { get; set; }
    }
}

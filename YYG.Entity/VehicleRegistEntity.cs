using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_vehicle_regist")]
   public class VehicleRegistEntity: DataBaseEntity
    {
        /// <summary>
        ///  电动车注册ID
        /// </summary>
        [Key]
        public int ElectricID { get; set; }

        /// <summary>
        ///  车主ID
        /// </summary>

        public int OwnerID { get; set; }

        /// <summary>
        ///  有效标志(有效:1,无效:2)
        /// </summary>

        public int ValidFlag { get; set; }

        /// <summary>
        ///  创建人员
        /// </summary>

        public Int32 CreateID { get; set; }

        /// <summary>
        ///  创建时间
        /// </summary>

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 登记点code
        /// </summary>
        [StringLength(20)]
        public string AreaCode { get; set; }

        /// <summary>
        ///  操作人员
        /// </summary>

        public Int32 OperatorID { get; set; }

        /// <summary>
        ///  操作时间
        /// </summary>

        public DateTime OperatorTime { get; set; }

        /// <summary>
        /// 撤销原因
        /// </summary>
        [StringLength(200)]
        public string Reason { get; set; }

        [ForeignKey("OwnerID")]
        public virtual VehicleOwnerEntity Owner { get; set; }

        public virtual ICollection<VehicleInfoEntity> Info { get; set; }

        public virtual ICollection<VehicleLicenseEntity> License { get; set; }
    }
}

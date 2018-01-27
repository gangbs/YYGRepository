using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_vehicle_license")]
   public class VehicleLicenseEntity: DataBaseEntity
    {
        /// <summary>
        ///  关联ID
        /// </summary>
        [Key]
        public Int32 RelationID { get; set; }

        /// <summary>
        ///  电动车注册ID
        /// </summary>

        public Int32 ElectricID { get; set; }

        /// <summary>
        ///  车牌号码
        /// </summary>
        [StringLength(20)]
        public String CarNo { get; set; }

        /// <summary>
        ///  电动车标签
        /// </summary>
        [StringLength(20)]
        public String CarRFID { get; set; }

        /// <summary>
        ///  电源标签
        /// </summary>
        [StringLength(20)]
        public String PowerRFID { get; set; }

        /// <summary>
        /// 副标签1
        /// </summary>
        [StringLength(20)]
        public string ViceRFID1 { get; set; }

        /// <summary>
        /// 副标签2
        /// </summary>
        [StringLength(20)]
        public string ViceRFID2 { get; set; }

        /// <summary>
        /// 副标签3
        /// </summary>
        [StringLength(20)]
        public string ViceRFID3 { get; set; }

        /// <summary>
        /// 副标签4
        /// </summary>
        [StringLength(20)]
        public string ViceRFID4 { get; set; }

        /// <summary>
        /// 副标签5
        /// </summary>
        [StringLength(20)]
        public string ViceRFID5 { get; set; }

        /// <summary>
        /// 副标签6
        /// </summary>
        [StringLength(20)]
        public string ViceRFID6 { get; set; }


        /// <summary>
        ///  有效标志(有效：1,  无效：2)
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

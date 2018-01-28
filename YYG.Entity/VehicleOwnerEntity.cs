using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_vehicle_owner")]
   public class VehicleOwnerEntity: DataBaseEntity
    {
        /// <summary>
        ///  车主ID
        /// </summary>
        [Key]
        public Int32 OwnerID { get; set; }

        /// <summary>
        ///  车主姓名
        /// </summary>
        [StringLength(20)]
        public String OwnerName { get; set; }

        /// <summary>
        ///  证件类型(身份证:1)
        /// </summary>

        public Int32 CardType { get; set; }

        /// <summary>
        ///  身份证
        /// </summary>
        [StringLength(20)]
        public string CardID { get; set; }

        /// <summary>
        ///  现居住地
        /// </summary>
        [StringLength(200)]
        public String Address { get; set; }

        /// <summary>
        ///  联系电话
        /// </summary>
        [StringLength(20)]
        public String Phone { get; set; }

        /// <summary>
        ///  备用电话
        /// </summary>
        [StringLength(20)]
        public String SecondPhone { get; set; }


        /// <summary>
        ///  操作人员
        /// </summary>

        public Int32 OperatorID { get; set; }

        /// <summary>
        ///  操作时间
        /// </summary>

        public DateTime OperatorTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }

        public virtual ICollection<VehicleRegistEntity> Regist { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_police_info")]
   public class PoliceEnity: DataBaseEntity
    {         
        [Key]
        public int PoliceID { get; set; }

        public int AccountID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }
        
        public int UserRole { get; set; }

        [StringLength(20)]
        public string CardID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string AreaCode { get; set; }

        [StringLength(20)]
        public string PoliceCode { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(200)]
        public string HomePlace { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string Remark { get; set; }
        
        public int ValidFlag { get; set; }
        
        public int OperatorID { get; set; }
        
        public DateTime OperateTime { get; set; }
        
        public int CreatorID { get; set; }
      
        public DateTime CreateTime { get; set; }
    }
}

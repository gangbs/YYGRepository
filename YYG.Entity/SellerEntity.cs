using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_seller")]
    public class SellerEntity: DataBaseEntity
    {              
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellerID { get; set; }
       
        public int AccountID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }
        
        public int UserRole { get; set; }

        [StringLength(20)]
        public string ShopName { get; set; }


        [StringLength(20)]
        public string ShopAddress { get; set; }


        [StringLength(20)]
        public string BusinessNo { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }


        [StringLength(20)]
        public string LNG { get; set; }


        [StringLength(20)]
        public string LAT { get; set; }


        [StringLength(20)]
        public string OwerName { get; set; }


        [StringLength(20)]
        public string SellerCardID { get; set; }


        [StringLength(200)]
        public string Remark { get; set; }        

        public int OperatorID { get; set; }        

        public DateTime OperatorTime { get; set; }

        [StringLength(20)]
        public string AreaCode { get; set; }
        
        public int ValidFlag { get; set; }
       
        public int CreatorID { get; set; }
        
        public DateTime CreateTime { get; set; }


        public virtual ICollection<SellerBrandEntity> SellerBrands { get; set; }
    }
}

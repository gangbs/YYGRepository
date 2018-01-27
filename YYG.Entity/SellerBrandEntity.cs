using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Entity
{
    [Table("t_seller_brand")]
   public class SellerBrandEntity: DataBaseEntity
    {        
        [Key]
        public int RelationID { get; set; }       
        public int SellerID { get; set; }        
        public int BrandID { get; set; }

        [ForeignKey("SellerID")]
        public virtual SellerEntity Seller { get; set; }        
    }
}

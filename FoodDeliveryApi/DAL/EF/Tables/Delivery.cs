using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Delivery
    {
        [Key]
        [ForeignKey("Order")]
        public int DeliveryId { get; set; }  

        [ForeignKey("DeliveryBoy")]
        public int DeliveryBoyId { get; set; }


        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Status { get; set; } 


        public virtual Order Order { get; set; }


        public virtual User DeliveryBoy { get; set; }
    }
}

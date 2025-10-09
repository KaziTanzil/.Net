using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
       

        [Column(TypeName = "decimal")]
        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Status { get; set; } 

        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }




        public virtual Payment Payment { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

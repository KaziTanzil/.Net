using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }



        [ForeignKey("FoodItem")]
        public int FoodId { get; set; }
        


        public virtual Order Order { get; set; }
        public virtual FoodItem FoodItem { get; set; }
    }
}

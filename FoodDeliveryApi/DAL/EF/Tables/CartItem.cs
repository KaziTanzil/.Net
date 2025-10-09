using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }


        [Column(TypeName ="int")]
        public int Quantity { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        

        [ForeignKey("FoodItem")]
        public int FoodId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual FoodItem FoodItem { get; set; }

        
    }
}

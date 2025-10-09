using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class FoodItem
    {
        [Key]
        public int FoodId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
       

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Contact { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<FoodItem> FoodItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

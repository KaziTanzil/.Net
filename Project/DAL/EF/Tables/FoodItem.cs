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
            public int FoodItemId { get; set; }

            [Required, MaxLength(100)]
            [Column(TypeName = "varchar")]
            public string Name { get; set; }

            [Required]
            public double Price { get; set; }

            [Required, MaxLength(50)]
            [Column(TypeName = "varchar")]
            public string Category { get; set; }
             
            
            
        }
    }


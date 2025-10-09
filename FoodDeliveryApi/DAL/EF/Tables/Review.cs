using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        
        

        public int Rating { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
   
        

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }


    }
}

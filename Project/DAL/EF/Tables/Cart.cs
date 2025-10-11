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

        public int CartId { get; set; }

        public int Quantity { get; set; }



        public decimal TotalPrice { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("FoodItem")]
        public int FoodItemId { get; set; }
        public virtual FoodItem FoodItem { get; set; }



    }
}

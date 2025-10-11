using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("FoodItem")]
        public int FoodItemId { get; set; }
        public virtual FoodItem FoodItem { get; set; }

        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}

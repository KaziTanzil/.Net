using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}

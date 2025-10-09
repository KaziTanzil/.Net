using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

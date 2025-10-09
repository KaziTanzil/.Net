using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        // For nested details
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}

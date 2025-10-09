using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DeliveryDTO
    {
        public int DeliveryId { get; set; }
        public int DeliveryBoyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } 
    }
}

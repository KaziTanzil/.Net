using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}

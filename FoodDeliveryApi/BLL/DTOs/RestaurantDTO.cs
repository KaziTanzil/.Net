using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Contact { get; set; }
        public double Rating { get; set; }
    }
}

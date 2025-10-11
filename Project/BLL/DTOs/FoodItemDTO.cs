using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FoodItemDTO
    {
        public int FoodItemId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }


        [Required, MaxLength(50)]
        public string Category { get; set; }


    }
}

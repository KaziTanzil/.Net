using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}

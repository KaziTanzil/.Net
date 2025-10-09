using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReviewRepo : IRepo<Review, int>
    {
        List<Review> GetByRestaurant(int restaurantId);
        List<Review> GetByUser(int userId);
        double GetAverageRating(int restaurantId);
    }
}

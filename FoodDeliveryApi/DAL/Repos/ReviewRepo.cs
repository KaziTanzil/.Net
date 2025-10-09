using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class ReviewRepo : Repo<Review, int>, IReviewRepo
    {
        public List<Review> GetByRestaurant(int restaurantId)
        {
            var query = from r in db.Reviews
                        where r.RestaurantId == restaurantId
                        select r;
            return query.ToList();
        }

        public List<Review> GetByUser(int userId)
        {
            var query = from r in db.Reviews
                        where r.UserId == userId
                        select r;
            return query.ToList();
        }

        public double GetAverageRating(int restaurantId)
        {
            var query = from r in db.Reviews
                        where r.RestaurantId == restaurantId
                        select r.Rating;

            return query.Any() ? query.Average() : 0;
        }
    }
}

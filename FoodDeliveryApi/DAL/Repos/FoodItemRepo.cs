using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class FoodItemRepo : Repo<FoodItem, int>, IFoodItemRepo
    {
        public List<FoodItem> GetByRestaurant(int restaurantId)
        {
            var query = from f in db.FoodItems
                        where f.RestaurantId == restaurantId
                        select f;
            return query.ToList();
        }

        public List<FoodItem> GetByCategory(int categoryId)
        {
            var query = from f in db.FoodItems
                        where f.CategoryId == categoryId
                        select f;
            return query.ToList();
        }

        public List<FoodItem> Search(string keyword)
        {
            var query = from f in db.FoodItems
                        where f.Name.ToLower().Contains(keyword.ToLower())
                              || f.Description.ToLower().Contains(keyword.ToLower())
                        select f;
            return query.ToList();
        }
    }
}

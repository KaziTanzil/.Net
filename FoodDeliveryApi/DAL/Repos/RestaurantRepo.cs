using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class RestaurantRepo : Repo<Restaurant, int>, IRestaurantRepo
    {
        public List<Restaurant> GetByCategory(int categoryId)
        {
            var query = from f in db.FoodItems
                        where f.CategoryId == categoryId
                        select f.Restaurant;

            return query.Distinct().ToList();
        }

        public List<Restaurant> SearchByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.ToLower().Contains(name.ToLower())
                        select r;

            return query.ToList();
        }
    }
}

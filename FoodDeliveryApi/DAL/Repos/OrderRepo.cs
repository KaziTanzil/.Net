using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class OrderRepo : Repo<Order, int>, IOrderRepo
    {
        public List<Order> GetByUser(int userId)
        {
            var query = from o in db.Orders
                        where o.UserId == userId
                        select o;
            return query.ToList();
        }

        public List<Order> GetByRestaurant(int restaurantId)
        {
            var query = from od in db.OrderDetails
                        where od.FoodItem.RestaurantId == restaurantId
                        select od.Order;
            return query.Distinct().ToList();
        }
    }
}

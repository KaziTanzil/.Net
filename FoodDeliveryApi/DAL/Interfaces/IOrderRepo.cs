using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepo : IRepo<Order, int>
    {
        List<Order> GetByUser(int userId);
        List<Order> GetByRestaurant(int restaurantId);
    }
}

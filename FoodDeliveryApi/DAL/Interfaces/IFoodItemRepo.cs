using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFoodItemRepo : IRepo<FoodItem, int>
    {
        List<FoodItem> GetByRestaurant(int restaurantId);
        List<FoodItem> GetByCategory(int categoryId);
        List<FoodItem> Search(string keyword);
    }
}

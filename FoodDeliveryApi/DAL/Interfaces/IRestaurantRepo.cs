using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRestaurantRepo : IRepo<Restaurant, int>
    {
        List<Restaurant> GetByCategory(int categoryId);
        List<Restaurant> SearchByName(string name);
    }
}

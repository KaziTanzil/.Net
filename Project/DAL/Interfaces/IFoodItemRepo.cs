using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFoodItemRepo
    {
        bool Create(FoodItem f);
        bool Update(FoodItem f);
        bool Delete(int id);
        List<FoodItem> Get();
        FoodItem Get(int id);

        List<FoodItem> GetByCategory(string category);
        List<FoodItem> SearchByName(string name);
    }
}
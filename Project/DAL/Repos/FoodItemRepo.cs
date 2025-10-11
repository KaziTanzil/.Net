using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    internal class FoodItemRepo : GenericRepo<FoodItem, int>
    {
        public bool Update(FoodItem obj)
        {
            var existing = (from f in db.FoodItems
                            where f.FoodItemId == obj.FoodItemId
                            select f).SingleOrDefault();

            if (existing == null) return false;

            if (!string.IsNullOrEmpty(obj.Name))
                existing.Name = obj.Name;

            if (obj.Price != 0)
                existing.Price = obj.Price;

            if (!string.IsNullOrEmpty(obj.Category))
                existing.Category = obj.Category;

            db.Entry(existing).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}

using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FoodItemRepo : Repo, IRepo<FoodItem, int, bool>
    {
        public bool Create(FoodItem obj)
        {
            db.FoodItems.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var item = (from f in db.FoodItems
                        where f.FoodItemId == id
                        select f).SingleOrDefault();
            if (item != null)
            {
                db.FoodItems.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<FoodItem> Get()
        {
            return (from f in db.FoodItems
                    select f).ToList();
        }

        public FoodItem Get(int id)
        {
            return (from f in db.FoodItems
                    where f.FoodItemId == id
                    select f).SingleOrDefault();
        }

        public bool Update(FoodItem obj)
        {
            var existing = Get(obj.FoodItemId);
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

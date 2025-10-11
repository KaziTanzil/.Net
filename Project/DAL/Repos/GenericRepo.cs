using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    public class GenericRepo<CLASS, ID> : Repo, IRepo<CLASS, ID, bool> where CLASS : class
    {
        public bool Create(CLASS obj)
        {
            db.Set<CLASS>().Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(ID id)
        {
            var entity = db.Set<CLASS>().Find(id);
            if (entity != null)
            {
                db.Set<CLASS>().Remove(entity);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CLASS> Get()
        {
            var data = (from e in db.Set<CLASS>()
                        select e).ToList();
            return data;
        }

        public CLASS Get(ID id)
        {
            var entity = db.Set<CLASS>().Find(id);
            return entity;
        }

        public bool Update(CLASS obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}

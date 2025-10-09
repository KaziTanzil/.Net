using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class Repo<CLASS, ID> : IRepo<CLASS, ID> where CLASS : class
    {
        internal UMSContext db;

        public Repo()
        {
            db = new UMSContext();
        }

        public void Create(CLASS obj)
        {
            db.Set<CLASS>().Add(obj);
            db.SaveChanges();
        }

        public void Delete(ID id)
        {
            var obj = db.Set<CLASS>().Find(id);
            if (obj != null)
            {
                db.Set<CLASS>().Remove(obj);
                db.SaveChanges();
            }
        }

        public List<CLASS> Get()
        {
            return db.Set<CLASS>().ToList();
        }

        public CLASS Get(ID id)
        {
            return db.Set<CLASS>().Find(id);
        }

        public void Update(CLASS obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}

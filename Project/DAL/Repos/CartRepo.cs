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
    internal class CartRepo : Repo, IRepo<Cart, int, bool>
    {
        public bool Create(Cart obj)
        {
            db.Carts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var cart = (from c in db.Carts
                        where c.CartId == id
                        select c).SingleOrDefault();
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Cart> Get()
        {
            return (from c in db.Carts
                    select c).ToList();
        }

        public Cart Get(int id)
        {
            return (from c in db.Carts
                    where c.CartId == id
                    select c).SingleOrDefault();
        }

        public bool Update(Cart obj)
        {
            var ex = Get(obj.CartId);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

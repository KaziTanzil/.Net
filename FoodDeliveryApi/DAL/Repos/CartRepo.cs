using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class CartRepo : Repo<Cart, int>
    {
        public Cart GetByUserId(int userId)
        {
            var query = from c in db.Carts
                        where c.UserId == userId
                        select c;
            return query.SingleOrDefault();
        }

        public List<Cart> GetAllByUserId(int userId)
        {
            var query = from c in db.Carts
                        where c.UserId == userId
                        select c;
            return query.ToList();
        }
    }
}


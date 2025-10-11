using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    internal class CartRepo : GenericRepo<Cart, int>
    {
        public bool Update(Cart obj)
        {
            var existing = (from c in db.Carts
                            where c.CartId == obj.CartId
                            select c).SingleOrDefault();

            if (existing == null) return false;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return true;
        }
    }
}

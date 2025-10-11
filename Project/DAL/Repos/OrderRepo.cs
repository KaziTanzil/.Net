using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    internal class OrderRepo : GenericRepo<Order, int>
    {
        public bool Update(Order obj)
        {
            var existing = (from o in db.Orders
                            where o.OrderId == obj.OrderId
                            select o).SingleOrDefault();

            if (existing == null) 
                return false;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return true;
        }
    }
}

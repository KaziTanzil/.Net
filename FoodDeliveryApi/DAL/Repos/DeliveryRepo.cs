using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class DeliveryRepo : Repo<Delivery, int>
    {
        public Delivery GetByOrderId(int orderId)
        {
            var query = from d in db.Deliveries
                        where d.DeliveryId == orderId
                        select d;
            return query.SingleOrDefault();
        }

        public List<Delivery> GetByStatus(string status)
        {
            var query = from d in db.Deliveries
                        where d.Status == status
                        select d;
            return query.ToList();
        }
    }
}

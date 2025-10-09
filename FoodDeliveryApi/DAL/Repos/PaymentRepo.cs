using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class PaymentRepo : Repo<Payment, int>
    {
        public Payment GetByOrderId(int orderId)
        {
            var query = from p in db.Payments
                        where p.PaymentId == orderId
                        select p;
            return query.SingleOrDefault();
        }

        public List<Payment> GetByStatus(string status)
        {
            var query = from p in db.Payments
                        where p.Status == status
                        select p;
            return query.ToList();
        }
    }
}

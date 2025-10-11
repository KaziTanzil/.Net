using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    internal class PaymentRepo : GenericRepo<Payment, int>
    {
        public bool Update(Payment obj)
        {
            var existing = (from p in db.Payments
                            where p.PaymentId == obj.PaymentId
                            select p).SingleOrDefault();

            if (existing == null) return false;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return true;
        }
    }
}

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
    internal class PaymentRepo : Repo, IRepo<Payment, int, bool>
    {
        public bool Create(Payment obj)
        {
            db.Payments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var pay = (from p in db.Payments
                       where p.PaymentId == id
                       select p).SingleOrDefault();
            if (pay != null)
            {
                db.Payments.Remove(pay);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Payment> Get()
        {
            return (from p in db.Payments
                    select p).ToList();
        }

        public Payment Get(int id)
        {
            return (from p in db.Payments
                    where p.PaymentId == id
                    select p).SingleOrDefault();
        }

        public bool Update(Payment obj)
        {
            var ex = Get(obj.PaymentId);
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

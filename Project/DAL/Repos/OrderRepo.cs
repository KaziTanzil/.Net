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
    internal class OrderRepo : Repo, IRepo<Order, int, bool>
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var order = (from o in db.Orders
                         where o.OrderId == id
                         select o).SingleOrDefault();
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Order> Get()
        {
            return (from o in db.Orders
                    select o).ToList();
        }

        public Order Get(int id)
        {
            return (from o in db.Orders
                    where o.OrderId == id
                    select o).SingleOrDefault();
        }

        public bool Update(Order obj)
        {
            var ex = Get(obj.OrderId);
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

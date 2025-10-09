using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class OrderDetailRepo : Repo<OrderDetail, int>
    {
        public List<OrderDetail> GetByOrderId(int orderId)
        {
            var query = from od in db.OrderDetails
                        where od.OrderId == orderId
                        select od;
            return query.ToList();
        }
    }
}

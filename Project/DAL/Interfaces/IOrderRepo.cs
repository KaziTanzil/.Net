using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepo
    {
        bool Create(Order o);
        bool Update(Order o);
        bool Delete(int id);
        List<Order> Get();
        Order Get(int id);

        List<Order> GetByUser(int userId);
        List<Order> GetByStatus(string status);
    }
}
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPaymentRepo
    {
        bool Create(Payment p);
        bool Update(Payment p);
        bool Delete(int id);
        List<Payment> Get();
        Payment Get(int id);

        
        List<Payment> GetByUser(int userId);
        List<Payment> GetByStatus(string status);
    }
}
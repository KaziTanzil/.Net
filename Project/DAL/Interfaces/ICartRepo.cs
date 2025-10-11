using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICartRepo
    {
        bool Create(Cart c);
        bool Update(Cart c);
        bool Delete(int id);
        List<Cart> Get();
        Cart Get(int id);

        // Extra functionality: Get cart items for a user
        List<Cart> GetByUser(int userId);
    }
}


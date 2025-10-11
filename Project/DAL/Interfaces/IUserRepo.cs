using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo
    {
        bool Create(User u);
        bool Update(User u);
        bool Delete(int id);
        List<User> Get();
        User Get(int id);
    }
}
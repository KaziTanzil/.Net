using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo : IRepo<User, int>
    {
        User GetByEmail(string email);
        bool ValidateUser(string email, string password);

        List<User> GetByRole(string role);
    }
}

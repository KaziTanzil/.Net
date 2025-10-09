using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthRepo
    {
        User GetByEmail(string email);           
        void Register(User user);                
        bool EmailExists(string email);          
    }
}

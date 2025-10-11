using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    namespace DAL.Interfaces
    {
        public interface IAuth
        {
            User Authenticate(string email, string password);
        }
    }
}

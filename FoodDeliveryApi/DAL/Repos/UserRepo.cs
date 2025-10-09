using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class UserRepo : Repo<User, int>, IUserRepo
    {
        public User GetByEmail(string email)
        {
            var E = from u in db.Users
                        where u.Email == email
                        select u;
            return E.FirstOrDefault();
        }

        public bool ValidateUser(string email, string password)
        {
            var user = from u in db.Users
                        where u.Email == email && u.PasswordHash == password
                        select u;
            return user.Any();
        }

        public List<User> GetByRole(string role)
        {
            var users = (from u in db.Users
                         where u.Role == role
                         select u).ToList();
            return users;
        }

    }
}

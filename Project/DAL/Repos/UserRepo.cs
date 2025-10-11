using DAL.EF.Tables;
using DAL.Interfaces.DAL.Interfaces;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : GenericRepo<User, int>, IAuth
    {
        public User Authenticate(string email, string pass)
        {
            var user = (from u in db.Users
                        where u.Email==email && u.PasswordHash==pass
                        select u).SingleOrDefault();
            return user;
        }

        public bool Update(User obj)
        {
            var existingUser = (from u in db.Users
                                where u.UserId == obj.UserId
                                select u).SingleOrDefault();

            if (existingUser == null) 
                return false;

            if (!string.IsNullOrEmpty(obj.Name))
                existingUser.Name = obj.Name;

            if (!string.IsNullOrEmpty(obj.Email))
                existingUser.Email = obj.Email;

            if (!string.IsNullOrEmpty(obj.Role))
                existingUser.Role = obj.Role;

            if (!string.IsNullOrEmpty(obj.PasswordHash))
                existingUser.PasswordHash = obj.PasswordHash;

            db.Entry(existingUser).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return true;
        }
    }
}

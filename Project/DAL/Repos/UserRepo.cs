using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Interfaces.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = (from u in db.Users
                        where u.UserId == id
                        select u).SingleOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> Get()
        {
            return (from u in db.Users
                    select u).ToList();
        }

        public User Get(int id)
        {
            return (from u in db.Users
                    where u.UserId == id
                    select u).SingleOrDefault();
        }

        public bool Update(User obj)
        {
            var existingUser = Get(obj.UserId);
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

            db.Entry(existingUser).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public User Authenticate(string email, string pass)
        {
            var user = (from u in db.Users
                        where u.Email.Equals(email) && u.PasswordHash.Equals(pass)
                        select u).SingleOrDefault();
            return user;
        }
    }
}

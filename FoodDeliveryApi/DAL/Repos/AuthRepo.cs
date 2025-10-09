using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AuthRepo : IAuthRepo
    {
        private UMSContext db;
        public AuthRepo()
        {
            db = new UMSContext();
        }

        public User GetByEmail(string email)
        {
          
            var user = (from u in db.Users
                        where u.Email == email
                        select u).SingleOrDefault();
            return user;
        }

        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            
            var exists = (from u in db.Users
                          where u.Email == email
                          select u).Any();
            return exists;
        }
    }
}

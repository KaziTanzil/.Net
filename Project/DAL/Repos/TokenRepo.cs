using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var token = (from t in db.Tokens
                         where t.Key == id
                         select t).SingleOrDefault();

            if (token != null)
            {
                db.Tokens.Remove(token);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Token> Get()
        {
            return (from t in db.Tokens
                    select t).ToList();
        }

        public Token Get(string id)
        {
            return (from t in db.Tokens
                    where t.Key == id
                    select t).SingleOrDefault();
        }

        public Token Update(Token obj)
        {
            var token = (from t in db.Tokens
                         where t.Key == obj.Key
                         select t).SingleOrDefault();

            if (token != null)
            {
                token.ExpiredAt = obj.ExpiredAt;
                db.SaveChanges();
                return token;
            }
            return null;
        }
    }
}

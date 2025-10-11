using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                         where t.Key.Equals(id)
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
            var data = (from t in db.Tokens
                        select t).ToList();
            return data;
        }

        public Token Get(string id)
        {
            var token = (from t in db.Tokens
                         where t.Key.Equals(id)
                         select t).SingleOrDefault();
            return token;
        }

        public Token Update(Token obj)
        {
            var token = (from t in db.Tokens
                         where t.Key.Equals(obj.Key)
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

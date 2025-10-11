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
        public Token Get(string id)
        {
            return (from t in db.Tokens
                    where t.Key == id
                    select t).SingleOrDefault();
        }




        public bool Delete(string q)
        {
            return false;
        }

        public List<Token> Get()
        {
            return null;
        }


        public Token Update(Token obj)
        {
         
            return null;
        }
    }
}

using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Token, TokenDTO>();
            });
            return new Mapper(config);
        }

        public static TokenDTO Authenticate(string email, string pass)
        {
            var user = DataAccessFactory.AuthData().Authenticate(email, pass);
            if (user != null)
            {
                var token = new Token()
                {
                    Key = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    ExpiredAt = null,
                    UserId = user.UserId
                };
                var tk = DataAccessFactory.TokenData().Create(token);
                return GetMapper().Map<TokenDTO>(tk);
            }
            return null;
        }

        public static bool IsTokenValid(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            return tok != null && tok.ExpiredAt == null;
        }

        public static bool IsAdmin(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            return tok != null && tok.ExpiredAt == null && tok.User.Role.Equals("Admin");
        }

        public static bool IsCustomer(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            return tok != null && tok.ExpiredAt == null && tok.User.Role.Equals("Customer");
        }

        public static bool IsDeliveryBoy(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            return tok != null && tok.ExpiredAt == null && tok.User.Role.Equals("DeliveryBoy");
        }

        public static bool Logout(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            if (tok != null)
            {
                tok.ExpiredAt = DateTime.Now;
                DataAccessFactory.TokenData().Update(tok);
                return true;
            }
            return false;
        }

        public static bool IsInRole(string token, string[] roles)
        {
            var tok = DataAccessFactory.TokenData().Get(token); 
            if (tok == null) return false;

            return roles.Contains(tok.User.Role);
        }

        public static int GetUserIdFromToken(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            if (tok != null && tok.ExpiredAt == null)
            {
                return tok.UserId; 
            }
            return -1; 
        }

    }
}

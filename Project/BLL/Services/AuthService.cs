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
                cfg.CreateMap<Token, TokenDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static TokenDTO Authenticate(string email, string pass)
        {
            var user = DataAccessFactory.AuthData().Authenticate(email, pass);
            if (user != null)
            {
                var token = new TokenDTO()
                {
                    Key = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    ExpiredAt = null,
                    UserId = user.UserId
                };
                var t = GetMapper().Map<Token>(token);
                var tk = DataAccessFactory.TokenData().Create(t);
                return GetMapper().Map<TokenDTO>(tk);
            }
            return null;
        }

        public static bool IsTokenValid(string tk)
        {
            
            var token = DataAccessFactory.TokenData().Get(tk);
            var a= token != null && token.ExpiredAt == null;
            return a;
        }

        public static bool IsAdmin(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            var a= tok != null && tok.ExpiredAt == null && tok.User.Role.Equals("Admin");
            return a;
        }

        public static bool IsCustomer(string tk)
        {
            var t = DataAccessFactory.TokenData().Get(tk);
           var a= t != null && t.ExpiredAt == null && t.User.Role.Equals("Customer");
            return a;
        }

        public static bool IsDeliveryBoy(string tk)
        {
            var tok = DataAccessFactory.TokenData().Get(tk);
            var a= tok != null && tok.ExpiredAt == null && tok.User.Role.Equals("DeliveryBoy");
            return a;
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

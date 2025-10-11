using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PaymentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<PaymentDTO> Get(string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            var data = DataAccessFactory.PaymentData().Get();

            if (AuthService.IsAdmin(token))
            {
                return GetMapper().Map<List<PaymentDTO>>(data);
            }

            if (AuthService.IsCustomer(token))
            {
                var myPayments = data
                    .Where(p => p.Order != null && p.Order.User.Email == tok.User.Email) 
                    .ToList();

                return GetMapper().Map<List<PaymentDTO>>(myPayments);
            }

            return null;
        }

        public static bool Create(PaymentDTO p, string token)
        {
            if (AuthService.IsCustomer(token))
            {
                var order = DataAccessFactory.OrderData().Get(p.OrderId);

               
                if (order == null || order.User.Email != DataAccessFactory.TokenData().Get(token).User.Email)
                    return false;

                var pay = GetMapper().Map<Payment>(p);
                return DataAccessFactory.PaymentData().Create(pay);
            }
            return false;
        }
    }
}

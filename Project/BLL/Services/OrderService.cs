using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OrderService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<OrderDTO> Get(string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            var orders = DataAccessFactory.OrderData().Get();

            if (AuthService.IsAdmin(token))
                return GetMapper().Map<List<OrderDTO>>(orders);

            if (AuthService.IsCustomer(token))
                return GetMapper().Map<List<OrderDTO>>(orders.Where(o => o.UserId == tok.User.UserId).ToList());

            return null;
        }

        public static bool Create(OrderDTO o, string token)
        {
            if (!AuthService.IsCustomer(token)) return false;

            var order = GetMapper().Map<Order>(o);
            return DataAccessFactory.OrderData().Create(order);
        }


        public static bool UpdateStatus(int orderId, string status, string token)
        {
            if (!(AuthService.IsAdmin(token) || AuthService.IsDeliveryBoy(token))) return false;

            var order = DataAccessFactory.OrderData().Get(orderId);
            if (order == null) return false;

            order.Status = status;
            return DataAccessFactory.OrderData().Update(order);
        }

     
        public static List<OrderDTO> GetHistory(string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            var orders = DataAccessFactory.OrderData().Get();

            if (AuthService.IsAdmin(token))
                return GetMapper().Map<List<OrderDTO>>(orders);

            if (AuthService.IsCustomer(token))
                return GetMapper().Map<List<OrderDTO>>(orders.Where(o => o.UserId == tok.User.UserId).ToList());

            return null;
        }
    }
}

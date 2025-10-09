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
        public static OrderDTO Get(int id)
        {
            var data = DataFactory.OrderData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<OrderDTO>(data);
        }

        public static List<OrderDTO> Get()
        {
            var data = DataFactory.OrderData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }

        public static void Create(OrderDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>());
            var mapper = new Mapper(config);
            DataFactory.OrderData().Create(mapper.Map<Order>(dto));
        }

        public static void Update(OrderDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>());
            var mapper = new Mapper(config);
            DataFactory.OrderData().Update(mapper.Map<Order>(dto));
        }

        public static void Delete(int id)
        {
            DataFactory.OrderData().Delete(id);
        }

        // Functional: Get orders by user
        public static List<OrderDTO> GetByUser(int userId)
        {
            var data = DataFactory.OrderData().Get().Where(o => o.UserId == userId).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }

        // Functional: Process cart into order
        public static void ProcessOrder(int cartId, int userId)
        {
            var cart = DataFactory.CartData().Get(cartId);
            if (cart == null || cart.CartItems.Count == 0) return;

            decimal total = cart.CartItems.Sum(ci => ci.Quantity * ci.FoodItem.Price);

            var order = new Order
            {
                UserId = userId,
                TotalPrice = total,
                Status = "Pending",
                OrderDate = System.DateTime.Now
            };

            DataFactory.OrderData().Create(order);

            foreach (var ci in cart.CartItems)
            {
                var detail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    FoodId = ci.FoodId,
                    Quantity = ci.Quantity,
                    Price = ci.Quantity * ci.FoodItem.Price
                };
                DataFactory.OrderDetailData().Create(detail);
            }

            // Optional: clear cart after order
            DataFactory.CartData().Delete(cartId);
        }
    }
}

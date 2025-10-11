using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class CartService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<CartDTO> Get(string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            var data = DataAccessFactory.CartData().Get();

            if (AuthService.IsAdmin(token))
                return GetMapper().Map<List<CartDTO>>(data);

            if (AuthService.IsCustomer(token))
            {
                var myCarts = (from c in data
                               where c.UserId == tok.User.UserId
                               select c).ToList();
                return GetMapper().Map<List<CartDTO>>(myCarts);
            }

            return null;
        }

        public static bool Add(CartDTO c, string token)
        {
            if (AuthService.IsCustomer(token))
            {
                var tok = DataAccessFactory.TokenData().Get(token);
                var foodItem = DataAccessFactory.FoodItemData().Get(c.FoodItemId);
                if (foodItem == null)
                    return false;

                var cart = GetMapper().Map<Cart>(c);
                cart.UserId = tok.User.UserId;

                cart.TotalPrice = cart.Quantity * (decimal)foodItem.Price;

                return DataAccessFactory.CartData().Create(cart);
            }
            return false;
        }


        public static bool Remove(int id, string token)
        {
            if (AuthService.IsCustomer(token))
            {
                return DataAccessFactory.CartData().Delete(id);
            }
            return false;
        }

        public static decimal GetTotalPrice(string token)
        {
            var carts = Get(token);
            if (carts != null && carts.Count > 0)
            {
                return carts.Sum(c => c.TotalPrice);
            }
            return 0;
        }
    }
}

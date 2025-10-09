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
        public static List<CartDTO> Get()
        {
            var data = DataFactory.CartData().Get();
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cart, CartDTO>()));
            return mapper.Map<List<CartDTO>>(data);
        }

        public static CartDTO Get(int id)
        {
            var data = DataFactory.CartData().Get(id);
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cart, CartDTO>()));
            return mapper.Map<CartDTO>(data);
        }

        public static void Create(CartDTO dto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CartDTO, Cart>()));
            var cart = mapper.Map<Cart>(dto);
            DataFactory.CartData().Create(cart);
        }

        public static void Update(CartDTO dto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CartDTO, Cart>()));
            var cart = mapper.Map<Cart>(dto);
            DataFactory.CartData().Update(cart);
        }

        public static void Delete(int id)
        {
            DataFactory.CartData().Delete(id);
        }

        // Functional methods
        public static void AddItem(int cartId, CartItemDTO dto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CartItemDTO, CartItem>()));
            var item = mapper.Map<CartItem>(dto);
            item.CartId = cartId;
            DataFactory.CartItemData().Create(item);
        }

        public static void RemoveItem(int cartItemId)
        {
            DataFactory.CartItemData().Delete(cartItemId);
        }

        public static decimal GetCartTotal(int cartId)
        {
            var cart = DataFactory.CartData().Get(cartId);
            return cart.CartItems.Sum(x => x.Quantity * x.FoodItem.Price);
        }
        // CartService
        public static List<CartDTO> GetByUser(int userId)
        {
            var data = DataFactory.CartData().Get().Where(c => c.UserId == userId).ToList();
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Cart, CartDTO>()));
            return mapper.Map<List<CartDTO>>(data);
        }

    }
}

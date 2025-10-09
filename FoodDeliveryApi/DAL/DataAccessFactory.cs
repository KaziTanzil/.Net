
using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataFactory
    {
        public static UserRepo UserData()
        {
            return new UserRepo();
        }


        public static IRepo<Restaurant, int> RestaurantData()
        {
            return new RestaurantRepo();
        }

        public static IRepo<Category, int> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<FoodItem, int> FoodItemData()
        {
            return new FoodItemRepo();
        }

        public static IRepo<Cart, int> CartData()
        {
            return new CartRepo();
        }

        public static IRepo<CartItem, int> CartItemData()
        {
            return new CartItemRepo();
        }

        public static IRepo<Order, int> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<OrderDetail, int> OrderDetailData()
        {
            return new OrderDetailRepo();
        }

        public static IRepo<Payment, int> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IRepo<Delivery, int> DeliveryData()
        {
            return new DeliveryRepo();
        }

        public static IRepo<Review, int> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IAuthRepo AuthData()
        {
            return new AuthRepo();
        }
    }
}

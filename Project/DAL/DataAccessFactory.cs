using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Interfaces.DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IAuth AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<FoodItem, int, bool> FoodItemData()
        {
            return new FoodItemRepo();
        }

        public static IRepo<Cart, int, bool> CartData()
        {
            return new CartRepo();
        }

        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<Payment, int, bool> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}

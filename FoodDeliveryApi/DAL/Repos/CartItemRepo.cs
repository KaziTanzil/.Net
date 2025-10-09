using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class CartItemRepo : Repo<CartItem, int>
    {
        public CartItem GetByCartAndFood(int cartId, int foodId)
        {
            var query = from ci in db.CartItems
                        where ci.CartId == cartId && ci.FoodId == foodId
                        select ci;
            return query.SingleOrDefault();
        }

        public List<CartItem> GetByCartId(int cartId)
        {
            var query = from ci in db.CartItems
                        where ci.CartId == cartId
                        select ci;
            return query.ToList();
        }
    }
}

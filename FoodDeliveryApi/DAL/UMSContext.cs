using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UMSContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}

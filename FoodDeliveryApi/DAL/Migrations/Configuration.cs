namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.UMSContext context)
        {
            Random random = new Random();


            if (!context.Users.Any())
            {
                for (int i = 1; i <= 20; i++)
                {
                    var role = (i % 5 == 0) ? "Admin" :
                               (i % 3 == 0) ? "DeliveryBoy" :
                               "Customer";

                    context.Users.AddOrUpdate(new User
                    {
                        Name = "User-"+i,
                        Email = $"user{i}@mail.com",
                        PasswordHash = "12345",
                        Role = role
                    });
                }
                context.SaveChanges();
            }

            if (!context.Restaurants.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    context.Restaurants.AddOrUpdate(new Restaurant
                    {
                        Name = $"Restaurant_{i}",
                        Address = $"Street {i}, City XYZ",
                        Contact = $"012345678{i}",
                        Rating = random.NextDouble() * 5
                    });
                }
                context.SaveChanges();
            }


            if (!context.Categories.Any())
            {
                string[] categoryNames = { "Pizza", "Burger", "Drinks", "Dessert", "Snacks" };

                categoryNames.ToList().ForEach(c =>
                    context.Categories.AddOrUpdate(new Category { Name = c })
                );
                context.SaveChanges();
            }


            if (!context.FoodItems.Any())
            {
                var categoryIds = context.Categories.Select(c => c.CategoryId).ToList();
                var restaurantIds = context.Restaurants.Select(r => r.RestaurantId).ToList();

                for (int i = 1; i <= 30; i++)
                {
                    context.FoodItems.AddOrUpdate(new FoodItem
                    {
                        Name = "Food_"+i,
                        Description = "Delicious item "+i,
                        Price = (decimal)(random.Next(100, 800)),
                        CategoryId = categoryIds[random.Next(categoryIds.Count)],
                        RestaurantId = restaurantIds[random.Next(restaurantIds.Count)]
                    });
                }
                context.SaveChanges();
            }


            if (!context.Carts.Any())
            {
                var userIds = context.Users.Select(u => u.UserId).ToList();
                for (int i = 1; i <= 10; i++)
                {
                    context.Carts.Add(new Cart
                    {
                        UserId = userIds[random.Next(userIds.Count)],
                        CreatedDate = DateTime.Now.AddDays(-random.Next(1, 30))
                    });
                }
                context.SaveChanges();
            }


            if (!context.CartItems.Any())
            {
                var cartIds = context.Carts.Select(c => c.CartId).ToList();
                var foodIds = context.FoodItems.Select(f => f.FoodId).ToList();

                for (int i = 1; i <= 30; i++)
                {
                    context.CartItems.AddOrUpdate(new CartItem
                    {
                        CartId = cartIds[random.Next(cartIds.Count)],
                        FoodId = foodIds[random.Next(foodIds.Count)],
                        Quantity = random.Next(1, 5)
                    });
                }
                context.SaveChanges();
            }


            if (!context.Orders.Any())
            {
                var userIds = context.Users.Select(u => u.UserId).ToList();
                for (int i = 1; i <= 15; i++)
                {
                    context.Orders.AddOrUpdate(new Order
                    {
                        UserId = userIds[random.Next(userIds.Count)],
                        TotalPrice = (decimal)random.Next(300, 2000),
                        Status = (i % 2 == 0) ? "Completed" : "Pending",
                        OrderDate = DateTime.Now.AddDays(-random.Next(1, 20))
                    });
                }
                context.SaveChanges();
            }


            if (!context.OrderDetails.Any())
            {
                var orderIds = context.Orders.Select(o => o.OrderId).ToList();
                var foodIds = context.FoodItems.Select(f => f.FoodId).ToList();

                for (int i = 1; i <= 40; i++)
                {
                    context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = orderIds[random.Next(orderIds.Count)],
                        FoodId = foodIds[random.Next(foodIds.Count)],
                        Quantity = random.Next(1, 4),
                        Price = (decimal)random.Next(100, 500)
                    });
                }
                context.SaveChanges();
            }


            if (!context.Payments.Any())
            {
                var orderIds = context.Orders.Select(o => o.OrderId).ToList();

                foreach (var orderId in orderIds)
                {
                    context.Payments.Add(new Payment
                    {
                        PaymentId = orderId,
                        PaymentMethod = (orderId % 2 == 0) ? "Online" : "COD",
                        Status = (orderId % 3 == 0) ? "Pending" : "Paid"
                    });
                }
                context.SaveChanges();
            }


            if (!context.Deliveries.Any())
            {
                var orderIds = context.Orders.Select(o => o.OrderId).ToList();
                var deliveryBoys = context.Users.Where(u => u.Role == "DeliveryBoy").Select(u => u.UserId).ToList();

                foreach (var orderId in orderIds)
                {
                    context.Deliveries.Add(new Delivery
                    {
                        DeliveryId = orderId,
                        DeliveryBoyId = deliveryBoys[random.Next(deliveryBoys.Count)],
                        Status = (orderId % 2 == 0) ? "Delivered" : "Pending"
                    });
                }
                context.SaveChanges();
            }


            if (!context.Reviews.Any())
            {
                var userIds = context.Users.Select(u => u.UserId).ToList();
                var restaurantIds = context.Restaurants.Select(r => r.RestaurantId).ToList();

                for (int i = 1; i <= 25; i++)
                {
                    context.Reviews.Add(new Review
                    {
                        UserId = userIds[random.Next(userIds.Count)],
                        RestaurantId = restaurantIds[random.Next(restaurantIds.Count)],
                        Rating = random.Next(1, 6),
                        Comment = $"Review comment {i}",
                        Date = DateTime.Now.AddDays(-random.Next(1, 10))
                    });
                }
                context.SaveChanges();
            }
        }
    }
}

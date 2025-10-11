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

            string[] roles = { "Admin", "Customer", "DeliveryBoy" };
            for (int i = 0; i < roles.Length; i++)
            {
                context.Users.AddOrUpdate(u => u.Email,
                    new User()
                    {
                        Name = roles[i] + " " + (i + 1),
                        Email = roles[i].ToLower() + "@food.com",
                        PasswordHash = roles[i].ToLower() + "123",
                        Role = roles[i]
                    });
            }

            context.SaveChanges();


            string[] foodNames = { "Burger", "Pizza", "Pasta", "Salad" };
            double[] prices = { 5.99, 8.99, 7.50, 4.50 };
            string[] categories = { "FastFood", "FastFood", "Italian", "Healthy" };

            for (int i = 0; i < foodNames.Length; i++)
            {
                context.FoodItems.AddOrUpdate(f => f.Name,
                    new FoodItem()
                    {
                        Name = foodNames[i],
                        Price = prices[i],
                        Category = categories[i]
                    });
            }

            context.SaveChanges();


            var customers = context.Users.Where(u => u.Role == "Customer").ToList();
            var foods = context.FoodItems.ToList();

            foreach (var customer in customers)
            {
                for (int i = 0; i < foods.Count; i++)
                {
                    context.Carts.Add(new Cart()
                    {
                        UserId = customer.UserId,
                        FoodItemId = foods[i].FoodItemId,
                        Quantity = i + 1
                    });
                }
            }

            context.SaveChanges();


            foreach (var customer in customers)
            {
                for (int o = 1; o <= 2; o++)
                {
                    var order = new Order()
                    {
                        UserId = customer.UserId,
                        OrderDate = DateTime.Now.AddDays(-o),
                        Status = o % 2 == 0 ? "Delivered" : "Pending"
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();

                    for (int f = 0; f < foods.Count; f++)
                    {
                        context.OrderItems.Add(new OrderItem()
                        {
                            OrderId = order.OrderId,
                            FoodItemId = foods[f].FoodItemId,
                            Quantity = f + 1,
                            TotalPrice = foods[f].Price * (f + 1)
                        });
                    }
                }
            }

            context.SaveChanges();


            var orders = context.Orders.ToList();

            foreach (var order in orders)
            {
                var totalAmount = context.OrderItems
                    .Where(oi => oi.OrderId == order.OrderId)
                    .Sum(oi => oi.TotalPrice);

                if (!context.Payments.Any(p => p.OrderId == order.OrderId))
                {
                    context.Payments.Add(new Payment()
                    {
                        OrderId = order.OrderId,
                        Amount = totalAmount,
                        PaymentMethod = "Card",
                        PaymentDate = order.OrderDate.AddDays(1),
                        Status = order.Status == "Delivered" ? "Paid" : "Pending"
                    });
                }
            }

            context.SaveChanges();


        }
    }
}


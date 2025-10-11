using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class FoodItemService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FoodItem, FoodItemDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<FoodItemDTO> Get(string token)
        {
            var data = DataAccessFactory.FoodItemData().Get();
            return GetMapper().Map<List<FoodItemDTO>>(data); 
        }


        public static FoodItemDTO Get(int id, string token)
        {
            if (AuthService.IsAdmin(token) || AuthService.IsCustomer(token))
            {
                var data = DataAccessFactory.FoodItemData().Get(id);
                return GetMapper().Map<FoodItemDTO>(data);
            }
            return null;
        }

        public static bool Create(FoodItemDTO f, string token)
        {
            if (AuthService.IsAdmin(token))
            {
                if (string.IsNullOrEmpty(f.Category))
                    return false; 

                var item = GetMapper().Map<FoodItem>(f);
                return DataAccessFactory.FoodItemData().Create(item);
            }
            return false;
        }


        public static bool Update(FoodItemDTO f, string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            if (tok != null && tok.ExpiredAt == null && AuthService.IsAdmin(token))
            {
                var repo = DataAccessFactory.FoodItemData();
                var existing = repo.Get(f.FoodItemId);
                if (existing == null) return false;
                existing.Price = f.Price == 0 ? existing.Price : f.Price; 
                existing.Category = string.IsNullOrEmpty(f.Category) ? existing.Category : f.Category;

                return repo.Update(existing);
            }
            return false;
        }


        public static bool Delete(int id, string token)
        {
            if (AuthService.IsAdmin(token))
            {
                return DataAccessFactory.FoodItemData().Delete(id);
            }
            return false;
        }


        public static List<FoodItemDTO> Search(string name, string category)
        {
            var items = Get(null); 
            if (!string.IsNullOrEmpty(name))
                items = items.Where(f => f.Name.ToLower().Contains(name.ToLower())).ToList();
            if (!string.IsNullOrEmpty(category))
                items = items.Where(f => f.Category.ToLower().Contains(category.ToLower())).ToList();

            return items;
        }

       
        public static List<dynamic> GetTopSelling()
        {
            var allOrders = DAL.DataAccessFactory.OrderData().Get();
            var allItems = Get(null);

            var topItems = allOrders
                .SelectMany(o => o.OrderItems) 
                .GroupBy(oi => oi.FoodItemId)
                .Select(g => new
                {
                    FoodItemId = g.Key,
                    QuantitySold = g.Sum(x => x.Quantity),
                    FoodName = allItems.FirstOrDefault(f => f.FoodItemId == g.Key)?.Name
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .ToList<dynamic>();

            return topItems;
        }
    }
}


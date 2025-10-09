using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class FoodItemService
    {
        // GET single item
        public static FoodItemDTO Get(int id)
        {
            var data = DataFactory.FoodItemData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodItem, FoodItemDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<FoodItemDTO>(data);
        }

        // GET all items
        public static List<FoodItemDTO> Get()
        {
            var data = DataFactory.FoodItemData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodItem, FoodItemDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<FoodItemDTO>>(data);
        }

        // CREATE
        public static void Create(FoodItemDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodItemDTO, FoodItem>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<FoodItem>(dto);
            DataFactory.FoodItemData().Create(obj);
        }

        // UPDATE
        public static void Update(FoodItemDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodItemDTO, FoodItem>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<FoodItem>(dto);
            DataFactory.FoodItemData().Update(obj);
        }

        // DELETE
        public static void Delete(int id)
        {
            DataFactory.FoodItemData().Delete(id);
        }

        // SEARCH / FILTER / SORT
        public static List<FoodItemDTO> SearchFilterSort(string keyword = "", int? categoryId = null, int? restaurantId = null, bool sortAsc = true)
        {
            var data = DataFactory.FoodItemData().Get().AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                data = data.Where(f => f.Name.ToLower().Contains(keyword.ToLower()));

            if (categoryId.HasValue)
                data = data.Where(f => f.CategoryId == categoryId.Value);

            if (restaurantId.HasValue)
                data = data.Where(f => f.RestaurantId == restaurantId.Value);

            data = sortAsc ? data.OrderBy(f => f.Price) : data.OrderByDescending(f => f.Price);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<FoodItem, FoodItemDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<FoodItemDTO>>(data.ToList());
        }

        // GET by category
        public static List<FoodItemDTO> GetByCategory(int categoryId)
        {
            var data = DataFactory.FoodItemData().Get().Where(f => f.CategoryId == categoryId).ToList();
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<FoodItem, FoodItemDTO>()));
            return mapper.Map<List<FoodItemDTO>>(data);
        }

        // GET by restaurant
        public static List<FoodItemDTO> GetByRestaurant(int restaurantId)
        {
            var data = DataFactory.FoodItemData().Get().Where(f => f.RestaurantId == restaurantId).ToList();
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<FoodItem, FoodItemDTO>()));
            return mapper.Map<List<FoodItemDTO>>(data);
        }
    }
}

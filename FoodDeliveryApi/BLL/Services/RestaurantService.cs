using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RestaurantService
    {
        public static RestaurantDTO Get(int id)
        {
            var data = DataFactory.RestaurantData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<RestaurantDTO>(data);
        }

        public static List<RestaurantDTO> Get()
        {
            var data = DataFactory.RestaurantData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<RestaurantDTO>>(data);
        }

        public static void Create(RestaurantDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantDTO, Restaurant>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<Restaurant>(dto);
            DataFactory.RestaurantData().Create(obj);
        }

        public static void Update(RestaurantDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestaurantDTO, Restaurant>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<Restaurant>(dto);
            DataFactory.RestaurantData().Update(obj);
        }

        public static void Delete(int id)
        {
            DataFactory.RestaurantData().Delete(id);
        }

        // Functional: Search/Filter/Sort
        public static List<RestaurantDTO> SearchFilterSort(string keyword = "", double? minRating = null, bool sortAsc = true)
        {
            var data = DataFactory.RestaurantData().Get().AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                data = data.Where(r => r.Name.ToLower().Contains(keyword.ToLower()));

            if (minRating.HasValue)
                data = data.Where(r => r.Rating >= minRating.Value);

            data = sortAsc ? data.OrderBy(r => r.Rating) : data.OrderByDescending(r => r.Rating);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Restaurant, RestaurantDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<RestaurantDTO>>(data.ToList());
        }
    }
}

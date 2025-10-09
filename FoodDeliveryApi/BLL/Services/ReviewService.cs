using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ReviewService
    {
        public static ReviewDTO Get(int id)
        {
            var data = DataFactory.ReviewData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ReviewDTO>(data);
        }

        public static List<ReviewDTO> Get()
        {
            var data = DataFactory.ReviewData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<ReviewDTO>>(data);
        }

        public static void Create(ReviewDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = new Mapper(config);
            DataFactory.ReviewData().Create(mapper.Map<Review>(dto));
        }

        public static void Update(ReviewDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = new Mapper(config);
            DataFactory.ReviewData().Update(mapper.Map<Review>(dto));
        }

        public static void Delete(int id)
        {
            DataFactory.ReviewData().Delete(id);
        }

        // Functional: Get reviews by restaurant
        public static List<ReviewDTO> GetByRestaurant(int restaurantId)
        {
            var data = DataFactory.ReviewData().Get().Where(r => r.RestaurantId == restaurantId).ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<ReviewDTO>>(data);
        }

        // Functional: Average rating
        public static double GetAverageRating(int restaurantId)
        {
            var reviews = DataFactory.ReviewData().Get().Where(r => r.RestaurantId == restaurantId).ToList();
            if (reviews.Count == 0) return 0;
            return reviews.Average(r => r.Rating);
        }
    }
}

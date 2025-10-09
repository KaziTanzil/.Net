using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService
    {
        public static CategoryDTO Get(int id)
        {
            var data = DataFactory.CategoryData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<CategoryDTO>(data);
        }

        public static List<CategoryDTO> Get()
        {
            var data = DataFactory.CategoryData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<CategoryDTO>>(data);
        }

        public static void Create(CategoryDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<Category>(dto);
            DataFactory.CategoryData().Create(obj);
        }

        public static void Update(CategoryDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<Category>(dto);
            DataFactory.CategoryData().Update(obj);
        }

        public static void Delete(int id)
        {
            DataFactory.CategoryData().Delete(id);
        }
    }
}

using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        public static UserDTO Get(int id)
        {
            var data = DataFactory.UserData().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }

        public static List<UserDTO> Get()
        {
            var data = DataFactory.UserData().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }

        public static void Create(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var obj = mapper.Map<User>(dto);
            DataFactory.UserData().Create(obj);
        }

        public static void Update(UserDTO dto)
        {
            var repo = DataFactory.UserData();
            var existing = repo.Get(dto.UserId); 
            if (existing != null)
            {
                existing.Name = dto.Name ?? existing.Name;
                existing.Email = dto.Email ?? existing.Email;
                existing.Role = dto.Role ?? existing.Role;
                repo.Update(existing);
            }
        }


        public static void Delete(int id)
        {
            DataFactory.UserData().Delete(id);
        }

        public static List<UserDTO> GetByRole(string role)
        {
            var data = DataFactory.UserData().GetByRole(role);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }

    }
}

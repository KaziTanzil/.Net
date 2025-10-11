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
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get(string token)
        {
            if (AuthService.IsAdmin(token))
            {
                var data = DataAccessFactory.UserData().Get();
                return GetMapper().Map<List<UserDTO>>(data);
            }
            return null;
        }






        public static string Create(UserDTO u)
        {
            if (string.IsNullOrEmpty(u.Name) || string.IsNullOrEmpty(u.Email) ||
                string.IsNullOrEmpty(u.Role) || string.IsNullOrEmpty(u.Password))
                return "All fields are required.";

            var userData = DataAccessFactory.UserData();

            
            var existingUser = (from usr in userData.Get()
                                where usr.Name == u.Name || usr.Email == u.Email
                                select usr).FirstOrDefault();

            if (existingUser != null)
            {
                if (existingUser.Email == u.Email)
                    return "Email already exists.";
                else if (existingUser.Name == u.Name)
                    return "Username already exists.";
            }

            var user = new User
            {
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                PasswordHash = u.Password 
            };

            var result = userData.Create(user);

            if (result)
                return "User created successfully.";
            else
                return "Failed to create user.";
        }





        public static bool Update(UserDTO u, string token)
        {
            var tok = DataAccessFactory.TokenData().Get(token);
            if (tok != null && tok.ExpiredAt == null && (AuthService.IsAdmin(token) || tok.UserId == u.UserId))
            {
                var userRepo = DataAccessFactory.UserData();
                var existing = userRepo.Get(u.UserId);
                if (existing == null) return false;

                
                existing.Name = string.IsNullOrEmpty(u.Name) ? existing.Name : u.Name;
                existing.Email = string.IsNullOrEmpty(u.Email) ? existing.Email : u.Email;
                existing.Role = string.IsNullOrEmpty(u.Role) ? existing.Role : u.Role;
                existing.PasswordHash = string.IsNullOrEmpty(u.Password) ? existing.PasswordHash : u.Password;

                return userRepo.Update(existing);
            }
            return false;
        }


        public static bool Delete(int id, string token)
        {
            if (AuthService.IsAdmin(token))
            {
                return DataAccessFactory.UserData().Delete(id);
            }
            return false;
        }
    }
}

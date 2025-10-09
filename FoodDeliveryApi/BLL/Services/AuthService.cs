using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;

namespace BLL.Services
{
    public class AuthService
    {
        public static UserDTO Login(string email, string password)
        {
            var user = DataFactory.AuthData().GetByEmail(email);
            if (user == null) return null;

            string hashed = HashPassword(password);
            if (user.PasswordHash != hashed) return null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(user);
        }

        public static bool Register(UserDTO dto)
        {
            if (DataFactory.AuthData().EmailExists(dto.Email)) return false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()                                                           .ForMember(u => u.PasswordHash, opt => opt.Ignore()));
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(dto);

            // Use plain password from dto
            user.PasswordHash = HashPassword(dto.Password);

            DataFactory.AuthData().Register(user);
            return true;
        }


        private static string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

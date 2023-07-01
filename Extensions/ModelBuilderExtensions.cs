using System.Text;
using System.Security.Cryptography;
using JwtWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using JwtWebApi.Entities.Enum;

namespace JwtWebApi.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            using HMACSHA512 hmac = new();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Hoang",
                    LastName = "Nguyen Ba",
                    Username = "hnb",
                    Role = Role.Admin,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),
                    PasswordSalt = hmac.Key
                },
                new User
                {
                    Id = 2,
                    FirstName = "Hoang",
                    LastName = "Nguyen Ba",
                    Username = "nbh",
                    Role = Role.User,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),
                    PasswordSalt = hmac.Key
                }


            );
        }
    }
}
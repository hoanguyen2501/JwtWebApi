using JwtWebApi.Entities;
using JwtWebApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Data
{
    public class JwtWebApiDbContext : DbContext
    {
        public JwtWebApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

using EShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<UserOrdersModel> DbUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOrdersModel>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd(); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
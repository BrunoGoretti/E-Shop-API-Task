using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<UserOptions> DbUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOptions>().HasNoKey();
        }
    }
}

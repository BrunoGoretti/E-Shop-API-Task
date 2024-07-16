using EShopAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
                : base(options) { }
        public DbSet<UserOrdersModel> DbUsers { get; set; }
    }
}

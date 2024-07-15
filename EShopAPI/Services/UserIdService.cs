using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Services
{
    public class UserIdService : IUserIdService
    {
        public IActionResult Index()
        {
            Console.WriteLine("asd");
        }
    }
}

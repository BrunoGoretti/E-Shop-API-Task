using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Services
{
    public class UserIdService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

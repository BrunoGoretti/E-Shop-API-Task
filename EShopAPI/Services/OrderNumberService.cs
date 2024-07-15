using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Services
{
    public class OrderNumberService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

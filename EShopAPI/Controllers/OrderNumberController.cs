using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    public class OrderNumberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

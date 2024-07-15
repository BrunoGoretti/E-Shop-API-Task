using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    public class UserIdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    public class PaymentGatewayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Services
{
    public class PaymentGatewayService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

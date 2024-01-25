using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Mvc.Controllers
{
    public class OrderController : MvcBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

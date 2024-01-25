using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Mvc.Controllers
{
    public class ErrorController : MvcBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

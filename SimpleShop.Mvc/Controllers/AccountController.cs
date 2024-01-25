using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Mvc.Controllers
{
    public class AccountController : MvcBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Join() 
        {
            return View();
        }

        public IActionResult Reset() 
        {
            return View();
        }

        public IActionResult ResetCode() 
        {
            return View();
        }

    }
}

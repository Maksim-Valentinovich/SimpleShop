using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Mvc.Controllers
{
    public class ErrorController : MvcBaseController
    {
        [AllowAnonymous]
        [Route("/NotFound")]
        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/ServerError")]
        [HttpGet]
        public IActionResult PageServerError()
        {
            return View();
        }
    }
}

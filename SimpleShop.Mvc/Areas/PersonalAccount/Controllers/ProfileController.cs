using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Mvc.Controllers;
using SimpleShop.Mvc.ViewsModels;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    public class ProfileController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public ProfileController(SimpleShopContext context)
        {
            _context = context;
        }

        [HttpGet("[controller]/{email}")]
        public IActionResult Index(string email)
        {
            return View();
        }
    }
}

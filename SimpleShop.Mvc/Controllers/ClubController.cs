using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;

namespace SimpleShop.Mvc.Controllers
{
    public class ClubController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public ClubController(SimpleShopContext context)
        {
            _context = context;
        }
        [HttpGet("[controller]/{name}")]
        public IActionResult Index(string name)
        {
            return View();
        }
    }
}

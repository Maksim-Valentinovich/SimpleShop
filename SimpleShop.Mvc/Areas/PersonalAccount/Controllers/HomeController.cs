using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Mvc.Areas.PersonalAccount.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Areas.PersonalAccount.Controllers
{
    [Area("PersonalAccount")]
    public class HomeController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public HomeController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("PersonalAccount/Home/Index")]
        [HttpGet("{clientId}")]
        public IActionResult Index(int clientId)
        {
            var cl = _context.Clients.FirstOrDefault(c => c.Id == clientId);

            ClientViewModel client = new()
            {
                Id = cl.Id,
                Name = cl.Name,
                Surname = cl.Surname,
                Patronymic = cl.Patronymic,
                Phone = cl.Phone,
                Email = cl.Email,
                IsMan = cl.IsMan,
                Birhday = cl.Birhday,
            };

            return View(client);
        }
    }
}

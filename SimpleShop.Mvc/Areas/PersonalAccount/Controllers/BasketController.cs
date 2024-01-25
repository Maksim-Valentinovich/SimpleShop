using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Mvc.Areas.PersonalAccount.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Areas.PersonalAccount.Controllers
{
    [Area("PersonalAccount")]
    public class BasketController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public BasketController(SimpleShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string email = "maks0076@mail.ru";

            var cl = _context.Clients.FirstOrDefault(c => c.Email == email);

            ClientViewModel client = new()
            {
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

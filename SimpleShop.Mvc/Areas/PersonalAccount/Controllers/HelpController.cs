using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Mvc.Areas.PersonalAccount.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Areas.PersonalAccount.Controllers
{
    [Area("PersonalAccount")]
    public class HelpController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public HelpController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("PersonalAccount/Help/Index")]
        [HttpGet("{clientId}")]
        public IActionResult Index(int clientId)
        {
            var cl = _context.Clients.FirstOrDefault(c => c.Id == clientId);

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

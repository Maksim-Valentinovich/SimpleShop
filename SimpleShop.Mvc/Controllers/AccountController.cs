using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using System.Security.Claims;
using SimpleShop.Mvc.ViewModels;
using SimpleShop.Domain.Entities.Clients;

namespace SimpleShop.Mvc.Controllers
{
    public class AccountController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public AccountController(SimpleShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (client != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToRoute(new { area = "PersonalAccount", controller = "Home", action = "Index", /*email = model.Email,*/ clientId = client.Id});
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (client == null)
                {
                    // добавляем пользователя в бд
                    _context.Clients.Add(new Client { Email = model.Email, Password = model.Password, Name = model.Name, Surname = model.Surname, Patronymic = model.Patronymic, Phone = model.Phone, Birhday = model.Birthday});
                    await _context.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Клиент с таким email уже существует!");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new (claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}

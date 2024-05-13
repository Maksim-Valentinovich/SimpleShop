using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Clients;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Mvc.ViewModels;
using System.Security.Claims;

namespace SimpleShop.Mvc.Controllers
{
    public class AccountController : MvcBaseController
    {
        private readonly IClientAppService _clientAppService;
        private readonly IMapper _mapper;

        public AccountController(IClientAppService clientAppService, IMapper mapper)
        {
            _clientAppService = clientAppService;
            _mapper = mapper;
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
                var client = await _clientAppService.GetAsync(model.Email, model.Password);
                if (client != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToRoute(new { area = "PersonalAccount", controller = "Home", action = "Index", clientId = client.Id });
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
                var client = await _clientAppService.GetAsync(model.Email);
                if (client == null)
                {
                    // добавляем пользователя в бд
                    var clientDto = _mapper.Map<ClientDto>(model);
                    await _clientAppService.AddAsync(clientDto);

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
            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
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

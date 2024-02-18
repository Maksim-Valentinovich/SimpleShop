using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.Orders;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class OrderController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public OrderController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("Store/Order/Index")]
        [HttpGet]
        public IActionResult Index(int productId, int clubId)
        {
            var category = _context.CategoryProducts
                .Where(c => c.ProductId == productId)
                .Select(c => c.Category)
                .OrderBy(c => c.Id)
                .Last();

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            var club = _context.Clubs.FirstOrDefault(p => p.Id == clubId);

            ProductViewModel prod = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CountVisit = product.CountVisit,
                CountPeople = product.CountPeople,
                CountDay = product.CountDay,
                ClubName = club.DisplayName,
                Info = category.Info,
                PictureLink = category.PictureLink,
                ClubId = clubId,
            };
            return View(prod);
        }


        [Route("Store/Order/Registration")]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [Route("Store/Order/Registration")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _context.Clients.FirstOrDefault(u => u.Email == model.Email);

                if (client == null)
                {
                    _context.Clients.Add(new Client { Email = model.Email, Name = model.Name, Surname = model.Surname, Patronymic = model.Patronymic, Phone = model.Phone, Password = "0" });
                    //_context.SaveChangesAsync();

                    ModelState.AddModelError("", "OK");

                    return View(model);
                }
                else
                {
                    //return PartialView("_ChoosePayModal");

                    ModelState.AddModelError("", "OK");

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Заполните все поля регистрации!");
                return View(model);
            }
        }


        //[Route("Store/Order/Registration")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Registration(RegistrationViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Client? client = await _context.Clients.FirstOrDefaultAsync(u => u.Email == model.Email);
        //        if (client == null)
        //        {
        //            _context.Clients.Add(new Client { Email = model.Email, Name = model.Name, Surname = model.Surname, Patronymic = model.Patronymic, Phone = model.Phone, Password = "0" });
        //            await _context.SaveChangesAsync();

        //            return PartialView("_ChoosePayModal");
        //        }
        //        else
        //        {
        //            return PartialView("_ChoosePayModal");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Заполните все поля регистрации!");
        //    }
        //    return View(model);
        //}


        [Route("Store/Order/Recommendations")]
        [HttpGet]
        public IActionResult Recommendations()
        {
            var productIds = _context.CategoryProducts
                .Where(c => c.CategoryId == 1)
                .Select(c => c.ProductId)
                .ToArray();

            var products = _context.Products
                .Where(c => productIds.Contains(c.Id))
                .ToList();

            return PartialView("_Recommendations", products.Select(c => new ProductViewModel
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                CountDay = c.CountDay,
                CountVisit = c.CountVisit,
                Id = c.Id,
            }));
        }

        [Route("Store/Order/ChoosePayModal")]
        [HttpGet]
        public IActionResult ChoosePayModal() 
        {
            return PartialView("_ChoosePayModal");
        }

        [Route("Store/Order/Product")]
        [HttpGet]
        public RedirectToRouteResult Product() 
        {
            return RedirectToRoute(new { area = "Store", controller = "ShopCard", action = "Product" });
        }

        [Route("Store/Order/DeleteProductOnCard")]
        [HttpGet]
        public RedirectToRouteResult DeleteProductOnCard(int indx)
        {
            return RedirectToRoute(new { area = "Store", controller = "ShopCard", action = "DeleteProductOnCard", index = indx});
        }

        [Route("Store/Order/AddToCard")]
        [HttpGet]
        public RedirectToRouteResult AddToCard(int productId)
        {
            return RedirectToRoute(new { area = "Store", controller = "ShopCard", action = "AddToCard", ids = productId });
        }

        [Route("Store/Order/BasketModal")]
        [HttpGet]
        public RedirectToRouteResult BasketModal()
        {
            return RedirectToRoute(new { area = "Store", controller = "ShopCard", action = "BasketModal" });
        }

        [Route("Store/Order/AddOrder")]
        [HttpGet]
        public void AddOrder(OrderViewModel model) 
        {
            _context.Orders.Add(new Order {ClientId = model.ClientId, Sum = model.Sum, Date = DateTime.Now, IsOnline = model.IsOnline, /*ProductId = model.ProductId*/ });
            _context.SaveChanges();
        }

        [Route("Store/Order/Pay")]
        [HttpGet]
        public IActionResult Pay()
        {
            return View();
        }
    }


}

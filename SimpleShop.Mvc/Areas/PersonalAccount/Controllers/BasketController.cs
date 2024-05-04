using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Products;
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

        [Route("PersonalAccount/Basket/Index")]
        [HttpGet("{clientId}")]
        public async Task<IActionResult> Index(int clientId)
        {
            var cl = await _context.Clients.FirstAsync(c => c.Id == clientId);

            ClientViewModel client = new()
            {
                Id= cl.Id,
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

        [Route("PersonalAccount/Basket/Product")]
        [HttpGet("{clientId}, {categoryId}")]
        public async Task <IActionResult> Product(int clientId, int categoryId) // не работает - переделать !
        {
            var productIdsCategory = await _context.CategoryProducts.Where(c => c.CategoryId == categoryId).Select(c => c.ProductId).ToArrayAsync();
            var orders = await _context.Orders.Where(x => x.ClientId == clientId).ToListAsync();

            List<Product>? products = null;

            foreach (var order in orders)
            {
                var productIdsInOrder = await _context.Subscriptions.Where(x => x.OrderId == order.Id).Select(x => x.ProductId).ToListAsync();
                var productIdsInOrderCategory = productIdsInOrder.Intersect(productIdsCategory);
                products = await _context.Products.Where(c => productIdsInOrderCategory.Contains(c.Id)).ToListAsync();
            }

            return PartialView("_Product", products?.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                CountDay = c.CountDay,
                Description = c.Description,
            }));

        }
    }
}

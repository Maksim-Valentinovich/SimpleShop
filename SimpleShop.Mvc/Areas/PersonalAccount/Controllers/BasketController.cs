using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int clientId)
        {
            var cl = _context.Clients.FirstOrDefault(c => c.Id == clientId);

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
        public IActionResult Product(int clientId, int categoryId)
        {
            var productIdsCategory = _context.CategoryProducts.Where(c => c.CategoryId == categoryId).Select(c => c.ProductId).ToArray();

            var orders = _context.Orders.Where(x => x.ClientId == clientId).ToList();

            List<Product>? products = null;

            foreach (var order in orders)
            {
                var productIdsInOrder = _context.Subscriptions.Where(x => x.OrderId == order.Id).Select(x => x.ProductId).ToList();

                var productIdsInOrderCategory = productIdsInOrder.Intersect(productIdsCategory);

                products = _context.Products.Where(c => productIdsInOrderCategory.Contains(c.Id)).ToList();

            }

            return base.PartialView("_Product", products.Select(c => new Mvc.Areas.PersonalAccount.ViewModels.ProductViewModel
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

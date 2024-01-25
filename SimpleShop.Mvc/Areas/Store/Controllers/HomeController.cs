using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Migrations;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class HomeController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public HomeController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("Store/Home/Index")]
        [HttpGet("{category}")]
        public IActionResult Index(string category = "Discount")
        {
            var categoryId = _context.Categories
                .Where(c => c.Name == category)
                .Select(c => c.Id)
                .ToArray();

            var productIds = _context.CategoryProducts
                .Where(c => c.CategoryId == categoryId.First())
                .Select(c => c.ProductId)
                .ToArray();

            var products = _context.Products
                .Where(c => productIds.Contains(c.Id))
                .ToList();

            return View(products.Select(c => new ProductViewModel
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                CountDay = c.CountDay,
                CountVisit = c.CountVisit,
                Id = c.Id,
            }));
        }

        [Route("Store/Home/ChooseClubModal")]
        [HttpGet("{productId}")]
        public IActionResult ChooseClubModal(int productId)
        {
            var clubIds = _context.ClubProducts
                .Where(c => c.ProductId == productId)
                .Select(c =>c.ClubId)
                .ToArray();

            var clubs = _context.Clubs
                .Where(c => clubIds.Contains(c.Id))
                .ToList();

            return PartialView("_ChooseClubModal", clubs.Select(c => new ProductInClubViewModel {
                ClubId = c.Id,
                ClubName = c.DisplayName,
                ProductId = productId,
            }));
        }
    }
}

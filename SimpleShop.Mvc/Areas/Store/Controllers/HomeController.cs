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
        public async Task<IActionResult> Index(string category = "Discount")
        {
            var categoryId = await _context.Categories
                .Where(c => c.Name == category)
                .Select(c => c.Id)
                .ToArrayAsync();

            var productIds = await _context.CategoryProducts
                .Where(c => c.CategoryId == categoryId.First())
                .Select(c => c.ProductId)
                .ToArrayAsync();

            var products = await _context.Products
                .Where(c => productIds.Contains(c.Id))
                .ToListAsync();

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
        public async Task<IActionResult> ChooseClubModal(int productId)
        {
            var clubIds = await _context.ClubProducts
                .Where(c => c.ProductId == productId)
                .Select(c =>c.ClubId)
                .ToArrayAsync();

            var clubs = await _context.Clubs
                .Where(c => clubIds.Contains(c.Id))
                .ToListAsync();

            return PartialView("_ChooseClubModal", clubs.Select(c => new ProductInClubViewModel {
                ClubId = c.Id,
                ClubName = c.DisplayName,
                ProductId = productId,
            }));
        }
    }
}

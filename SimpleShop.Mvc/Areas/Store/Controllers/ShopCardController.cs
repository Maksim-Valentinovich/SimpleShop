using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Products;
using SimpleShop.Domain.Entities.ShopCards;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class ShopCardController : MvcBaseController
    {
        private readonly ShopCard _shopCard;
        private readonly SimpleShopContext _context;
        public ShopCardController(ShopCard shopCard, SimpleShopContext context)
        {
            _shopCard = shopCard;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Store/ShopCard/AddToCard")]
        [HttpGet]
        public RedirectToActionResult AddToCard(int productId, int clubId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.Id == productId);

            Club? club = _context.Clubs.FirstOrDefault(p => p.Id == clubId);

            _shopCard.AddToCard(product, club);

            return RedirectToAction("BasketModal");
        }

        [Route("Store/ShopCard/DeleteProductOnCard")]
        [HttpGet]
        public IActionResult DeleteProductOnCard(int index)
        {
            _shopCard.DeleteProduct(index);

            return PartialView("_BasketModal", new ShopCardFiveViewModel
            {
                ShopCard = _shopCard,
            });
        }

        [Route("Store/ShopCard/BasketModal")]
        [HttpGet]
        public IActionResult BasketModal()
        {
            var items = _shopCard.GetShopItems();

            _shopCard.ListShopItems = items;

            return PartialView("_BasketModal", new ShopCardFiveViewModel
            {
                ShopCard = _shopCard,
            });
        }

        [Route("Store/ShopCard/Product")]
        [HttpGet]
        public IActionResult Product()
        {
            var items = _shopCard.GetShopItems();

            _shopCard.ListShopItems = items;

            var clubs = _shopCard.GetShopClubs();

            _shopCard.ListShopClubs = clubs;

            return PartialView("_Product", new ShopCardFiveViewModel
            {
                ShopCard = _shopCard,
            });
        }

    }
}

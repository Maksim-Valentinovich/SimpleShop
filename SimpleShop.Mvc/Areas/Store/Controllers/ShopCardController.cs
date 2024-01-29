using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
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

        public RedirectToActionResult AddToCard(int ids)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ids);

            _shopCard.AddToCard(product);

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

        public IActionResult BasketModal()
        {
            var items = _shopCard.GetShopItems();

            _shopCard.ListShopItems = items;

            return PartialView("_BasketModal", new ShopCardFiveViewModel
            {
                ShopCard = _shopCard,
            });
        }
        public IActionResult Product()
        {
            var items = _shopCard.GetShopItems();

            _shopCard.ListShopItems = items;

            return PartialView("_Product", new ShopCardFiveViewModel
            {
                ShopCard = _shopCard,
            });
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Clubs;
using SimpleShop.Application.Products;
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
        private readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;
        private readonly IClubAppService _clubAppService;
        private readonly ShopCard _shopCard;
        public ShopCardController(ShopCard shopCard, IProductAppService productAppService, IClubAppService clubAppService, IMapper mapper)
        {
            _shopCard = shopCard;
            _productAppService = productAppService;
            _clubAppService = clubAppService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Store/ShopCard/AddToCard")]
        [HttpGet]
        public async Task<RedirectToActionResult> AddToCard(int productId, int clubId)
        {
            var product = _mapper.Map<Product>(await _productAppService.GetAsync(productId));
            var club = _mapper.Map<Club>(await _clubAppService.GetAsync(clubId));

            _shopCard.AddToCard(product, club);

            return RedirectToAction("BasketModal"); //убрать
        }

        [Route("Store/ShopCard/DeleteProductOnCard")]
        [HttpGet]
        public IActionResult DeleteProductOnCard(int index)
        {
            _shopCard.DeleteProduct(index);

            return Ok();
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

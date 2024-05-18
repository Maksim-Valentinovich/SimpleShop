using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.ShopCard;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class ShopCardController : MvcBaseController
    {
        private readonly IMapper _mapper;
        private readonly IShopCardAppService _shopCardAppService;

        public ShopCardController(IShopCardAppService shopCardAppService, IMapper mapper)
        {
            _shopCardAppService = shopCardAppService;
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
            await _shopCardAppService.AddProduct(productId, clubId);
            return RedirectToAction("BasketModal"); //убрать
        }

        [Route("Store/ShopCard/DeleteProductOnCard")]
        [HttpGet]
        public IActionResult DeleteProductOnCard(int index)
        {
            _shopCardAppService.DeleteProduct(index);
            return Ok();
        }

        [Route("Store/ShopCard/BasketModal")]
        [HttpGet]
        public IActionResult BasketModal()
        {
            var model = _shopCardAppService.GetShopItems();
            return PartialView("_BasketModal", _mapper.Map<ShopCardFiveViewModel>(model));
        }

        [Route("Store/ShopCard/Product")]
        [HttpGet]
        public IActionResult Product()
        {
            var model = _shopCardAppService.GetShopItems();
            return PartialView("_Product", _mapper.Map<ShopCardFiveViewModel>(model));
        }

    }
}

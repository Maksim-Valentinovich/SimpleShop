using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Clubs;
using SimpleShop.Application.Products;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class HomeController : MvcBaseController
    {
        private readonly IProductAppService _productAppService;
        private readonly IClubAppService _clubAppService;
        private readonly IMapper _mapper;

        public HomeController(IProductAppService productAppService, IMapper mapper, IClubAppService clubAppService)
        {
            _productAppService = productAppService;
            _mapper = mapper;
            _clubAppService = clubAppService;
        }

        [Route("Store/Home/Index")]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Index(int categoryId = 1)
        {
            var products = await _productAppService.GetAllAsync(categoryId);
            var models = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(models);
        }

        [Route("Store/Home/ChooseClubModal")]
        [HttpGet("{productId}")]
        public async Task<IActionResult> ChooseClubModal(int productId)
        {
            var clubs = await _clubAppService.GetClubsFromProductAsync(productId);
            var models = _mapper.Map<IEnumerable<ProductViewModel>>(clubs);
            return PartialView("_ChooseClubModal", models);
        }
    }
}

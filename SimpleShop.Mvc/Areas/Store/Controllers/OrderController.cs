using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Clients;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs;
using SimpleShop.Application.Orders;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Application.Products;
using SimpleShop.Domain.Entities.ShopCards;
using SimpleShop.Mvc.Areas.Store.Dto.Order;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.Controllers;
using System.Text.Json;

namespace SimpleShop.Mvc.Areas.Store.Controllers
{
    [Area("Store")]
    public class OrderController : MvcBaseController
    {
        private readonly IProductAppService _productAppService;
        private readonly IClubAppService _clubAppService;
        private readonly IClientAppService _clientAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly IProductOrderAppService _productOrderAppService;
        private readonly IMapper _mapper;

        public OrderController(IProductAppService productAppService, IClubAppService clubAppService, IMapper mapper, IClientAppService clientAppService, IOrderAppService orderAppService, IProductOrderAppService productOrderAppService)
        {
            _productAppService = productAppService;
            _clubAppService = clubAppService;
            _mapper = mapper;
            _clientAppService = clientAppService;
            _orderAppService = orderAppService;
            _productOrderAppService = productOrderAppService;
        }

        [Route("Store/Order/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int productId, int clubId)
        {
            var categoryProduct = await _productAppService.GetAsync(productId);
            var club = await _clubAppService.GetAsync(clubId);

            var model = _mapper.Map<ProductViewModel>(categoryProduct);
            //_mapper.Map(club, model);
            model.ClubId = club.Id;
            model.ClubName = club.DisplayName;
            return View(model);
        }


        [Route("Store/Order/MakeOrder")]
        [HttpPost]
        public async Task<IActionResult> MakeOrder(MakeOrderDto input)
        {
            var client = await _clientAppService.GetAsync(input.Email);
            if (client == null)
            {
                var clientDto = _mapper.Map<ClientDto>(input);
                await _clientAppService.AddAsync(clientDto);
                
                var order = _mapper.Map<OrderDto>(input);
                order.ClientId = _clientAppService.GetLast();
                await _orderAppService.AddAsync(order);
            }
            else
            {
                var order = _mapper.Map<OrderDto>(input);
                order.ClientId = client.Id;
                await _orderAppService.AddAsync(order, client.Id);
            }

            var card = JsonSerializer.Deserialize<ShopCard>(ShopCard.Session!.GetString("ShopCard")!);
            var products = card!.ListShopItems!.ToList();
            var clubs = card!.ListShopClubs!.ToList();
            decimal sum = 0;
            var lastOrder = await _orderAppService.GetLast();

            for (int i = 0; i < products?.Count; i++)
            {
                ProductOrderDto productOrderDto = new()
                {
                    ProductId = products[i].Id,
                    OrderId = lastOrder.Id,
                    ClubId = clubs[i].Id
                };
                await _productOrderAppService.AddAsync(productOrderDto);
                sum += products[i].Price;
            }
            lastOrder.Sum = sum;
            await _orderAppService.AddAsync(lastOrder);

            HttpContext.Session.Clear();
            return Ok();
        }

        [Route("Store/Order/Recommendations")]
        [HttpGet]
        public async Task<IActionResult> Recommendations()
        {
            int categoryId = 1;
            var categoryProduct = await _productAppService.GetAllAsync(categoryId);

            var model = _mapper.Map<IEnumerable<ProductViewModel>>(categoryProduct);
            return PartialView("_Recommendations", model);
        }

        [Route("Store/Order/PayModal")]
        [HttpGet]
        public IActionResult PayModal()
        {
            return PartialView("_PayModal");
        }

        [Route("Store/Order/FinishPay")]
        [HttpGet]
        public IActionResult FinishPay()
        {
            return View();
        }

        [Route("Store/Order/Registration")]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
    }


}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clubs;
using SimpleShop.Application.Products;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.Orders;
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
        private readonly SimpleShopContext _context;
        private readonly IProductAppService _productAppService;
        private readonly IClubAppService _clubAppService;
        private readonly IMapper _mapper;

        public OrderController(SimpleShopContext context, IProductAppService productAppService, IClubAppService clubAppService, IMapper mapper)
        {
            _context = context;
            _productAppService = productAppService;
            _clubAppService = clubAppService;
            _mapper = mapper;
        }

        [Route("Store/Order/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int productId, int clubId)
        {
            var categoryProduct = await _productAppService.GetAsync(productId);
            var club = await _clubAppService.GetAsync(clubId);

            var model = _mapper.Map<ProductViewModel>(categoryProduct);
            _mapper.Map(club, model);

            return View(model);
        }


        [Route("Store/Order/MakeOrder")]
        [HttpPost]
        public async Task<IActionResult> MakeOrder(MakeOrderDto input)
        {
            var client = await _context.Clients.FirstAsync(u => u.Email == input.Email);
            if (client == null)
            {
                await _context.Clients.AddAsync(new Client { Email = input.Email, Name = input.Name, Surname = input.Surname, Patronymic = input.Patronymic, Phone = input.Phone, IsMan = input.IsMan, Birhday = input.Birthday });
                await _context.Orders.AddAsync(new Order { ClientId = _context.Clients.OrderBy(c => c.Id).Last().Id, Date = DateTime.Now, IsOnline = input.IsOnline });
            }
            else
            {
                await _context.Orders.AddAsync(new Order { ClientId = client.Id, Date = DateTime.Now, IsOnline = input.IsOnline });
            }

            var card = JsonSerializer.Deserialize<ShopCard>(ShopCard.Session!.GetString("ShopCard")!);

            var products = card!.ListShopItems!.ToList();
            var clubs = card!.ListShopClubs!.ToList();
            var lastOrder = await _context.Orders.OrderBy(c => c.Id).LastAsync();
            decimal sum = 0;

            for (int i = 0; i < products?.Count; i++)
            {
                await _context.Subscriptions.AddAsync(new ProductOrder { ProductId = products[i].Id, OrderId = lastOrder.Id, ClubId = clubs[i].Id });
                sum += products[i].Price;
            }
            lastOrder.Sum = sum;

            await _context.SaveChangesAsync();
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

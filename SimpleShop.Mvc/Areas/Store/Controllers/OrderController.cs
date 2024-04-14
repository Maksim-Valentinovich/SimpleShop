﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public OrderController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("Store/Order/Index")]
        [HttpGet]
        public IActionResult Index(int productId, int clubId)
        {
            var category = _context.CategoryProducts
                .Where(c => c.ProductId == productId)
                .Select(c => c.Category)
                .OrderBy(c => c.Id)
                .Last();

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            var club = _context.Clubs.FirstOrDefault(p => p.Id == clubId);

            ProductViewModel prod = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CountVisit = product.CountVisit,
                CountPeople = product.CountPeople,
                CountDay = product.CountDay,
                ClubName = club.DisplayName,
                Info = category.Info,
                PictureLink = category.PictureLink,
                ClubId = clubId,
            };
            return View(prod);
        }


        [Route("Store/Order/Registration")]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [Route("Store/Order/MakeOrder")]
        [HttpPost]
        public IActionResult MakeOrder(MakeOrderDto input)
        {
            var client = _context.Clients.FirstOrDefault(u => u.Email == input.Email);

            if (client == null)
            {
                _context.Clients.Add(new Client { Email = input.Email, Name = input.Name, Surname = input.Surname, Patronymic = input.Patronymic, Phone = input.Phone, IsMan = input.IsMan, Birhday = input.Birthday });
                _context.Orders.Add(new Order { ClientId = _context.Clients.OrderBy(c => c.Id).Last().Id, Date = DateTime.Now, IsOnline = input.IsOnline });
            }
            else
            {
                _context.Orders.Add(new Order { ClientId = client.Id, Date = DateTime.Now, IsOnline = input.IsOnline });
            }

            var card = JsonSerializer.Deserialize<ShopCard>(ShopCard.Session.GetString("ShopCard"));

            var products = card?.ListShopItems?.ToList();

            var clubs = card?.ListShopClubs?.ToList();

            var lastOrder = _context.Orders.OrderBy(c => c.Id).Last();

            decimal sum = 0;

            for (int i = 0; i < products?.Count; i++)
            {
                _context.Subscriptions.Add(new ProductOrder { ProductId = products[i].Id, OrderId = lastOrder.Id, ClubId = clubs[i].Id });
                sum += products[i].Price;
            }

            lastOrder.Sum = sum;

            _context.SaveChanges();

            HttpContext.Session.Clear();

            return Ok();
        }

        [Route("Store/Order/Recommendations")]
        [HttpGet]
        public IActionResult Recommendations()
        {
            var productIds = _context.CategoryProducts
                .Where(c => c.CategoryId == 1)
                .Select(c => c.ProductId)
                .ToArray();

            var products = _context.Products
                .Where(c => productIds.Contains(c.Id))
                .ToList();

            return PartialView("_Recommendations", products.Select(c => new ProductViewModel
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                CountDay = c.CountDay,
                CountVisit = c.CountVisit,
                Id = c.Id,
            }));
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
    }


}

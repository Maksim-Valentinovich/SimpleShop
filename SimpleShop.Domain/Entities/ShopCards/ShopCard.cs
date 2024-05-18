﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Entities.Products;
using SimpleShop.Domain.Entities.Clubs;
using System.Text;
using System.Text.Json;

namespace SimpleShop.Domain.Entities.ShopCards
{
    /// <summary>
    /// Почему оно лежит рядом с моделями бд? Закинуть к сервисам.
    /// Похоже на костыль под переписку, но надо отдельно обсуждать если будет желание, что ты тут хотел реализовать.Вряд ли это нужно хранить в Сессиях.
    /// </summary>
    public class ShopCard : Entity
    {
        private static IServiceProvider? Services { get; set; }
        public static ISession? Session { get; set; }

        public List<Product>? ListShopItems { get; set; }

        public List<Club>? ListShopClubs {  get; set; }

        public static ShopCard GetCard(IHttpContextAccessor contextAccessor)
        {
            Session = contextAccessor?.HttpContext.Session;

            if (Session.GetString("ShopCard") == null)
            {
                ShopCard cardNew = new();

                string json = JsonSerializer.Serialize(cardNew);

                Session.SetString("ShopCard", json);
            }
            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));

            return new ShopCard() { ListShopItems = card?.ListShopItems, ListShopClubs = card?.ListShopClubs };
        }

        public void AddToCard(Product product, Club club)
        {
            ShopCard card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            if (card.ListShopItems == null)
            {
                card.ListShopItems = new List<Product>() { product };
                card.ListShopClubs = new List<Club>() { club };
            }
            else
            {
                card.ListShopItems.Add(product);
                card.ListShopClubs?.Add(club);
            }

            ShopCard cardNew = new() { ListShopItems = card.ListShopItems, ListShopClubs = card.ListShopClubs };

            string json = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", json);
        }

        public void DeleteProduct(int index)
        {
            ShopCard card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            card.ListShopItems?.RemoveAt(index);
            card.ListShopClubs?.RemoveAt(index);

            ShopCard cardNew = new() { ListShopItems = card.ListShopItems, ListShopClubs = card.ListShopClubs };

            string cardNewJson = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", cardNewJson);
        }

        public List<Product> GetShopItems()
        {
            var card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            card.ListShopItems ??= new List<Product>() {};

            return card.ListShopItems;
        }

        public List<Club>? GetShopClubs() 
        {
            var card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));
            return card?.ListShopClubs;
        }
    }
}
